using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class SmsHeader
{
    public Guid SmsHedUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public string SmsHedName { get; set; }

    public bool? SmsHedStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual ICollection<SmsDetail> SmsDetails { get; set; } = new List<SmsDetail>();
}
