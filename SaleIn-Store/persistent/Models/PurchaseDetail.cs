using System;
using System.Collections.Generic;

namespace persistent.Models;

public partial class PurchaseDetail
{
    public Guid PurchDetUid { get; set; }

    public Guid? PurchUid { get; set; }

    public Guid? WarHosUid { get; set; }

    public Guid? PrdUid { get; set; }

    public Guid? UomUid { get; set; }

    public double? PurchDetQuantity { get; set; }

    public decimal? PurchDetPricePerUnit { get; set; }

    public decimal? PurchDetDiscount { get; set; }

    public decimal? PurchDetTax { get; set; }

    public decimal? PurchDetTotalAmount { get; set; }

    public string PurchDetDescribtion { get; set; }

    public bool? PurchDetStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public int? PurchDetRowOrder { get; set; }

    public virtual Product PrdU { get; set; }

    public virtual Purchase PurchU { get; set; }

    public virtual ICollection<SerialDetail> SerialDetails { get; set; } = new List<SerialDetail>();

    public virtual UnitOfMeasurement UomU { get; set; }

    public virtual WareHouse WarHosU { get; set; }
}
