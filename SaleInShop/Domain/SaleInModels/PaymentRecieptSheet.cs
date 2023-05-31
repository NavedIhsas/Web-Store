using System;
using System.Collections.Generic;

namespace Domain.SaleInModels;

public partial class PaymentRecieptSheet
{
    public Guid PayRciptSheetUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public Guid? PurchUid { get; set; }

    public Guid? InvUid { get; set; }

    public Guid? AccUid { get; set; }

    public string PayRciptSheetNumber { get; set; }

    /// <summary>
    /// 1- برگه دریافت 2- برگه پرداخت
    /// </summary>
    public int? PayRciptSheetType { get; set; }

    public decimal? PayRciptSheetTotalAmount { get; set; }

    public DateTime? PayRciptSheetDate { get; set; }

    public string PayRciptSheetDescribtion { get; set; }

    public bool? PayRciptSheetStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public Guid? OrdUid { get; set; }

    public Guid? StkTrnsUid { get; set; }

    public Guid? WarHosRecUid { get; set; }

    public Guid? AccClbUid { get; set; }

    public bool? PayRciptSheetStatusControl { get; set; }

    public virtual Account AccU { get; set; }

    public virtual Invoice InvU { get; set; }

    public virtual Order OrdU { get; set; }

    public virtual ICollection<PaymentReceiptRelatedPurchaseInvoice> PaymentReceiptRelatedPurchaseInvoices { get; set; } = new List<PaymentReceiptRelatedPurchaseInvoice>();

    public virtual ICollection<PaymentRecieptDetail> PaymentRecieptDetails { get; set; } = new List<PaymentRecieptDetail>();

    public virtual Purchase PurchU { get; set; }

    public virtual StockTransfer StkTrnsU { get; set; }

    public virtual WarehouseReciept WarHosRecU { get; set; }
}
