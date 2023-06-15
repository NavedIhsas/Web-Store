namespace Domain.ShopModels;

public class WareHouse
{
    public Guid WarHosUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public string WarHosName { get; set; }

    public string WarHosCode { get; set; }

    public bool? WarHosStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual FiscalPeriod FisPeriodU { get; set; }

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<ProductQuantityOnHand> ProductQuantityOnHands { get; set; } =
        new List<ProductQuantityOnHand>();

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();

    public virtual ICollection<QuoteDetail> QuoteDetails { get; set; } = new List<QuoteDetail>();

    public virtual ICollection<StockTransferDetail> StockTransferDetails { get; set; } =
        new List<StockTransferDetail>();

    public virtual ICollection<WarehouseRecieptDetail> WarehouseRecieptDetails { get; set; } =
        new List<WarehouseRecieptDetail>();
}