using System;
using System.Collections.Generic;

namespace Domain.SaleInModels;

public partial class ChequeSheet
{
    public Guid CheqSheetUid { get; set; }

    public Guid? AgtUid { get; set; }

    public string CheqSheetNumber { get; set; }

    public DateTime? CheqSheetDueDate { get; set; }

    public decimal? CheqSheetAmount { get; set; }

    public string CheqSheetBankName { get; set; }

    public string CheqSheetBankBranch { get; set; }

    public string CheqSheetBankCode { get; set; }

    public string CheqSheetDescribtion { get; set; }

    public bool? CheqSheetStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual Agreement AgtU { get; set; }
}
