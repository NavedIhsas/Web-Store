using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class DefualtAccountDefinition
{
    public Guid DftAccDfinUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public Guid? AccUid { get; set; }

    public Guid? SalCatUid { get; set; }

    public string DftAccDfinName { get; set; }

    public bool? DftAccDfinIsUsedInPaymentSheet { get; set; }

    public bool? DftAccDfinIsUsedInRecieptSheet { get; set; }

    public bool? DftAccDfinIsUsedInDocuments { get; set; }

    public bool? DftAccDfinIsUsedInCheque { get; set; }

    public bool? DftAccDfinStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual Account AccU { get; set; }

    public virtual ICollection<ChequSheetStatus> ChequSheetStatuses { get; set; } = new List<ChequSheetStatus>();

    public virtual ICollection<DocumentDetail> DocumentDetails { get; set; } = new List<DocumentDetail>();

    public virtual SalesCategory SalCatU { get; set; }
}
