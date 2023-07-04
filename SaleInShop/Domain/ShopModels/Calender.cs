using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class Calender
{
    public Guid ClrId { get; set; }

    public DateTime ClrDate { get; set; }

    public long ClrFrSalon { get; set; }

    public int ClrFrShifts { get; set; }

    public Guid ClrFrContract { get; set; }

    public short ClrReserveType { get; set; }

    public Guid? ClrFrAccountclub { get; set; }

    public bool ClrGender { get; set; }

    public virtual ICollection<CalenderDetail> CalenderDetails { get; set; } = new List<CalenderDetail>();

    public virtual AccountClub ClrFrAccountclubNavigation { get; set; }

    public virtual Contract ClrFrContractNavigation { get; set; }

    public virtual Salon ClrFrSalonNavigation { get; set; }

    public virtual Shift ClrFrShiftsNavigation { get; set; }

    public virtual ICollection<InOut> InOuts { get; set; } = new List<InOut>();

    public virtual ICollection<PersonelCalender> PersonelCalenders { get; set; } = new List<PersonelCalender>();
}
