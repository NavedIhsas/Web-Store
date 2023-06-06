using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class InvoiceDetails2
{
    public Guid InvDetUid { get; set; }

    public Guid? InvUid { get; set; }

    public Guid? WarHosUid { get; set; }

    public Guid? PrdUid { get; set; }

    public Guid? UomUid { get; set; }

    public double? InvDetQuantity { get; set; }

    public decimal? InvDetPricePerUnit { get; set; }

    public decimal? InvDetDiscount { get; set; }

    public decimal? InvDetTax { get; set; }

    public decimal? InvDetTotalAmount { get; set; }

    public string InvDetDescribtion { get; set; }

    public bool? InvDetStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public double? InvDetPercentDiscount { get; set; }

    public double? InvDetTaxValue { get; set; }

    public decimal? InvDetPricePerUnitExchange { get; set; }

    public decimal? InvDetPriceExchange { get; set; }

    public Guid? InvDetParentUid { get; set; }

    public int? InvDetPayment { get; set; }

    public decimal? InvDetDiscountExchange { get; set; }

    public decimal? InvDetTotalExchange { get; set; }

    public int? InvDetRowOrder { get; set; }

    public int? InvDetRowGroup { get; set; }

    public int? InvDetPrint { get; set; }

    public Guid? ServiceunitUid { get; set; }

    public double? InvDetShareDiscountPer { get; set; }

    public Guid? InvDetRetRefrence { get; set; }

    public double? InvDetQuantity2 { get; set; }
}
