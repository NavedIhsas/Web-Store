using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class ClassProperty
{
    public Guid ClsPrpUid { get; set; }

    public string ClsPrpName { get; set; }

    public string ClsPrpCode { get; set; }

    public int? ClsPrpLengthDetailCode { get; set; }

    public string ClsPrpDescription { get; set; }

    public int? ClsPrpStatus { get; set; }

    public bool? ClsPrpEnable { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }
}
