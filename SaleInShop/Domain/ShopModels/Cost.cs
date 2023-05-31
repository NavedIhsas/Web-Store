using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class Cost
{
    public Guid CstUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public Guid? RgdObjUid { get; set; }

    public Guid? CstRgdUid { get; set; }

    public string CstNumber { get; set; }

    public decimal? CstTotalAmount { get; set; }

    public DateTime? CstDate { get; set; }

    public string CstDescribtion { get; set; }

    public bool? CstStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual ICollection<CostDetail> CostDetails { get; set; } = new List<CostDetail>();

    public virtual FiscalPeriod FisPeriodU { get; set; }

    public virtual RegardingObject RgdObjU { get; set; }
}
