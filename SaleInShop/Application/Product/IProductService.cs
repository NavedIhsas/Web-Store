using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using Application.Common;
using Application.Interfaces.Context;
using AutoMapper;
using AutoMapper.Internal;
using Domain.ShopModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Product
{
    public interface IProductService
    {
        ResultDto CreateProduct(CreateProduct command);
        List<ProductDto> GetAll();
        ProductDetails GetDetails(Guid id);
        List<PropertySelectOptionDto> PropertySelectOption();
        List<UnitOfMeasurementDto> UnitOfMeasurement();

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
                    PrdPricePerUnit1 = x.PrdPricePerUnit1 ?? 0,
                    TaxName = x.TaxName,
                    TaxValue = x.TaxValue,
                    PrdLvlName = x.PrdLvlName,
                    Image64 = Convert.FromBase64String(x.PrdImage??""),
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

        public List<PropertySelectOptionDto> PropertySelectOption()
        {
            return _shopContext.Properties.Select(x => new PropertySelectOptionDto() { Id = x.Id, Name = x.Name })
                 .AsNoTracking().ToList();
        }

        public List<UnitOfMeasurementDto> UnitOfMeasurement()
        {
            
         return  _shopContext.UnitOfMeasurements.Select(x => new { x.UomUid, x.UomName })
              .Select(x=>new UnitOfMeasurementDto(){Name = x.UomName,Id = x.UomUid})
              .AsNoTracking().ToList();
          
        }

        public ResultDto CreateProduct(CreateProduct command)
        {
            var result = new ResultDto();
            if (_shopContext.Products.Any(x =>
                    x.PrdName == command.PrdName.Fix() && x.PrdLvlUid3 == command.PrdLvlUid3))
                return result.Failed(ValidateMessage.Duplicate);

            command.PrdImage = ToBase64.Image(Image.FromStream(command.Images.OpenReadStream()), ImageFormat.Jpeg);

            var product = _mapper.Map<Domain.ShopModels.Product>(command);
            _shopContext.Products.Add(product);
            _shopContext.SaveChanges();

            foreach (var picture in command.Files.Select(commandFile => 
                         Image.FromStream(commandFile.OpenReadStream(),
                             true, true)).Select(image1 =>
                         ToBase64.Image(image1, System.Drawing.Imaging.ImageFormat.Jpeg)).Select(base64String => new ProductPicture()
            {
                Id = Guid.NewGuid(),
                Image = base64String,
                ProductId = product.PrdUid,
            }))
            {
                _shopContext.ProductPictures.Add(picture);
                _shopContext.SaveChanges();
            }

            return result.Succeeded();
        }
    }
}

public class UnitOfMeasurementDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class PropertySelectOptionDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
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

public class CreateProperty
{
    public Guid Id { get; set; }
    public string Value { get; set; }
    public string Name { get; set; }
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
    public Guid PrdUid { get; set; }=Guid.NewGuid();

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public Guid? TaxUid { get; set; }
    public Guid? PrdLvlUid3 { get; set; }

    public string PrdName { get; set; }

    public string PrdCode { get; set; }

    public string PrdBarcode { get; set; }

    public string PrdIranCode { get; set; }

    public decimal? PrdCoefficient { get; set; }

    public decimal? PrdPricePerUnit1 { get; set; }

    public decimal? PrdPricePerUnit2 { get; set; }

    public long? PrdMinQuantityOnHand { get; set; }

    public long? PrdMaxQuantityOnHand { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public string PrdUnit2 { get; set; }

    public Guid? PrdWareHouse { get; set; }

    public decimal? PrdPricePerUnit3 { get; set; }

    public decimal? PrdPricePerUnit4 { get; set; }

    public decimal? PrdPricePerUnit5 { get; set; }

    public string PrdImage { get; set; }

    public bool? PrdNameShow { get; set; }

    public int? PrdDiscountType { get; set; }

    public decimal? PrdDiscount { get; set; }

    public string ShortDescription { get; set; }
    public int? PrdLvlType { get; set; }

    public List<IFormFile> Files { get; set; }
    public IFormFile Images { get; set; }
    public Guid PrdUnit { get; set; }

}