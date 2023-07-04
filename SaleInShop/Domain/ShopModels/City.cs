using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class City
{
    public Guid CityUid { get; set; }

    public Guid SttUid { get; set; }

    public string CityName { get; set; }

    public string CityCode { get; set; }

    public bool? CityStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual ICollection<BusinessUnit> BusinessUnits { get; set; } = new List<BusinessUnit>();

    public virtual ICollection<PhoneBook> PhoneBooks { get; set; } = new List<PhoneBook>();

    public virtual State SttU { get; set; }
}
