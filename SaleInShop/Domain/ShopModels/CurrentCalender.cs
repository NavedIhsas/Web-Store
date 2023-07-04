using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class CurrentCalender
{
    public long CcId { get; set; }

    public DateTime CcDate { get; set; }

    public bool? CcIsHoliday { get; set; }

    public bool? CcIsFriday { get; set; }

    public string CcEvents { get; set; }
}
