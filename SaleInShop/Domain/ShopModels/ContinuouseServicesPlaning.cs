using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class ContinuouseServicesPlaning
{
    public long CspUid { get; set; }

    public Guid CspFrProduct { get; set; }

    public Guid CspFrAccountclub { get; set; }

    public bool CspGenedr { get; set; }

    public int CspStartTime { get; set; }

    public int CspEndTime { get; set; }

    public short CspNumOfSessions { get; set; }

    public DateTime CspStartDate { get; set; }

    public short CspDayPlan { get; set; }

    public int? CspCapacity { get; set; }

    public virtual ICollection<CalenderDetail> CalenderDetails { get; set; } = new List<CalenderDetail>();

    public virtual AccountClub CspFrAccountclubNavigation { get; set; }

    public virtual Product CspFrProductNavigation { get; set; }

    public virtual ICollection<InOut> InOuts { get; set; } = new List<InOut>();

    public virtual ICollection<ServiceTransaction> ServiceTransactions { get; set; } = new List<ServiceTransaction>();
}
