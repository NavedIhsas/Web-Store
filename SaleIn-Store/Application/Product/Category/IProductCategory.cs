using Application.SettingsDb;
using AutoMapper;
using Domain.SaleInModels;
using Domain.ShopModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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
        void CreatePrdCategory(ProductCategory.ProductLevelDto command);
    }

    public class ProductCategory : IProductCategory
    {
        private readonly ShopContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public ProductCategory(IMapper mapper, SaleInContext saleInContext, ShopContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public void CreatePrdCategory(ProductLevelDto command)
        {

            var baseConfig = _contextAccessor.HttpContext.Session.GetJson<BaseConfigDto>("BaseConfig");
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
        }
    }
}
