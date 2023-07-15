using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class Bank
{
    public Guid BankUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public string BankName { get; set; }

    public string BankCode { get; set; }

    public bool? BankStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public Guid? AccUid { get; set; }

    public bool? BankActive { get; set; }

    public int Type { get; set; }

    public virtual ICollection<BankPose> BankPoses { get; set; } = new List<BankPose>();

    public virtual ICollection<ChequSheet> ChequSheets { get; set; } = new List<ChequSheet>();
}
