using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Order
{
    public Guid OrdUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public Guid? SalCatUid { get; set; }

    public Guid? AccUid { get; set; }

    public Guid? QutUid { get; set; }

    public string OrdNumber { get; set; }

    public decimal? OrdTotalAmount { get; set; }

    public decimal? OrdTotalDiscount { get; set; }

    public decimal? OrdTotalTax { get; set; }

    public decimal? OrdTotalCost { get; set; }

    public decimal? OrdExtendedAmount { get; set; }

    public DateTime? OrdDate { get; set; }

    public string OrdDescribtion { get; set; }

    public bool? OrdStatusControl { get; set; }

    public bool? OrdStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public bool? OrdFinalStatusControl { get; set; }

    public virtual Account AccU { get; set; }

    public virtual FiscalPeriod FisPeriodU { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<PaymentRecieptSheet> PaymentRecieptSheets { get; set; } = new List<PaymentRecieptSheet>();

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual SalesCategory SalCatU { get; set; }

    public virtual ICollection<WarehouseReciept> WarehouseReciepts { get; set; } = new List<WarehouseReciept>();
}
