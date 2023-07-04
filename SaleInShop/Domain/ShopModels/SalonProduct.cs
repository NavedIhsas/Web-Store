using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class SalonProduct
{
    public Guid SpId { get; set; }

    public Guid SpFrProduct { get; set; }

    public long SpFrSalon { get; set; }

    public virtual Product SpFrProductNavigation { get; set; }

    public virtual Salon SpFrSalonNavigation { get; set; }
}
