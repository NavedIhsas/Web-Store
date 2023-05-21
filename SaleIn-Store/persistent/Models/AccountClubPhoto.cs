using System;
using System.Collections.Generic;

namespace persistent.Models;

public partial class AccountClubPhoto
{
    public Guid AccPhtUid { get; set; }

    public string AccPhtPath { get; set; }

    public Guid? AccClbUid { get; set; }

    public string AccPhtCode { get; set; }

    public string AccPhtName { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public bool? AccPhtStatus { get; set; }
}
