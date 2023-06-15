namespace Domain.SaleInModels;

public class Invoice
{
    public Guid InvUid { get; set; }

    public Guid? InvParentUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public Guid? SalCatUid { get; set; }

    public Guid? AccUid { get; set; }

    public Guid? OrdUid { get; set; }

    public Guid? QutUid { get; set; }

    public Guid? CstCtrUid { get; set; }

    public string InvNumber { get; set; }

    public decimal? InvTotalAmount { get; set; }

    public decimal? InvTotalDiscount { get; set; }

    public decimal? InvTotalTax { get; set; }

    public decimal? InvTotalCost { get; set; }

    public decimal? InvExtendedAmount { get; set; }

    public DateTime? InvDate { get; set; }

    public DateTime? InvDueDate { get; set; }

    public string InvReference { get; set; }

    public string InvDescribtion { get; set; }

    public bool? InvStatusControl { get; set; }

    public bool? InvStatus { get; set; }

    public bool? InvFinalStatusControl { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public string InvBarcode { get; set; }

    public int? InvSync { get; set; }

    public decimal? InvDetTotalDiscount { get; set; }

    public decimal? InvTotalAmountCrm { get; set; }

    public decimal? InvDetTotalDiscountCrm { get; set; }

    public Guid? WrkSttUid { get; set; }

    public bool? InvCharge { get; set; }

    public decimal? InvTotalExchange { get; set; }

    public decimal? InvDiscountExchange { get; set; }

    public decimal? InvExtendedExchange { get; set; }

    public Guid? InvApplicantUid { get; set; }

    public string InvStartTime { get; set; }

    public string InvEndTime { get; set; }

    public string InvDailyNumber { get; set; }

    public Guid? IncidentUid { get; set; }

    public bool? InvFormal { get; set; }

    public double? InvPercentDiscount { get; set; }

    public byte? InvTypeOrder { get; set; }

    public Guid? AccClbUid { get; set; }

    public decimal? InvDeposit { get; set; }

    public int? InvPaymentStatus { get; set; }

    public int? InvSection { get; set; }

    public string InvDueTime { get; set; }

    public byte? InvCurrency { get; set; }

    public decimal? InvDiscount2 { get; set; }

    public int? InvDiscountType { get; set; }

    public string InvDefaultAddress { get; set; }

    public int? InvStep { get; set; }

    public virtual AccountClub AccClbU { get; set; }

    public virtual Account AccU { get; set; }

    public virtual ICollection<ConditionLog> ConditionLogs { get; set; } = new List<ConditionLog>();

    public virtual CostCenter CstCtrU { get; set; }

    public virtual FiscalPeriod FisPeriodU { get; set; }

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual Order OrdU { get; set; }

    public virtual ICollection<PaymentReceiptRelatedPurchaseInvoice>
        PaymentReceiptRelatedPurchaseInvoices { get; set; } = new List<PaymentReceiptRelatedPurchaseInvoice>();

    public virtual ICollection<PaymentRecieptSheet> PaymentRecieptSheets { get; set; } =
        new List<PaymentRecieptSheet>();

    public virtual Quote QutU { get; set; }

    public virtual ICollection<RelatedPersonnel> RelatedPersonnel { get; set; } = new List<RelatedPersonnel>();

    public virtual SalesCategory SalCatU { get; set; }
}