using System;
using System.Collections.Generic;

namespace persistent.Models;

public partial class SerialDetail
{
    public Guid SerDetUid { get; set; }

    public Guid? SerUid { get; set; }

    public Guid? InvDetUid { get; set; }

    public Guid? PurchDetUid { get; set; }

    public string SerDetNumber { get; set; }

    public int? SerDetState { get; set; }

    public bool? SerDetStatus { get; set; }

    public int? SerDetSync { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual InvoiceDetail InvDetU { get; set; }

    public virtual PurchaseDetail PurchDetU { get; set; }
}
