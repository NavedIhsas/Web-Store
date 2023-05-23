using Amazon.SecurityToken.Model.Internal.MarshallTransformations;
using Application.SettingsDb;
using AutoMapper;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using static Application.Product.Category.ProductCategory;

namespace Application.Product.Category
{
    /// <summary>
    /// product level
    /// </summary>
    public interface IProductCategory
    {
        List<ProductLevelDto> GetLevelList();
        public List<ProductLevelDto> GetParentLevelList();
        int GetSubCodeCount();
        int GetMainCodeCount();
    }

    public class ProductCategory:IProductCategory
    {
        private readonly  SaleInContext _context;
        private readonly IMapper _mapper;
        
        public ProductCategory(SaleInContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<ProductLevelDto> GetLevelList()
        {
            var result = _context.ProductLevels.AsNoTracking().Select(x=>new ProductLevelDto
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
            var result= _context.Settings.SingleOrDefault(x => x.SetKey == ConstantParameter.DigitCountMainGroupCode)
                ?.SetValue;
            return result != null ? int.Parse(result) : 0;
        }
        public int GetSubCodeCount()
        {
            var result= _context.Settings.SingleOrDefault(x => x.SetKey == ConstantParameter.DigitCountSubGroupCode)
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
        }
    }
}
