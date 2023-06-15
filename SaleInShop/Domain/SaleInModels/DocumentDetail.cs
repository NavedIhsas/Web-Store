namespace Domain.SaleInModels;

public class DocumentDetail
{
    public Guid DocDetUid { get; set; }

    public Guid? AccUid { get; set; }

    public Guid? DocUid { get; set; }

    public Guid? RgdObjUid { get; set; }

    public Guid? DocDetRgdUid { get; set; }

    public Guid? CstCtrUid { get; set; }

    public decimal? DocDetLiabilityAmount { get; set; }

    public decimal? DocDetCreditoryAmount { get; set; }

    public string DocDetDescription { get; set; }

    public bool? DocDetStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public Guid? DftAccDfinUid { get; set; }

    public virtual Account AccU { get; set; }

    public virtual CostCenter CstCtrU { get; set; }

    public virtual DefualtAccountDefinition DftAccDfinU { get; set; }

    public virtual Document DocU { get; set; }

    public virtual RegardingObject RgdObjU { get; set; }
}