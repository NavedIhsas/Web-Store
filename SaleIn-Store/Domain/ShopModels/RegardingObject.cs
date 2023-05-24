using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class RegardingObject
{
    public Guid RgdObjUid { get; set; }

    public string RgdObjUidName { get; set; }

    public string RgdObjName { get; set; }

    public string RgdObjCode { get; set; }

    public bool? RgdObjStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual ICollection<Cost> Costs { get; set; } = new List<Cost>();

    public virtual ICollection<DocumentDetail> DocumentDetails { get; set; } = new List<DocumentDetail>();

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
}
