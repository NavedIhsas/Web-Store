using AutoMapper;

namespace Application.Product
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
            CreateMap<ProductDto, Domain.ShopModels.Product>();
        }
    }
}
