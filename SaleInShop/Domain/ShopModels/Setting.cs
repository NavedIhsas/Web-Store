using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class Setting
{
    public Guid SetUid { get; set; }

    public string SetKey { get; set; }

    public string SetValue { get; set; }

    public string SetBase { get; set; }
}
