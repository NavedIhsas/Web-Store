using AutoMapper;
using Domain.ShopModels;

namespace Application.Product
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
            CreateMap<ProductDto, Domain.ShopModels.Product>();
            CreateMap<CreateProduct, Domain.ShopModels.Product>().ReverseMap();
            CreateMap<ProductProperty, ProductPropertiesDto>();
            CreateMap<ProductPicture, ProductPicturesDto>().ReverseMap();
            CreateMap<ProductProperty, PropertySelectOptionDto>().ReverseMap();
      

            CreateMap<Domain.ShopModels.Product, EditProduct>().ReverseMap();
        }
    }
}
