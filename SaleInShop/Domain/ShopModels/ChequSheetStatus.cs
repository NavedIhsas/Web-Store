
using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class ChequSheetStatus
{
    public Guid CheqSheetStusUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? CheqSheetUid { get; set; }

    public Guid? AccUidType { get; set; }

    public Guid? DftAccDfinUid { get; set; }

    public bool? CheqSheetStusStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public Guid? RgdObjUid { get; set; }

    public Guid? CheqSheetStusRgdUid { get; set; }

    public virtual Account AccUidTypeNavigation { get; set; }

    public virtual BusinessUnit BusUnitU { get; set; }

    public virtual ChequSheet CheqSheetU { get; set; }

    public virtual DefualtAccountDefinition DftAccDfinU { get; set; }
}
