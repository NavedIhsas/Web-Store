using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ExchangeDetail
{
    public Guid ExchDetUid { get; set; }

    public Guid? ExchUid { get; set; }

    public Guid? ExchRateFromUid { get; set; }

    public decimal? ExchDetFromAmount { get; set; }

    public decimal? ExchDetFromBasePrice { get; set; }

    public Guid? ExchRateToUid { get; set; }

    public decimal? ExchDetToAmount { get; set; }

    public decimal? ExchDetToBasePrice { get; set; }

    public bool? ExchDetStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual Exchange ExchU { get; set; }
}
