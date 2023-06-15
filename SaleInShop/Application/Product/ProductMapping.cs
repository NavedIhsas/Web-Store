using Application.Product.ProductDto;
using AutoMapper;
using Domain.ShopModels;

namespace Application.Product;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        this.CreateMap<ProductDto.ProductDto, Domain.ShopModels.Product>();
        this.CreateMap<CreateProduct, Domain.ShopModels.Product>().ReverseMap();
        this.CreateMap<ProductProperty, ProductPropertiesDto>();
        this.CreateMap<ProductPicture, ProductPicturesDto>().ReverseMap();
        this.CreateMap<ProductProperty, PropertySelectOptionDto>().ReverseMap();
        this.CreateMap<Domain.ShopModels.Product, EditProduct>().ReverseMap();
    }  
}