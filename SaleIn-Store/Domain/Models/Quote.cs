using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Quote
{
    public Guid QutUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public Guid? SalCatUid { get; set; }

    public Guid? AccUid { get; set; }

    public string QutNumber { get; set; }

    public decimal? QutTotalAmount { get; set; }

    public decimal? QutTotalDiscount { get; set; }

    public decimal? QutTotalTax { get; set; }

    public decimal? QutTotalCost { get; set; }

    public decimal? QutExtendedAmount { get; set; }

    public DateTime? QutDate { get; set; }

    public string QutDescribtion { get; set; }

    public bool? QutStatusControl { get; set; }

    public bool? QutStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public bool? QutFinalStatusControl { get; set; }

    public virtual Account AccU { get; set; }

    public virtual FiscalPeriod FisPeriodU { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<QuoteDetail> QuoteDetails { get; set; } = new List<QuoteDetail>();

    public virtual SalesCategory SalCatU { get; set; }

    public virtual ICollection<WarehouseReciept> WarehouseReciepts { get; set; } = new List<WarehouseReciept>();
}
