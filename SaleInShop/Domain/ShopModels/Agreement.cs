using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class Agreement
{
    public Guid AgtUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public Guid? AccUidSeller { get; set; }

    public Guid? AccUidBuyer { get; set; }

    public Guid? CarUid { get; set; }

    public Guid? TaxUid { get; set; }

    public string AgtSerialNumber { get; set; }

    public string AgtFromSeller { get; set; }

    public string AgtCauseSeller { get; set; }

    public string AgtFromBuyer { get; set; }

    public string AgtCauseBuyer { get; set; }

    public string AgtToneCar { get; set; }

    public string AgtCauseCar { get; set; }

    public int? AgtYearMonth { get; set; }

    public DateTime? AgtStartDate { get; set; }

    public DateTime? AgtEndDate { get; set; }

    public decimal? AgtSectionedPrice { get; set; }

    public string AgtOtherPrice { get; set; }

    public decimal? AgtRemainRentPrice { get; set; }

    public string AgtRemainPrice { get; set; }

    public string AgtTimeRent { get; set; }

    public decimal? AgtTimeRentPrice { get; set; }

    public DateTime? AgtSetDocumentDate { get; set; }

    public string AgtOfficialDocumentNumber { get; set; }

    public string AgtOfficialAddressDocument { get; set; }

    public decimal? AgtDamageSellerPrice { get; set; }

    public string AgtNumberInstallment { get; set; }

    public decimal? AgtDamagePrice { get; set; }

    public DateTime? AgtDueDate { get; set; }

    public string AgtDueTime { get; set; }

    public DateTime? AgtOtherDueDate { get; set; }

    public decimal? AgtDamageTransferDocument { get; set; }

    public string AgtAdvisorNumberCertificate { get; set; }

    public decimal? AgtAdvisorSellerPrice { get; set; }

    public decimal? AgtAdvisorBuyerPrice { get; set; }

    public decimal? AgtAdvisorTaxPrice { get; set; }

    public string AgtAdvisorDescribtion { get; set; }

    public string AgtDate { get; set; }

    public string AgtTime { get; set; }

    public string AgtDescribtion { get; set; }

    public int? AgtType { get; set; }

    public int? AgtKind { get; set; }

    public bool? AgtStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public DateTime? AgtCurrentDate { get; set; }

    public int? AgtTaxName { get; set; }

    public virtual Account AccUidBuyerNavigation { get; set; }

    public virtual Account AccUidSellerNavigation { get; set; }

    public virtual BusinessUnit BusUnitU { get; set; }

    public virtual Car CarU { get; set; }

    public virtual ICollection<ChequeSheet> ChequeSheets { get; set; } = new List<ChequeSheet>();

    public virtual Tax TaxU { get; set; }
}
