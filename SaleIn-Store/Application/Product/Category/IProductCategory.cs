using Application.Common;
using Application.Interfaces.Context;
using AutoMapper;
using Domain.SaleInModels;
using Domain.ShopModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using static Application.Product.Category.ProductCategory;
using ProductLevel = Domain.SaleInModels.ProductLevel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Product.Category
{
    /// <summary>
    /// product level
    /// </summary>
    public interface IProductCategory
    {
        List<ProductCategory.ProductLevelDto> GetLevelList();
        public List<ProductCategory.ProductLevelDto> GetParentLevelList();
        int GetSubCodeCount();
        int GetMainCodeCount();
        string GetPrdLvlCheck(string groupId);
        ResultDto<List<ProductLevelDto>> CreatePrdCategory(CreateProductLevel command);
        ResultDto Remove(Guid id);
    }

    public class ProductCategory : IProductCategory
    {
        private readonly IShopContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ILogger<ProductCategory> _logger;

        public ProductCategory(IMapper mapper, IShopContext context, IHttpContextAccessor contextAccessor, ILogger<ProductCategory> logger)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _logger = logger;
            _mapper = mapper;
        }

        public ResultDto<List<ProductLevelDto>> CreatePrdCategory(CreateProductLevel command)
        {
            var result = new ResultDto<List<ProductLevelDto>>();
            try
            {
                if (_context.ProductLevels.Any(x => x.PrdLvlName == command.Name.Fix()))
                    return result.Failed("رکوردی با این نام از قبل وجود دارد");
                var map = _mapper.Map<Domain.ShopModels.ProductLevel>(command);
                _context.ProductLevels.Add(map);
                _context.SaveChanges();
                return result.Succeeded(GetLevelList());
            }
            catch (Exception e)
            {
                _logger.LogError($"حین ثبت گروه کالا ها خطای زیر رخ داد {e}");
                return result.Failed("عملیات با خطا مواجه شد");
            }
        }

        public ResultDto Remove(Guid id)
        {
            var result = new ResultDto();

            try
            {
                var productLevel = _context.ProductLevels.SingleOrDefault(x => x.PrdLvlUid == id);
                if (productLevel == null) return result.Failed("هیچ رکوردی با این شناسه یافت نشد");
                _context.ProductLevels.Remove(productLevel);
                _context.SaveChanges();
                return result.Succeeded();
            }
            catch (Exception e)
            {
                _logger.LogError($"حین حذف گروه کالا با شناسه {id} خطای زیر رخ داد {e}");
                return result.Failed("عملیات با خطا مواجه شد");
            }
        }

        public string GetPrdLvlCheck(string groupId)
        {
            var result = _context.ProductLevels.SingleOrDefault(x => x.PrdLvlUid == new Guid(groupId));
            return result?.PrdLvlCode;
        }

        public List<ProductLevelDto> GetLevelList()
        {
            var result = _context.ProductLevels.AsNoTracking().Select(x => new ProductLevelDto
            {
                Id = x.PrdLvlUid,
                Name = x.PrdLvlName,
                Status = x.PrdLvlStatus,
                ParentId = x.PrdLvlParentUid,
                Code = x.PrdLvlCode,
            }).ToList();

            foreach (var sub in result)
            {
                sub.Sub = _context.ProductLevels.SingleOrDefault(x => x.PrdLvlUid == sub.ParentId)?.PrdLvlName;

            }
            return result;
        }


        public int GetMainCodeCount()
        {
            var result = _context.Settings.SingleOrDefault(x => x.SetKey == ConstantParameter.DigitCountMainGroupCode)
                ?.SetValue;
            return result != null ? int.Parse(result) : 0;
        }
        public int GetSubCodeCount()
        {
            var result = _context.Settings.SingleOrDefault(x => x.SetKey == ConstantParameter.DigitCountSubGroupCode)
                ?.SetValue;
            return result != null ? int.Parse(result) : 0;
        }
        public List<ProductLevelDto> GetParentLevelList()
        {
            var parent = _context.ProductLevels.Where(x => x.PrdLvlParentUid == null).AsNoTracking().ToList();
            return _mapper.Map<List<ProductLevelDto>>(parent).ToList();
        }

        public class ProductLevelDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public bool? Status { get; set; }
            public Guid? ParentId { get; set; }
            public string Sub { get; set; }
            public string Code { get; set; }
            public string CodeValue { get; set; }
        }

        public class CreateProductLevel
        {
            public Guid Id { get; set; }

            public string Name { get; set; }
            public bool? Status { get; set; }
            public Guid? ParentId { get; set; }
            public string CodeValue { get; set; }
            public string Code { get; set; }
        }
    }
}
