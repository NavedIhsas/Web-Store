using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class SalonDetail
{
    public long SdId { get; set; }

    public long SdFrSalon { get; set; }

    public Guid SdFrAccountclub { get; set; }

    public virtual AccountClub SdFrAccountclubNavigation { get; set; }

    public virtual Salon SdFrSalonNavigation { get; set; }
}
