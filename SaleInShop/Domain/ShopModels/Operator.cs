namespace Domain.ShopModels;

public class Operator
{
    public Guid OprUid { get; set; }

    /// <summary>
    ///     عملگر
    /// </summary>
    public string OprName { get; set; }

    /// <summary>
    ///     نام نمایشی فیلد در برنامه
    /// </summary>
    public string OprText { get; set; }

    public int? OprType { get; set; }

    public virtual ICollection<ConditionDetail> ConditionDetails { get; set; } = new List<ConditionDetail>();
}