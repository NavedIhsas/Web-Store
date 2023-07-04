using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class Shift
{
    public int ShfId { get; set; }

    public string ShfName { get; set; }

    public int ShfStartTime { get; set; }

    public int ShfEndTime { get; set; }

    public int ShfTelorance { get; set; }

    public virtual ICollection<Calender> Calenders { get; set; } = new List<Calender>();
}
