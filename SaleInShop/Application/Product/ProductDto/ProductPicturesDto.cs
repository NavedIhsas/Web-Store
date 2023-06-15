namespace Application.Product.ProductDto;

public class ProductPicturesDto
{
    public Guid Id { get; set; }
    public string Image { get; set; }
    public byte[] ImageBase64 { get; set; }
}