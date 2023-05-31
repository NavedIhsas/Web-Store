using System;
using System.Collections.Generic;

namespace Domain.SaleInModels;

public partial class SystemGame
{
    public Guid SysUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public string SysNumber { get; set; }

    public DateTime? SysLastStartTime { get; set; }

    public DateTime? SysLastEndTime { get; set; }

    public int? SysAditionalNumber { get; set; }

    public bool? SysOnline { get; set; }

    public double? SysOnlinePercent { get; set; }

    public decimal? SysOnlinePrice { get; set; }

    public double? SysGamepadAditionalPercent { get; set; }

    public decimal? SysGamepadAditionalPrice { get; set; }

    public int? SysFromTime { get; set; }

    public double? SysFromTimePercent { get; set; }

    public decimal? SysFromTimePrice { get; set; }

    public Guid? PrdUid { get; set; }

    public bool? SysStatus { get; set; }

    public bool? SysActive { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public int? SysChairCount { get; set; }

    public Guid? AccClbUid { get; set; }

    public bool? SysReserve { get; set; }

    public virtual Product PrdU { get; set; }
}
