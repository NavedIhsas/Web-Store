using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.Product.ProductDto;

public class CreateProperty
{
    [BindRequired] public Guid Id { get; set; }

    public string Value { get; set; }
    public string Name { get; set; }
    public Guid PropertyId { get; set; }
}