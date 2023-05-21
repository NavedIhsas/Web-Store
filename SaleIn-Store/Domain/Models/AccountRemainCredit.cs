using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class AccountRemainCredit
{
    public Guid AccRemCrtUid { get; set; }

    public Guid? AccUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public decimal? AccRemCrtRemainCredit { get; set; }

    public bool? AccRemCrtStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual Account AccU { get; set; }
}
