using System;
using System.Collections.Generic;

namespace Domain.SaleInModels;

public partial class PhoneBook
{
    public Guid PhbUid { get; set; }

    public Guid? CityUid { get; set; }

    public string PhbName { get; set; }

    public DateTime? PhbBrithday { get; set; }

    public string PhbNationalCode { get; set; }

    public string PhbEconomicCode { get; set; }

    public string PhbNationalId { get; set; }

    public string PhbPostalCode { get; set; }

    public string PhbPhone1 { get; set; }

    public string PhbPhone2 { get; set; }

    public string PhbMobile { get; set; }

    public string PhbAddress { get; set; }

    public string PhbDescribtion { get; set; }

    public bool? PhbStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public string PhbFatherName { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual City CityU { get; set; }
}
