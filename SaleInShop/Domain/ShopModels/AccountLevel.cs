namespace Domain.ShopModels;

public class AccountLevel
{
    public Guid AccLvlUid { get; set; }

    public Guid? AccLvlParentUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public string AccLvlName { get; set; }

    public string AccLvlCode { get; set; }

    public bool? AccLvlStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public Guid? AccLvlFrGuid { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual FiscalPeriod FisPeriodU { get; set; }
}