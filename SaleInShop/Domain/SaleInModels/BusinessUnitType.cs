namespace Domain.SaleInModels;

public class BusinessUnitType
{
    public Guid BusUnitTypUid { get; set; }

    public string BusUnitTypName { get; set; }

    public bool? BusUnitTypStatus { get; set; }

    public DateTime? BusUnitTypCreatedon { get; set; }

    public Guid? BusUnitTypCreatedby { get; set; }

    public DateTime? BusUnitTypModifiedon { get; set; }

    public Guid? BusUnitTypModifiedby { get; set; }

    public virtual ICollection<BusinessUnit> BusinessUnits { get; set; } = new List<BusinessUnit>();
}