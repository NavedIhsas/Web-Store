using System;
using System.Collections.Generic;

namespace Domain.SaleInModels;

public partial class Account
{
    public Guid AccUid { get; set; }

    public Guid? BusUnitUid { get; set; }

    public Guid? FisPeriodUid { get; set; }

    public Guid? AccTypUid { get; set; }

    public Guid? AccRateUid { get; set; }

    public Guid? PhbUid { get; set; }

    public Guid? AccLvlUid1 { get; set; }

    public Guid? AccLvlUid2 { get; set; }

    public Guid? AccLvlUid3 { get; set; }

    public Guid? AccLvlUid4 { get; set; }

    public string AccName { get; set; }

    public string AccCode { get; set; }

    /// <summary>
    /// نوع حساب: 1- حقیقی 2- حقوقی 3- حقوقی دولتی 4-سایر
    /// </summary>
    public int? AccKind { get; set; }

    /// <summary>
    /// نوع خریدار: 1- عادی 2- مصرف کننده نهایی 3- صادرات 4- سایر
    /// </summary>
    public int? AccPurchaserType { get; set; }

    /// <summary>
    /// نوع شخص: 1- تامین کننده 2- مصرف کننده 3- هردو
    /// </summary>
    public int? AccPersonalType { get; set; }

    public decimal? AccFirstFiscalPeriodCredit { get; set; }

    public decimal? AccRemainCredit { get; set; }

    public decimal? AccLiabilityMaxAmount { get; set; }

    public decimal? AccCreditoryMaxAmount { get; set; }

    public bool? AccSms { get; set; }

    public bool? AccStatus { get; set; }

    public DateTime? SysUsrCreatedon { get; set; }

    public Guid? SysUsrCreatedby { get; set; }

    public DateTime? SysUsrModifiedon { get; set; }

    public Guid? SysUsrModifiedby { get; set; }

    public long? AccTotalScore { get; set; }

    public long? AccTotalCredit { get; set; }

    public Guid? AccParentUid { get; set; }

    public int? AccDefaultPriceInvoice { get; set; }

    public int? AccSyncCrm { get; set; }

    public virtual AccountLevel AccLvlUid4Navigation { get; set; }

    public virtual AccountRating AccRateU { get; set; }

    public virtual AccountType AccTypU { get; set; }

    public virtual ICollection<AccountClub> AccountClubs { get; set; } = new List<AccountClub>();

    public virtual ICollection<AccountRemainCredit> AccountRemainCredits { get; set; } = new List<AccountRemainCredit>();

    public virtual ICollection<Agreement> AgreementAccUidBuyerNavigations { get; set; } = new List<Agreement>();

    public virtual ICollection<Agreement> AgreementAccUidSellerNavigations { get; set; } = new List<Agreement>();

    public virtual ICollection<ChequSheetStatus> ChequSheetStatuses { get; set; } = new List<ChequSheetStatus>();

    public virtual ICollection<ChequSheet> ChequSheets { get; set; } = new List<ChequSheet>();

    public virtual ICollection<Chequ> Chequs { get; set; } = new List<Chequ>();

    public virtual ICollection<CostDetail> CostDetailAccUs { get; set; } = new List<CostDetail>();

    public virtual ICollection<CostDetail> CostDetailCstDetAccUs { get; set; } = new List<CostDetail>();

    public virtual ICollection<DefualtAccountDefinition> DefualtAccountDefinitions { get; set; } = new List<DefualtAccountDefinition>();

    public virtual ICollection<DocumentDetail> DocumentDetails { get; set; } = new List<DocumentDetail>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<PaymentRecieptDetail> PaymentRecieptDetails { get; set; } = new List<PaymentRecieptDetail>();

    public virtual ICollection<PaymentRecieptSheet> PaymentRecieptSheets { get; set; } = new List<PaymentRecieptSheet>();

    public virtual PhoneBook PhbU { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual ICollection<Quote> Quotes { get; set; } = new List<Quote>();

    public virtual ICollection<StockTransfer> StockTransfers { get; set; } = new List<StockTransfer>();

    public virtual ICollection<Tax> TaxTaxAccUs { get; set; } = new List<Tax>();

    public virtual ICollection<Tax> TaxTaxTaxesAccUs { get; set; } = new List<Tax>();

    public virtual ICollection<WarehouseReciept> WarehouseReciepts { get; set; } = new List<WarehouseReciept>();
}
