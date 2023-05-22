using Amazon.SecurityToken.Model.Internal.MarshallTransformations;
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
    }

    public class ProductCategory:IProductCategory
    {
        private readonly  SaleInContext _context;
        private readonly IMapper _mappr;
        public ProductCategory(SaleInContext context, IMapper mappr)
        {
            _context = context;
            _mappr = mappr;
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

        public List<ProductLevelDto> GetParentLevelList()
        {
            var parent = _context.ProductLevels.Where(x => x.PrdLvlParentUid == null).AsNoTracking().ToList();
            return _mappr.Map<List<ProductLevelDto>>(parent).ToList();
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
