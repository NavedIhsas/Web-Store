using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class ProductSubset
{
    public Guid PrdSubUid { get; set; }

    public Guid? PrdParentUid { get; set; }

    public Guid? PrdUid { get; set; }

    public bool? PrdSubStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public double? PrdSubQuantity { get; set; }
}
