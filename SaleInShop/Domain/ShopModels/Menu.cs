using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class Menu
{
    public Guid MnuUid { get; set; }

    public Guid? MnuParentUid { get; set; }

    public string MnuName { get; set; }

    public string MnuPeriority { get; set; }

    public bool? MnuStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual ICollection<MenuUser> MenuUsers { get; set; } = new List<MenuUser>();
}
