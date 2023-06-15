namespace Domain.ShopModels;

public class ProductQuantity
{
    public Guid PrdQuanUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public DateTime? PrdQuanDate { get; set; }

    public bool? PrdQuanStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual ICollection<ProductQuantityOnHand> ProductQuantityOnHands { get; set; } =
        new List<ProductQuantityOnHand>();
}