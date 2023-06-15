namespace Domain.SaleInModels;

public class AtelierCategory
{
    public Guid AtlCatUid { get; set; }

    public string AtlCatName { get; set; }

    public string AtlCatCode { get; set; }

    public bool? AtlCatStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }
}