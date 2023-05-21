using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class BusinessUnit
{
    public Guid BusUnitUid { get; set; }

    public Guid? BusUnitTypUid { get; set; }

    public Guid? LangUid { get; set; }

    public string BusUnitName { get; set; }

    public string BusUnitBriefname { get; set; }

    public string BusUnitRegistrationNumber { get; set; }

    public string BusUnitEconomicCode { get; set; }

    public string BusUnitPhone1 { get; set; }

    public string BusUnitPhone2 { get; set; }

    public string BusUnitFax1 { get; set; }

    public string BusUnitFax2 { get; set; }

    public string BusUnitEmail { get; set; }

    public string BusUnitWebsite { get; set; }

    public string BusUnitZipCode { get; set; }

    public string BusUnitId { get; set; }

    public string BusUnitAddress { get; set; }

    public bool? BusUnitStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public Guid? CityUid { get; set; }

    public virtual ICollection<AccountRating> AccountRatings { get; set; } = new List<AccountRating>();

    public virtual ICollection<Agreement> Agreements { get; set; } = new List<Agreement>();

    public virtual BusinessUnitType BusUnitTypU { get; set; }

    public virtual ICollection<ChequSheetStatus> ChequSheetStatuses { get; set; } = new List<ChequSheetStatus>();

    public virtual ICollection<Chequ> Chequs { get; set; } = new List<Chequ>();

    public virtual City CityU { get; set; }

    public virtual ICollection<Condition> Conditions { get; set; } = new List<Condition>();

    public virtual ICollection<FiscalPeriod> FiscalPeriods { get; set; } = new List<FiscalPeriod>();

    public virtual Language Lan { get; set; }

    public virtual ICollection<UnitOfMeasurement> UnitOfMeasurements { get; set; } = new List<UnitOfMeasurement>();

    public virtual ICollection<WarehouseReciept> WarehouseReciepts { get; set; } = new List<WarehouseReciept>();
}
