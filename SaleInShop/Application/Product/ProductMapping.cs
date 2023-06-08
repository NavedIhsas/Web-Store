﻿using AutoMapper;
using Domain.ShopModels;

namespace Application.Product
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
            CreateMap<ProductDto, Domain.ShopModels.Product>();
            CreateMap<CreateProduct, Domain.ShopModels.Product>();
            CreateMap<ProductProperty, ProductPropertiesDto>();
            CreateMap<ProductPicture, ProductPicturesDto>();
            CreateMap<Domain.ShopModels.Product, EditProduct>();
        }
    }
}