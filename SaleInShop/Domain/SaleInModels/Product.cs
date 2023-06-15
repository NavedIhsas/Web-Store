namespace Domain.SaleInModels;

public class Product
{
    public Guid PrdUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public Guid? TaxUid { get; set; }

    public Guid? PrdLvlUid1 { get; set; }

    public Guid? PrdLvlUid2 { get; set; }

    public Guid? PrdLvlUid3 { get; set; }

    public Guid? UomUid1 { get; set; }

    public Guid? UomUid2 { get; set; }

    public string PrdName { get; set; }

    public string PrdCode { get; set; }

    public string PrdBarcode { get; set; }

    public string PrdIranCode { get; set; }

    public decimal? PrdCoefficient { get; set; }

    public decimal? PrdPricePerUnit1 { get; set; }

    public decimal? PrdPricePerUnit2 { get; set; }

    public long? PrdMinQuantityOnHand { get; set; }

    public long? PrdMaxQuantityOnHand { get; set; }

    public string PrdTechnicalDescription { get; set; }

    public bool? PrdTax { get; set; }

    public bool? PrdStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public int PrdUniqid { get; set; }

    public int? PrdTarazoId { get; set; }

    public int? PrdMemory { get; set; }

    public int? PrdMemory2 { get; set; }

    public string PrdUnit { get; set; }

    public string PrdUnit2 { get; set; }

    public double? PrdPercentDiscount { get; set; }

    public Guid? PrdWareHouse { get; set; }

    public decimal? PrdTaxValue { get; set; }

    public decimal? PrdPricePerUnitExchange { get; set; }

    public decimal? PrdPricePerUnit3 { get; set; }

    public decimal? PrdPricePerUnit4 { get; set; }

    public decimal? PrdPricePerUnit5 { get; set; }

    public double? PrdRemain { get; set; }

    public string PrdImage { get; set; }

    public bool? PrdNameShow { get; set; }

    public bool? PrdImageShow { get; set; }

    public string PrdNameInPrint { get; set; }

    public string PrdLatinName { get; set; }

    public int? PrdMaxSale { get; set; }

    public long? PrdStamp { get; set; }

    public int? PrdSerial { get; set; }

    public bool? PrdNameInPrintTouchActive { get; set; }

    public bool? PrdStatusApp { get; set; }

    public int? PrdDiscountType { get; set; }

    public decimal? PrdDiscount { get; set; }

    public decimal? PrdCoefficient2 { get; set; }

    public bool? PrdPriceInPrint { get; set; }

    public bool? PrdIsUnit1Bigger { get; set; }

    public string PrdSalegroupid { get; set; }

    public virtual ICollection<Barcode> Barcodes { get; set; } = new List<Barcode>();

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ProductLevel PrdLvlUid3Navigation { get; set; }

    public virtual ICollection<ProductQuantityOnHand> ProductQuantityOnHands { get; set; } =
        new List<ProductQuantityOnHand>();

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();

    public virtual ICollection<QuoteDetail> QuoteDetails { get; set; } = new List<QuoteDetail>();

    public virtual ICollection<StockTransferDetail> StockTransferDetails { get; set; } =
        new List<StockTransferDetail>();

    public virtual ICollection<SystemGame> SystemGames { get; set; } = new List<SystemGame>();

    public virtual Tax TaxU { get; set; }

    public virtual UnitOfMeasurement UomUid1Navigation { get; set; }

    public virtual UnitOfMeasurement UomUid2Navigation { get; set; }

    public virtual ICollection<WarehouseRecieptDetail> WarehouseRecieptDetails { get; set; } =
        new List<WarehouseRecieptDetail>();
}