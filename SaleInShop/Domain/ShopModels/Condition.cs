using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class Condition
{
    public Guid ConUid { get; set; }

    public string ConName { get; set; }

    public string ConText { get; set; }

    public string ConTextShow { get; set; }

    public int? ConPriority { get; set; }

    public int? ConGroup { get; set; }

    public decimal? ConPercent { get; set; }

    public long? ConPrice { get; set; }

    public int? ConScore { get; set; }

    public int? ConForPerPrice { get; set; }

    public bool? ConIntroducedBy { get; set; }

    public decimal? ConIntroducerPercent { get; set; }

    public int? ConType { get; set; }

    public Guid? BusUid { get; set; }

    public DateTime? ConStartDate { get; set; }

    public DateTime? ConEndDate { get; set; }

    public bool? ConActivation { get; set; }

    public bool? ConStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual BusinessUnit BusU { get; set; }

    public virtual ICollection<ConditionDetail> ConditionDetails { get; set; } = new List<ConditionDetail>();

    public virtual ICollection<ConditionLog> ConditionLogs { get; set; } = new List<ConditionLog>();
}
