using System;
using System.Collections.Generic;

namespace Domain.SaleInModels;

public partial class SystemUser
{
    public Guid SysUsrUid { get; set; }

    public Guid? SysUsrParentUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public string SysUsrFirstName { get; set; }

    public string SysUsrLastName { get; set; }

    public string SysUsrCode { get; set; }

    public string SysUsrUsername { get; set; }

    public string SysUsrPassword { get; set; }

    public string SysUsrPhone { get; set; }

    public string SysUsrMobile { get; set; }

    public string SysUsrEmail { get; set; }

    public string SysUsrWesite { get; set; }

    public bool? SysUsrStatus { get; set; }

    public bool? SysUsrIsVisible { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public Guid? RolUid { get; set; }

    public string SysUsrBackgroundImage { get; set; }

    public string SysUsrForecolor { get; set; }

    public Guid? AccUid { get; set; }

    public virtual ICollection<MenuUser> MenuUsers { get; set; } = new List<MenuUser>();

    public virtual Role RolU { get; set; }
}
