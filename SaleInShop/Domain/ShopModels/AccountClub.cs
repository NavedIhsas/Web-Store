using System;
using System.Collections.Generic;

namespace Domain.ShopModels;

public partial class AccountClub
{
    public Guid AccClbUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public string AccClbName { get; set; }

    public string AccClbCode { get; set; }

    public bool? AccClbSms { get; set; }

    public bool? AccClbStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public Guid? AccParentUid { get; set; }

    public Guid? AccUid { get; set; }

    public Guid? AccRateUid { get; set; }

    public string AccClbNationalCode { get; set; }

    public string AccClbPostalCode { get; set; }

    public string AccClbPhone1 { get; set; }

    public string AccClbPhone2 { get; set; }

    public string AccClbMobile { get; set; }

    public string AccClbMobile2 { get; set; }

    public DateTime? AccClbBrithday { get; set; }

    public Guid? AccClbParentUid { get; set; }

    public int? AccClbSync { get; set; }

    public decimal? AccClbRemainCredit { get; set; }

    public Guid? CityUid { get; set; }

    public string AccClbOldNumber { get; set; }

    public Guid? AccClbTypUid { get; set; }

    public int? AccClbNationality { get; set; }

    public int? AccClbSex { get; set; }

    public string AccClbAddress { get; set; }

    public string AccClbAddress2 { get; set; }

    public string AccClbDescribtion { get; set; }

    public long? AccClbScore { get; set; }

    public decimal? AccClbCredit { get; set; }

    public string AccClbAgentName { get; set; }

    public string AccClbCompanyName { get; set; }

    public Guid? CntUid { get; set; }

    public string AccClbClubCard { get; set; }

    public Guid? AccFloatUid { get; set; }

    public int? AccClbCreditType { get; set; }

    public string AccClbDefaultAddress { get; set; }

    public string AccClbPassword { get; set; }

    public string AccClbLat { get; set; }

    public string AccClbLong { get; set; }

    public string AccClbLat1 { get; set; }

    public string AccClbLong1 { get; set; }

    public bool? AccClbStatusApp { get; set; }

    public string AccClbFolder { get; set; }

    public int? AccFrJob { get; set; }

    public Guid? AccFrContract { get; set; }

    public string AccCardSerial { get; set; }

    public short? AccRelationType { get; set; }

    public virtual AccountClubType AccClbTypU { get; set; }

    public virtual Contract AccFrContractNavigation { get; set; }

    public virtual Job AccFrJobNavigation { get; set; }

    public virtual Account AccU { get; set; }

    public virtual ICollection<AccountClubCard> AccountClubCards { get; set; } = new List<AccountClubCard>();

    public virtual ICollection<CalenderDetail> CalenderDetails { get; set; } = new List<CalenderDetail>();

    public virtual ICollection<Calender> Calenders { get; set; } = new List<Calender>();

    public virtual ICollection<CardRechage> CardRechages { get; set; } = new List<CardRechage>();

    public virtual ICollection<ContinuouseServicesPlaning> ContinuouseServicesPlanings { get; set; } = new List<ContinuouseServicesPlaning>();

    public virtual ICollection<InOut> InOuts { get; set; } = new List<InOut>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<PersonelCalender> PersonelCalenders { get; set; } = new List<PersonelCalender>();

    public virtual ICollection<SalonDetail> SalonDetails { get; set; } = new List<SalonDetail>();

    public virtual ICollection<ServiceTransaction> ServiceTransactions { get; set; } = new List<ServiceTransaction>();
}
