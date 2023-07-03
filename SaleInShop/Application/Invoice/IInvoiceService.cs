using Application.BaseData;
using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Context;
using Application.Product;
using AutoMapper;
using Domain.SaleInModels;
using Microsoft.AspNetCore.Http;
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
        ResultDto<List<InvoiceDetailsDto>> GetInvoiceList();
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
            var invoice = _authHelper.GetCookie("invoice");
            var invoiceDetails = _authHelper.GetCookie("productList");
            var single = JsonConvert.DeserializeObject<CreateInvoice>(invoice);


            var addNes = new Domain.ShopModels.Invoice
            {
                InvUid = Guid.NewGuid(),
                AccUid = single.AccClubId,
                InvTotalAmount = single.Total,
                InvTotalDiscount = single.PriceWithDiscount,
                InvTotalTax = single.TotalGetTax,
                InvDescribtion = single.Description,
            };
            _context.Invoices.Add(addNes);
            _context.SaveChanges();
            var details = JsonConvert.DeserializeObject<List<InvoiceDetailsDto>>(invoiceDetails);

            foreach (var detail in  details)
            {
                var addNews = new Domain.ShopModels.InvoiceDetail()
                {
                    InvDetUid = Guid.NewGuid(),
                    InvUid = addNes.InvUid,
                    PrdUid = detail.ProductId,
                    InvDetQuantity = detail.Value,
                    InvDetPricePerUnit = Convert.ToDecimal(detail.Price),
                    InvDetDiscount = detail.DiscountAmount,
                    InvDetTax = detail.GetTax,
                    InvDetTotalAmount = detail.Total,
                    InvDetDescribtion = detail.Des,
                    InvDetPercentDiscount =Convert.ToInt64(detail.Discount),
                    InvDetTaxValue = detail.GetTax,
                    InvDetPayment = detail.PaidAmount,
                };
                _context.InvoiceDetails.Add(addNews);
                _context.SaveChanges();
            }
            return result.Succeeded();
        }

        public ResultDto<List<InvoiceDetailsDto>> GetInvoiceList()
        {
            var dto = new ResultDto<List<InvoiceDetailsDto>>();
            var result= _context.InvoiceDetails.Include(x=>x.PrdU).AsNoTracking().Select(x=>new InvoiceDetailsDto()
           {
               Name = x.PrdU.PrdName,
               Des = x.InvDetDescribtion,
               Discount = x.InvDetPercentDiscount??0,
               Price = x.InvDetPricePerUnit??0,
               ProductId = x.PrdUid??Guid.Empty,
               
           }).ToList();
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
    public string Name { get; set; }
    public Decimal Price { get; set; }
    public double Discount { get; set; }
    public int Total { get; set; }
    public int Value { get; set; }
    public int DiscountAmount { get; set; }
    public int PaidAmount { get; set; }
    public int GetTax { get; set; }
    public string Des { get; set; }
}
public class CreateInvoice
{
    public int Amount { get; set; }
    public int Total { get; set; }
    public int PriceWithDiscount { get; set; }
    public int PaidAmount { get; set; }
    public int GetTax { get; set; }
    public int TotalPriceWithDiscount { get; set; }
    public int TotalPaidAmount { get; set; }
    public int TotalGetTax { get; set; }
    public Guid? AccClubId { get; set; }
    public string Description { get; set; }
}

public class InvoiceMapping : Profile
{
    public InvoiceMapping()
    {
        this.CreateMap<Domain.ShopModels.Product, ProductSessionList>()
            .ForMember(x => x.Name, opt => opt.MapFrom(x => x.PrdName))
            .ForMember(x => x.Price, opt => opt.MapFrom(x => x.PrdPricePerUnit1))
            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.PrdUid));
    }
}