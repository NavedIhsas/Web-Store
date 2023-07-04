using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class CalenderDetail
{
    public Guid CdId { get; set; }

    public Guid CdFrCalender { get; set; }

    public Guid CdFrProduct { get; set; }

    public Guid CdFrAccountclub { get; set; }

    public int CdStartTime { get; set; }

    public int CdEndTime { get; set; }

    public long? CdFrCsp { get; set; }

    public decimal? CdPersonelCommission { get; set; }

    public decimal? CdPersonelPayment { get; set; }

    public virtual AccountClub CdFrAccountclubNavigation { get; set; }

    public virtual Calender CdFrCalenderNavigation { get; set; }

    public virtual ContinuouseServicesPlaning CdFrCspNavigation { get; set; }

    public virtual Product CdFrProductNavigation { get; set; }

    public virtual ICollection<InOut> InOuts { get; set; } = new List<InOut>();
}
