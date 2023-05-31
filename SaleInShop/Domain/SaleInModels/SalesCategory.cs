using System;
using System.Collections.Generic;

namespace Domain.SaleInModels;

public partial class SalesCategory
{
    public Guid SalCatUid { get; set; }

    public string SalCatName { get; set; }

    public string SalCatCode { get; set; }

    public bool? SalCatStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual ICollection<DefualtAccountDefinition> DefualtAccountDefinitions { get; set; } = new List<DefualtAccountDefinition>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<PaymentRecieptDetail> PaymentRecieptDetails { get; set; } = new List<PaymentRecieptDetail>();

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual ICollection<Quote> Quotes { get; set; } = new List<Quote>();

    public virtual ICollection<WarehouseReciept> WarehouseReciepts { get; set; } = new List<WarehouseReciept>();
}
