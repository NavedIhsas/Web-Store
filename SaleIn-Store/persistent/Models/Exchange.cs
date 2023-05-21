using System;
using System.Collections.Generic;

namespace persistent.Models;

public partial class Exchange
{
    public Guid ExchUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public string ExchNumber { get; set; }

    public DateTime? ExchDate { get; set; }

    public Guid? AccClbUid { get; set; }

    public Guid? AccClbParentUid { get; set; }

    public bool? ExchSync { get; set; }

    public bool? ExchStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public int? ExchPrintCount { get; set; }

    public virtual ICollection<ExchangeDetail> ExchangeDetails { get; set; } = new List<ExchangeDetail>();
}
