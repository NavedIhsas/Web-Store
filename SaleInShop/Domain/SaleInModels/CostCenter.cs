namespace Domain.SaleInModels;

public class CostCenter
{
    public Guid CstCtrUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public string CstCtrName { get; set; }

    public string CstCtrCode { get; set; }

    public decimal? CstCtrRemainCredit { get; set; }

    public bool? CstCtrStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual ICollection<DocumentDetail> DocumentDetails { get; set; } = new List<DocumentDetail>();

    public virtual FiscalPeriod FisPeriodU { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}