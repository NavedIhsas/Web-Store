namespace Domain.ShopModels;

public class Car
{
    public Guid CarUid { get; set; }

    public string CarName { get; set; }

    public string CarType { get; set; }

    public string CarSystem { get; set; }

    public string CarBrigade { get; set; }

    public string CarModel { get; set; }

    public string CarColor { get; set; }

    public string CarCapacity { get; set; }

    public string CarNumberCylinder { get; set; }

    public string CarFuelType { get; set; }

    public string CarNumberAxis { get; set; }

    public string CarNumberWheel { get; set; }

    public string CarNumberEngines { get; set; }

    public string CarNumberChassis { get; set; }

    public string CarNumberNaja { get; set; }

    public string CarVin { get; set; }

    public string CarDescribtion { get; set; }

    public bool? CarStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual ICollection<Agreement> Agreements { get; set; } = new List<Agreement>();
}