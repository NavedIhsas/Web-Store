using Domain.ShopModels;

namespace Application.Product.ProductDto;

public class EditProduct : CreateProduct
{
    public virtual ICollection<ProductPicturesDto> ProductPictures { get; set; }
    public virtual ICollection<PropertySelectOptionDto> ProductProperty { get; set; }

    public virtual ICollection<ProductProperty> ProductProperties { get; set; }
}