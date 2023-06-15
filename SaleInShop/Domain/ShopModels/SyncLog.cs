namespace Domain.ShopModels;

public class SyncLog
{
    public Guid SynUid { get; set; }

    public string SynSuccessful { get; set; }

    public string SynUnsuccessful { get; set; }

    /// <summary>
    ///     [1-kala][2-hesab][3-moshtari][4-factor][5-karbar]
    /// </summary>
    public int? SynType { get; set; }

    public DateTime SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }
}