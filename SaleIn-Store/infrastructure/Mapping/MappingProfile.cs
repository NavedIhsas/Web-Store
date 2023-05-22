using AutoMapper;
using Domain.Models;
using static Application.Product.Category.ProductCategory;

namespace infrastructure.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductLevelDto, ProductLevel>().ForMember(x=>x.PrdLvlName,opt=>opt.MapFrom(x=>x.Name))
                .ForMember(x=>x.PrdLvlUid,opt=>opt.MapFrom(x=>x.Id)).ReverseMap();
        }
    }
}
