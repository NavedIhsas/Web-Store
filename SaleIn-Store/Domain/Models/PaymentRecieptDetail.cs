using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class PaymentRecieptDetail
{
    public Guid PayRciptDetUid { get; set; }

    public Guid? PayRciptSheetUid { get; set; }

    public Guid? AccUid { get; set; }

    public Guid? SalCatUid { get; set; }

    public decimal? PayRciptDetTotalAmount { get; set; }

    public string PayRciptDetDraft { get; set; }

    public string PayRciptDetDescribtion { get; set; }

    public bool? PayRciptDetStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    /// <summary>
    /// [1 - نقد]-[2 - کارت خوان]-[3 - بن]-[4 - باشگاه]-[5 - اعتباری]
    /// </summary>
    public int? PayRciptDetType { get; set; }

    public Guid? BankUid { get; set; }

    public int? PayRciptDetSync { get; set; }

    public Guid? CutomerClubDetailUid { get; set; }

    public Guid? ExchRateUid { get; set; }

    public decimal? ExchRatePrice { get; set; }

    public decimal? PayRciptDetTotalAmountEchange { get; set; }

    public Guid? PayRciptDetPayer { get; set; }

    public bool? PayRciptDetStatusControl { get; set; }

    public Guid? ExchUid { get; set; }

    public Guid? CheqSheetUid { get; set; }

    public virtual Account AccU { get; set; }

    public virtual PaymentRecieptSheet PayRciptSheetU { get; set; }

    public virtual SalesCategory SalCatU { get; set; }
}
