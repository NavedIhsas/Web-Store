namespace Domain.ShopModels;

public class Language
{
    public Guid LangUid { get; set; }

    public string LangPersianName { get; set; }

    public string LangEnglishName { get; set; }

    public string LangCode { get; set; }

    public bool? LangStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual ICollection<BusinessUnit> BusinessUnits { get; set; } = new List<BusinessUnit>();
}