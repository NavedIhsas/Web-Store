using Microsoft.EntityFrameworkCore;

namespace Domain.StoredProcedure
{
    [Keyless]
    public class SpPreInvoiceList
    {
        public Guid InvDetailsId { get; set; }
        public string InvNumber { get; set; }
        public DateTime? InvDate { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public double? TotalAmount { get; set; }
        public double RemainValue { get; set; }
        public double SumQuantityUse { get; set; }
        public string PrdLvlName { get; set; }
        public decimal? Price1 { get; set; }
        public Guid ProductLevelId { get; set; }
        public double Quantity { get; set; }
        public decimal? TaxTaxesValues { get; set; }
        public decimal? TaxValue { get; set; }
    }
}
