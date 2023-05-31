using System;
using System.Collections.Generic;

namespace Domain.SaleInModels;

public partial class ChequSheet
{
    public Guid CheqSheetUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public Guid? CheqUid { get; set; }

    public Guid? AccUidType { get; set; }

    public Guid? AccUid { get; set; }

    public Guid? AccUidRelated { get; set; }

    public Guid? BankUid { get; set; }

    public string CheqSheetNo { get; set; }

    public string CheqAccNo { get; set; }

    public DateTime? CheqFctDate { get; set; }

    public string CheqAssignment { get; set; }

    public decimal? CheqSheetAmount { get; set; }

    public string CheqSheetDescription { get; set; }

    public DateTime? CheqSheetDueDate { get; set; }

    public bool? ChequeSheetStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public DateTime? CheqSheetReceivedDate { get; set; }

    public string CheqSheetSayadNumber { get; set; }

    public virtual Account AccU { get; set; }

    public virtual Bank BankU { get; set; }

    public virtual Chequ CheqU { get; set; }

    public virtual ICollection<ChequSheetStatus> ChequSheetStatuses { get; set; } = new List<ChequSheetStatus>();

    public virtual FiscalPeriod FisPeriodU { get; set; }
}
