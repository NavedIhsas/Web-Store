using Application.Common;
using Application.Interfaces.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Product
{
    public interface IProductService
    {
        ResultDto Create(CreateProduct command);
        List<ProductDto> GetAll();
        ProductDetails GetDetails(Guid id);
    }

    public class ProductService : IProductService
    {
        private readonly IShopContext _shopContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IShopContext shopContext, IMapper mapper, ILogger<ProductService> logger)
        {
            _shopContext = shopContext;
            _mapper = mapper;
            _logger = logger;
        }


        public ResultDto Create(CreateProduct command)
        {
            var result = new ResultDto();
            if (_shopContext.Products.Any(x => x.PrdLvlUid1 != command.PrdLvlUid1 && x.PrdName == command.PrdName.Fix()))
                return result.Failed(ValidateMessage.Duplicate);

            var map = _mapper.Map<Domain.ShopModels.Product>(command);
            _shopContext.Products.Add(map);
            _shopContext.SaveChanges();
            return result.Succeeded();
        }


        public List<ProductDto> GetAll()
        {
            var result = _shopContext.Products.
                Include(x => x.TaxU).
                Include(x => x.PrdLvlUid3Navigation)
                .AsNoTracking().Select(x => new
                {
                    x.PrdUid,
                    x.PrdName,
                    x.PrdCode,
                    x.PrdLvlUid3,
                    x.PrdImage,
                    x.TaxU.TaxName,
                    x.TaxU.TaxValue,
                    x.PrdStatus,
                    x.PrdPricePerUnit1,
                    x.PrdLvlUid3Navigation.PrdLvlName,
                }).Select(x => new ProductDto
                {

                    PrdUid = x.PrdUid,
                    PrdName = x.PrdName,
                    PrdCode = x.PrdCode,
                    PrdLevelId = x.PrdLvlName,
                    PrdImage = x.PrdImage,
                    PrdLvlUId = null,
                    PrdStatus = x.PrdStatus,
                    PrdPricePerUnit1 = x.PrdPricePerUnit1??0,
                    TaxName = x.TaxName,
                    TaxValue = x.TaxValue,
                    PrdLvlName = x.PrdLvlName,
                    Image64 = Convert.FromBase64String(x.PrdImage),
        }).ToList();

            // var products = _mapper.Map<List<ProductDto>>(result);
            return result;
        }

        public ProductDetails GetDetails(Guid id)
        {
            return _shopContext.Products.AsNoTracking().Select(x => new
            {
                x.PrdName,
                x.PrdUid,
                x.PrdMaxSale,
                x.PrdDiscount,
                x.PrdDiscountType,
                x.PrdPricePerUnit2,
                x.PrdPricePerUnit3,
                x.PrdPricePerUnit4,
                x.PrdTaxValue
            }).Select(x => new ProductDetails
            {
                PrdName = x.PrdName,
                PrdUid = x.PrdUid,
                PrdMaxSale = x.PrdMaxSale ?? 0,
                PrdDiscount = x.PrdDiscount ?? 0,
                PrdDiscountType = x.PrdDiscountType ?? 0,
                PrdPricePerUnit2 = x.PrdPricePerUnit2 ?? 0,
                PrdPricePerUnit3 = x.PrdPricePerUnit3 ?? 0,
                PrdPricePerUnit4 = x.PrdPricePerUnit4 ?? 0,
                PrdTaxValue = x.PrdTaxValue ?? 0
            }).SingleOrDefault(x => x.PrdUid == id);
        }
    }
}


public class ProductDetails
{
    public Guid PrdUid { get; set; }
    public string PrdName { get; set; }
    public int PrdMaxSale { get; set; }
    public decimal PrdDiscount { get; set; }
    public decimal PrdDiscountType { get; set; }
    public decimal PrdPricePerUnit2 { get; set; }
    public decimal PrdPricePerUnit3 { get; set; }
    public decimal PrdPricePerUnit4 { get; set; }
    public decimal PrdTaxValue { get; set; }
}

public class ProductDto
{
    public Guid PrdUid { get; set; }
    public string PrdName { get; set; }
    public string PrdCode { get; set; }
    public string PrdLevelId { get; set; }
    public string PrdImage { get; set; }
    public string PrdLvlUId { get; set; }
    public bool? PrdStatus { get; set; }
    public decimal PrdPricePerUnit1 { get; set; }
    public string TaxName { get; set; }
    public decimal? TaxValue { get; set; }
    public string PrdLvlName { get; set; }
    public byte[] Image64 { get; set; }

}

public class CreateProduct
{
    public Guid PrdLvlUid1 { get; set; }
    public string PrdName { get; set; }
}