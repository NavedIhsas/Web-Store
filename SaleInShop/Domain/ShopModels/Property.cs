namespace Domain.ShopModels;

public class Property
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Type { get; set; }

    public bool IsSpecial { get; set; }

    public virtual ICollection<ProductProperty> ProductProperties { get; set; } = new List<ProductProperty>();
}