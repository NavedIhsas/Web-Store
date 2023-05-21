using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class RelatedPersonnel
{
    public Guid RelPrsUid { get; set; }

    public Guid? InvUid { get; set; }

    public Guid? PrsUid { get; set; }

    public bool? RelPrsStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual Invoice InvU { get; set; }

    public virtual Personnel PrsU { get; set; }
}
