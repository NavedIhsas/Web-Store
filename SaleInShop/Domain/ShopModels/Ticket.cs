using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class Ticket
{
    public long TktId { get; set; }

    public long TktFrSalon { get; set; }

    public Guid TktFrCreateBy { get; set; }

    public short TktType { get; set; }

    public decimal? TktAmount { get; set; }

    public decimal? TktDiscountRial { get; set; }

    public decimal? TktDiscountPercent { get; set; }

    public decimal? TktSaleAmount { get; set; }

    public string TktName { get; set; }

    public int TktNumber { get; set; }

    public DateTime TktCreateOn { get; set; }

    public DateTime TktExpireDate { get; set; }

    public virtual ICollection<TicketDetail> TicketDetails { get; set; } = new List<TicketDetail>();

    public virtual ICollection<TicketProduct> TicketProducts { get; set; } = new List<TicketProduct>();

    public virtual SystemUser TktFrCreateByNavigation { get; set; }

    public virtual Salon TktFrSalonNavigation { get; set; }
}
