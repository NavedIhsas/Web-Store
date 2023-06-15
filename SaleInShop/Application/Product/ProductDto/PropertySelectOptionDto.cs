namespace Application.Product.ProductDto;

public class PropertySelectOptionDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public Guid PropertyId { get; set; }
}