namespace Domain.ShopModels;

public class StockTransfer
{
    public Guid StkTrnsUid { get; set; }

    public Guid? StkTrnsParentUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public Guid? SalCatUid { get; set; }

    public Guid? AccUid { get; set; }

    public Guid? OrdUid { get; set; }

    public Guid? QutUid { get; set; }

    public Guid? CstCtrUid { get; set; }

    public string StkTrnsNumber { get; set; }

    public decimal? StkTrnsTotalAmount { get; set; }

    public decimal? StkTrnsTotalDiscount { get; set; }

    public decimal? StkTrnsTotalTax { get; set; }

    public decimal? StkTrnsTotalCost { get; set; }

    public decimal? StkTrnsExtendedAmount { get; set; }

    public DateTime? StkTrnsDate { get; set; }

    public DateTime? StkTrnsDueDate { get; set; }

    public string StkTrnsReference { get; set; }

    public string StkTrnsDescribtion { get; set; }

    public bool? StkTrnsStatusControl { get; set; }

    public bool? StkTrnsStatus { get; set; }

    public bool? StkTrnsFinalStatusControl { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual Account AccU { get; set; }

    public virtual ICollection<PaymentRecieptSheet> PaymentRecieptSheets { get; set; } =
        new List<PaymentRecieptSheet>();

    public virtual ICollection<StockTransferDetail> StockTransferDetails { get; set; } =
        new List<StockTransferDetail>();
}