using System;
using System.Collections.Generic;

namespace persistent.Models;

public partial class ProductQuantityOnHand
{
    public Guid PrdQuanHndUid { get; set; }

    public Guid? PrdQuanUid { get; set; }

    public Guid? WarHosUid { get; set; }

    public Guid? PrdUid { get; set; }

    public double? PrdQuanHndQuantityOnHand { get; set; }

    public decimal? PrdQuanHndPrice { get; set; }

    public int? PrdQuanHndType { get; set; }

    public bool? PrdQuanHndStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual ProductQuantity PrdQuanU { get; set; }

    public virtual Product PrdU { get; set; }

    public virtual WareHouse WarHosU { get; set; }
}
