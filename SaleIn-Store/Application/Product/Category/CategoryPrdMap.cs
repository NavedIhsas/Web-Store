using AutoMapper;
using Domain.ShopModels;
using static Application.Product.Category.ProductCategory;

namespace Application.Product.Category
{
    public class CategoryPrdMap : Profile
    {
        public CategoryPrdMap()
        {
            CreateMap<ProductLevelDto, ProductLevel>().ForMember(x => x.PrdLvlName,
                    opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.PrdLvlUid,
                    opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.PrdLvlCode, opt => opt.MapFrom(x => x.Code))
                .ForMember(x => x.PrdLvlUid, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<CreateProductLevel, ProductLevel>().ForMember(x => x.PrdLvlName,
                    opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.PrdLvlUid,
                    opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.PrdLvlCode, opt => opt.MapFrom(x => x.CodeValue))
                .ForMember(x => x.PrdLvlUid, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.PrdLvlCodeValue, opt => opt.MapFrom(x => x.Code))
                .ReverseMap();
        }
    }
}
