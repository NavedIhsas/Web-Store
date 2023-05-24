using System;
using System.Collections.Generic;

namespace Domain.SaleInModels;

public partial class PaymentReceiptRelatedPurchaseInvoice
{
    public Guid PayRciptRelUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public Guid PayRciptSheetUid { get; set; }

    public Guid? PurchUid { get; set; }

    public Guid? InvUid { get; set; }

    public bool? PayRciptRelStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual Invoice InvU { get; set; }

    public virtual PaymentRecieptSheet PayRciptSheetU { get; set; }

    public virtual Purchase PurchU { get; set; }
}
