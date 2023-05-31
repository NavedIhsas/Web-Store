using System;
using System.Collections.Generic;

namespace Domain.SaleInModels;

public partial class Field
{
    public Guid FldUid { get; set; }

    /// <summary>
    /// نام فیلد در دیتابیس
    /// </summary>
    public string FldName { get; set; }

    /// <summary>
    /// نام نمایشی فیلد دربرنامه
    /// </summary>
    public string FldText { get; set; }

    /// <summary>
    /// نوع فیلد برای اعمال روی کل فاکتور یا ردیف های فاکتور
    /// </summary>
    public int? FldType { get; set; }

    public virtual ICollection<ConditionDetail> ConditionDetails { get; set; } = new List<ConditionDetail>();
}
