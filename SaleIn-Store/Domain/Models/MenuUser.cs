using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class MenuUser
{
    public Guid MnuUsrUid { get; set; }

    public Guid? SysUsrUid { get; set; }

    public Guid? MnuUid { get; set; }

    public virtual Menu MnuU { get; set; }

    public virtual SystemUser SysUsrU { get; set; }
}
