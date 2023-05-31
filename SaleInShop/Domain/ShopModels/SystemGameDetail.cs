using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class SystemGameDetail
{
    public Guid SysDetUid { get; set; }

    public Guid? SysUid { get; set; }

    public Guid? InvDetUid { get; set; }

    public DateTime? SysDetStartTime { get; set; }

    public DateTime? SysDetEndTime { get; set; }

    public bool? SysDetOnline { get; set; }

    public int? SysDetGamepad { get; set; }

    public bool? SysDetStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public Guid? InvUid { get; set; }

    public bool? SysDetActive { get; set; }
}
