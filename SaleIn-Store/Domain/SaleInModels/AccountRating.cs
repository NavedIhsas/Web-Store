using System;
using System.Collections.Generic;

namespace Domain.SaleInModels;

public partial class AccountRating
{
    public Guid AccRateUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public string AccRateName { get; set; }

    public int? AccRatePriority { get; set; }

    public bool? AccRateStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public long? AccRateStartScore { get; set; }

    public long? AccRateEndScore { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual BusinessUnit BusUnitU { get; set; }
}
