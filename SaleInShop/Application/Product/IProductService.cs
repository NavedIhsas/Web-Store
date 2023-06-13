using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Context;
using AutoMapper;
using AutoMapper.Internal;
using Domain.ShopModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        ResultDto Remove(Guid id);
        ResultDto UpdateProduct(EditProduct command);
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

        public ResultDto Remove(Guid id)
        {
            var result = new ResultDto();
            try
            {
                var product = _shopContext.Products.Find(id);
                if (product == null)
                {
                    _logger.LogError($"Don't Any Record width Id {id} of Table Product");
                    throw new Exception($"Don't Any Record width Id {id} of Table Product");
                }

                _shopContext.ProductPictures.RemoveRange(_shopContext.ProductPictures.Where(x => x.ProductId == id));
                _shopContext.ProductProperties.RemoveRange(_shopContext.ProductProperties.Where(x => x.ProductId == id));
                _shopContext.Products.Remove(product);
                _shopContext.SaveChanges();
                return result.Succeeded();
            }
            catch (Exception e)
            {
                _logger.LogError($"حین حذف محصول با آیدی {id} خطای زیر رخ داد {e}");
                return result.Failed("عملیات با خطا مواجه شد");
            }
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
                    x.PrdUnit,
                    x.PrdUnit2,
                    x.PrdIranCode,
                    x.PrdBarcode,
                    x.Weight,
                    x.Volume,
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
                    IranCode = x.PrdIranCode,
                    Weight = x.Weight,
                    Volume = x.Volume,
                    BarCode = x.PrdBarcode,
                    Unit1 = x.PrdUnit,
                    Unit2 = x.PrdUnit2,
                }).ToList();

            // var products = _mapper.Map<List<ProductDto>>(result);
            return result;
        }

        public EditProduct GetDetailsForEdit(Guid id)
        {
            var product = _shopContext.Products.Include(x => x.PrdLvlUid3Navigation).Include(x => x.ProductPictures).Include(x => x.ProductProperties).ThenInclude(x => x.Property).SingleOrDefault(x => x.PrdUid == id);
            var map = _mapper.Map<EditProduct>(product);
            map.Image = Convert.FromBase64String(map.PrdImage);

            _contextAccessor.HttpContext.Session.Remove("edit-Property");
            _contextAccessor.HttpContext.Session.Remove("edit-picture");

            foreach (var property in map.ProductProperties)
            {
                var getProperty = _contextAccessor.HttpContext.Session.GetJson<List<PropertySelectOptionDto>>("edit-Property") ?? new List<PropertySelectOptionDto>();

                getProperty.Add(new PropertySelectOptionDto()
                {
                    PropertyId = property.PropertyId,
                    Name = property.Property.Name,
                    Id = property.Id,
                    Value = property.Value,
                });
                _contextAccessor.HttpContext.Session.SetJson("edit-Property", getProperty);
            }
            var getPictures = _contextAccessor.HttpContext.Session.GetJson<List<ProductPicturesDto>>("edit-picture") ?? new List<ProductPicturesDto>();

            foreach (var picture in map.ProductPictures)
            {
                getPictures.Add(new ProductPicturesDto()
                {
                    ImageBase64 = Convert.FromBase64String(picture.Image),
                    Id = picture.Id,
                });
            }
            _contextAccessor.HttpContext.Session.SetJson("edit-picture", getPictures);

            return map;
        }


        public ProductDetails GetDetails(Guid id)
        {
            return _shopContext.Products.Include(x => x.UomUid1Navigation).Include(x => x.FkProductUnit2Navigation).Select(x => new
            {
                x.PrdName,
                x.PrdUid,
                x.PrdMaxSale,
                x.PrdDiscount,
                x.PrdDiscountType,
                x.PrdPricePerUnit2,
                x.PrdPricePerUnit3,
                x.PrdPricePerUnit4,
                x.PrdTaxValue,
                x.FkProductUnitNavigation,
                x.FkProductUnit2Navigation,
                x.PrdUnit2,
                x.PrdIranCode,
                x.PrdBarcode,
                x.Weight,
                x.Volume,
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
                IranCode = x.PrdIranCode ?? "",
                Weight = x.Weight ?? "",
                Volume = x.Volume ?? "",
                BarCode = x.PrdBarcode ?? "",
                Unit1 = x.FkProductUnitNavigation.UomName ?? "",
                Unit2 = x.FkProductUnit2Navigation.UomName ?? "",

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
                command.PrdUid = Guid.NewGuid();
                if (_shopContext.Products.Any(x =>
                        x.PrdName == command.PrdName.Fix() && x.PrdLvlUid3 == command.PrdLvlUid3))
                    return result.Failed(ValidateMessage.Duplicate);
                if (command.Images != null)
                    command.PrdImage = ToBase64.Image(command.Images, ImageFormat.Jpeg);
                var product = _mapper.Map<Domain.ShopModels.Product>(command);
                _shopContext.Products.Add(product);
                _shopContext.SaveChanges();

                if (command.Files.Any())
                {
                    foreach (var addPicture in command.Files.Select(picture => ToBase64.Image(picture)).Select(image => new ProductPicture()
                    {
                        Id = Guid.NewGuid(),
                        Image = image,
                        ProductId = product.PrdUid,
                    }))
                    {
                        _shopContext.ProductPictures.Add(addPicture);
                        _shopContext.SaveChanges();
                    }
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



        public ResultDto UpdateProduct(EditProduct command)
        {
            var result = new ResultDto();

            var code = _authHelper.CheckLength(command.PrdCode);
            if (code == null) return result.Failed("حین چک کردن کد کالا خطای رخ داد،لطفا جدول تنظیمات را بررسی کنید");
            if (code == false) return result.Failed("طول کد کالا بیش تر حد مجاز هست");

            using var transaction = _shopContext.Database.BeginTransaction();
            try
            {
                var product = _shopContext.Products.Find(command.PrdUid);
                if (product == null)
                {
                    _logger.LogError($"Don't found Any Product With Id {command.PrdUid} on table product");
                    throw new Exception($"Don't found Any Product With Id {command.PrdUid} on table product");
                }
                if (_shopContext.Products.Any(x =>
                       (x.PrdName == product.PrdName && x.PrdLvlUid3 == product.PrdLvlUid3) && x.PrdUid != product.PrdUid))
                    return result.Failed(ValidateMessage.Duplicate);
                if (command.Images != null)
                    command.PrdImage = ToBase64.Image(command.Images);


                command.PrdUid = product.PrdUid;
                if (string.IsNullOrWhiteSpace(command.PrdImage))
                    command.PrdImage = product.PrdImage;

                var productMap = _mapper.Map(command, product);

                productMap.PrdUniqid = 0;
                _shopContext.Products.Update(productMap).Property(x => x.PrdUniqid).IsModified = false;
                _shopContext.SaveChanges();


                var pictures = _contextAccessor.HttpContext.Session.GetJson<List<ProductPicturesDto>>("edit-picture").ToList();
                if (pictures.Any())
                {
                    var list=new List<ProductPicture>();
                    foreach (var picture in pictures)
                    {
                        var productPictures = _shopContext.ProductPictures.FirstOrDefault(x => x.ProductId == product.PrdUid && x.Id ==picture.Id);
                        list.Add(productPictures);
                    }
                    foreach (var picture in pictures)
                    {

                        var update = _shopContext.ProductPictures.SingleOrDefault(x => x.Id == picture.Id);
                        if (update == null) continue;
                        update.Image = Convert.ToBase64String(picture.ImageBase64);
                        _shopContext.ProductPictures.Update(update);
                        _shopContext.SaveChanges();
                    }
                }

                if (command.Files.Any())
                {

                    foreach (var picture in command.Files.Select(image1 =>
                                 ToBase64.Image(image1)).Select(base64String => new ProductPicture()
                                 {
                                     Id = Guid.NewGuid(),
                                     Image = base64String,
                                     ProductId = product.PrdUid,
                                 }))
                    {
                        _shopContext.ProductPictures.Add(picture);
                        _shopContext.SaveChanges();
                    }
                }


                var getProperty =
                    _contextAccessor.HttpContext.Session.GetJson<List<PropertySelectOptionDto>>("edit-Property");
                if (getProperty != null && getProperty.Any())
                {

                    var find = getProperty.Where(x => x.Id != Guid.Empty).ToList();
                    var newAdd = getProperty.Where(x => x.Id == Guid.Empty).ToList();
                    if (find.Any())
                    {
                        foreach (var dto in find)
                        {
                            var update = _shopContext.ProductProperties.SingleOrDefault(x => x.Id == dto.Id);
                            if (update != null)
                            {
                                update.Value = dto.Value;
                                update.PropertyId = dto.PropertyId;
                                _shopContext.ProductProperties.Update(update);
                            }

                            _shopContext.SaveChanges();
                        }
                    }
                    if (newAdd.Any())
                    {
                        foreach (var update in newAdd.Select(dto => new ProductProperty
                        {
                            Id = Guid.NewGuid(),
                            Value = dto.Value,
                            PropertyId = dto.PropertyId,
                            ProductId = product.PrdUid,
                        }))
                        {
                            _shopContext.ProductProperties.Add(update);
                            _shopContext.SaveChanges();
                        }
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
    public Guid PropertyId { get; set; }
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
    public string Unit1 { get; set; }
    public string Unit2 { get; set; }
    public string Weight { get; set; }
    public string Volume { get; set; }
    public string IranCode { get; set; }
    public string BarCode { get; set; }
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
    public byte[] ImageBase64 { get; set; }
}

public class CreateProperty
{
    [BindRequired]
    public Guid Id { get; set; }
    public string Value { get; set; }
    public string Name { get; set; }
    public Guid PropertyId { get; set; }
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
    public string Unit1 { get; set; }
    public string Unit2 { get; set; }
    public string Weight { get; set; }
    public string Volume { get; set; }
    public string IranCode { get; set; }
    public string BarCode { get; set; }

}

public class EditProduct : CreateProduct
{
    public virtual ICollection<ProductPicturesDto> ProductPictures { get; set; }

    public virtual ICollection<ProductProperty> ProductProperties { get; set; }
    public virtual ProductLevel PrdLvlUid3Navigation { get; set; }
}

public class CreateProduct
{
    public Guid PrdUid { get; set; }

    public Guid? TaxUid { get; set; }

    [BindRequired]
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

    public Guid? PrdWareHouse { get; set; }

    public decimal? PrdPricePerUnit3 { get; set; }

    public decimal? PrdPricePerUnit4 { get; set; }

    public decimal? PrdPricePerUnit5 { get; set; }

    public string PrdImage { get; set; }
    public byte[] Image { get; set; }

    public string PrdNameInPrint { get; set; }

    public int? PrdDiscountType { get; set; }

    public decimal? PrdDiscount { get; set; }

    public string ShortDescription { get; set; }
    public string WebDescription { get; set; }
    public int? PrdLvlType { get; set; }
    public string Volume { get; set; }
    public string Weight { get; set; }
    public bool? PrdIsUnit1Bigger { get; set; }

    public List<IFormFile> Files { get; set; } = new List<IFormFile>();
    public IFormFile Images { get; set; }

    [BindRequired]
    public Guid? FkProductUnit { get; set; }
    public Guid? FkProductUnit2 { get; set; }


}

