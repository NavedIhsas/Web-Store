using Application.BaseData.Dto;
using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Context;
using Application.Product.ProductDto;
using AutoMapper;
using Domain.ShopModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Application.Product
{
    public interface IProductService
    {
        Domain.ShopModels.Product GetProduct(Guid id);
        JsonResult GetAllProduct(JqueryDatatableParam param);
        ResultDto<JsonResult> GetAllProductForInvoice(JqueryDatatableParam param);
        ResultDto CreateProduct(CreateProduct command);
        List<ProductDto.ProductDto> GetAll();
        ProductDetails GetDetails(Guid id);
        List<PropertySelectOptionDto> PropertySelectOption();
        List<UnitOfMeasurementDto> UnitOfMeasurement();

        /// <summary>
        /// </summary>
        /// <param name="id">PropertyId</param>
        /// <returns></returns>
        List<ProductPropertiesDto> GetProductProperty(Guid id);

        EditProduct GetDetailsForEdit(Guid id);
        List<ProductPicturesDto> GetProductPictures(Guid productId);
        decimal? GetPrice(Guid? productId, int priceLevel);
        ResultDto Remove(Guid id);
        ResultDto UpdateProduct(EditProduct command);
        decimal CalculateDiscount(Guid? productId, Guid? accountClubId, int priceLevel);
        ResultDto<JsonResult> GetAllProductForPreInvoice(JqueryDatatableParam param);
    }

    public class ProductService : IProductService
    {
        private readonly IAuthHelper _authHelper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;
        private readonly IShopContext _shopContext;

        public ProductService(IShopContext shopContext, IMapper mapper, ILogger<ProductService> logger,
            IHttpContextAccessor contextAccessor, IAuthHelper authHelper)
        {
            _shopContext = shopContext;
            _mapper = mapper;
            _logger = logger;
            _contextAccessor = contextAccessor;
            _authHelper = authHelper;
        }

        public Domain.ShopModels.Product GetProduct(Guid id) => _shopContext.Products.Find(id);

        public List<ProductPropertiesDto> GetProductProperty(Guid id)
        {
            return _mapper.Map<List<ProductPropertiesDto>>(_shopContext.ProductProperties.Include(x => x.Property)
                .Where(x => x.ProductId == id).AsNoTracking());
        }

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
                _shopContext.ProductProperties.RemoveRange(
                    _shopContext.ProductProperties.Where(x => x.ProductId == id));
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

        public List<ProductDto.ProductDto> GetAll()
        {
            var result = _shopContext.Products.Include(x => x.TaxU).Include(x => x.PrdLvlUid3Navigation)
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
                    x.PrdLvlUid3Navigation.PrdLvlName
                }).Select(x => new ProductDto.ProductDto
                {
                    PrdUid = x.PrdUid,
                    PrdName = x.PrdName,
                    PrdCode = x.PrdCode,
                    PrdLevelId = x.PrdLvlName,
                    PrdImage = x.PrdImage,
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
                    Unit2 = x.PrdUnit2
                }).ToList();

            // var products = _mapper.Map<List<ProductDto>>(result);
            return result;
        }



        public JsonResult GetAllProduct(JqueryDatatableParam param)
        {
            var list = _shopContext.Products.Include(x => x.PrdLvlUid3Navigation).Include(x => x.TaxU).AsNoTracking().Select(x => new
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
                x.PrdLvlUid3Navigation.PrdLvlName
            }).Select(x => new ProductDto.ProductDto
            {
                PrdUid = x.PrdUid,
                PrdName = x.PrdName,
                PrdCode = x.PrdCode,
                PrdLevelId = x.PrdLvlName,
                PrdImage = x.PrdImage,
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
                Unit2 = x.PrdUnit2
            });

            if (!string.IsNullOrEmpty(param.SSearch))
            {
                list = list.Where(x => x.PrdName.ToLower().Contains(param.SSearch.ToLower())
                || x.PrdName.Contains(param.SSearch.ToLower())
                || x.PrdLvlName.Contains(param.SSearch.ToLower())
                || x.TaxName.Contains(param.SSearch.ToLower())
                || x.PrdCode.Contains(param.SSearch.ToLower())
                );
            }

            var sortColumnIndex = Convert.ToInt32(_contextAccessor.HttpContext.Request.Query["iSortCol_0"]);
            var sortDirection = _contextAccessor.HttpContext.Request.Query["sSortDir_0"];

            switch (sortColumnIndex)
            {
                case 0:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.PrdImage) : list.OrderByDescending(c => c.PrdImage);
                    break;

                case 1:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.PrdName) : list.OrderByDescending(c => c.PrdName);
                    break;
                case 2:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.PrdLvlName) : list.OrderByDescending(c => c.PrdLvlName);
                    break;

                case 3:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.PrdCode) : list.OrderByDescending(c => c.PrdCode);
                    break;

                case 4:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.TaxName) : list.OrderByDescending(c => c.TaxName);
                    break;

                case 5:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.PrdStatus) : list.OrderByDescending(c => c.PrdStatus);
                    break;


                default:
                    {
                        string OrderingFunction(ProductDto.ProductDto e) => sortColumnIndex == 0 ? e.PrdName : "";
                        IOrderedEnumerable<ProductDto.ProductDto> rr = null;
                        rr = sortDirection == "asc" ? list.AsEnumerable().OrderBy((Func<ProductDto.ProductDto, string>)OrderingFunction) : list.AsEnumerable().OrderByDescending((Func<ProductDto.ProductDto, string>)OrderingFunction);

                        list = rr.AsQueryable();
                        break;
                    }
            }

            IQueryable<ProductDto.ProductDto> displayResult;
            if (param.IDisplayLength != 0)
                displayResult = list.Skip(param.IDisplayStart)
                .Take(param.IDisplayLength);
            else displayResult = list;
            var totalRecords = list.Count();

            var result1 = (new
            {
                param.SEcho,
                iTotalRecords = totalRecords,
                iTotalDisplayRecords = totalRecords,
                aaData = displayResult
            });
            return new JsonResult(result1, new JsonSerializerOptions { PropertyNamingPolicy = null });

        }

        private static int ConvertPercentToAmount(decimal? price, decimal? discountPrice)
        {
            if (price is 0 or null) return 0;
            var result = (discountPrice * 100) / price;
            return Convert.ToInt32(result);
        }


        private decimal CalculateAcClubDiscount(Guid? accountClubId, int priceLevel)
        {
            decimal discount = 0;
            var clubType = _shopContext.AccountClubTypes
                .Select(x => new { x.AccClbTypUid, x.AccClbTypDetDiscount, x.AccClbTypPercentDiscount })
                .SingleOrDefault(x => x.AccClbTypUid == accountClubId);
            discount = Convert.ToDecimal(clubType.AccClbTypPercentDiscount);
            return discount;
        }

        private decimal CalculateProductDiscount(Guid? productId, int priceLevel)
        {
            var product = _shopContext.Products
                .Select(x => new { x.PrdUid, x.PrdDiscountType, x.PrdDiscount, x.PrdPercentDiscount, x.PrdPricePerUnit1, x.PrdPricePerUnit2, x.PrdPricePerUnit3, x.PrdPricePerUnit4, x.PrdPricePerUnit5, })
                .AsNoTracking().SingleOrDefault(x => x.PrdUid == productId);

            decimal discount = 0;
            if (product == null) return discount;
            var productDiscount = product.PrdDiscount;
            if (product.PrdDiscountType == ConstantParameter.Percent)
                discount = product.PrdDiscount ?? 0;
            else if (product.PrdDiscountType == ConstantParameter.Amount)
            {
                discount = priceLevel switch
                {
                    PriceInvoiceLevel.Level1 =>
                        ConvertPercentToAmount(product.PrdPricePerUnit1, productDiscount),
                    PriceInvoiceLevel.Level2 =>
                        ConvertPercentToAmount(product.PrdPricePerUnit2, productDiscount),
                    PriceInvoiceLevel.Level3 =>
                        ConvertPercentToAmount(product.PrdPricePerUnit3, productDiscount),
                    PriceInvoiceLevel.Level4 =>
                        ConvertPercentToAmount(product.PrdPricePerUnit4, productDiscount),
                    PriceInvoiceLevel.Level5 =>
                        ConvertPercentToAmount(product.PrdPricePerUnit5, productDiscount),

                    _ => discount
                };
            }

            return discount;
        }

        public decimal? GetPrice(Guid? productId, int priceLevel)
        {
            var product = _shopContext.Products
                .Select(x => new { x.PrdUid, x.PrdPercentDiscount, x.PrdPricePerUnit1, x.PrdPricePerUnit2, x.PrdPricePerUnit3, x.PrdPricePerUnit4, x.PrdPricePerUnit5, })
                .AsNoTracking().SingleOrDefault(x => x.PrdUid == productId);

            if (product == null)
                return null;

            decimal? price = null;
            price = priceLevel switch
            {
                PriceInvoiceLevel.Level1 =>
                  product.PrdPricePerUnit1,
                PriceInvoiceLevel.Level2 =>
                  price = product.PrdPricePerUnit2,
                PriceInvoiceLevel.Level3 =>
                  price = product.PrdPricePerUnit3,
                PriceInvoiceLevel.Level4 =>
                  price = product.PrdPricePerUnit4,
                PriceInvoiceLevel.Level5 =>
                  price = product.PrdPricePerUnit5,
                _ => null
            };

            return price;
        }
        public decimal CalculateDiscount(Guid? productId, Guid? accountClubId, int priceLevel)
        {
            var discountType = _authHelper.GetInvoiceDiscountStatus();
            decimal discount = 0;
            switch (discountType)
            {
                case InvoiceDetDiscountStatus.Product:
                    discount = this.CalculateProductDiscount(productId, priceLevel);
                    break;
                case InvoiceDetDiscountStatus.AccountClubType:
                    discount = this.CalculateAcClubDiscount(accountClubId, priceLevel);
                    break;
                case InvoiceDetDiscountStatus.Both:
                    {
                        var productDiscount = this.CalculateProductDiscount(productId, priceLevel);
                        var accClubType = this.CalculateAcClubDiscount(accountClubId, priceLevel);
                        discount = productDiscount + accClubType;
                        break;
                    }
                case null:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return discount;
        }
        public ResultDto<JsonResult> GetAllProductForInvoice(JqueryDatatableParam param)
        {
            var result = new ResultDto<JsonResult>();
            var cookie = _authHelper.GetCookie("AccountClubList");
            AccountClubDto account;
            try
            {
                 account = JsonConvert.DeserializeObject<AccountClubDto>(cookie);
            }
            catch (Exception e)
            {

                throw new Exception("");
            }
            if (account == null)
            {
                _logger.LogError($"An error occurred while retrieving data from cookie (AccountClubList) ");
                return result.Failed("خطا در دریافت اطلاعات، لطفا با پشتیبانی تماس بگرید");
            }
            var list = _shopContext.Products.Include(x => x.PrdLvlUid3Navigation).Include(x => x.TaxU).AsNoTracking().Select(x => new
            {

                x.PrdUid,
                x.PrdName,
                x.PrdPricePerUnit1,
                x.PrdLvlUid3Navigation.PrdLvlName,
                x.TaxU.TaxValue,
                x.TaxU.TaxTaxesValue
            }).Select(x => new ProductDto.ProductDto
            {
                PrdUid = x.PrdUid,
                PrdName = x.PrdName,
                PrdLevelId = x.PrdLvlName,
                PrdPricePerUnit1 = x.PrdPricePerUnit1 ?? 0,
                PrdLvlName = x.PrdLvlName,
                PriceLevel = account.AccTypePriceLevel ?? 0,
                AccClubTypeId = account.AccClbTypUid ?? Guid.Empty,
                InvoiceDiscount = account.InvoiceDiscount ?? 0,
                DiscountPercent = Convert.ToDecimal(account.AccClubDiscount),
                TaxValue = x.TaxValue ?? 0 + x.TaxTaxesValue ?? 0
            });

            if (!string.IsNullOrEmpty(param.SSearch))
            {
                list = list.Where(x => x.PrdName.ToLower().Contains(param.SSearch.ToLower())
                || x.PrdName.Contains(param.SSearch.ToLower())
                || x.PrdLvlName.Contains(param.SSearch.ToLower())
                || x.PrdPricePerUnit1.ToString().Contains(param.SSearch));
            }

            var sortColumnIndex = Convert.ToInt32(_contextAccessor.HttpContext.Request.Query["iSortCol_0"]);
            var sortDirection = _contextAccessor.HttpContext.Request.Query["sSortDir_0"];

            switch (sortColumnIndex)
            {
                case 0:
                    list = sortDirection == "asc" ? list.OrderBy(c => c) : list.OrderByDescending(c => c.PrdImage);
                    break;

                case 1:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.PrdName) : list.OrderByDescending(c => c.PrdName);
                    break;
                case 2:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.PrdLvlName) : list.OrderByDescending(c => c.PrdLvlName);
                    break;

                default:
                    {
                        string OrderingFunction(ProductDto.ProductDto e) => sortColumnIndex == 0 ? e.PrdName : "";
                        IOrderedEnumerable<ProductDto.ProductDto> rr = null;
                        rr = sortDirection == "asc" ? list.AsEnumerable().OrderBy((Func<ProductDto.ProductDto, string>)OrderingFunction) : list.AsEnumerable().OrderByDescending((Func<ProductDto.ProductDto, string>)OrderingFunction);

                        list = rr.AsQueryable();
                        break;
                    }
            }

            IQueryable<ProductDto.ProductDto> displayResult;
            if (param.IDisplayLength != 0)
                displayResult = list.Skip(param.IDisplayStart)
                .Take(param.IDisplayLength);
            else displayResult = list;
            var totalRecords = list.Count();


            var result1 = (new
            {
                param.SEcho,
                iTotalRecords = totalRecords,
                iTotalDisplayRecords = totalRecords,
                aaData = displayResult.ToList()
            });

            var shareDiscount = _authHelper.GetTaxBeforeDiscount();
            foreach (var dto in result1.aaData)
            {

                dto.DiscountPercent = this.CalculateDiscount(dto.PrdUid, dto.AccClubTypeId, dto.PriceLevel);

                if (shareDiscount == 1)
                {
                    dto.DiscountSaveToDb = dto.DiscountPercent;
                    dto.DiscountPercent += Convert.ToDecimal(dto.InvoiceDiscount);
                    dto.InvoiceDiscountPercent = dto.InvoiceDiscount;
                    dto.InvoiceDiscount=0;
                    if (dto.DiscountPercent > 100)
                    {
                        dto.DiscountPercent = 100;
                        dto.TaxValue = 0;
                        dto.TotalPaidAmount = 0;
                        dto.InvoiceDiscount = 0;
                    }


                }

               
                dto.Price = this.GetPrice(dto.PrdUid, dto.PriceLevel);
                // dto.InvoiceDiscount = dto.InvoiceDiscount;
            }
            var jsonRe = new JsonResult(result1, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return result.Succeeded(jsonRe);

        }
         public ResultDto<JsonResult> GetAllProductForPreInvoice(JqueryDatatableParam param)
        {
            var result = new ResultDto<JsonResult>();
            var list =new List<ProductDto.ProductDto>();
            var cookie = _authHelper.GetCookie("AccountClubList");

            AccountClubDto account;
            try
            {
                 account = JsonConvert.DeserializeObject<AccountClubDto>(cookie);
            }
            catch (Exception e)
            {

                throw new Exception("");
            }
            if (account == null)
            {
                _logger.LogError($"An error occurred while retrieving data from cookie (AccountClubList) ");
                return result.Failed("خطا در دریافت اطلاعات، لطفا با پشتیبانی تماس بگرید");
            }

            var invoices = _shopContext.Invoices.Include(x=>x.InvoiceDetails).Where(x => x.AccClbUid == account.AccClbUid).ToList();
            foreach (var invoice in from invoice in invoices from details in invoice.InvoiceDetails select details)
            {
                var res = _shopContext.Products.Where(x => x.PrdUid == invoice.PrdUid).Include(x => x.PrdLvlUid3Navigation).Include(x => x.TaxU).AsNoTracking().Select(x => new
                {
                    x.PrdUid,
                    x.PrdName,
                    x.PrdPricePerUnit1,
                    x.PrdLvlUid3Navigation.PrdLvlName,
                    x.TaxU.TaxValue,
                    x.TaxU.TaxTaxesValue
                }).Select(x => new ProductDto.ProductDto
                {
                    PrdUid = x.PrdUid,
                    PrdName = x.PrdName,
                    PrdLevelId = x.PrdLvlName,
                    PrdPricePerUnit1 = x.PrdPricePerUnit1 ?? 0,
                    PrdLvlName = x.PrdLvlName,
                    PriceLevel = account.AccTypePriceLevel ?? 0,
                    AccClubTypeId = account.AccClbTypUid ?? Guid.Empty,
                    InvoiceDiscount = account.InvoiceDiscount ?? 0,
                    DiscountPercent = Convert.ToDecimal(account.AccClubDiscount),
                    TaxValue = x.TaxValue ?? 0 + x.TaxTaxesValue ?? 0
                }).ToList();
                list.AddRange(res);
            }
           

            if (!string.IsNullOrEmpty(param.SSearch))
            {
                list = list.Where(x => x.PrdName.ToLower().Contains(param.SSearch.ToLower())
                || x.PrdName.Contains(param.SSearch.ToLower())
                || x.PrdLvlName.Contains(param.SSearch.ToLower())
                || x.PrdPricePerUnit1.ToString().Contains(param.SSearch)).ToList();
            }

            var sortColumnIndex = Convert.ToInt32(_contextAccessor.HttpContext.Request.Query["iSortCol_0"]);
            var sortDirection = _contextAccessor.HttpContext.Request.Query["sSortDir_0"];

            switch (sortColumnIndex)
            {
                case 0:
                    list = sortDirection == "asc" ? list.OrderBy(c => c).ToList() : list.OrderByDescending(c => c.PrdImage).ToList();
                    break;

                case 1:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.PrdName).ToList() : list.OrderByDescending(c => c.PrdName).ToList();
                    break;
                case 2:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.PrdLvlName).ToList() : list.OrderByDescending(c => c.PrdLvlName).ToList();
                    break;

                default:
                    {
                        string OrderingFunction(ProductDto.ProductDto e) => sortColumnIndex == 0 ? e.PrdName : "";
                        IOrderedEnumerable<ProductDto.ProductDto> rr = null;
                        rr = sortDirection == "asc" ? list.AsEnumerable().OrderBy((Func<ProductDto.ProductDto, string>)OrderingFunction) : list.AsEnumerable().OrderByDescending((Func<ProductDto.ProductDto, string>)OrderingFunction);

                        list = rr.AsQueryable().ToList();
                        break;
                    }
            }

            List<ProductDto.ProductDto> displayResult;
            if (param.IDisplayLength != 0)
               displayResult =list.Skip(param.IDisplayStart)
                    .Take(param.IDisplayLength).ToList();
            else displayResult = list;
            var totalRecords = list.Count();


            var result1 = (new
            {
                param.SEcho,
                iTotalRecords = totalRecords,
                iTotalDisplayRecords = totalRecords,
                aaData = displayResult.ToList()
            });

            var shareDiscount = _authHelper.GetTaxBeforeDiscount();
            foreach (var dto in result1.aaData)
            {

                dto.DiscountPercent = this.CalculateDiscount(dto.PrdUid, dto.AccClubTypeId, dto.PriceLevel);

                if (shareDiscount == 1)
                {
                    dto.DiscountSaveToDb = dto.DiscountPercent;
                    dto.DiscountPercent += Convert.ToDecimal(dto.InvoiceDiscount);
                    dto.InvoiceDiscountPercent = dto.InvoiceDiscount;
                    dto.InvoiceDiscount=0;
                    if (dto.DiscountPercent > 100)
                    {
                        dto.DiscountPercent = 100;
                        dto.TaxValue = 0;
                        dto.TotalPaidAmount = 0;
                        dto.InvoiceDiscount = 0;
                    }


                }

               
                dto.Price = this.GetPrice(dto.PrdUid, dto.PriceLevel);
                // dto.InvoiceDiscount = dto.InvoiceDiscount;
            }
            var jsonRe = new JsonResult(result1, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return result.Succeeded(jsonRe);

        }

        public EditProduct GetDetailsForEdit(Guid id)
        {
            var product = _shopContext.Products.Include(x => x.PrdLvlUid3Navigation).Include(x => x.ProductPictures)
                .Include(x => x.ProductProperties).ThenInclude(x => x.Property).SingleOrDefault(x => x.PrdUid == id);
            if (product == null)
            {
                _logger.LogError($"Don't Found Any Record With Id {id} On Table Product");
                throw new ArgumentNullException($"Don't Found Any Record With Id {id} On Table Product");
            }
            var map = _mapper.Map<EditProduct>(product);
            map.Image = Convert.FromBase64String(map.PrdImage);
            var getProperty =
                _contextAccessor.HttpContext.Session.GetJson<List<PropertySelectOptionDto>>("edit-Property");
            var getPictures = _contextAccessor.HttpContext.Session.GetJson<List<ProductPicturesDto>>("edit-picture");
            if (getProperty != null && getPictures != null)
            {
                map.ProductPictures = getPictures;
                map.ProductProperty = getProperty;
                return map;
            }

            map.ProductProperty = map.ProductProperties.Select(x => new PropertySelectOptionDto
            {
                Id = x.Id,
                Name = x.Property.Name,
                PropertyId = x.PropertyId,
                Value = x.Value
            }).ToList();

            _contextAccessor.HttpContext.Session.Remove("edit-Property");
            _contextAccessor.HttpContext.Session.Remove("edit-picture");
            getProperty = new List<PropertySelectOptionDto>();
            getPictures = new List<ProductPicturesDto>();
            foreach (var property in map.ProductProperty)
            {
                getProperty.Add(new PropertySelectOptionDto
                {
                    PropertyId = property.PropertyId,
                    Name = property.Name,
                    Id = property.Id,
                    Value = property.Value
                });
                _contextAccessor.HttpContext.Session.SetJson("edit-Property", getProperty);
            }

            foreach (var picture in map.ProductPictures)
                getPictures.Add(new ProductPicturesDto
                {
                    ImageBase64 = Convert.FromBase64String(picture.Image),
                    Id = picture.Id
                });

            _contextAccessor.HttpContext.Session.SetJson("edit-picture", getPictures);

            return map;
        }


        public ProductDetails GetDetails(Guid id)
        {
            return _shopContext.Products.Include(x => x.UomUid1Navigation).Include(x => x.FkProductUnit2Navigation)
                .Select(x => new
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
                    x.Volume
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
                    Unit2 = x.FkProductUnit2Navigation.UomName ?? ""
                }).SingleOrDefault(x => x.PrdUid == id);
        }

        public List<PropertySelectOptionDto> PropertySelectOption()
        {
            return _shopContext.Properties.Select(x => new PropertySelectOptionDto { Id = x.Id, Name = x.Name })
                .AsNoTracking().ToList();
        }

        public List<UnitOfMeasurementDto> UnitOfMeasurement()
        {
            return _shopContext.UnitOfMeasurements.Select(x => new { x.UomUid, x.UomName })
                .Select(x => new UnitOfMeasurementDto { Name = x.UomName, Id = x.UomUid })
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
                    return result.Failed(ValidateMessage.DuplicateName);
                if (command.Images != null)
                    command.PrdImage = ToBase64.Image(command.Images);
                var product = _mapper.Map<Domain.ShopModels.Product>(command);

                _shopContext.Products.Add(product);
                _shopContext.SaveChanges();

                if (command.Files.Any())
                    foreach (var addPicture in command.Files.Select(picture => ToBase64.Image(picture)).Select(image =>
                                 new ProductPicture
                                 {
                                     Id = Guid.NewGuid(),
                                     Image = image,
                                     ProductId = product.PrdUid
                                 }))
                    {
                        _shopContext.ProductPictures.Add(addPicture);
                        _shopContext.SaveChanges();
                    }


                var getProperty =
                    _contextAccessor.HttpContext.Session.GetJson<List<PropertySelectOptionDto>>("Product-Property");
                if (getProperty != null && getProperty.Any())
                    foreach (var newProp in getProperty.Select(property => new ProductProperty
                    {
                        Id = Guid.NewGuid(),
                        Value = property.Value,
                        ProductId = product.PrdUid,
                        PropertyId = property.Id
                    }))
                    {
                        _shopContext.ProductProperties.Add(newProp);
                        _shopContext.SaveChanges();
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
                        x.PrdName == product.PrdName && x.PrdLvlUid3 == product.PrdLvlUid3 &&
                        x.PrdUid != product.PrdUid))
                    return result.Failed(ValidateMessage.DuplicateName);
                if (command.Images != null)
                    command.PrdImage = ToBase64.Image(command.Images);


                command.PrdUid = product.PrdUid;
                if (string.IsNullOrWhiteSpace(command.PrdImage))
                    command.PrdImage = product.PrdImage;

                var productMap = _mapper.Map(command, product);

                productMap.PrdUniqid = 0;
                _shopContext.Products.Update(productMap).Property(x => x.PrdUniqid).IsModified = false;
                _shopContext.SaveChanges();

                if (command.Files.Any())
                    this.UpdatePictures(product.PrdUid, command.Files);


                this.UpdateProperties(product.PrdUid);
                transaction.Commit();
                return result.Succeeded();
            }
            catch (Exception exception)
            {
                transaction.Rollback();
                _logger.LogError($"حین ویرایش محصول خطای زیر رخ داده است {exception}");
                return result.Failed($"حین ویرایش محصول خطای زیر رخ داده است ");
            }
        }


        private void UpdateProperties(Guid productId)
        {
            var getProperty =
                _contextAccessor.HttpContext.Session.GetJson<List<PropertySelectOptionDto>>("edit-Property") ??
                new List<PropertySelectOptionDto>();

            _shopContext.ProductProperties.Where(x => x.ProductId == productId).ExecuteDelete();

            foreach (var dto in getProperty)
            {
                var update = new ProductProperty
                {
                    PropertyId = dto.PropertyId,
                    Value = dto.Value,
                    ProductId = productId,
                    Id = Guid.NewGuid()
                };

                _shopContext.ProductProperties.Add(update);
                _shopContext.SaveChanges();
            }
        }

        private void UpdatePictures(Guid productId, List<IFormFile> files)
        {
            var pictures = _contextAccessor.HttpContext.Session.GetJson<List<ProductPicturesDto>>("edit-picture")
                .ToList();

            if (!pictures.Any())
                _shopContext.ProductPictures.Where(x => x.ProductId == productId).ExecuteDelete();
            if (pictures.Any())
            {
                var list = new List<ProductPicture>();
                foreach (var picture in pictures)
                {
                    var productPictures =
                        _shopContext.ProductPictures.FirstOrDefault(x =>
                            x.ProductId == productId && x.Id == picture.Id);
                    list.Add(productPictures);
                }

                var list2 = _shopContext.ProductPictures.Where(x => x.ProductId == productId).ToList();
                var list3 = list2.Except(list).ToList();
                _shopContext.ProductPictures.RemoveRange(list3);
                _shopContext.SaveChanges();
            }

            if (files.Any())
            {
                var getPictures =
                    _contextAccessor.HttpContext.Session.GetJson<List<ProductPicturesDto>>("edit-picture");

                foreach (var picture in files)
                {
                    var base64String = ToBase64.Image(picture);
                    var add = new ProductPicture
                    {
                        Image = base64String,
                        Id = Guid.NewGuid(),
                        ProductId = productId
                    };
                    _shopContext.ProductPictures.Add(add);
                    _shopContext.SaveChanges();

                    getPictures.Add(new ProductPicturesDto
                    {
                        Id = add.Id,
                        ImageBase64 = Convert.FromBase64String(add.Image),
                        Image = add.Image
                    });
                    _contextAccessor.HttpContext.Session.SetJson("edit-picture", getPictures);
                }
            }
        }
    }
}
