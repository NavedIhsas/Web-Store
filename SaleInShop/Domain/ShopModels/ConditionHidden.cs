namespace Domain.ShopModels;

public class ConditionHidden
{
    public Guid ConditionHiddenUid { get; set; }

    public DateTime? ConditionHiddenFromDate { get; set; }

    public DateTime? ConditionHiddenToDate { get; set; }

    public int? ConditionHiddenCount { get; set; }

    public decimal? ConditionHiddenAmount { get; set; }

    public bool? ConditionHiddenAccept { get; set; }

    public bool? ConditionHiddenStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }
}