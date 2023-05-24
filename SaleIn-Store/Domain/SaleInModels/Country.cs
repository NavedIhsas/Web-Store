using System;
using System.Collections.Generic;

namespace Domain.SaleInModels;

public partial class Country
{
    public Guid CntUid { get; set; }

    public string CntName { get; set; }

    public bool? CntStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }
}
