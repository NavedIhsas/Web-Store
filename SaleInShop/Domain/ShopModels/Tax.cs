namespace Domain.ShopModels;

public class Tax
{
    public Guid TaxUid { get; set; }

    public Guid? TaxAccUid { get; set; }

    public Guid? TaxTaxesAccUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public string TaxName { get; set; }

    public string TaxCode { get; set; }

    public decimal? TaxValue { get; set; }

    public decimal? TaxTaxesValue { get; set; }

    public bool? TaxStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual ICollection<Agreement> Agreements { get; set; } = new List<Agreement>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual Account TaxAccU { get; set; }

    public virtual Account TaxTaxesAccU { get; set; }
}