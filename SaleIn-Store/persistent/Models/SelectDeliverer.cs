using System;
using System.Collections.Generic;

namespace persistent.Models;

public partial class SelectDeliverer
{
    public Guid SlcPrsUid { get; set; }

    public Guid? PrsUid { get; set; }

    public Guid? InvUid { get; set; }

    public int? SlcPrsDeliver { get; set; }

    public bool? SlcPrsStatus { get; set; }

    public bool? SlcPrsActive { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public bool? SlcPrsSendSms { get; set; }
}
