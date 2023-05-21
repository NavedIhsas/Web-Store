using System;
using System.Collections.Generic;

namespace persistent.Models;

public partial class WarehouseRecieptDetail
{
    public Guid WarHosRecDetUid { get; set; }

    public Guid? WarHosRecUid { get; set; }

    public Guid? WarHosUid { get; set; }

    public Guid? PrdUid { get; set; }

    public Guid? UomUid { get; set; }

    public double? WarHosRecDetQuantity { get; set; }

    public decimal? WarHosRecDetPricePerUnit { get; set; }

    public decimal? WarHosRecDetDiscount { get; set; }

    public decimal? WarHosRecDetTax { get; set; }

    public decimal? WarHosRecDetTotalAmount { get; set; }

    public string WarHosRecDetDescribtion { get; set; }

    public bool? WarHosRecDetStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual Product PrdU { get; set; }

    public virtual UnitOfMeasurement UomU { get; set; }

    public virtual WareHouse WarHosU { get; set; }
}
