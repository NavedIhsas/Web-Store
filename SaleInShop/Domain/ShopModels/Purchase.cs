
using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class Purchase
{
    public Guid PurchUid { get; set; }

    public Guid? PurchParentUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public Guid? SalCatUid { get; set; }

    public Guid? AccUid { get; set; }

    public string PurchNumber { get; set; }

    public decimal? PurchTotalAmount { get; set; }

    public decimal? PurchTotalDiscount { get; set; }

    public decimal? PurchTotalTax { get; set; }

    public decimal? PurchTotalCost { get; set; }

    public decimal? PurchExtendedAmount { get; set; }

    public string PurchReference { get; set; }

    public DateTime? PurchDate { get; set; }

    public DateTime? PurchDueDate { get; set; }

    public string PurchDescribtion { get; set; }

    public bool? PurchStatusControl { get; set; }

    public bool? PurchStatus { get; set; }

    public bool? PurchFinalStatusControl { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public Guid? OrdUid { get; set; }

    public Guid? AccClbUid { get; set; }

    public Guid? WrkSttUid { get; set; }

    public int? PurchSync { get; set; }

    public decimal? PurchDetTotalDiscount { get; set; }

    public virtual Account AccU { get; set; }

    public virtual FiscalPeriod FisPeriodU { get; set; }

    public virtual Order OrdU { get; set; }

    public virtual ICollection<PaymentReceiptRelatedPurchaseInvoice> PaymentReceiptRelatedPurchaseInvoices { get; set; } = new List<PaymentReceiptRelatedPurchaseInvoice>();

    public virtual ICollection<PaymentRecieptSheet> PaymentRecieptSheets { get; set; } = new List<PaymentRecieptSheet>();

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();

    public virtual SalesCategory SalCatU { get; set; }
}
