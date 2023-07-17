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
        public decimal? TotalAmount { get; set; }
        public decimal? RemainAmount { get; set; }
        public string PrdLvlName { get; set; }
        public decimal? Price1 { get; set; }
        public Guid ProductLevelId { get; set; }
        public double Quantity { get; set; }
        public decimal? TaxTaxesValues { get; set; }
        public decimal? TaxValue { get; set; }
    }
}
