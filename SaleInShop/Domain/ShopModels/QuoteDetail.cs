namespace Domain.ShopModels;

public class QuoteDetail
{
    public Guid QutDetUid { get; set; }

    public Guid? QutUid { get; set; }

    public Guid? WarHosUid { get; set; }

    public Guid? PrdUid { get; set; }

    public Guid? UomUid { get; set; }

    public double? QutDetQuantity { get; set; }

    public decimal? QutDetPricePerUnit { get; set; }

    public decimal? QutDetDiscount { get; set; }

    public decimal? QutDetTax { get; set; }

    public decimal? QutDetTotalAmount { get; set; }

    public string QutDetDescribtion { get; set; }

    public bool? QutDetStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual Product PrdU { get; set; }

    public virtual Quote QutU { get; set; }

    public virtual UnitOfMeasurement UomU { get; set; }

    public virtual WareHouse WarHosU { get; set; }
}