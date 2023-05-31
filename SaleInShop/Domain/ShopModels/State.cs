
using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class State
{
    public Guid SttUid { get; set; }

    public string SttName { get; set; }

    public string SttCode { get; set; }

    public bool? SttStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
