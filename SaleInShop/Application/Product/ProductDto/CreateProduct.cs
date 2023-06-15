using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.Product.ProductDto
{
    public class CreateProduct
    {
        public Guid PrdUid { get; set; }

        public Guid? TaxUid { get; set; }

        [BindRequired] public Guid PrdLvlUid3 { get; set; }

        public string PrdName { get; set; }

        public string PrdCode { get; set; }

        public string PrdBarcode { get; set; }

        public string PrdIranCode { get; set; }

        public decimal? PrdCoefficient { get; set; }

        public decimal? PrdPricePerUnit1 { get; set; }

        public decimal? PrdPricePerUnit2 { get; set; }

        public long? PrdMinQuantityOnHand { get; set; }

        public long? PrdMaxQuantityOnHand { get; set; }

        public Guid? PrdWareHouse { get; set; }

        public decimal? PrdPricePerUnit3 { get; set; }

        public decimal? PrdPricePerUnit4 { get; set; }

        public decimal? PrdPricePerUnit5 { get; set; }

        public string PrdImage { get; set; }
        public byte[] Image { get; set; }

        public string PrdNameInPrint { get; set; }

        public int? PrdDiscountType { get; set; }

        public decimal? PrdDiscount { get; set; }

        public string ShortDescription { get; set; }
        public string WebDescription { get; set; }
        public int? PrdLvlType { get; set; }
        public string Volume { get; set; }
        public string Weight { get; set; }
        public bool? PrdIsUnit1Bigger { get; set; }
        public int Type { get; set; }

        public List<IFormFile> Files { get; set; } = new();
        public IFormFile Images { get; set; }

        [BindRequired] public Guid? FkProductUnit { get; set; }

        public Guid? FkProductUnit2 { get; set; }
    }
}
