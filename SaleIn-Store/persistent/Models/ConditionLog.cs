using System;
using System.Collections.Generic;

namespace persistent.Models;

public partial class ConditionLog
{
    public Guid LogUid { get; set; }

    public Guid? InvUid { get; set; }

    public Guid? AccUid { get; set; }

    public Guid? ConUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public decimal? InvExtendedAmount { get; set; }

    public decimal? ConLogCreditAmount { get; set; }

    public int? ConLogScoreAmount { get; set; }

    public bool? ConLogStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public Guid? AccClbUid { get; set; }

    public decimal? CurrencyAmount { get; set; }

    public decimal? ExchRatePrice { get; set; }

    public string FollowupId { get; set; }

    public Guid? BankUid { get; set; }

    public Guid? AccClbPayerUid { get; set; }

    public Guid? ExchRateUid { get; set; }

    public int? PayRciptDetType { get; set; }

    public virtual Condition ConU { get; set; }

    public virtual Invoice InvU { get; set; }
}
