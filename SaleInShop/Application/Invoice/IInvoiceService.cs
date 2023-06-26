using Application.BaseData;
using Application.Common;
using Application.Interfaces.Context;
using Application.Product;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Application.Invoice
{
    public interface IInvoiceService
    {
        ResultDto<List<ProductSessionList>> ProductToList(Guid id);
        ResultDto<List<ProductSessionList>> RemoveFromProductList(Guid id);
    }

    public class InvoiceService:IInvoiceService
    {
        private readonly IShopContext _context;
        private readonly IProductService _productService;
        private readonly ILogger<InvoiceService> _logger;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        public InvoiceService(IShopContext context, IProductService productService, ILogger<InvoiceService> logger, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _productService = productService;
            _logger = logger;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        public ResultDto<List<ProductSessionList>> ProductToList(Guid id)
        {
            var result = new ResultDto<List<ProductSessionList>>();

            try
            {
                
                var product=_productService.GetProduct(id);
                if (product == null)
                {
                    _logger.LogError($"The Product wasn't added To session because this id {id} doesn't exist");
                    return result.Failed("محصول به لیست اظافه نشد");
                }

                var list = _contextAccessor.HttpContext!.Session.GetJson<List<ProductSessionList>>(SessionName.ProductList) ??
                           new List<ProductSessionList>();

                var find= list.SingleOrDefault(x => x.Id == id);
                if (find != null)
                {
                    find.Value = find.Value + 1;
                    list.Remove(find);
                    list.Add(find);;
                    _contextAccessor.HttpContext.Session.SetJson(SessionName.ProductList,list);
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

            var product =list.SingleOrDefault(x=>x.Id==id);
            if (product == null)
            {
                _logger.LogError($"product not found on session with Id {id}");
                return result.Failed("محصول از لیست حذف نشد");
            }

            list.Remove(product);
            _contextAccessor.HttpContext.Session.SetJson(SessionName.ProductList, list);
            return result.Succeeded(list);
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