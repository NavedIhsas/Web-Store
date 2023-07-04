using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class ProductPicture
{
    public Guid Id { get; set; }

    public string Image { get; set; }

    public Guid ProductId { get; set; }

    public virtual Product Product { get; set; }
}
