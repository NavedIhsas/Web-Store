using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Barcode
{
    public Guid BarUid { get; set; }

    public Guid? PrdUid { get; set; }

    public string BarBarcode { get; set; }

    public bool? BarStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual Product PrdU { get; set; }
}
