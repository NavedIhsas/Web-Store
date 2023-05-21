using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class AccountClubType
{
    public Guid AccClbTypUid { get; set; }

    public string AccClbTypName { get; set; }

    public bool? AccClbTypStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public int? AccClbTypDefaultPriceInvoice { get; set; }

    public double? AccClbTypPercentDiscount { get; set; }

    public int? AccClbTypDiscountType { get; set; }

    public double? AccClbTypDetDiscount { get; set; }
}
