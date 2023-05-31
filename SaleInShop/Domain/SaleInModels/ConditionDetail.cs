using System;
using System.Collections.Generic;

namespace Domain.SaleInModels;

public partial class ConditionDetail
{
    public Guid ConDetUid { get; set; }

    public Guid? ConUid { get; set; }

    public int? ConDetRownumber { get; set; }

    public string ConDetBegin { get; set; }

    public Guid? FldUid { get; set; }

    public Guid? OprUid { get; set; }

    public string ConDetParameterValue { get; set; }

    public Guid? AccLvlUid { get; set; }

    public Guid? PrdLvlUid { get; set; }

    public string ConDetEnd { get; set; }

    public string ConDetConditionOperator { get; set; }

    public bool? ConDetStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual Condition ConU { get; set; }

    public virtual Field FldU { get; set; }

    public virtual Operator OprU { get; set; }
}
