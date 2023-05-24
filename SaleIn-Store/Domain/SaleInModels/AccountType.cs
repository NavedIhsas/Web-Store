using System;
using System.Collections.Generic;

namespace Domain.SaleInModels;

public partial class AccountType
{
    public Guid AccTypUid { get; set; }

    public string AccTypName { get; set; }

    public bool? AccTypStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
