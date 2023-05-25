using AutoMapper;
using Domain.ShopModels;
using static Application.Product.Category.ProductCategory;

namespace Application.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductLevelDto, ProductLevel>().ForMember(x=>x.PrdLvlName,
                    opt=>opt.MapFrom(x=>x.Name))
                .ForMember(x=>x.PrdLvlUid,
                    opt=>opt.MapFrom(x=>x.Id))
                .ForMember(x=>x.PrdLvlCode,opt=>opt.MapFrom(x=>x.Code))
                .ForMember(x=>x.PrdLvlUid,opt=>opt.MapFrom(x=>x.Id==new Guid()))
                .ReverseMap();
        }
    }
}
