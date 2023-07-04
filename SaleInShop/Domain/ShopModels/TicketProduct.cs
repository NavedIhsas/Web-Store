using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class TicketProduct
{
    public Guid TpId { get; set; }

    public Guid TpFrProduct { get; set; }

    public long TpFrTicket { get; set; }

    public virtual Product TpFrProductNavigation { get; set; }

    public virtual Ticket TpFrTicketNavigation { get; set; }
}
