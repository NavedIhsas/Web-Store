namespace Domain.ShopModels;

public class ProductPicture
{
    public Guid Id { get; set; }

    public string Image { get; set; }

    public Guid ProductId { get; set; }

    public virtual Product Product { get; set; }
}