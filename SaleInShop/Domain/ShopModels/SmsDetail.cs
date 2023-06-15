namespace Domain.ShopModels;

public class SmsDetail
{
    public Guid SmsDetUid { get; set; }

    public Guid? SmsHedUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public int? SmsDetMessageType { get; set; }

    public string SmsDetMessage { get; set; }

    public bool? SmsDetNewline { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public Guid? FldUid { get; set; }

    public virtual SmsHeader SmsHedU { get; set; }
}