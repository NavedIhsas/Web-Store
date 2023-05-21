using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class FiscalPeriod
{
    public Guid FisPeriodUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public string FisPeriodName { get; set; }

    public string FisPeriodCode { get; set; }

    public DateTime? FisPeriodStartDate { get; set; }

    public DateTime? FisPeriodEndDate { get; set; }

    public bool? FisPeriodIsActive { get; set; }

    public bool? FisPeriodIsClosed { get; set; }

    public bool? FisPeriodStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public virtual ICollection<AccountLevel> AccountLevels { get; set; } = new List<AccountLevel>();

    public virtual BusinessUnit BusUnitU { get; set; }

    public virtual ICollection<ChequSheet> ChequSheets { get; set; } = new List<ChequSheet>();

    public virtual ICollection<Chequ> Chequs { get; set; } = new List<Chequ>();

    public virtual ICollection<CostCenter> CostCenters { get; set; } = new List<CostCenter>();

    public virtual ICollection<Cost> Costs { get; set; } = new List<Cost>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ProductLevel> ProductLevels { get; set; } = new List<ProductLevel>();

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual ICollection<Quote> Quotes { get; set; } = new List<Quote>();

    public virtual ICollection<WareHouse> WareHouses { get; set; } = new List<WareHouse>();
}
