using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class ProductLevel
{
    public Guid PrdLvlUid { get; set; }

    public Guid? PrdLvlParentUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public string PrdLvlName { get; set; }

    public string PrdLvlCode { get; set; }

    public bool? PrdLvlStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public int? PrdLvlTouchKeyNumber { get; set; }

    public bool? PrdLvlBooth { get; set; }

    public int? PrdLvlCustomTab { get; set; }

    public int? PrdLvlCustomButton { get; set; }

    public string PrdLvlPrinter { get; set; }

    public int? PrdLvlExpButton { get; set; }

    public bool? PrdLvlAllowPrinter2 { get; set; }

    public int? PrdLvlType { get; set; }

    public virtual FiscalPeriod FisPeriodU { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
