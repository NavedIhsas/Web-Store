using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class PhotoDetail
{
    public Guid PhtDetUid { get; set; }

    public Guid? AccPhtUid { get; set; }

    public Guid? InvDetUid { get; set; }

    public string PhtDetCode { get; set; }

    public string PhtDetName { get; set; }

    public int? PhtDetCount { get; set; }

    public string PhtDetSize { get; set; }

    public string PhtDetPath { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public int? PhtDetKindPrint { get; set; }

    public int? PhtDetGetFileType { get; set; }
}
