using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class Property
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Type { get; set; }

    public bool? IsSpecial { get; set; }
}
