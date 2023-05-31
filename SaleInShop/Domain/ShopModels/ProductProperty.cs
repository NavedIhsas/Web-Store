using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class ProductProperty
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public string Value { get; set; }

    public Guid? PropertyId { get; set; }

    public virtual Property Property { get; set; }
}
