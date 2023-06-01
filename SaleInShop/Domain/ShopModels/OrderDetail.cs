using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class OrderDetail
{
    public Guid OrdDetUid { get; set; }

    public Guid? OrdUid { get; set; }

    public Guid? WarHosUid { get; set; }

    public Guid? PrdUid { get; set; }

    public Guid? UomUid { get; set; }

    public double? OrdDetQuantity { get; set; }

    public decimal? OrdDetPricePerUnit { get; set; }

    public decimal? OrdDetDiscount { get; set; }

    public decimal? OrdDetTax { get; set; }

    public decimal? OrdDetTotalAmount { get; set; }

    public string OrdDetDescribtion { get; set; }

    public bool? OrdDetStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual Order OrdU { get; set; }

    public virtual Product PrdU { get; set; }

    public virtual UnitOfMeasurement UomU { get; set; }

    public virtual WareHouse WarHosU { get; set; }
}
