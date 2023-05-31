
using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class Document
{
    public Guid DocUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public Guid? RgdObjUid { get; set; }

    public Guid? DocRgdUid { get; set; }

    public string DocNumber { get; set; }

    public DateTime? DocDate { get; set; }

    public string DocReference { get; set; }

    public string DocDescription { get; set; }

    public bool? DocCheck { get; set; }

    public bool? DocStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual ICollection<DocumentDetail> DocumentDetails { get; set; } = new List<DocumentDetail>();

    public virtual RegardingObject RgdObjU { get; set; }
}
