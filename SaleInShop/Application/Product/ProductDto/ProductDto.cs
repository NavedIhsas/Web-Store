namespace Application.Product.ProductDto;

public class ProductDto
{
    public Guid PrdUid { get; set; }
    public Guid AccClubTypeId { get; set; }
    public int PriceLevel { get; set; }
    public Guid InvoiceDetailsId { get; set; }
    public string PrdName { get; set; }
    public string PrdCode { get; set; }
    public string PrdLevelId { get; set; }
    public string PrdImage { get; set; }
    public Guid PrdLvlUId { get; set; }
    public bool? PrdStatus { get; set; }
    public decimal PrdPricePerUnit1 { get; set; }
    public decimal? Price { get; set; }
    public string TaxName { get; set; }
    public decimal? TaxValue { get; set; }
    public string PrdLvlName { get; set; }
    public double Remain { get; set; }
    public byte[] Image64 { get; set; }
    public string Unit1 { get; set; }
    public string Unit2 { get; set; }
    public string Weight { get; set; }
    public string Volume { get; set; }
    public string IranCode { get; set; }
    public string BarCode { get; set; }
    public decimal DiscountPercent { get; set; }
    public decimal DiscountSaveToDb { get; set; }
    public double InvoiceDiscount { get; set; }
    public double InvoiceDiscountPercent { get; set; }
    public bool? ShareDiscount { get; set; }
    public decimal TotalPaidAmount { get; set; }
    public double SumQuantityUse { get; set; }
    public double? Quantity { get; set; }
}