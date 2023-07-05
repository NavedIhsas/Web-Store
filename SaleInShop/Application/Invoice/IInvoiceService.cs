using System.Text.Json;
using Application.BaseData;
using Application.BaseData.Dto;
using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Context;
using Application.Product;
using AutoMapper;
using Domain.SaleInModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Application.Invoice
{
    public interface IInvoiceService
    {
        ResultDto<List<ProductSessionList>> ProductToList(Guid id);
        ResultDto<List<ProductSessionList>> RemoveFromProductList(Guid id);
        ResultDto Create();
        JsonResult GetInvoiceList(JqueryDatatableParam param);
        ResultDto<List<InvoiceDetailsDto>> InvoiceDetails(Guid invoiceId);
    }

    public class InvoiceService : IInvoiceService
    {
        private readonly IShopContext _context;
        private readonly IProductService _productService;
        private readonly ILogger<InvoiceService> _logger;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IAuthHelper _authHelper;
        public InvoiceService(IShopContext context, IProductService productService, ILogger<InvoiceService> logger, IMapper mapper, IHttpContextAccessor contextAccessor, IAuthHelper authHelper)
        {
            _context = context;
            _productService = productService;
            _logger = logger;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _authHelper = authHelper;
        }

        public ResultDto<List<ProductSessionList>> ProductToList(Guid id)
        {
            var result = new ResultDto<List<ProductSessionList>>();

            try
            {

                var product = _productService.GetProduct(id);
                if (product == null)
                {
                    _logger.LogError($"The Product wasn't added To session because this id {id} doesn't exist");
                    return result.Failed("محصول به لیست اظافه نشد");
                }

                var list = _contextAccessor.HttpContext!.Session.GetJson<List<ProductSessionList>>(SessionName.ProductList) ??
                           new List<ProductSessionList>();

                var find = list.SingleOrDefault(x => x.Id == id);
                if (find != null)
                {
                    find.Value = find.Value + 1;
                    list.Remove(find);
                    list.Add(find); ;
                    _contextAccessor.HttpContext.Session.SetJson(SessionName.ProductList, list);
                    return result.Succeeded(list);
                }

                var map = _mapper.Map<ProductSessionList>(product);
                map.Value = 1;
                list.Add(map);
                _contextAccessor.HttpContext.Session.SetJson(SessionName.ProductList, list);
                return result.Succeeded(list);
            }
            catch (Exception e)
            {
                _logger.LogError($"when Adding product to session ,occurred following error {e}");
                return result.Failed("محصول به لیست اظافه نشد، لطفا با پشتیبانی تماس بگیرید");
            }
        }

        public ResultDto<List<ProductSessionList>> RemoveFromProductList(Guid id)
        {
            var result = new ResultDto<List<ProductSessionList>>();


            var list = _contextAccessor.HttpContext!.Session.GetJson<List<ProductSessionList>>(SessionName.ProductList) ??
                       new List<ProductSessionList>();

            var product = list.SingleOrDefault(x => x.Id == id);
            if (product == null)
            {
                _logger.LogError($"product not found on session with Id {id}");
                return result.Failed("محصول از لیست حذف نشد");
            }

            list.Remove(product);
            _contextAccessor.HttpContext.Session.SetJson(SessionName.ProductList, list);
            return result.Succeeded(list);
        }



        public ResultDto Create()
        {
            var result = new ResultDto();

            var cookie = _authHelper.GetCookie("AccountClubList");
            var account = JsonConvert.DeserializeObject<AccountClubDto>(cookie);
            var invoice = _authHelper.GetCookie("invoice");
            var invoiceDetails = _authHelper.GetCookie("productList");
            var single = JsonConvert.DeserializeObject<CreateInvoice>(invoice);
            var map = new Domain.ShopModels.Invoice();
            try
            {
                map = _mapper.Map<Domain.ShopModels.Invoice>(single);
                map.AccClbUid = account.AccClbUid;
                _context.Invoices.Add(map);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogError($"An error occurred while creating the invoice {e}");
                result.Failed("هنگام ثبت اطلاعات خطای رخ داد.");
            }
            var details = JsonConvert.DeserializeObject<List<InvoiceDetailsDto>>(invoiceDetails);

            foreach (var detail in details)
            {
                var addNews = new Domain.ShopModels.InvoiceDetail()
                {
                    InvDetUid = Guid.NewGuid(),
                    InvUid = map.InvUid,
                    PrdUid = detail.ProductId,
                    InvDetQuantity = detail.Value,
                    InvDetPricePerUnit = Convert.ToDecimal(detail.Price),
                    InvDetDiscount = detail.DiscountAmount,
                    InvDetTax = detail.Tax,
                    InvDetTotalAmount = detail.Total,
                    InvDetDescribtion = detail.Des,
                    InvDetPercentDiscount = Convert.ToInt64(detail.Discount),
                    InvDetTaxValue = Convert.ToDouble(detail.Tax),
                    InvDetPayment = detail.PaidAmount,
                };
                _context.InvoiceDetails.Add(addNews);
                _context.SaveChanges();
            }
            return result.Succeeded();
        }

        public JsonResult GetInvoiceList(JqueryDatatableParam param)
        {
            
            var list = _context.Invoices.Include(x => x.AccClbU).AsNoTracking();

            if (!string.IsNullOrEmpty(param.SSearch))
            {
                list = list.Where(x =>
                    x.InvNumber.Contains(param.SSearch.ToLower())
                    || x.AccClbU.AccClbName.ToLower().Contains(param.SSearch.ToLower())
                    || x.AccClbU.AccClbCode.ToLower().Contains(param.SSearch.ToLower())
                    //|| x.InvDate.ToFarsi().Contains(param.SSearch.ToLower())
                    || x.InvExtendedAmount.ToString().ToLower().Contains(param.SSearch.ToLower()));
            }

            var sortColumnIndex = Convert.ToInt32(_contextAccessor.HttpContext.Request.Query["iSortCol_0"]);
            var sortDirection = _contextAccessor.HttpContext.Request.Query["sSortDir_0"];

            switch (sortColumnIndex)
            {
                case 2:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.AccClbU.AccClbName) : list.OrderByDescending(c => c.AccClbU.AccClbName);
                    break;
                case 3:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.AccClbU.AccClbCode) : list.OrderByDescending(c => c.AccClbU.AccClbCode);
                    break;
                case 0:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.InvNumber) : list.OrderByDescending(c => c.InvNumber);
                    break;
                case 1:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.InvDate) : list.OrderByDescending(c => c.InvDate);
                    break;

                case 4:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.InvExtendedAmount) : list.OrderByDescending(c => c.InvExtendedAmount);
                    break;


                default:
                    {
                        string OrderingFunction(Domain.ShopModels.Invoice e) => sortColumnIndex == 0 ? e.InvDate.ToString() : e.InvNumber;
                        IOrderedEnumerable<Domain.ShopModels.Invoice> rr = null;

                        rr = sortDirection == "asc"
                            ? list.AsEnumerable().OrderBy((Func<Domain.ShopModels.Invoice, string>)OrderingFunction)
                            : list.AsEnumerable().OrderByDescending((Func<Domain.ShopModels.Invoice, string>)OrderingFunction);

                        list = rr.AsQueryable();
                        break;
                    }
            }

            IQueryable<Domain.ShopModels.Invoice> displayResult;
            if (param.IDisplayLength != 0)
                displayResult = list.Skip(param.IDisplayStart)
                .Take(param.IDisplayLength);
            else displayResult = list;
            var totalRecords = list.Count();
            var map=new List<InvoiceDto>();
            try
            {
                 map = _mapper.Map<List<InvoiceDto>>(displayResult.ToList());

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            var result = (new
            {
                param.SEcho,
                iTotalRecords = totalRecords,
                iTotalDisplayRecords = totalRecords,
                aaData = map
            });
            return new JsonResult(result, new JsonSerializerOptions { PropertyNamingPolicy = null });
        }

        public ResultDto<List<InvoiceDetailsDto>> InvoiceDetails(Guid invoiceId)
        {
            var dto = new ResultDto<List<InvoiceDetailsDto>>();
            var result = _context.InvoiceDetails
                .Where(x => x.InvUid == invoiceId)
                .Include(x => x.PrdU)
                .Include(x => x.InvU)
                .ThenInclude(x => x.AccClbU)
                .ThenInclude(x => x.AccClbTypU).
            Select(x => new InvoiceDetailsDto
            {
                ProductId = x.PrdUid ?? Guid.Empty,
                Name = x.PrdU.PrdName,
                Price = x.InvDetPricePerUnit ?? 0,
                Discount = x.InvDetPercentDiscount ?? 0,
                Total = x.InvDetTotalAmount ?? 0,
                Value = x.InvDetQuantity ?? 0,
                DiscountAmount = x.InvDetDiscount ?? 0,
                PaidAmount = x.InvDetPayment ?? 0,
                Tax = x.InvDetTax ?? 0,
                Des = x.InvDetDescribtion,
                AccountName = x.InvU.AccClbU.AccClbName,
                AccountCode = x.InvU.AccClbU.AccClbCode,
                Mobile = x.InvU.AccClbU.AccClbMobile,
                AccountType = x.InvU.AccClbU.AccClbTypU.AccClbTypName,
                Address = x.InvU.AccClbU.AccClbAddress,
                AccountDiscount = x.InvU.AccClbU.AccClbTypU.AccClbTypDiscountType??0,
                PriceLevel = x.InvU.AccClbU.AccClbTypU.AccClbTypDefaultPriceInvoice?? 0,
              
            }).AsNoTracking().ToList();
            return dto.Succeeded(result);
        }
    }
}

public class ProductSessionList
{
    public string Name { get; set; }
    public int Value { get; set; }
    public Guid Id { get; set; }
    public double Price { get; set; }
}


public class InvoiceDetailsDto
{
    public Guid ProductId { get; set; }
    public Guid AccountId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public double Discount { get; set; }
    public Decimal Total { get; set; }
    public double Value { get; set; }
    public decimal DiscountAmount { get; set; }
    public int PaidAmount { get; set; }
    public decimal Tax { get; set; }
    public string Des { get; set; }
    public string AccountName { get; set; }
    public string Mobile { get; set; }
    public string AccountCode { get; set; }
    public string Address { get; set; }
    public string AccountType { get; set; }
    public int PriceLevel { get; set; }
    public int AccountDiscount { get; set; }
}


public class InvoiceDto
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public int TotalAmount { get; set; }
    public DateTime CreationDate { get; set; }
    public Guid? AccClubId { get; set; }
    /// <summary>
    /// Account Club Name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Account Club Code
    /// </summary>
    public string Code { get; set; }

}
public class CreateInvoice
{
    public CreateInvoice()
    {
        Id = Guid.NewGuid();
        Date = DateTime.Now;
        var branch = 3001;
        var number = new Random();
        Number = branch + number.Next(1, 1000);
    }
    public Guid Id { get; set; }
    public int Amount { get; set; }
    public int Total { get; set; }
    public int PriceWithDiscount { get; set; }
    public int PaidAmount { get; set; }
    public int Tax { get; set; }
    public int TotalPriceWithDiscount { get; set; }
    public int TotalPaidAmount { get; set; }
    public int TotalGetTax { get; set; }
    public DateTime Date { get; set; }
    public int TotalDiscountAmount { get; set; }
    public Guid? AccUid { get; set; }
    public string Description { get; set; }
    public int Number { get; set; }
}

public class InvoiceMapping : Profile
{
    public InvoiceMapping()
    {
        this.CreateMap<Domain.ShopModels.Product, ProductSessionList>()
            .ForMember(x => x.Name, opt => opt.MapFrom(x => x.PrdName))
            .ForMember(x => x.Price, opt => opt.MapFrom(x => x.PrdPricePerUnit1))
            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.PrdUid));

        this.CreateMap<Domain.ShopModels.Invoice, InvoiceDto>()
            .ForMember(x => x.TotalAmount, opt => opt.MapFrom(x => x.InvExtendedAmount))
            .ForMember(x => x.Name, opt => opt.MapFrom(x => x.AccClbU.AccClbName))
            .ForMember(x => x.Code, opt => opt.MapFrom(x => x.AccClbU.AccClbCode))
            .ForMember(x => x.AccClubId, opt => opt.MapFrom(x => x.AccClbUid))
            .ForMember(x => x.CreationDate, opt => opt.MapFrom(x => x.InvDate.ToFarsi()))
            .ForMember(x => x.Number, opt => opt.MapFrom(x => x.InvNumber))
            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.InvUid));


        this.CreateMap<CreateInvoice, Domain.ShopModels.Invoice>()
            .ForMember(x => x.InvTotalAmount, opt => opt.MapFrom(x => x.Total))
            .ForMember(x => x.InvTotalDiscount, opt => opt.MapFrom(x => x.TotalDiscountAmount))
            .ForMember(x => x.InvTotalTax, opt => opt.MapFrom(x => x.TotalGetTax))
            .ForMember(x => x.InvExtendedAmount, opt => opt.MapFrom(x => x.TotalPaidAmount))
            .ForMember(x => x.InvDescribtion, opt => opt.MapFrom(x => x.Description))
            .ForMember(x => x.InvDate, opt => opt.MapFrom(x => x.Date))
            .ForMember(x => x.InvNumber, opt => opt.MapFrom(x => x.Number))
            .ForMember(x => x.InvUid, opt => opt.MapFrom(x => x.Id));

        this.CreateMap<InvoiceDetail, InvoiceDetailsDto>()
            .ForMember(x => x.Name, opt => opt.MapFrom(x => x.PrdU.PrdName))
            .ForMember(x => x.Name, opt => opt.MapFrom(x => x.PrdU.TaxU.TaxValue + x.PrdU.TaxU.TaxTaxesValue));
    }
}