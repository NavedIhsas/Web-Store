namespace Application.Product.ProductDto;

public class ProductDetails
{
    public Guid PrdUid { get; set; }
    public string PrdName { get; set; }
    public int PrdMaxSale { get; set; }
    public decimal PrdDiscount { get; set; }
    public decimal PrdDiscountType { get; set; }
    public decimal PrdPricePerUnit2 { get; set; }
    public decimal PrdPricePerUnit3 { get; set; }
    public decimal PrdPricePerUnit4 { get; set; }
    public decimal PrdTaxValue { get; set; }
    public string Unit1 { get; set; }
    public string Unit2 { get; set; }
    public string Weight { get; set; }
    public string Volume { get; set; }
    public string IranCode { get; set; }
    public string BarCode { get; set; }
    public List<ProductPropertiesDto> Properties { get; set; }
    public List<ProductPicturesDto> Pictures { get; set; }
}