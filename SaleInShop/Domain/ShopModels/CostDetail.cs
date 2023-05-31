
using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class CostDetail
{
    public Guid CstDetUid { get; set; }

    public Guid? CstUid { get; set; }

    public Guid? CstDetAccUid { get; set; }

    public Guid? AccUid { get; set; }

    public decimal? CstDetCost { get; set; }

    public bool? CstDetStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual Account AccU { get; set; }

    public virtual Account CstDetAccU { get; set; }

    public virtual Cost CstU { get; set; }
}
