namespace Domain.ShopModels;

public class ProductLevelAccess
{
    public Guid PrdLvlAcsUid { get; set; }

    public int? PrdLvlAcsSectionInt { get; set; }

    public Guid? PrdLvlAcsSectionUid { get; set; }

    public Guid? PrdLvlUid2 { get; set; }

    public int? PrdLvlAcsTabNumber { get; set; }

    public bool? PrdLvlAcsStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }
}