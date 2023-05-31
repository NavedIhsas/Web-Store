using System;
using System.Collections.Generic;

namespace Domain.SaleInModels;

public partial class StockTransferDetail
{
    public Guid StkTrnsDetUid { get; set; }

    public Guid? StkTrnsUid { get; set; }

    public Guid? WarHosUid { get; set; }

    public Guid? PrdUid { get; set; }

    public Guid? UomUid { get; set; }

    public double? StkTrnsDetQuantity { get; set; }

    public decimal? StkTrnsDetPricePerUnit { get; set; }

    public decimal? StkTrnsDetDiscount { get; set; }

    public decimal? StkTrnsDetTax { get; set; }

    public decimal? StkTrnsDetTotalAmount { get; set; }

    public string StkTrnsDetDescribtion { get; set; }

    public bool? StkTrnsDetStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual Product PrdU { get; set; }

    public virtual StockTransfer StkTrnsU { get; set; }

    public virtual UnitOfMeasurement UomU { get; set; }

    public virtual WareHouse WarHosU { get; set; }
}
