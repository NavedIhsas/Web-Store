namespace Domain.ShopModels;

public class UnitOfMeasurement
{
    public Guid UomUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public string UomName { get; set; }

    public string UomCode { get; set; }

    public bool? UomStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual BusinessUnit BusUnitU { get; set; }

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Product> ProductFkProductUnit2Navigations { get; set; } = new List<Product>();

    public virtual ICollection<Product> ProductFkProductUnitNavigations { get; set; } = new List<Product>();

    public virtual ICollection<Product> ProductUomUid1Navigations { get; set; } = new List<Product>();

    public virtual ICollection<Product> ProductUomUid2Navigations { get; set; } = new List<Product>();

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();

    public virtual ICollection<QuoteDetail> QuoteDetails { get; set; } = new List<QuoteDetail>();

    public virtual ICollection<StockTransferDetail> StockTransferDetails { get; set; } =
        new List<StockTransferDetail>();

    public virtual ICollection<WarehouseRecieptDetail> WarehouseRecieptDetails { get; set; } =
        new List<WarehouseRecieptDetail>();
}