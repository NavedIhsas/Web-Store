using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Context;
using AutoMapper;
using AutoMapper.Internal;
using Domain.ShopModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Validation.Annotations;

namespace Application.Product
{
    public interface IProductService
    {
        ResultDto CreateProduct(CreateProduct command);
        List<ProductDto> GetAll();
        ProductDetails GetDetails(Guid id);
        List<PropertySelectOptionDto> PropertySelectOption();
        List<UnitOfMeasurementDto> UnitOfMeasurement();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">PropertyId</param>
        /// <returns></returns>
        List<ProductPropertiesDto> GetProductProperty(Guid id);
        EditProduct GetDetailsForEdit(Guid id);
        List<ProductPicturesDto> GetProductPictures(Guid productId);

    }

    public class ProductService : IProductService
    {
        private readonly IShopContext _shopContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IAuthHelper _authHelper;

        public ProductService(IShopContext shopContext, IMapper mapper, ILogger<ProductService> logger, IHttpContextAccessor contextAccessor, IAuthHelper authHelper)
        {
            _shopContext = shopContext;
            _mapper = mapper;
            _logger = logger;
            _contextAccessor = contextAccessor;
            _authHelper = authHelper;
        }

        public List<ProductPropertiesDto> GetProductProperty(Guid id) =>
        _mapper.Map<List<ProductPropertiesDto>>(_shopContext.ProductProperties.Include(x => x.Property).Where(x => x.ProductId == id).AsNoTracking());

        public List<ProductPicturesDto> GetProductPictures(Guid productId)
        {
            var result = _shopContext.ProductPictures.Where(x => x.ProductId == productId);
            var map = _mapper.Map<List<ProductPicturesDto>>(result);
            //foreach (var picturesDto in map)
            //    picturesDto.ImageBase64 = Convert.FromBase64String(picturesDto.Image);
            return map.ToList();
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
                    Image64 = Convert.FromBase64String(x.PrdImage ?? ""),
                }).ToList();

            // var products = _mapper.Map<List<ProductDto>>(result);
            return result;
        }

        public EditProduct GetDetailsForEdit(Guid id)
        {
            var product = _shopContext.Products.Include(x => x.PrdLvlUid3Navigation).Include(x => x.ProductPictures).Include(x => x.ProductProperties).ThenInclude(x => x.Property).SingleOrDefault(x => x.PrdUid == id);
            var map = _mapper.Map<EditProduct>(product);
            foreach (var property in map.ProductProperties)
            {
                var getProperty = _contextAccessor.HttpContext.Session.GetJson<List<PropertySelectOptionDto>>("Product-Property") ?? new List<PropertySelectOptionDto>();

                getProperty.Add(new PropertySelectOptionDto()
                {
                    Name = property.Property.Name,
                    Id = property.PropertyId,
                    Value = property.Value,
                });
                _contextAccessor.HttpContext.Session.SetJson("Product-Property", getProperty);
            }
            var getPictures = _contextAccessor.HttpContext.Session.GetJson<List<ProductPicturesDto>>("Product-picture") ?? new List<ProductPicturesDto>();

            foreach (var picture in map.ProductPictures)
            {
                getPictures.Add(new ProductPicturesDto()
                {
                    ImageBase64 = Convert.FromBase64String(picture.Image),
                    Id = picture.Id,
                });
            }
            _contextAccessor.HttpContext.Session.SetJson("Product-picture", getPictures);

            return map;
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
                PrdTaxValue = x.PrdTaxValue ?? 0,
            }).SingleOrDefault(x => x.PrdUid == id);
        }

        public List<PropertySelectOptionDto> PropertySelectOption()
        {
            return _shopContext.Properties.Select(x => new PropertySelectOptionDto() { Id = x.Id, Name = x.Name })
                 .AsNoTracking().ToList();
        }

        public List<UnitOfMeasurementDto> UnitOfMeasurement()
        {

            return _shopContext.UnitOfMeasurements.Select(x => new { x.UomUid, x.UomName })
                 .Select(x => new UnitOfMeasurementDto() { Name = x.UomName, Id = x.UomUid })
                 .AsNoTracking().ToList();

        }

        public ResultDto CreateProduct(CreateProduct command)
        {
            var result = new ResultDto();


            var code = _authHelper.CheckLength(command.PrdCode);
            if (code == null) return result.Failed("حین چک کردن کد کالا خطای رخ داد،لطفا جدول تنظیمات را بررسی کنید");
            if (code == false) return result.Failed("طول کد کالا بیش تر حد مجاز هست");

            using var transaction = _shopContext.Database.BeginTransaction();
            try
            {
                if (_shopContext.Products.Any(x =>
                        x.PrdName == command.PrdName.Fix() && x.PrdLvlUid3 == command.PrdLvlUid3))
                    return result.Failed(ValidateMessage.Duplicate);
                if (command.Images != null)
                    command.PrdImage = ToBase64.Image(Image.FromStream(command.Images.OpenReadStream()), ImageFormat.Jpeg);
                var product = _mapper.Map<Domain.ShopModels.Product>(command);
                _shopContext.Products.Add(product);
                _shopContext.SaveChanges();

                foreach (var picture in command.Files.Select(commandFile =>
                             Image.FromStream(commandFile.OpenReadStream(),
                                 true, true)).Select(image1 =>
                             ToBase64.Image(image1, ImageFormat.Jpeg)).Select(base64String => new ProductPicture()
                             {
                                 Id = Guid.NewGuid(),
                                 Image = base64String,
                                 ProductId = product.PrdUid,
                             }))
                {
                    _shopContext.ProductPictures.Add(picture);
                    _shopContext.SaveChanges();
                }


                var getProperty =
                    _contextAccessor.HttpContext.Session.GetJson<List<PropertySelectOptionDto>>("Product-Property");
                if (getProperty != null && getProperty.Any())
                {
                    foreach (var newProp in getProperty.Select(property => new ProductProperty()
                    {
                        Id = Guid.NewGuid(),
                        Value = property.Value,
                        ProductId = product.PrdUid,
                        PropertyId = property.Id,
                    }))
                    {
                        _shopContext.ProductProperties.Add(newProp);
                        _shopContext.SaveChanges();
                    }
                }
                transaction.Commit();
                return result.Succeeded();
            }
            catch (Exception exception)
            {
                transaction.Rollback();
                _logger.LogError($"حین ثبت سفارش خطای زیر رخ داده است {exception}");
                throw new Exception($"حین ثبت سفارش خطای زیر رخ داده است {exception.Message}");
            }
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
    public List<ProductPropertiesDto> Properties { get; set; }
    public List<ProductPicturesDto> Pictures { get; set; }
}

public class ProductPropertiesDto
{
    public Guid Id { get; set; }
    public string Value { get; set; }
    public string PropertyName { get; set; }

}

public class ProductPicturesDto
{
    public Guid Id { get; set; }

    public string Image { get; set; }

    public Guid ProductId { get; set; }
    public byte[] ImageBase64 { get; set; }
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

public class EditProduct : CreateProduct
{
    public virtual ICollection<ProductPicturesDto> ProductPictures { get; set; }

    public virtual ICollection<ProductProperty> ProductProperties { get; set; }
    public virtual ProductLevel PrdLvlUid3Navigation { get; set; }
}

public class CreateProduct
{
    public Guid PrdUid { get; set; } = Guid.NewGuid();

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public Guid? TaxUid { get; set; }

    [ValidGuid(ErrorMessage = "guid معتیر نیست")]
    [CustomValidation(typeof(Validator), "ValidateGuid")]
    public Guid PrdLvlUid3 { get; set; }

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

    public string PrdNameInPrint { get; set; }

    public int? PrdDiscountType { get; set; }

    public decimal? PrdDiscount { get; set; }

    public string ShortDescription { get; set; }
    public string WebDescription { get; set; }
    public int? PrdLvlType { get; set; }
    public string Volume { get; set; }
    public string Weight { get; set; }
    public bool? PrdIsUnit1Bigger { get; set; }

    public List<IFormFile> Files { get; set; }
    public IFormFile Images { get; set; }
    public Guid? FkProductUnit { get; set; }
    public Guid? FkProductUnit2 { get; set; }


}

