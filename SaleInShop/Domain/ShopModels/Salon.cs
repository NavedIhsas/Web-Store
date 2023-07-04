using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class Salon
{
    public long SlnId { get; set; }

    public string SlnName { get; set; }

    public short SlnType { get; set; }

    public Guid? FrWarHosUid { get; set; }

    public virtual ICollection<Calender> Calenders { get; set; } = new List<Calender>();

    public virtual ICollection<CardRechage> CardRechages { get; set; } = new List<CardRechage>();

    public virtual WareHouse FrWarHosU { get; set; }

    public virtual ICollection<SalonDetail> SalonDetails { get; set; } = new List<SalonDetail>();

    public virtual ICollection<SalonProduct> SalonProducts { get; set; } = new List<SalonProduct>();

    public virtual ICollection<ServiceTransaction> ServiceTransactions { get; set; } = new List<ServiceTransaction>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
