namespace Domain.ShopModels;

public class Personnel
{
    public Guid PrsUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public string PrsFirstName { get; set; }

    public string PrsLastName { get; set; }

    public string PrsId { get; set; }

    public int? PrsSex { get; set; }

    public string PrsPhone1 { get; set; }

    public string PrsPhone2 { get; set; }

    public string PrsJobtitle { get; set; }

    public bool? PrsStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public int? PrsType { get; set; }

    public bool? PrsFixed { get; set; }

    public string PrsDescription { get; set; }

    public virtual ICollection<RelatedPersonnel> RelatedPersonnel { get; set; } = new List<RelatedPersonnel>();
}