namespace Domain.SaleInModels;

public class OrderType
{
    public Guid OrdTypUid { get; set; }

    public string OrdTypName { get; set; }

    public byte? OrdTypCode { get; set; }

    public int? OrdTypPriority { get; set; }

    public byte? OrdTypType { get; set; }

    public bool? OrdTypStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public string OrdTypColor { get; set; }

    public string OrdTypFile { get; set; }

    public string OrdTypFile2 { get; set; }
}