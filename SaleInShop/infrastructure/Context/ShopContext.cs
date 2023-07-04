using Application.Common;
using Application.Interfaces.Context;
using Domain.ShopModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Context;

public partial class ShopContext : DbContext, IShopContext
{
    private readonly IHttpContextAccessor _httpContext;

    public ShopContext()
    {
    }

    public ShopContext(DbContextOptions<ShopContext> options, IHttpContextAccessor httpContext)
        : base(options)
    {
        _httpContext = httpContext;
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountClub> AccountClubs { get; set; }

    public virtual DbSet<AccountClubCard> AccountClubCards { get; set; }

    public virtual DbSet<AccountClubPhoto> AccountClubPhotos { get; set; }

    public virtual DbSet<AccountClubType> AccountClubTypes { get; set; }

    public virtual DbSet<AccountLevel> AccountLevels { get; set; }

    public virtual DbSet<AccountRating> AccountRatings { get; set; }

    public virtual DbSet<AccountRemainCredit> AccountRemainCredits { get; set; }

    public virtual DbSet<AccountType> AccountTypes { get; set; }

    public virtual DbSet<Agreement> Agreements { get; set; }

    public virtual DbSet<AgreementAtelier> AgreementAteliers { get; set; }

    public virtual DbSet<AgreementAtelierLog> AgreementAtelierLogs { get; set; }

    public virtual DbSet<AtelierCategory> AtelierCategories { get; set; }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<Barcode> Barcodes { get; set; }

    public virtual DbSet<BusinessUnit> BusinessUnits { get; set; }

    public virtual DbSet<BusinessUnitType> BusinessUnitTypes { get; set; }

    public virtual DbSet<Calender> Calenders { get; set; }

    public virtual DbSet<CalenderDetail> CalenderDetails { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CardRechage> CardRechages { get; set; }

    public virtual DbSet<Chequ> Chequs { get; set; }

    public virtual DbSet<ChequSheet> ChequSheets { get; set; }

    public virtual DbSet<ChequSheetStatus> ChequSheetStatuses { get; set; }

    public virtual DbSet<ChequeSheet> ChequeSheets { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<ClassProperty> ClassProperties { get; set; }

    public virtual DbSet<Condition> Conditions { get; set; }

    public virtual DbSet<ConditionDetail> ConditionDetails { get; set; }

    public virtual DbSet<ConditionHidden> ConditionHiddens { get; set; }

    public virtual DbSet<ConditionLog> ConditionLogs { get; set; }

    public virtual DbSet<ContinuouseServicesPlaning> ContinuouseServicesPlanings { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<ContractDetail> ContractDetails { get; set; }

    public virtual DbSet<Cost> Costs { get; set; }

    public virtual DbSet<CostCenter> CostCenters { get; set; }

    public virtual DbSet<CostDetail> CostDetails { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<CurrentCalender> CurrentCalenders { get; set; }

    public virtual DbSet<DefualtAccountDefinition> DefualtAccountDefinitions { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<DocumentDetail> DocumentDetails { get; set; }

    public virtual DbSet<Exchange> Exchanges { get; set; }

    public virtual DbSet<ExchangeDetail> ExchangeDetails { get; set; }

    public virtual DbSet<ExchangeRate> ExchangeRates { get; set; }

    public virtual DbSet<Field> Fields { get; set; }

    public virtual DbSet<FiscalPeriod> FiscalPeriods { get; set; }

    public virtual DbSet<InOut> InOuts { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public virtual DbSet<InvoiceDetails2> InvoiceDetails2s { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuUser> MenuUsers { get; set; }

    public virtual DbSet<ObjectDescription> ObjectDescriptions { get; set; }

    public virtual DbSet<Operator> Operators { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderType> OrderTypes { get; set; }

    public virtual DbSet<PaymentReceiptRelatedPurchaseInvoice> PaymentReceiptRelatedPurchaseInvoices { get; set; }

    public virtual DbSet<PaymentRecieptDetail> PaymentRecieptDetails { get; set; }

    public virtual DbSet<PaymentRecieptSheet> PaymentRecieptSheets { get; set; }

    public virtual DbSet<PersonelCalender> PersonelCalenders { get; set; }

    public virtual DbSet<Personnel> Personnel { get; set; }

    public virtual DbSet<PhoneBook> PhoneBooks { get; set; }

    public virtual DbSet<PhotoDetail> PhotoDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductLevel> ProductLevels { get; set; }

    public virtual DbSet<ProductLevelAccess> ProductLevelAccesses { get; set; }

    public virtual DbSet<ProductPicture> ProductPictures { get; set; }

    public virtual DbSet<ProductProperty> ProductProperties { get; set; }

    public virtual DbSet<ProductQuantity> ProductQuantities { get; set; }

    public virtual DbSet<ProductQuantityOnHand> ProductQuantityOnHands { get; set; }

    public virtual DbSet<ProductSubset> ProductSubsets { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }

    public virtual DbSet<Quote> Quotes { get; set; }

    public virtual DbSet<QuoteDetail> QuoteDetails { get; set; }

    public virtual DbSet<RegardingObject> RegardingObjects { get; set; }

    public virtual DbSet<RelatedPersonnel> RelatedPersonnel { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleAccess> RoleAccesses { get; set; }

    public virtual DbSet<SalesCategory> SalesCategories { get; set; }

    public virtual DbSet<Salon> Salons { get; set; }

    public virtual DbSet<SalonDetail> SalonDetails { get; set; }

    public virtual DbSet<SalonProduct> SalonProducts { get; set; }

    public virtual DbSet<SelectDeliverer> SelectDeliverers { get; set; }

    public virtual DbSet<SerialDetail> SerialDetails { get; set; }

    public virtual DbSet<ServiceTransaction> ServiceTransactions { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<SmsDetail> SmsDetails { get; set; }

    public virtual DbSet<SmsHeader> SmsHeaders { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<StockTransfer> StockTransfers { get; set; }

    public virtual DbSet<StockTransferDetail> StockTransferDetails { get; set; }

    public virtual DbSet<SyncLog> SyncLogs { get; set; }

    public virtual DbSet<SystemGame> SystemGames { get; set; }

    public virtual DbSet<SystemGameDetail> SystemGameDetails { get; set; }

    public virtual DbSet<SystemUser> SystemUsers { get; set; }

    public virtual DbSet<Tab> Tabs { get; set; }

    public virtual DbSet<Tax> Taxes { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketDetail> TicketDetails { get; set; }

    public virtual DbSet<TicketProduct> TicketProducts { get; set; }

    public virtual DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; }

    public virtual DbSet<WareHouse> WareHouses { get; set; }

    public virtual DbSet<WarehouseReciept> WarehouseReciepts { get; set; }

    public virtual DbSet<WarehouseRecieptDetail> WarehouseRecieptDetails { get; set; }

    public virtual DbSet<WorkStation> WorkStations { get; set; }

    public virtual DbSet<WorkYear> WorkYears { get; set; }


    public override int SaveChanges()
    {
        var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Deleted || x.State == EntityState.Added);
        foreach (var entry in modifiedEntries)
        {
            var baseConfig = _httpContext.HttpContext.Session.GetJson<BaseConfigDto>("BaseConfig");

            var getEntityType = entry.Context.Model.FindEntityType(entry.Entity.GetType());
            if (getEntityType != null)
            {
                //shodow property
                var insert = getEntityType.FindProperty("SysUsrCreatedon");
                var insertBy = getEntityType.FindProperty("SysUsrCreatedby");
                var updateBy = getEntityType.FindProperty("SysUsrModifiedby");
                var updateDate = getEntityType.FindProperty("SysUsrModifiedon");
                var busUnitUid = getEntityType.FindProperty("BusUnitUid");
                var fisPeriodUid = getEntityType.FindProperty("FisPeriodUid");


                if (entry.State == EntityState.Added && busUnitUid != null) entry.Property("BusUnitUid").CurrentValue = baseConfig.BusUnitUId;
                if (entry.State == EntityState.Added && fisPeriodUid != null) entry.Property("FisPeriodUid").CurrentValue = baseConfig.FisPeriodUId;//TODO current user

                if (entry.State == EntityState.Added && insert != null) entry.Property("SysUsrCreatedon").CurrentValue = DateTime.Now;
                if (entry.State == EntityState.Added && insertBy != null) entry.Property("SysUsrCreatedby").CurrentValue = new Guid();//TODO current user

                if (entry.State == EntityState.Modified && updateBy != null) entry.Property("SysUsrModifiedon").CurrentValue = DateTime.Now;
                if (entry.State == EntityState.Modified && updateDate != null)
                    entry.Property("SysUsrModifiedby").CurrentValue = entry.Property("SysUsrCreatedby").CurrentValue = new Guid();//TODO current user
            }
        }
        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_CI_AS");

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccUid);

            entity.ToTable("Account");

            entity.Property(e => e.AccUid)
                .ValueGeneratedNever()
                .HasColumnName("ACC_UID");
            entity.Property(e => e.AccCode)
                .HasMaxLength(50)
                .HasColumnName("ACC_CODE");
            entity.Property(e => e.AccCreditoryMaxAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ACC_CREDITORY_MAX_AMOUNT");
            entity.Property(e => e.AccDefaultPriceInvoice).HasColumnName("ACC_DEFAULT_PRICE_INVOICE");
            entity.Property(e => e.AccFirstFiscalPeriodCredit)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ACC_FIRST_FISCAL_PERIOD_CREDIT");
            entity.Property(e => e.AccKind)
                .HasComment("نوع حساب: 1- حقیقی 2- حقوقی 3- حقوقی دولتی 4-سایر")
                .HasColumnName("ACC_KIND");
            entity.Property(e => e.AccLiabilityMaxAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ACC_LIABILITY_MAX_AMOUNT");
            entity.Property(e => e.AccLvlUid1).HasColumnName("ACC_LVL_UID1");
            entity.Property(e => e.AccLvlUid2).HasColumnName("ACC_LVL_UID2");
            entity.Property(e => e.AccLvlUid3).HasColumnName("ACC_LVL_UID3");
            entity.Property(e => e.AccLvlUid4).HasColumnName("ACC_LVL_UID4");
            entity.Property(e => e.AccName)
                .HasMaxLength(100)
                .HasColumnName("ACC_NAME");
            entity.Property(e => e.AccParentUid).HasColumnName("ACC_PARENT_UID");
            entity.Property(e => e.AccPersonalType)
                .HasComment("نوع شخص: 1- تامین کننده 2- مصرف کننده 3- هردو")
                .HasColumnName("ACC_PERSONAL_TYPE");
            entity.Property(e => e.AccPurchaserType)
                .HasComment("نوع خریدار: 1- عادی 2- مصرف کننده نهایی 3- صادرات 4- سایر")
                .HasColumnName("ACC_PURCHASER_TYPE");
            entity.Property(e => e.AccRateUid).HasColumnName("ACC_RATE_UID");
            entity.Property(e => e.AccRemainCredit)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ACC_REMAIN_CREDIT");
            entity.Property(e => e.AccSms).HasColumnName("ACC_SMS");
            entity.Property(e => e.AccStatus).HasColumnName("ACC_STATUS");
            entity.Property(e => e.AccSyncCrm).HasColumnName("ACC_SYNC_CRM");
            entity.Property(e => e.AccTotalCredit).HasColumnName("ACC_TOTAL_CREDIT");
            entity.Property(e => e.AccTotalScore).HasColumnName("ACC_TOTAL_SCORE");
            entity.Property(e => e.AccTypUid).HasColumnName("ACC_TYP_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.PhbUid).HasColumnName("PHB_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.AccLvlUid4Navigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.AccLvlUid4)
                .HasConstraintName("FK_Account_AccountLevel1");

            entity.HasOne(d => d.AccRateU).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.AccRateUid)
                .HasConstraintName("FK_Account_AccountRating");

            entity.HasOne(d => d.AccTypU).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.AccTypUid)
                .HasConstraintName("FK_Account_AccountType");

            entity.HasOne(d => d.PhbU).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.PhbUid)
                .HasConstraintName("FK_Account_PhoneBook");
        });

        modelBuilder.Entity<AccountClub>(entity =>
        {
            entity.HasKey(e => e.AccClbUid);

            entity.ToTable("AccountClub");

            entity.HasIndex(e => e.AccClbMobile, "IX_ACC_CLB_MOBILE");

            entity.HasIndex(e => e.AccClbName, "IX_ACC_CLB_NAME");

            entity.HasIndex(e => new { e.BusUnitUid, e.FisPeriodUid, e.AccClbStatus, e.AccClbCode, e.AccClbSync }, "IX_BUS_UNIT_UID_FIS_PERIOD_UID_ACC_CLB_STATUS_ACC_CLB_CODE_ACC_CLB_SYNC");

            entity.Property(e => e.AccClbUid)
                .ValueGeneratedNever()
                .HasColumnName("ACC_CLB_UID");
            entity.Property(e => e.AccCardSerial)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ACC_CARD_SERIAL");
            entity.Property(e => e.AccClbAddress).HasColumnName("ACC_CLB_ADDRESS");
            entity.Property(e => e.AccClbAddress2).HasColumnName("ACC_CLB_ADDRESS2");
            entity.Property(e => e.AccClbAgentName)
                .HasMaxLength(100)
                .HasColumnName("ACC_CLB_AGENT_NAME");
            entity.Property(e => e.AccClbBrithday)
                .HasColumnType("datetime")
                .HasColumnName("ACC_CLB_BRITHDAY");
            entity.Property(e => e.AccClbClubCard)
                .HasMaxLength(16)
                .HasColumnName("ACC_CLB_CLUB_CARD");
            entity.Property(e => e.AccClbCode)
                .HasMaxLength(50)
                .HasColumnName("ACC_CLB_CODE");
            entity.Property(e => e.AccClbCompanyName)
                .HasMaxLength(100)
                .HasColumnName("ACC_CLB_COMPANY_NAME");
            entity.Property(e => e.AccClbCredit)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ACC_CLB_CREDIT");
            entity.Property(e => e.AccClbCreditType).HasColumnName("ACC_CLB_CREDIT_TYPE");
            entity.Property(e => e.AccClbDefaultAddress)
                .HasMaxLength(200)
                .HasDefaultValueSql("('1')")
                .HasColumnName("ACC_CLB_DEFAULT_ADDRESS");
            entity.Property(e => e.AccClbDescribtion).HasColumnName("ACC_CLB_DESCRIBTION");
            entity.Property(e => e.AccClbFolder)
                .HasMaxLength(500)
                .HasColumnName("ACC_CLB_FOLDER");
            entity.Property(e => e.AccClbLat)
                .HasMaxLength(15)
                .HasColumnName("ACC_CLB_LAT");
            entity.Property(e => e.AccClbLat1)
                .HasMaxLength(15)
                .HasColumnName("ACC_CLB_LAT1");
            entity.Property(e => e.AccClbLong)
                .HasMaxLength(15)
                .HasColumnName("ACC_CLB_LONG");
            entity.Property(e => e.AccClbLong1)
                .HasMaxLength(15)
                .HasColumnName("ACC_CLB_LONG1");
            entity.Property(e => e.AccClbMobile)
                .HasMaxLength(20)
                .HasColumnName("ACC_CLB_MOBILE");
            entity.Property(e => e.AccClbMobile2)
                .HasMaxLength(20)
                .HasColumnName("ACC_CLB_MOBILE2");
            entity.Property(e => e.AccClbName)
                .HasMaxLength(100)
                .HasColumnName("ACC_CLB_NAME");
            entity.Property(e => e.AccClbNationalCode)
                .HasMaxLength(10)
                .HasColumnName("ACC_CLB_NATIONAL_CODE");
            entity.Property(e => e.AccClbNationality).HasColumnName("ACC_CLB_NATIONALITY");
            entity.Property(e => e.AccClbOldNumber)
                .HasMaxLength(20)
                .HasColumnName("ACC_CLB_OLD_NUMBER");
            entity.Property(e => e.AccClbParentUid).HasColumnName("ACC_CLB_PARENT_UID");
            entity.Property(e => e.AccClbPassword)
                .HasMaxLength(30)
                .HasColumnName("ACC_CLB_PASSWORD");
            entity.Property(e => e.AccClbPhone1)
                .HasMaxLength(20)
                .HasColumnName("ACC_CLB_PHONE1");
            entity.Property(e => e.AccClbPhone2)
                .HasMaxLength(20)
                .HasColumnName("ACC_CLB_PHONE2");
            entity.Property(e => e.AccClbPostalCode)
                .HasMaxLength(20)
                .HasColumnName("ACC_CLB_POSTAL_CODE");
            entity.Property(e => e.AccClbRemainCredit)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ACC_CLB_REMAIN_CREDIT");
            entity.Property(e => e.AccClbScore).HasColumnName("ACC_CLB_SCORE");
            entity.Property(e => e.AccClbSex).HasColumnName("ACC_CLB_SEX");
            entity.Property(e => e.AccClbSms).HasColumnName("ACC_CLB_SMS");
            entity.Property(e => e.AccClbStatus).HasColumnName("ACC_CLB_STATUS");
            entity.Property(e => e.AccClbStatusApp)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACC_CLB_STATUS_APP");
            entity.Property(e => e.AccClbSync).HasColumnName("ACC_CLB_SYNC");
            entity.Property(e => e.AccClbTypUid).HasColumnName("ACC_CLB_TYP_UID");
            entity.Property(e => e.AccFloatUid).HasColumnName("ACC_FLOAT_UID");
            entity.Property(e => e.AccFrContract).HasColumnName("ACC_FR_CONTRACT");
            entity.Property(e => e.AccFrJob).HasColumnName("ACC_FR_JOB");
            entity.Property(e => e.AccParentUid).HasColumnName("ACC_PARENT_UID");
            entity.Property(e => e.AccRateUid).HasColumnName("ACC_RATE_UID");
            entity.Property(e => e.AccRelationType).HasColumnName("ACC_RELATION_TYPE");
            entity.Property(e => e.AccUid).HasColumnName("ACC_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.CityUid).HasColumnName("CITY_UID");
            entity.Property(e => e.CntUid).HasColumnName("CNT_UID");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.AccClbTypU).WithMany(p => p.AccountClubs)
                .HasForeignKey(d => d.AccClbTypUid)
                .HasConstraintName("FK_AccountClub_AccountClubType");

            entity.HasOne(d => d.AccFrContractNavigation).WithMany(p => p.AccountClubs)
                .HasForeignKey(d => d.AccFrContract)
                .HasConstraintName("FK_AccountClub_Contract");

            entity.HasOne(d => d.AccFrJobNavigation).WithMany(p => p.AccountClubs)
                .HasForeignKey(d => d.AccFrJob)
                .HasConstraintName("FK_AccountClub_Jobs");

            entity.HasOne(d => d.AccU).WithMany(p => p.AccountClubs)
                .HasForeignKey(d => d.AccUid)
                .HasConstraintName("FK_AccountClub_Account");
        });

        modelBuilder.Entity<AccountClubCard>(entity =>
        {
            entity.HasKey(e => e.AccId);

            entity.ToTable("AccountClubCard");

            entity.Property(e => e.AccId).HasColumnName("ACC_ID");
            entity.Property(e => e.AccCardSerial)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ACC_CARD_SERIAL");
            entity.Property(e => e.AccCreateOn)
                .HasColumnType("date")
                .HasColumnName("ACC_CREATE_ON");
            entity.Property(e => e.AccDesc)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("ACC_DESC");
            entity.Property(e => e.AccFrAccountclub).HasColumnName("ACC_FR_ACCOUNTCLUB");
            entity.Property(e => e.AccFrCreateBy).HasColumnName("ACC_FR_CREATE_BY");
            entity.Property(e => e.AccType).HasColumnName("ACC_TYPE");

            entity.HasOne(d => d.AccFrAccountclubNavigation).WithMany(p => p.AccountClubCards)
                .HasForeignKey(d => d.AccFrAccountclub)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountClubCard_AccountClub");

            entity.HasOne(d => d.AccFrCreateByNavigation).WithMany(p => p.AccountClubCards)
                .HasForeignKey(d => d.AccFrCreateBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountClubCard_SystemUsers");
        });

        modelBuilder.Entity<AccountClubPhoto>(entity =>
        {
            entity.HasKey(e => e.AccPhtUid);

            entity.ToTable("AccountClubPhoto");

            entity.Property(e => e.AccPhtUid)
                .ValueGeneratedNever()
                .HasColumnName("ACC_PHT_UID");
            entity.Property(e => e.AccClbUid).HasColumnName("ACC_CLB_UID");
            entity.Property(e => e.AccPhtCode)
                .HasMaxLength(150)
                .HasColumnName("ACC_PHT_CODE");
            entity.Property(e => e.AccPhtName)
                .HasMaxLength(150)
                .HasColumnName("ACC_PHT_NAME");
            entity.Property(e => e.AccPhtPath)
                .HasMaxLength(500)
                .HasColumnName("ACC_PHT_PATH");
            entity.Property(e => e.AccPhtStatus).HasColumnName("ACC_PHT_STATUS");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<AccountClubType>(entity =>
        {
            entity.HasKey(e => e.AccClbTypUid);

            entity.ToTable("AccountClubType");

            entity.Property(e => e.AccClbTypUid)
                .ValueGeneratedNever()
                .HasColumnName("ACC_CLB_TYP_UID");
            entity.Property(e => e.AccClbTypDefaultPriceInvoice).HasColumnName("ACC_CLB_TYP_DEFAULT_PRICE_INVOICE");
            entity.Property(e => e.AccClbTypDetDiscount)
                .HasDefaultValueSql("((0))")
                .HasColumnName("ACC_CLB_TYP_DET_DISCOUNT");
            entity.Property(e => e.AccClbTypDiscountType)
                .HasDefaultValueSql("((0))")
                .HasColumnName("ACC_CLB_TYP_DISCOUNT_TYPE");
            entity.Property(e => e.AccClbTypName)
                .HasMaxLength(150)
                .HasColumnName("ACC_CLB_TYP_NAME");
            entity.Property(e => e.AccClbTypPercentDiscount)
                .HasDefaultValueSql("((0))")
                .HasColumnName("ACC_CLB_TYP_PERCENT_DISCOUNT");
            entity.Property(e => e.AccClbTypStatus).HasColumnName("ACC_CLB_TYP_STATUS");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<AccountLevel>(entity =>
        {
            entity.HasKey(e => e.AccLvlUid);

            entity.ToTable("AccountLevel");

            entity.Property(e => e.AccLvlUid)
                .ValueGeneratedNever()
                .HasColumnName("ACC_LVL_UID");
            entity.Property(e => e.AccLvlCode)
                .HasMaxLength(50)
                .HasColumnName("ACC_LVL_CODE");
            entity.Property(e => e.AccLvlFrGuid).HasColumnName("ACC_LVL_FR_GUID");
            entity.Property(e => e.AccLvlName)
                .HasMaxLength(100)
                .HasColumnName("ACC_LVL_NAME");
            entity.Property(e => e.AccLvlParentUid).HasColumnName("ACC_LVL_PARENT_UID");
            entity.Property(e => e.AccLvlStatus).HasColumnName("ACC_LVL_STATUS");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.FisPeriodU).WithMany(p => p.AccountLevels)
                .HasForeignKey(d => d.FisPeriodUid)
                .HasConstraintName("FK_AccountLevel_FiscalPeriod");
        });

        modelBuilder.Entity<AccountRating>(entity =>
        {
            entity.HasKey(e => e.AccRateUid);

            entity.ToTable("AccountRating");

            entity.Property(e => e.AccRateUid)
                .ValueGeneratedNever()
                .HasColumnName("ACC_RATE_UID");
            entity.Property(e => e.AccRateEndScore).HasColumnName("ACC_RATE_END_SCORE");
            entity.Property(e => e.AccRateName)
                .HasMaxLength(100)
                .HasColumnName("ACC_RATE_NAME");
            entity.Property(e => e.AccRatePriority).HasColumnName("ACC_RATE_PRIORITY");
            entity.Property(e => e.AccRateStartScore).HasColumnName("ACC_RATE_START_SCORE");
            entity.Property(e => e.AccRateStatus).HasColumnName("ACC_RATE_STATUS");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.BusUnitU).WithMany(p => p.AccountRatings)
                .HasForeignKey(d => d.BusUnitUid)
                .HasConstraintName("FK_AccountRating_BusinessUnits");
        });

        modelBuilder.Entity<AccountRemainCredit>(entity =>
        {
            entity.HasKey(e => e.AccRemCrtUid);

            entity.Property(e => e.AccRemCrtUid)
                .ValueGeneratedNever()
                .HasColumnName("ACC_REM_CRT_UID");
            entity.Property(e => e.AccRemCrtRemainCredit)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ACC_REM_CRT_REMAIN_CREDIT");
            entity.Property(e => e.AccRemCrtStatus).HasColumnName("ACC_REM_CRT_STATUS");
            entity.Property(e => e.AccUid).HasColumnName("ACC_UID");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.AccU).WithMany(p => p.AccountRemainCredits)
                .HasForeignKey(d => d.AccUid)
                .HasConstraintName("FK_AccountRemainCredits_Account");
        });

        modelBuilder.Entity<AccountType>(entity =>
        {
            entity.HasKey(e => e.AccTypUid);

            entity.ToTable("AccountType", tb => tb.HasTrigger("trgForInsertAccountType"));

            entity.Property(e => e.AccTypUid)
                .ValueGeneratedNever()
                .HasColumnName("ACC_TYP_UID");
            entity.Property(e => e.AccTypName)
                .HasMaxLength(100)
                .HasColumnName("ACC_TYP_NAME");
            entity.Property(e => e.AccTypStatus).HasColumnName("ACC_TYP_STATUS");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<Agreement>(entity =>
        {
            entity.HasKey(e => e.AgtUid);

            entity.ToTable("Agreement");

            entity.Property(e => e.AgtUid)
                .ValueGeneratedNever()
                .HasColumnName("AGT_UID");
            entity.Property(e => e.AccUidBuyer).HasColumnName("ACC_UID_BUYER");
            entity.Property(e => e.AccUidSeller).HasColumnName("ACC_UID_SELLER");
            entity.Property(e => e.AgtAdvisorBuyerPrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("AGT_ADVISOR_BUYER_PRICE");
            entity.Property(e => e.AgtAdvisorDescribtion).HasColumnName("AGT_ADVISOR_DESCRIBTION");
            entity.Property(e => e.AgtAdvisorNumberCertificate)
                .HasMaxLength(50)
                .HasColumnName("AGT_ADVISOR_NUMBER_CERTIFICATE");
            entity.Property(e => e.AgtAdvisorSellerPrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("AGT_ADVISOR_SELLER_PRICE");
            entity.Property(e => e.AgtAdvisorTaxPrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("AGT_ADVISOR_TAX_PRICE");
            entity.Property(e => e.AgtCauseBuyer)
                .HasMaxLength(100)
                .HasColumnName("AGT_CAUSE_BUYER");
            entity.Property(e => e.AgtCauseCar)
                .HasMaxLength(100)
                .HasColumnName("AGT_CAUSE_CAR");
            entity.Property(e => e.AgtCauseSeller)
                .HasMaxLength(100)
                .HasColumnName("AGT_CAUSE_SELLER");
            entity.Property(e => e.AgtCurrentDate)
                .HasColumnType("datetime")
                .HasColumnName("AGT_CURRENT_DATE");
            entity.Property(e => e.AgtDamagePrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("AGT_DAMAGE_PRICE");
            entity.Property(e => e.AgtDamageSellerPrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("AGT_DAMAGE_SELLER_PRICE");
            entity.Property(e => e.AgtDamageTransferDocument)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("AGT_DAMAGE_TRANSFER_DOCUMENT");
            entity.Property(e => e.AgtDate)
                .HasMaxLength(300)
                .HasColumnName("AGT_DATE");
            entity.Property(e => e.AgtDescribtion).HasColumnName("AGT_DESCRIBTION");
            entity.Property(e => e.AgtDueDate)
                .HasColumnType("datetime")
                .HasColumnName("AGT_DUE_DATE");
            entity.Property(e => e.AgtDueTime)
                .HasMaxLength(300)
                .HasColumnName("AGT_DUE_TIME");
            entity.Property(e => e.AgtEndDate)
                .HasColumnType("datetime")
                .HasColumnName("AGT_END_DATE");
            entity.Property(e => e.AgtFromBuyer)
                .HasMaxLength(100)
                .HasColumnName("AGT_FROM_BUYER");
            entity.Property(e => e.AgtFromSeller)
                .HasMaxLength(100)
                .HasColumnName("AGT_FROM_SELLER");
            entity.Property(e => e.AgtKind).HasColumnName("AGT_KIND");
            entity.Property(e => e.AgtNumberInstallment)
                .HasMaxLength(10)
                .HasColumnName("AGT_NUMBER_INSTALLMENT");
            entity.Property(e => e.AgtOfficialAddressDocument).HasColumnName("AGT_OFFICIAL_ADDRESS_DOCUMENT");
            entity.Property(e => e.AgtOfficialDocumentNumber)
                .HasMaxLength(50)
                .HasColumnName("AGT_OFFICIAL_DOCUMENT_NUMBER");
            entity.Property(e => e.AgtOtherDueDate)
                .HasColumnType("datetime")
                .HasColumnName("AGT_OTHER_DUE_DATE");
            entity.Property(e => e.AgtOtherPrice)
                .HasMaxLength(500)
                .HasColumnName("AGT_OTHER_PRICE");
            entity.Property(e => e.AgtRemainPrice)
                .HasMaxLength(500)
                .HasColumnName("AGT_REMAIN_PRICE");
            entity.Property(e => e.AgtRemainRentPrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("AGT_REMAIN_RENT_PRICE");
            entity.Property(e => e.AgtSectionedPrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("AGT_SECTIONED_PRICE");
            entity.Property(e => e.AgtSerialNumber)
                .HasMaxLength(50)
                .HasColumnName("AGT_SERIAL_NUMBER");
            entity.Property(e => e.AgtSetDocumentDate)
                .HasColumnType("datetime")
                .HasColumnName("AGT_SET_DOCUMENT_DATE");
            entity.Property(e => e.AgtStartDate)
                .HasColumnType("datetime")
                .HasColumnName("AGT_START_DATE");
            entity.Property(e => e.AgtStatus).HasColumnName("AGT_STATUS");
            entity.Property(e => e.AgtTaxName).HasColumnName("AGT_TAX_NAME");
            entity.Property(e => e.AgtTime)
                .HasMaxLength(50)
                .HasColumnName("AGT_TIME");
            entity.Property(e => e.AgtTimeRent)
                .HasMaxLength(10)
                .HasColumnName("AGT_TIME_RENT");
            entity.Property(e => e.AgtTimeRentPrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("AGT_TIME_RENT_PRICE");
            entity.Property(e => e.AgtToneCar)
                .HasMaxLength(50)
                .HasColumnName("AGT_TONE_CAR");
            entity.Property(e => e.AgtType).HasColumnName("AGT_TYPE");
            entity.Property(e => e.AgtYearMonth).HasColumnName("AGT_YEAR_MONTH");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.CarUid).HasColumnName("CAR_UID");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
            entity.Property(e => e.TaxUid).HasColumnName("TAX_UID");

            entity.HasOne(d => d.AccUidBuyerNavigation).WithMany(p => p.AgreementAccUidBuyerNavigations)
                .HasForeignKey(d => d.AccUidBuyer)
                .HasConstraintName("FK_Agreement_Account1");

            entity.HasOne(d => d.AccUidSellerNavigation).WithMany(p => p.AgreementAccUidSellerNavigations)
                .HasForeignKey(d => d.AccUidSeller)
                .HasConstraintName("FK_Agreement_Account");

            entity.HasOne(d => d.BusUnitU).WithMany(p => p.Agreements)
                .HasForeignKey(d => d.BusUnitUid)
                .HasConstraintName("FK_Agreement_BusinessUnits");

            entity.HasOne(d => d.CarU).WithMany(p => p.Agreements)
                .HasForeignKey(d => d.CarUid)
                .HasConstraintName("FK_Agreement_Car");

            entity.HasOne(d => d.TaxU).WithMany(p => p.Agreements)
                .HasForeignKey(d => d.TaxUid)
                .HasConstraintName("FK_Agreement_Tax");
        });

        modelBuilder.Entity<AgreementAtelier>(entity =>
        {
            entity.HasKey(e => e.AgtAtlUid);

            entity.ToTable("AgreementAtelier");

            entity.HasIndex(e => e.AccClbUid, "IX_ACC_CLB_UID");

            entity.HasIndex(e => e.AgtAtlSerialNumber, "IX_AGT_ATL_SERIAL_NUMBER");

            entity.HasIndex(e => e.SysUsrCreatedon, "IX_SYS_USR_CREATEDON");

            entity.Property(e => e.AgtAtlUid)
                .ValueGeneratedNever()
                .HasColumnName("AGT_ATL_UID");
            entity.Property(e => e.AccClbUid).HasColumnName("ACC_CLB_UID");
            entity.Property(e => e.AccUid).HasColumnName("ACC_UID");
            entity.Property(e => e.AgtAtlAdditionalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("AGT_ATL_ADDITIONAL_AMOUNT");
            entity.Property(e => e.AgtAtlArchive).HasColumnName("AGT_ATL_ARCHIVE");
            entity.Property(e => e.AgtAtlArchiveAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("AGT_ATL_ARCHIVE_AMOUNT");
            entity.Property(e => e.AgtAtlBrideHairdresserAddress).HasColumnName("AGT_ATL_BRIDE_HAIRDRESSER_ADDRESS");
            entity.Property(e => e.AgtAtlBrideHomeAddress).HasColumnName("AGT_ATL_BRIDE_HOME_ADDRESS");
            entity.Property(e => e.AgtAtlBrideHomeMobile)
                .HasMaxLength(25)
                .HasColumnName("AGT_ATL_BRIDE_HOME_MOBILE");
            entity.Property(e => e.AgtAtlBrideHomePhone)
                .HasMaxLength(25)
                .HasColumnName("AGT_ATL_BRIDE_HOME_PHONE");
            entity.Property(e => e.AgtAtlBuyer)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_BUYER");
            entity.Property(e => e.AgtAtlCelebrationDate)
                .HasColumnType("datetime")
                .HasColumnName("AGT_ATL_CELEBRATION_DATE");
            entity.Property(e => e.AgtAtlCelebrationType)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_CELEBRATION_TYPE");
            entity.Property(e => e.AgtAtlCurrentDate)
                .HasColumnType("datetime")
                .HasColumnName("AGT_ATL_CURRENT_DATE");
            entity.Property(e => e.AgtAtlCustomerFilmOk)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_CUSTOMER_FILM_OK");
            entity.Property(e => e.AgtAtlCustomerOk)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_CUSTOMER_OK");
            entity.Property(e => e.AgtAtlDateOfBirthChild)
                .HasColumnType("datetime")
                .HasColumnName("AGT_ATL_DATE_OF_BIRTH_CHILD");
            entity.Property(e => e.AgtAtlDeliverer)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_DELIVERER");
            entity.Property(e => e.AgtAtlDelivererUid).HasColumnName("AGT_ATL_DELIVERER_UID");
            entity.Property(e => e.AgtAtlDeliveryDate)
                .HasColumnType("datetime")
                .HasColumnName("AGT_ATL_DELIVERY_DATE");
            entity.Property(e => e.AgtAtlDescribtion)
                .HasMaxLength(4000)
                .HasColumnName("AGT_ATL_DESCRIBTION");
            entity.Property(e => e.AgtAtlDesignedBuyer)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_DESIGNED_BUYER");
            entity.Property(e => e.AgtAtlDesignedDate)
                .HasColumnType("datetime")
                .HasColumnName("AGT_ATL_DESIGNED_DATE");
            entity.Property(e => e.AgtAtlDesigner)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_DESIGNER");
            entity.Property(e => e.AgtAtlDesignerUid).HasColumnName("AGT_ATL_DESIGNER_UID");
            entity.Property(e => e.AgtAtlDesigningDueDate)
                .HasColumnType("datetime")
                .HasColumnName("AGT_ATL_DESIGNING_DUE_DATE");
            entity.Property(e => e.AgtAtlDesigningEndDate)
                .HasColumnType("datetime")
                .HasColumnName("AGT_ATL_DESIGNING_END_DATE");
            entity.Property(e => e.AgtAtlDesigningOkAnswerable)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_DESIGNING_OK_ANSWERABLE");
            entity.Property(e => e.AgtAtlDesigningOkAnswerableUid).HasColumnName("AGT_ATL_DESIGNING_OK_ANSWERABLE_UID");
            entity.Property(e => e.AgtAtlEndTime)
                .HasMaxLength(8)
                .HasColumnName("AGT_ATL_END_TIME");
            entity.Property(e => e.AgtAtlFinalDeliveryDate)
                .HasColumnType("datetime")
                .HasColumnName("AGT_ATL_FINAL_DELIVERY_DATE");
            entity.Property(e => e.AgtAtlFlowerShopAddress).HasColumnName("AGT_ATL_FLOWER_SHOP_ADDRESS");
            entity.Property(e => e.AgtAtlGroomHomeAddress).HasColumnName("AGT_ATL_GROOM_HOME_ADDRESS");
            entity.Property(e => e.AgtAtlGroomHomeMobile)
                .HasMaxLength(25)
                .HasColumnName("AGT_ATL_GROOM_HOME_MOBILE");
            entity.Property(e => e.AgtAtlGroomHomePhone)
                .HasMaxLength(25)
                .HasColumnName("AGT_ATL_GROOM_HOME_PHONE");
            entity.Property(e => e.AgtAtlKind).HasColumnName("AGT_ATL_KIND");
            entity.Property(e => e.AgtAtlMajlesAddress).HasColumnName("AGT_ATL_MAJLES_ADDRESS");
            entity.Property(e => e.AgtAtlName)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_NAME");
            entity.Property(e => e.AgtAtlPayRciptSheetUid).HasColumnName("AGT_ATL_PAY_RCIPT_SHEET_UID");
            entity.Property(e => e.AgtAtlPhotoCount).HasColumnName("AGT_ATL_PHOTO_COUNT");
            entity.Property(e => e.AgtAtlPhotographer)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_PHOTOGRAPHER");
            entity.Property(e => e.AgtAtlPhotographerUid).HasColumnName("AGT_ATL_PHOTOGRAPHER_UID");
            entity.Property(e => e.AgtAtlPrintSendDate)
                .HasColumnType("datetime")
                .HasColumnName("AGT_ATL_PRINT_SEND_DATE");
            entity.Property(e => e.AgtAtlPrintSender)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_PRINT_SENDER");
            entity.Property(e => e.AgtAtlPrintSenderUid).HasColumnName("AGT_ATL_PRINT_SENDER_UID");
            entity.Property(e => e.AgtAtlSelectionAnswerable)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_SELECTION_ANSWERABLE");
            entity.Property(e => e.AgtAtlSelectionAnswerableUid).HasColumnName("AGT_ATL_SELECTION_ANSWERABLE_UID");
            entity.Property(e => e.AgtAtlSerialNumber)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_SERIAL_NUMBER");
            entity.Property(e => e.AgtAtlStartTime)
                .HasMaxLength(8)
                .HasColumnName("AGT_ATL_START_TIME");
            entity.Property(e => e.AgtAtlStatus).HasColumnName("AGT_ATL_STATUS");
            entity.Property(e => e.AgtAtlType).HasColumnName("AGT_ATL_TYPE");
            entity.Property(e => e.AtlCatUid).HasColumnName("ATL_CAT_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.InvUidFilm).HasColumnName("INV_UID_FILM");
            entity.Property(e => e.InvUidPhoto).HasColumnName("INV_UID_PHOTO");
            entity.Property(e => e.InvUidService).HasColumnName("INV_UID_SERVICE");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<AgreementAtelierLog>(entity =>
        {
            entity.HasKey(e => e.AgtAtlLogUid);

            entity.ToTable("AgreementAtelierLog");

            entity.HasIndex(e => e.AgtAtlLogIdentity, "IX_AgreementAtelierLog");

            entity.Property(e => e.AgtAtlLogUid)
                .ValueGeneratedNever()
                .HasColumnName("AGT_ATL_LOG_UID");
            entity.Property(e => e.AccClbUid).HasColumnName("ACC_CLB_UID");
            entity.Property(e => e.AccUid).HasColumnName("ACC_UID");
            entity.Property(e => e.AgtAtlAdditionalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("AGT_ATL_ADDITIONAL_AMOUNT");
            entity.Property(e => e.AgtAtlArchive).HasColumnName("AGT_ATL_ARCHIVE");
            entity.Property(e => e.AgtAtlArchiveAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("AGT_ATL_ARCHIVE_AMOUNT");
            entity.Property(e => e.AgtAtlBrideHairdresserAddress).HasColumnName("AGT_ATL_BRIDE_HAIRDRESSER_ADDRESS");
            entity.Property(e => e.AgtAtlBrideHomeAddress).HasColumnName("AGT_ATL_BRIDE_HOME_ADDRESS");
            entity.Property(e => e.AgtAtlBrideHomeMobile)
                .HasMaxLength(25)
                .HasColumnName("AGT_ATL_BRIDE_HOME_MOBILE");
            entity.Property(e => e.AgtAtlBrideHomePhone)
                .HasMaxLength(25)
                .HasColumnName("AGT_ATL_BRIDE_HOME_PHONE");
            entity.Property(e => e.AgtAtlBuyer)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_BUYER");
            entity.Property(e => e.AgtAtlCelebrationDate)
                .HasColumnType("datetime")
                .HasColumnName("AGT_ATL_CELEBRATION_DATE");
            entity.Property(e => e.AgtAtlCelebrationType)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_CELEBRATION_TYPE");
            entity.Property(e => e.AgtAtlCurrentDate)
                .HasColumnType("datetime")
                .HasColumnName("AGT_ATL_CURRENT_DATE");
            entity.Property(e => e.AgtAtlCustomerFilmOk)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_CUSTOMER_FILM_OK");
            entity.Property(e => e.AgtAtlCustomerOk)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_CUSTOMER_OK");
            entity.Property(e => e.AgtAtlDateOfBirthChild)
                .HasColumnType("datetime")
                .HasColumnName("AGT_ATL_DATE_OF_BIRTH_CHILD");
            entity.Property(e => e.AgtAtlDeliverer)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_DELIVERER");
            entity.Property(e => e.AgtAtlDelivererUid).HasColumnName("AGT_ATL_DELIVERER_UID");
            entity.Property(e => e.AgtAtlDeliveryDate)
                .HasColumnType("datetime")
                .HasColumnName("AGT_ATL_DELIVERY_DATE");
            entity.Property(e => e.AgtAtlDescribtion)
                .HasMaxLength(4000)
                .HasColumnName("AGT_ATL_DESCRIBTION");
            entity.Property(e => e.AgtAtlDesignedBuyer)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_DESIGNED_BUYER");
            entity.Property(e => e.AgtAtlDesignedDate)
                .HasColumnType("datetime")
                .HasColumnName("AGT_ATL_DESIGNED_DATE");
            entity.Property(e => e.AgtAtlDesigner)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_DESIGNER");
            entity.Property(e => e.AgtAtlDesignerUid).HasColumnName("AGT_ATL_DESIGNER_UID");
            entity.Property(e => e.AgtAtlDesigningDueDate)
                .HasColumnType("datetime")
                .HasColumnName("AGT_ATL_DESIGNING_DUE_DATE");
            entity.Property(e => e.AgtAtlDesigningEndDate)
                .HasColumnType("datetime")
                .HasColumnName("AGT_ATL_DESIGNING_END_DATE");
            entity.Property(e => e.AgtAtlDesigningOkAnswerable)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_DESIGNING_OK_ANSWERABLE");
            entity.Property(e => e.AgtAtlDesigningOkAnswerableUid).HasColumnName("AGT_ATL_DESIGNING_OK_ANSWERABLE_UID");
            entity.Property(e => e.AgtAtlEndTime)
                .HasMaxLength(8)
                .HasColumnName("AGT_ATL_END_TIME");
            entity.Property(e => e.AgtAtlFinalDeliveryDate)
                .HasColumnType("datetime")
                .HasColumnName("AGT_ATL_FINAL_DELIVERY_DATE");
            entity.Property(e => e.AgtAtlFlowerShopAddress).HasColumnName("AGT_ATL_FLOWER_SHOP_ADDRESS");
            entity.Property(e => e.AgtAtlGroomHomeAddress).HasColumnName("AGT_ATL_GROOM_HOME_ADDRESS");
            entity.Property(e => e.AgtAtlGroomHomeMobile)
                .HasMaxLength(25)
                .HasColumnName("AGT_ATL_GROOM_HOME_MOBILE");
            entity.Property(e => e.AgtAtlGroomHomePhone)
                .HasMaxLength(25)
                .HasColumnName("AGT_ATL_GROOM_HOME_PHONE");
            entity.Property(e => e.AgtAtlKind).HasColumnName("AGT_ATL_KIND");
            entity.Property(e => e.AgtAtlLogIdentity)
                .ValueGeneratedOnAdd()
                .HasColumnName("AGT_ATL_LOG_IDENTITY");
            entity.Property(e => e.AgtAtlMajlesAddress).HasColumnName("AGT_ATL_MAJLES_ADDRESS");
            entity.Property(e => e.AgtAtlName)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_NAME");
            entity.Property(e => e.AgtAtlPayRciptSheetUid).HasColumnName("AGT_ATL_PAY_RCIPT_SHEET_UID");
            entity.Property(e => e.AgtAtlPhotoCount).HasColumnName("AGT_ATL_PHOTO_COUNT");
            entity.Property(e => e.AgtAtlPhotographer)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_PHOTOGRAPHER");
            entity.Property(e => e.AgtAtlPhotographerUid).HasColumnName("AGT_ATL_PHOTOGRAPHER_UID");
            entity.Property(e => e.AgtAtlPrint).HasColumnName("AGT_ATL_PRINT");
            entity.Property(e => e.AgtAtlPrintSendDate)
                .HasColumnType("datetime")
                .HasColumnName("AGT_ATL_PRINT_SEND_DATE");
            entity.Property(e => e.AgtAtlPrintSender)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_PRINT_SENDER");
            entity.Property(e => e.AgtAtlPrintSenderUid).HasColumnName("AGT_ATL_PRINT_SENDER_UID");
            entity.Property(e => e.AgtAtlSave).HasColumnName("AGT_ATL_SAVE");
            entity.Property(e => e.AgtAtlSelectionAnswerable)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_SELECTION_ANSWERABLE");
            entity.Property(e => e.AgtAtlSelectionAnswerableUid).HasColumnName("AGT_ATL_SELECTION_ANSWERABLE_UID");
            entity.Property(e => e.AgtAtlSerialNumber)
                .HasMaxLength(50)
                .HasColumnName("AGT_ATL_SERIAL_NUMBER");
            entity.Property(e => e.AgtAtlStartTime)
                .HasMaxLength(8)
                .HasColumnName("AGT_ATL_START_TIME");
            entity.Property(e => e.AgtAtlStatus).HasColumnName("AGT_ATL_STATUS");
            entity.Property(e => e.AgtAtlType).HasColumnName("AGT_ATL_TYPE");
            entity.Property(e => e.AgtAtlUid).HasColumnName("AGT_ATL_UID");
            entity.Property(e => e.AtlCatUid).HasColumnName("ATL_CAT_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.InvUidFilm).HasColumnName("INV_UID_FILM");
            entity.Property(e => e.InvUidPhoto).HasColumnName("INV_UID_PHOTO");
            entity.Property(e => e.InvUidService).HasColumnName("INV_UID_SERVICE");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<AtelierCategory>(entity =>
        {
            entity.HasKey(e => e.AtlCatUid);

            entity.ToTable("AtelierCategory");

            entity.Property(e => e.AtlCatUid)
                .ValueGeneratedNever()
                .HasColumnName("ATL_CAT_UID");
            entity.Property(e => e.AtlCatCode)
                .HasMaxLength(50)
                .HasColumnName("ATL_CAT_CODE");
            entity.Property(e => e.AtlCatName)
                .HasMaxLength(100)
                .HasColumnName("ATL_CAT_NAME");
            entity.Property(e => e.AtlCatStatus).HasColumnName("ATL_CAT_STATUS");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<Bank>(entity =>
        {
            entity.HasKey(e => e.BankUid);

            entity.ToTable("Bank");

            entity.Property(e => e.BankUid)
                .ValueGeneratedNever()
                .HasColumnName("BANK_UID");
            entity.Property(e => e.AccUid).HasColumnName("ACC_UID");
            entity.Property(e => e.BankActive)
                .HasDefaultValueSql("((1))")
                .HasColumnName("BANK_ACTIVE");
            entity.Property(e => e.BankCode)
                .HasMaxLength(50)
                .HasColumnName("BANK_CODE");
            entity.Property(e => e.BankName)
                .HasMaxLength(100)
                .HasColumnName("BANK_NAME");
            entity.Property(e => e.BankStatus).HasColumnName("BANK_STATUS");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<Barcode>(entity =>
        {
            entity.HasKey(e => e.BarUid);

            entity.ToTable("Barcode");

            entity.Property(e => e.BarUid)
                .ValueGeneratedNever()
                .HasColumnName("BAR_UID");
            entity.Property(e => e.BarBarcode)
                .HasMaxLength(50)
                .HasColumnName("BAR_BARCODE");
            entity.Property(e => e.BarStatus).HasColumnName("BAR_STATUS");
            entity.Property(e => e.PrdUid).HasColumnName("PRD_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.PrdU).WithMany(p => p.Barcodes)
                .HasForeignKey(d => d.PrdUid)
                .HasConstraintName("FK_Barcode_Product");
        });

        modelBuilder.Entity<BusinessUnit>(entity =>
        {
            entity.HasKey(e => e.BusUnitUid);

            entity.Property(e => e.BusUnitUid)
                .ValueGeneratedNever()
                .HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.BusUnitAddress).HasColumnName("BUS_UNIT_ADDRESS");
            entity.Property(e => e.BusUnitBriefname)
                .HasMaxLength(100)
                .HasColumnName("BUS_UNIT_BRIEFNAME");
            entity.Property(e => e.BusUnitEconomicCode)
                .HasMaxLength(20)
                .HasColumnName("BUS_UNIT_ECONOMIC_CODE");
            entity.Property(e => e.BusUnitEmail)
                .HasMaxLength(50)
                .HasColumnName("BUS_UNIT_EMAIL");
            entity.Property(e => e.BusUnitFax1)
                .HasMaxLength(20)
                .HasColumnName("BUS_UNIT_FAX1");
            entity.Property(e => e.BusUnitFax2)
                .HasMaxLength(20)
                .HasColumnName("BUS_UNIT_FAX2");
            entity.Property(e => e.BusUnitId)
                .HasMaxLength(20)
                .HasColumnName("BUS_UNIT_ID");
            entity.Property(e => e.BusUnitName)
                .HasMaxLength(100)
                .HasColumnName("BUS_UNIT_NAME");
            entity.Property(e => e.BusUnitPhone1)
                .HasMaxLength(20)
                .HasColumnName("BUS_UNIT_PHONE1");
            entity.Property(e => e.BusUnitPhone2)
                .HasMaxLength(20)
                .HasColumnName("BUS_UNIT_PHONE2");
            entity.Property(e => e.BusUnitRegistrationNumber)
                .HasMaxLength(20)
                .HasColumnName("BUS_UNIT_REGISTRATION_NUMBER");
            entity.Property(e => e.BusUnitStatus).HasColumnName("BUS_UNIT_STATUS");
            entity.Property(e => e.BusUnitTypUid).HasColumnName("BUS_UNIT_TYP_UID");
            entity.Property(e => e.BusUnitWebsite)
                .HasMaxLength(50)
                .HasColumnName("BUS_UNIT_WEBSITE");
            entity.Property(e => e.BusUnitZipCode)
                .HasMaxLength(10)
                .HasColumnName("BUS_UNIT_ZIP_CODE");
            entity.Property(e => e.CityUid).HasColumnName("CITY_UID");
            entity.Property(e => e.LangUid).HasColumnName("LANG_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.BusUnitTypU).WithMany(p => p.BusinessUnits)
                .HasForeignKey(d => d.BusUnitTypUid)
                .HasConstraintName("FK_BusinessUnits_BusinessUnitType");

            entity.HasOne(d => d.CityU).WithMany(p => p.BusinessUnits)
                .HasForeignKey(d => d.CityUid)
                .HasConstraintName("FK_BusinessUnits_City");

            entity.HasOne(d => d.Lan).WithMany(p => p.BusinessUnits)
                .HasForeignKey(d => d.LangUid)
                .HasConstraintName("FK_BusinessUnits_Language");
        });

        modelBuilder.Entity<BusinessUnitType>(entity =>
        {
            entity.HasKey(e => e.BusUnitTypUid);

            entity.ToTable("BusinessUnitType", tb => tb.HasTrigger("trgForInsertBusinessUnitType"));

            entity.Property(e => e.BusUnitTypUid)
                .ValueGeneratedNever()
                .HasColumnName("BUS_UNIT_TYP_UID");
            entity.Property(e => e.BusUnitTypCreatedby).HasColumnName("BUS_UNIT_TYP_CREATEDBY");
            entity.Property(e => e.BusUnitTypCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("BUS_UNIT_TYP_CREATEDON");
            entity.Property(e => e.BusUnitTypModifiedby).HasColumnName("BUS_UNIT_TYP_MODIFIEDBY");
            entity.Property(e => e.BusUnitTypModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("BUS_UNIT_TYP_MODIFIEDON");
            entity.Property(e => e.BusUnitTypName)
                .HasMaxLength(100)
                .HasColumnName("BUS_UNIT_TYP_NAME");
            entity.Property(e => e.BusUnitTypStatus).HasColumnName("BUS_UNIT_TYP_STATUS");
        });

        modelBuilder.Entity<Calender>(entity =>
        {
            entity.HasKey(e => e.ClrId);

            entity.ToTable("Calender");

            entity.Property(e => e.ClrId)
                .ValueGeneratedNever()
                .HasColumnName("CLR_ID");
            entity.Property(e => e.ClrDate)
                .HasColumnType("date")
                .HasColumnName("CLR_DATE");
            entity.Property(e => e.ClrFrAccountclub).HasColumnName("CLR_FR_ACCOUNTCLUB");
            entity.Property(e => e.ClrFrContract).HasColumnName("CLR_FR_CONTRACT");
            entity.Property(e => e.ClrFrSalon).HasColumnName("CLR_FR_SALON");
            entity.Property(e => e.ClrFrShifts).HasColumnName("CLR_FR_SHIFTS");
            entity.Property(e => e.ClrGender).HasColumnName("CLR_GENDER");
            entity.Property(e => e.ClrReserveType).HasColumnName("CLR_RESERVE_TYPE");

            entity.HasOne(d => d.ClrFrAccountclubNavigation).WithMany(p => p.Calenders)
                .HasForeignKey(d => d.ClrFrAccountclub)
                .HasConstraintName("FK_Calender_AccountClub");

            entity.HasOne(d => d.ClrFrContractNavigation).WithMany(p => p.Calenders)
                .HasForeignKey(d => d.ClrFrContract)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calender_Contract");

            entity.HasOne(d => d.ClrFrSalonNavigation).WithMany(p => p.Calenders)
                .HasForeignKey(d => d.ClrFrSalon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calender_Salon");

            entity.HasOne(d => d.ClrFrShiftsNavigation).WithMany(p => p.Calenders)
                .HasForeignKey(d => d.ClrFrShifts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calender_Shifts");
        });

        modelBuilder.Entity<CalenderDetail>(entity =>
        {
            entity.HasKey(e => e.CdId);

            entity.ToTable("CalenderDetail");

            entity.Property(e => e.CdId)
                .ValueGeneratedNever()
                .HasColumnName("CD_ID");
            entity.Property(e => e.CdEndTime).HasColumnName("CD_END_TIME");
            entity.Property(e => e.CdFrAccountclub).HasColumnName("CD_FR_ACCOUNTCLUB");
            entity.Property(e => e.CdFrCalender).HasColumnName("CD_FR_CALENDER");
            entity.Property(e => e.CdFrCsp).HasColumnName("CD_FR_CSP");
            entity.Property(e => e.CdFrProduct).HasColumnName("CD_FR_PRODUCT");
            entity.Property(e => e.CdPersonelCommission)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("CD_PERSONEL_COMMISSION");
            entity.Property(e => e.CdPersonelPayment)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("CD_PERSONEL_PAYMENT");
            entity.Property(e => e.CdStartTime).HasColumnName("CD_START_TIME");

            entity.HasOne(d => d.CdFrAccountclubNavigation).WithMany(p => p.CalenderDetails)
                .HasForeignKey(d => d.CdFrAccountclub)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CalenderDetail_AccountClub");

            entity.HasOne(d => d.CdFrCalenderNavigation).WithMany(p => p.CalenderDetails)
                .HasForeignKey(d => d.CdFrCalender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CalenderDetail_Calender");

            entity.HasOne(d => d.CdFrCspNavigation).WithMany(p => p.CalenderDetails)
                .HasForeignKey(d => d.CdFrCsp)
                .HasConstraintName("FK_CalenderDetail_ContinuouseServicesPlaning");

            entity.HasOne(d => d.CdFrProductNavigation).WithMany(p => p.CalenderDetails)
                .HasForeignKey(d => d.CdFrProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CalenderDetail_Product");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.CarUid);

            entity.ToTable("Car");

            entity.Property(e => e.CarUid)
                .ValueGeneratedNever()
                .HasColumnName("CAR_UID");
            entity.Property(e => e.CarBrigade)
                .HasMaxLength(100)
                .HasColumnName("CAR_BRIGADE");
            entity.Property(e => e.CarCapacity)
                .HasMaxLength(50)
                .HasColumnName("CAR_CAPACITY");
            entity.Property(e => e.CarColor)
                .HasMaxLength(50)
                .HasColumnName("CAR_COLOR");
            entity.Property(e => e.CarDescribtion).HasColumnName("CAR_DESCRIBTION");
            entity.Property(e => e.CarFuelType)
                .HasMaxLength(50)
                .HasColumnName("CAR_FUEL_TYPE");
            entity.Property(e => e.CarModel)
                .HasMaxLength(50)
                .HasColumnName("CAR_MODEL");
            entity.Property(e => e.CarName)
                .HasMaxLength(100)
                .HasColumnName("CAR_NAME");
            entity.Property(e => e.CarNumberAxis)
                .HasMaxLength(50)
                .HasColumnName("CAR_NUMBER_AXIS");
            entity.Property(e => e.CarNumberChassis)
                .HasMaxLength(50)
                .HasColumnName("CAR_NUMBER_CHASSIS");
            entity.Property(e => e.CarNumberCylinder)
                .HasMaxLength(50)
                .HasColumnName("CAR_NUMBER_CYLINDER");
            entity.Property(e => e.CarNumberEngines)
                .HasMaxLength(50)
                .HasColumnName("CAR_NUMBER_ENGINES");
            entity.Property(e => e.CarNumberNaja)
                .HasMaxLength(50)
                .HasColumnName("CAR_NUMBER_NAJA");
            entity.Property(e => e.CarNumberWheel)
                .HasMaxLength(50)
                .HasColumnName("CAR_NUMBER_WHEEL");
            entity.Property(e => e.CarStatus).HasColumnName("CAR_STATUS");
            entity.Property(e => e.CarSystem)
                .HasMaxLength(100)
                .HasColumnName("CAR_SYSTEM");
            entity.Property(e => e.CarType)
                .HasMaxLength(100)
                .HasColumnName("CAR_TYPE");
            entity.Property(e => e.CarVin)
                .HasMaxLength(50)
                .HasColumnName("CAR_VIN");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<CardRechage>(entity =>
        {
            entity.HasKey(e => e.CrId);

            entity.ToTable("CardRechage");

            entity.Property(e => e.CrId)
                .ValueGeneratedNever()
                .HasColumnName("CR_ID");
            entity.Property(e => e.CrCreatedOn)
                .HasColumnType("date")
                .HasColumnName("CR_CREATED_ON");
            entity.Property(e => e.CrExpireDate)
                .HasColumnType("date")
                .HasColumnName("CR_EXPIRE_DATE");
            entity.Property(e => e.CrFrAccountclub).HasColumnName("CR_FR_ACCOUNTCLUB");
            entity.Property(e => e.CrFrContract).HasColumnName("CR_FR_CONTRACT");
            entity.Property(e => e.CrFrCreatedBy).HasColumnName("CR_FR_CREATED_BY");
            entity.Property(e => e.CrFrModifiedBy).HasColumnName("CR_FR_MODIFIED_BY");
            entity.Property(e => e.CrFrSalon).HasColumnName("CR_FR_SALON");
            entity.Property(e => e.CrModifiedOn)
                .HasColumnType("date")
                .HasColumnName("CR_MODIFIED_ON");
            entity.Property(e => e.CrRemaining)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("CR_REMAINING");
            entity.Property(e => e.CrStartDate)
                .HasColumnType("date")
                .HasColumnName("CR_START_DATE");
            entity.Property(e => e.CrStatus).HasColumnName("CR_STATUS");
            entity.Property(e => e.CrTransactionNum).HasColumnName("CR_TRANSACTION_NUM");

            entity.HasOne(d => d.CrFrAccountclubNavigation).WithMany(p => p.CardRechages)
                .HasForeignKey(d => d.CrFrAccountclub)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CardRechage_AccountClub");

            entity.HasOne(d => d.CrFrContractNavigation).WithMany(p => p.CardRechages)
                .HasForeignKey(d => d.CrFrContract)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CardRechage_Contract");

            entity.HasOne(d => d.CrFrCreatedByNavigation).WithMany(p => p.CardRechageCrFrCreatedByNavigations)
                .HasForeignKey(d => d.CrFrCreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CardRechage_SystemUsers_CreateBy");

            entity.HasOne(d => d.CrFrModifiedByNavigation).WithMany(p => p.CardRechageCrFrModifiedByNavigations)
                .HasForeignKey(d => d.CrFrModifiedBy)
                .HasConstraintName("FK_CardRechage_SystemUsers_ModifiedBy");

            entity.HasOne(d => d.CrFrSalonNavigation).WithMany(p => p.CardRechages)
                .HasForeignKey(d => d.CrFrSalon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CardRechage_Salon");
        });

        modelBuilder.Entity<Chequ>(entity =>
        {
            entity.ToTable("Chequ");

            entity.Property(e => e.CheqUid)
                .ValueGeneratedNever()
                .HasColumnName("CHEQ_UID");
            entity.Property(e => e.AccUid).HasColumnName("ACC_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.CheqFromSerialNo)
                .HasMaxLength(50)
                .HasColumnName("CHEQ_FROM_SERIAL_NO");
            entity.Property(e => e.CheqReceiptDate)
                .HasColumnType("datetime")
                .HasColumnName("CHEQ_RECEIPT_DATE");
            entity.Property(e => e.CheqSerialNo)
                .HasMaxLength(50)
                .HasColumnName("CHEQ_SERIAL_NO");
            entity.Property(e => e.CheqStatus).HasColumnName("CHEQ_STATUS");
            entity.Property(e => e.CheqToSerialNo)
                .HasMaxLength(50)
                .HasColumnName("CHEQ_TO_SERIAL_NO");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.AccU).WithMany(p => p.Chequs)
                .HasForeignKey(d => d.AccUid)
                .HasConstraintName("FK_Chequ_Account");

            entity.HasOne(d => d.BusUnitU).WithMany(p => p.Chequs)
                .HasForeignKey(d => d.BusUnitUid)
                .HasConstraintName("FK_Chequ_BusinessUnits");

            entity.HasOne(d => d.FisPeriodU).WithMany(p => p.Chequs)
                .HasForeignKey(d => d.FisPeriodUid)
                .HasConstraintName("FK_Chequ_FiscalPeriod");
        });

        modelBuilder.Entity<ChequSheet>(entity =>
        {
            entity.HasKey(e => e.CheqSheetUid);

            entity.ToTable("ChequSheet");

            entity.Property(e => e.CheqSheetUid)
                .ValueGeneratedNever()
                .HasColumnName("CHEQ_SHEET_UID");
            entity.Property(e => e.AccUid).HasColumnName("ACC_UID");
            entity.Property(e => e.AccUidRelated).HasColumnName("ACC_UID_RELATED");
            entity.Property(e => e.AccUidType).HasColumnName("ACC_UID_TYPE");
            entity.Property(e => e.BankUid).HasColumnName("BANK_UID");
            entity.Property(e => e.CheqAccNo)
                .HasMaxLength(50)
                .HasColumnName("CHEQ_ACC_NO");
            entity.Property(e => e.CheqAssignment)
                .HasMaxLength(50)
                .HasColumnName("CHEQ_ASSIGNMENT");
            entity.Property(e => e.CheqFctDate)
                .HasColumnType("datetime")
                .HasColumnName("CHEQ_FCT_DATE");
            entity.Property(e => e.CheqSheetAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("CHEQ_SHEET_AMOUNT");
            entity.Property(e => e.CheqSheetDescription).HasColumnName("CHEQ_SHEET_DESCRIPTION");
            entity.Property(e => e.CheqSheetDueDate)
                .HasColumnType("datetime")
                .HasColumnName("CHEQ_SHEET_DUE_DATE");
            entity.Property(e => e.CheqSheetNo)
                .HasMaxLength(50)
                .HasColumnName("CHEQ_SHEET_NO");
            entity.Property(e => e.CheqSheetReceivedDate)
                .HasColumnType("datetime")
                .HasColumnName("CHEQ_SHEET_RECEIVED_DATE");
            entity.Property(e => e.CheqSheetSayadNumber)
                .HasMaxLength(30)
                .HasColumnName("CHEQ_SHEET_SAYAD_NUMBER");
            entity.Property(e => e.CheqUid).HasColumnName("CHEQ_UID");
            entity.Property(e => e.ChequeSheetStatus).HasColumnName("CHEQUE_SHEET_STATUS");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.AccU).WithMany(p => p.ChequSheets)
                .HasForeignKey(d => d.AccUid)
                .HasConstraintName("FK_ChequSheet_Account");

            entity.HasOne(d => d.BankU).WithMany(p => p.ChequSheets)
                .HasForeignKey(d => d.BankUid)
                .HasConstraintName("FK_ChequSheet_Bank");

            entity.HasOne(d => d.CheqU).WithMany(p => p.ChequSheets)
                .HasForeignKey(d => d.CheqUid)
                .HasConstraintName("FK_ChequSheet_Chequ");

            entity.HasOne(d => d.FisPeriodU).WithMany(p => p.ChequSheets)
                .HasForeignKey(d => d.FisPeriodUid)
                .HasConstraintName("FK_ChequSheet_FiscalPeriod");
        });

        modelBuilder.Entity<ChequSheetStatus>(entity =>
        {
            entity.HasKey(e => e.CheqSheetStusUid);

            entity.ToTable("ChequSheetStatus");

            entity.Property(e => e.CheqSheetStusUid)
                .ValueGeneratedNever()
                .HasColumnName("CHEQ_SHEET_STUS_UID");
            entity.Property(e => e.AccUidType).HasColumnName("ACC_UID_TYPE");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.CheqSheetStusRgdUid).HasColumnName("CHEQ_SHEET_STUS_RGD_UID");
            entity.Property(e => e.CheqSheetStusStatus).HasColumnName("CHEQ_SHEET_STUS_STATUS");
            entity.Property(e => e.CheqSheetUid).HasColumnName("CHEQ_SHEET_UID");
            entity.Property(e => e.DftAccDfinUid).HasColumnName("DFT_ACC_DFIN_UID");
            entity.Property(e => e.RgdObjUid).HasColumnName("RGD_OBJ_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.AccUidTypeNavigation).WithMany(p => p.ChequSheetStatuses)
                .HasForeignKey(d => d.AccUidType)
                .HasConstraintName("FK_ChequSheetStatus_Account");

            entity.HasOne(d => d.BusUnitU).WithMany(p => p.ChequSheetStatuses)
                .HasForeignKey(d => d.BusUnitUid)
                .HasConstraintName("FK_ChequSheetStatus_BusinessUnits");

            entity.HasOne(d => d.CheqSheetU).WithMany(p => p.ChequSheetStatuses)
                .HasForeignKey(d => d.CheqSheetUid)
                .HasConstraintName("FK_ChequSheetStatus_ChequSheet");

            entity.HasOne(d => d.DftAccDfinU).WithMany(p => p.ChequSheetStatuses)
                .HasForeignKey(d => d.DftAccDfinUid)
                .HasConstraintName("FK_ChequSheetStatus_DefualtAccountDefinition");
        });

        modelBuilder.Entity<ChequeSheet>(entity =>
        {
            entity.HasKey(e => e.CheqSheetUid);

            entity.ToTable("ChequeSheet");

            entity.Property(e => e.CheqSheetUid)
                .ValueGeneratedNever()
                .HasColumnName("CHEQ_SHEET_UID");
            entity.Property(e => e.AgtUid).HasColumnName("AGT_UID");
            entity.Property(e => e.CheqSheetAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("CHEQ_SHEET_AMOUNT");
            entity.Property(e => e.CheqSheetBankBranch)
                .HasMaxLength(100)
                .HasColumnName("CHEQ_SHEET_BANK_BRANCH");
            entity.Property(e => e.CheqSheetBankCode)
                .HasMaxLength(50)
                .HasColumnName("CHEQ_SHEET_BANK_CODE");
            entity.Property(e => e.CheqSheetBankName)
                .HasMaxLength(100)
                .HasColumnName("CHEQ_SHEET_BANK_NAME");
            entity.Property(e => e.CheqSheetDescribtion).HasColumnName("CHEQ_SHEET_DESCRIBTION");
            entity.Property(e => e.CheqSheetDueDate)
                .HasColumnType("datetime")
                .HasColumnName("CHEQ_SHEET_DUE_DATE");
            entity.Property(e => e.CheqSheetNumber)
                .HasMaxLength(50)
                .HasColumnName("CHEQ_SHEET_NUMBER");
            entity.Property(e => e.CheqSheetStatus).HasColumnName("CHEQ_SHEET_STATUS");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.AgtU).WithMany(p => p.ChequeSheets)
                .HasForeignKey(d => d.AgtUid)
                .HasConstraintName("FK_ChequeSheet_Agreement");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityUid);

            entity.ToTable("City", tb => tb.HasTrigger("trgForInsertCity"));

            entity.Property(e => e.CityUid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("CITY_UID");
            entity.Property(e => e.CityCode)
                .HasMaxLength(50)
                .HasColumnName("CITY_CODE");
            entity.Property(e => e.CityName)
                .HasMaxLength(255)
                .HasColumnName("CITY_NAME");
            entity.Property(e => e.CityStatus).HasColumnName("CITY_STATUS");
            entity.Property(e => e.SttUid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("STT_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.SttU).WithMany(p => p.Cities)
                .HasForeignKey(d => d.SttUid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_City_State1");
        });

        modelBuilder.Entity<ClassProperty>(entity =>
        {
            entity.HasKey(e => e.ClsPrpUid);

            entity.HasIndex(e => e.SysUsrCreatedon, "IX_SYS_USR_CREATEDON");

            entity.Property(e => e.ClsPrpUid)
                .ValueGeneratedNever()
                .HasColumnName("CLS_PRP_UID");
            entity.Property(e => e.ClsPrpCode)
                .HasMaxLength(50)
                .HasColumnName("CLS_PRP_CODE");
            entity.Property(e => e.ClsPrpDescription).HasColumnName("CLS_PRP_DESCRIPTION");
            entity.Property(e => e.ClsPrpEnable).HasColumnName("CLS_PRP_ENABLE");
            entity.Property(e => e.ClsPrpLengthDetailCode).HasColumnName("CLS_PRP_LENGTH_DETAIL_CODE");
            entity.Property(e => e.ClsPrpName)
                .HasMaxLength(100)
                .HasColumnName("CLS_PRP_NAME");
            entity.Property(e => e.ClsPrpStatus).HasColumnName("CLS_PRP_STATUS");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<Condition>(entity =>
        {
            entity.HasKey(e => e.ConUid);

            entity.ToTable("Condition");

            entity.Property(e => e.ConUid)
                .ValueGeneratedNever()
                .HasColumnName("CON_UID");
            entity.Property(e => e.BusUid).HasColumnName("BUS_UID");
            entity.Property(e => e.ConActivation).HasColumnName("CON_ACTIVATION");
            entity.Property(e => e.ConEndDate)
                .HasColumnType("datetime")
                .HasColumnName("CON_END_DATE");
            entity.Property(e => e.ConForPerPrice).HasColumnName("CON_FOR_PER_PRICE");
            entity.Property(e => e.ConGroup).HasColumnName("CON_GROUP");
            entity.Property(e => e.ConIntroducedBy).HasColumnName("CON_INTRODUCED_BY");
            entity.Property(e => e.ConIntroducerPercent)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CON_INTRODUCER_PERCENT");
            entity.Property(e => e.ConName)
                .HasMaxLength(300)
                .HasColumnName("CON_NAME");
            entity.Property(e => e.ConPercent)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CON_PERCENT");
            entity.Property(e => e.ConPrice).HasColumnName("CON_PRICE");
            entity.Property(e => e.ConPriority).HasColumnName("CON_PRIORITY");
            entity.Property(e => e.ConScore).HasColumnName("CON_SCORE");
            entity.Property(e => e.ConStartDate)
                .HasColumnType("datetime")
                .HasColumnName("CON_START_DATE");
            entity.Property(e => e.ConStatus).HasColumnName("CON_STATUS");
            entity.Property(e => e.ConText).HasColumnName("CON_TEXT");
            entity.Property(e => e.ConTextShow).HasColumnName("CON_TEXT_SHOW");
            entity.Property(e => e.ConType).HasColumnName("CON_TYPE");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.BusU).WithMany(p => p.Conditions)
                .HasForeignKey(d => d.BusUid)
                .HasConstraintName("FK_Condition_BusinessUnits");
        });

        modelBuilder.Entity<ConditionDetail>(entity =>
        {
            entity.HasKey(e => e.ConDetUid);

            entity.Property(e => e.ConDetUid)
                .ValueGeneratedNever()
                .HasColumnName("CON_DET_UID");
            entity.Property(e => e.AccLvlUid).HasColumnName("ACC_LVL_UID");
            entity.Property(e => e.ConDetBegin)
                .HasMaxLength(2)
                .HasColumnName("CON_DET_BEGIN");
            entity.Property(e => e.ConDetConditionOperator)
                .HasMaxLength(10)
                .HasColumnName("CON_DET_CONDITION_OPERATOR");
            entity.Property(e => e.ConDetEnd)
                .HasMaxLength(2)
                .HasColumnName("CON_DET_END");
            entity.Property(e => e.ConDetParameterValue)
                .HasMaxLength(50)
                .HasColumnName("CON_DET_PARAMETER_VALUE");
            entity.Property(e => e.ConDetRownumber).HasColumnName("CON_DET_ROWNUMBER");
            entity.Property(e => e.ConDetStatus).HasColumnName("CON_DET_STATUS");
            entity.Property(e => e.ConUid).HasColumnName("CON_UID");
            entity.Property(e => e.FldUid).HasColumnName("FLD_UID");
            entity.Property(e => e.OprUid).HasColumnName("OPR_UID");
            entity.Property(e => e.PrdLvlUid).HasColumnName("PRD_LVL_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.ConU).WithMany(p => p.ConditionDetails)
                .HasForeignKey(d => d.ConUid)
                .HasConstraintName("FK_ConditionDetails_Condition");

            entity.HasOne(d => d.FldU).WithMany(p => p.ConditionDetails)
                .HasForeignKey(d => d.FldUid)
                .HasConstraintName("FK_ConditionDetails_Field");

            entity.HasOne(d => d.OprU).WithMany(p => p.ConditionDetails)
                .HasForeignKey(d => d.OprUid)
                .HasConstraintName("FK_ConditionDetails_Operator");
        });

        modelBuilder.Entity<ConditionHidden>(entity =>
        {
            entity.HasKey(e => e.ConditionHiddenUid);

            entity.ToTable("Condition_Hidden");

            entity.Property(e => e.ConditionHiddenUid)
                .ValueGeneratedNever()
                .HasColumnName("CONDITION_HIDDEN_UID");
            entity.Property(e => e.ConditionHiddenAccept).HasColumnName("CONDITION_HIDDEN_ACCEPT");
            entity.Property(e => e.ConditionHiddenAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("CONDITION_HIDDEN_AMOUNT");
            entity.Property(e => e.ConditionHiddenCount).HasColumnName("CONDITION_HIDDEN_COUNT");
            entity.Property(e => e.ConditionHiddenFromDate)
                .HasColumnType("datetime")
                .HasColumnName("CONDITION_HIDDEN_FROM_DATE");
            entity.Property(e => e.ConditionHiddenStatus).HasColumnName("CONDITION_HIDDEN_STATUS");
            entity.Property(e => e.ConditionHiddenToDate)
                .HasColumnType("datetime")
                .HasColumnName("CONDITION_HIDDEN_TO_DATE");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<ConditionLog>(entity =>
        {
            entity.HasKey(e => e.LogUid);

            entity.ToTable("ConditionLog");

            entity.Property(e => e.LogUid)
                .ValueGeneratedNever()
                .HasColumnName("LOG_UID");
            entity.Property(e => e.AccClbPayerUid).HasColumnName("ACC_CLB_PAYER_UID");
            entity.Property(e => e.AccClbUid).HasColumnName("ACC_CLB_UID");
            entity.Property(e => e.AccUid).HasColumnName("ACC_UID");
            entity.Property(e => e.BankUid).HasColumnName("BANK_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.ConLogCreditAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("CON_LOG_CREDIT_AMOUNT");
            entity.Property(e => e.ConLogScoreAmount).HasColumnName("CON_LOG_SCORE_AMOUNT");
            entity.Property(e => e.ConLogStatus).HasColumnName("CON_LOG_STATUS");
            entity.Property(e => e.ConUid).HasColumnName("CON_UID");
            entity.Property(e => e.CurrencyAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CURRENCY_AMOUNT");
            entity.Property(e => e.ExchRatePrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("EXCH_RATE_PRICE");
            entity.Property(e => e.ExchRateUid).HasColumnName("EXCH_RATE_UID");
            entity.Property(e => e.FollowupId)
                .HasMaxLength(50)
                .HasColumnName("FOLLOWUP_ID");
            entity.Property(e => e.InvExtendedAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("INV_EXTENDED_AMOUNT");
            entity.Property(e => e.InvUid).HasColumnName("INV_UID");
            entity.Property(e => e.PayRciptDetType).HasColumnName("PAY_RCIPT_DET_TYPE");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.ConU).WithMany(p => p.ConditionLogs)
                .HasForeignKey(d => d.ConUid)
                .HasConstraintName("FK_ConditionLog_Condition");

            entity.HasOne(d => d.InvU).WithMany(p => p.ConditionLogs)
                .HasForeignKey(d => d.InvUid)
                .HasConstraintName("FK_ConditionLog_Invoice");
        });

        modelBuilder.Entity<ContinuouseServicesPlaning>(entity =>
        {
            entity.HasKey(e => e.CspUid);

            entity.ToTable("ContinuouseServicesPlaning");

            entity.Property(e => e.CspUid).HasColumnName("CSP_UID");
            entity.Property(e => e.CspCapacity).HasColumnName("CSP_CAPACITY");
            entity.Property(e => e.CspDayPlan).HasColumnName("CSP_DAY_PLAN");
            entity.Property(e => e.CspEndTime).HasColumnName("CSP_END_TIME");
            entity.Property(e => e.CspFrAccountclub).HasColumnName("CSP_FR_ACCOUNTCLUB");
            entity.Property(e => e.CspFrProduct).HasColumnName("CSP_FR_PRODUCT");
            entity.Property(e => e.CspGenedr).HasColumnName("CSP_GENEDR");
            entity.Property(e => e.CspNumOfSessions).HasColumnName("CSP_NUM_OF_SESSIONS");
            entity.Property(e => e.CspStartDate)
                .HasColumnType("date")
                .HasColumnName("CSP_START_DATE");
            entity.Property(e => e.CspStartTime).HasColumnName("CSP_START_TIME");

            entity.HasOne(d => d.CspFrAccountclubNavigation).WithMany(p => p.ContinuouseServicesPlanings)
                .HasForeignKey(d => d.CspFrAccountclub)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContinuouseServicesPlaning_AccountClub");

            entity.HasOne(d => d.CspFrProductNavigation).WithMany(p => p.ContinuouseServicesPlanings)
                .HasForeignKey(d => d.CspFrProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContinuouseServicesPlaning_Product");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.CntId);

            entity.ToTable("Contract");

            entity.Property(e => e.CntId)
                .ValueGeneratedNever()
                .HasColumnName("CNT_ID");
            entity.Property(e => e.CntContractNum)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CNT_CONTRACT_NUM");
            entity.Property(e => e.CntCreateon)
                .HasColumnType("date")
                .HasColumnName("CNT_CREATEON");
            entity.Property(e => e.CntEndDate)
                .HasColumnType("date")
                .HasColumnName("CNT_END_DATE");
            entity.Property(e => e.CntFrContract).HasColumnName("CNT_FR_CONTRACT");
            entity.Property(e => e.CntFrCreatedby).HasColumnName("CNT_FR_CREATEDBY");
            entity.Property(e => e.CntFrModifiedby).HasColumnName("CNT_FR_MODIFIEDBY");
            entity.Property(e => e.CntModifiedon)
                .HasColumnType("date")
                .HasColumnName("CNT_MODIFIEDON");
            entity.Property(e => e.CntStartDate)
                .HasColumnType("date")
                .HasColumnName("CNT_START_DATE");
            entity.Property(e => e.CntTitle)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("CNT_TITLE");
            entity.Property(e => e.CntType).HasColumnName("CNT_TYPE");

            entity.HasOne(d => d.CntFrContractNavigation).WithMany(p => p.InverseCntFrContractNavigation)
                .HasForeignKey(d => d.CntFrContract)
                .HasConstraintName("FK_Contract_Contract");

            entity.HasOne(d => d.CntFrCreatedbyNavigation).WithMany(p => p.ContractCntFrCreatedbyNavigations)
                .HasForeignKey(d => d.CntFrCreatedby)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contract_SystemUsers_Create");

            entity.HasOne(d => d.CntFrModifiedbyNavigation).WithMany(p => p.ContractCntFrModifiedbyNavigations)
                .HasForeignKey(d => d.CntFrModifiedby)
                .HasConstraintName("FK_Contract_SystemUsers_Modify");
        });

        modelBuilder.Entity<ContractDetail>(entity =>
        {
            entity.HasKey(e => e.CdId);

            entity.ToTable("ContractDetail");

            entity.Property(e => e.CdId)
                .ValueGeneratedNever()
                .HasColumnName("CD_ID");
            entity.Property(e => e.CdBaseTime).HasColumnName("CD_BASE_TIME");
            entity.Property(e => e.CdBaseTimeCost)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("CD_BASE_TIME_COST");
            entity.Property(e => e.CdCreditLimit)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("CD_CREDIT_LIMIT");
            entity.Property(e => e.CdDiscountPercent)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("CD_DISCOUNT_PERCENT");
            entity.Property(e => e.CdDiscountRial)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("CD_DISCOUNT_RIAL");
            entity.Property(e => e.CdExtraCost)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("CD_EXTRA_COST");
            entity.Property(e => e.CdExtraTime).HasColumnName("CD_EXTRA_TIME");
            entity.Property(e => e.CdFrContract).HasColumnName("CD_FR_CONTRACT");
            entity.Property(e => e.CdFrProduct).HasColumnName("CD_FR_PRODUCT");

            entity.HasOne(d => d.CdFrContractNavigation).WithMany(p => p.ContractDetails)
                .HasForeignKey(d => d.CdFrContract)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContractDetail_Contract");

            entity.HasOne(d => d.CdFrProductNavigation).WithMany(p => p.ContractDetails)
                .HasForeignKey(d => d.CdFrProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContractDetail_Product");
        });

        modelBuilder.Entity<Cost>(entity =>
        {
            entity.HasKey(e => e.CstUid);

            entity.ToTable("Cost");

            entity.Property(e => e.CstUid)
                .ValueGeneratedNever()
                .HasColumnName("CST_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.CstDate)
                .HasColumnType("datetime")
                .HasColumnName("CST_DATE");
            entity.Property(e => e.CstDescribtion)
                .HasMaxLength(100)
                .HasColumnName("CST_DESCRIBTION");
            entity.Property(e => e.CstNumber)
                .HasMaxLength(50)
                .HasColumnName("CST_NUMBER");
            entity.Property(e => e.CstRgdUid).HasColumnName("CST_RGD_UID");
            entity.Property(e => e.CstStatus).HasColumnName("CST_STATUS");
            entity.Property(e => e.CstTotalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("CST_TOTAL_AMOUNT");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.RgdObjUid).HasColumnName("RGD_OBJ_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.FisPeriodU).WithMany(p => p.Costs)
                .HasForeignKey(d => d.FisPeriodUid)
                .HasConstraintName("FK_Cost_FiscalPeriod");

            entity.HasOne(d => d.RgdObjU).WithMany(p => p.Costs)
                .HasForeignKey(d => d.RgdObjUid)
                .HasConstraintName("FK_Cost_RegardingObject");
        });

        modelBuilder.Entity<CostCenter>(entity =>
        {
            entity.HasKey(e => e.CstCtrUid);

            entity.ToTable("CostCenter");

            entity.Property(e => e.CstCtrUid)
                .ValueGeneratedNever()
                .HasColumnName("CST_CTR_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.CstCtrCode)
                .HasMaxLength(50)
                .HasColumnName("CST_CTR_CODE");
            entity.Property(e => e.CstCtrName)
                .HasMaxLength(100)
                .HasColumnName("CST_CTR_NAME");
            entity.Property(e => e.CstCtrRemainCredit)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("CST_CTR_REMAIN_CREDIT");
            entity.Property(e => e.CstCtrStatus).HasColumnName("CST_CTR_STATUS");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.FisPeriodU).WithMany(p => p.CostCenters)
                .HasForeignKey(d => d.FisPeriodUid)
                .HasConstraintName("FK_CostCenter_FiscalPeriod");
        });

        modelBuilder.Entity<CostDetail>(entity =>
        {
            entity.HasKey(e => e.CstDetUid);

            entity.Property(e => e.CstDetUid)
                .ValueGeneratedNever()
                .HasColumnName("CST_DET_UID");
            entity.Property(e => e.AccUid).HasColumnName("ACC_UID");
            entity.Property(e => e.CstDetAccUid).HasColumnName("CST_DET_ACC_UID");
            entity.Property(e => e.CstDetCost)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("CST_DET_COST");
            entity.Property(e => e.CstDetStatus).HasColumnName("CST_DET_STATUS");
            entity.Property(e => e.CstUid).HasColumnName("CST_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.AccU).WithMany(p => p.CostDetailAccUs)
                .HasForeignKey(d => d.AccUid)
                .HasConstraintName("FK_CostDetails_Account1");

            entity.HasOne(d => d.CstDetAccU).WithMany(p => p.CostDetailCstDetAccUs)
                .HasForeignKey(d => d.CstDetAccUid)
                .HasConstraintName("FK_CostDetails_Account");

            entity.HasOne(d => d.CstU).WithMany(p => p.CostDetails)
                .HasForeignKey(d => d.CstUid)
                .HasConstraintName("FK_CostDetails_Cost");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CntUid);

            entity.ToTable("Country");

            entity.Property(e => e.CntUid)
                .ValueGeneratedNever()
                .HasColumnName("CNT_UID");
            entity.Property(e => e.CntName)
                .HasMaxLength(50)
                .HasColumnName("CNT_NAME");
            entity.Property(e => e.CntStatus).HasColumnName("CNT_STATUS");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<CurrentCalender>(entity =>
        {
            entity.HasKey(e => e.CcId);

            entity.ToTable("CurrentCalender");

            entity.Property(e => e.CcId).HasColumnName("CC_ID");
            entity.Property(e => e.CcDate)
                .HasColumnType("date")
                .HasColumnName("CC_DATE");
            entity.Property(e => e.CcEvents)
                .HasMaxLength(200)
                .HasColumnName("CC_EVENTS");
            entity.Property(e => e.CcIsFriday).HasColumnName("CC_IS_FRIDAY");
            entity.Property(e => e.CcIsHoliday).HasColumnName("CC_IS_HOLIDAY");
        });

        modelBuilder.Entity<DefualtAccountDefinition>(entity =>
        {
            entity.HasKey(e => e.DftAccDfinUid);

            entity.ToTable("DefualtAccountDefinition");

            entity.Property(e => e.DftAccDfinUid)
                .ValueGeneratedNever()
                .HasColumnName("DFT_ACC_DFIN_UID");
            entity.Property(e => e.AccUid).HasColumnName("ACC_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.DftAccDfinIsUsedInCheque).HasColumnName("DFT_ACC_DFIN_IS_USED_IN_CHEQUE");
            entity.Property(e => e.DftAccDfinIsUsedInDocuments).HasColumnName("DFT_ACC_DFIN_IS_USED_IN_DOCUMENTS");
            entity.Property(e => e.DftAccDfinIsUsedInPaymentSheet).HasColumnName("DFT_ACC_DFIN_IS_USED_IN_PAYMENT_SHEET");
            entity.Property(e => e.DftAccDfinIsUsedInRecieptSheet).HasColumnName("DFT_ACC_DFIN_IS_USED_IN_RECIEPT_SHEET");
            entity.Property(e => e.DftAccDfinName)
                .HasMaxLength(100)
                .HasColumnName("DFT_ACC_DFIN_NAME");
            entity.Property(e => e.DftAccDfinStatus).HasColumnName("DFT_ACC_DFIN_STATUS");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.SalCatUid).HasColumnName("SAL_CAT_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.AccU).WithMany(p => p.DefualtAccountDefinitions)
                .HasForeignKey(d => d.AccUid)
                .HasConstraintName("FK_DefualtAccountDefinition_Account");

            entity.HasOne(d => d.SalCatU).WithMany(p => p.DefualtAccountDefinitions)
                .HasForeignKey(d => d.SalCatUid)
                .HasConstraintName("FK_DefualtAccountDefinition_SalesCategory");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.DocUid);

            entity.ToTable("Document");

            entity.Property(e => e.DocUid)
                .ValueGeneratedNever()
                .HasColumnName("DOC_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.DocCheck).HasColumnName("DOC_CHECK");
            entity.Property(e => e.DocDate)
                .HasColumnType("datetime")
                .HasColumnName("DOC_DATE");
            entity.Property(e => e.DocDescription).HasColumnName("DOC_DESCRIPTION");
            entity.Property(e => e.DocNumber)
                .HasMaxLength(50)
                .HasColumnName("DOC_NUMBER");
            entity.Property(e => e.DocReference)
                .HasMaxLength(100)
                .HasColumnName("DOC_REFERENCE");
            entity.Property(e => e.DocRgdUid).HasColumnName("DOC_RGD_UID");
            entity.Property(e => e.DocStatus).HasColumnName("DOC_STATUS");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.RgdObjUid).HasColumnName("RGD_OBJ_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.RgdObjU).WithMany(p => p.Documents)
                .HasForeignKey(d => d.RgdObjUid)
                .HasConstraintName("FK_Document_RegardingObject");
        });

        modelBuilder.Entity<DocumentDetail>(entity =>
        {
            entity.HasKey(e => e.DocDetUid);

            entity.Property(e => e.DocDetUid)
                .ValueGeneratedNever()
                .HasColumnName("DOC_DET_UID");
            entity.Property(e => e.AccUid).HasColumnName("ACC_UID");
            entity.Property(e => e.CstCtrUid).HasColumnName("CST_CTR_UID");
            entity.Property(e => e.DftAccDfinUid).HasColumnName("DFT_ACC_DFIN_UID");
            entity.Property(e => e.DocDetCreditoryAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("DOC_DET_CREDITORY_AMOUNT");
            entity.Property(e => e.DocDetDescription).HasColumnName("DOC_DET_DESCRIPTION");
            entity.Property(e => e.DocDetLiabilityAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("DOC_DET_LIABILITY_AMOUNT");
            entity.Property(e => e.DocDetRgdUid).HasColumnName("DOC_DET_RGD_UID");
            entity.Property(e => e.DocDetStatus).HasColumnName("DOC_DET_STATUS");
            entity.Property(e => e.DocUid).HasColumnName("DOC_UID");
            entity.Property(e => e.RgdObjUid).HasColumnName("RGD_OBJ_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.AccU).WithMany(p => p.DocumentDetails)
                .HasForeignKey(d => d.AccUid)
                .HasConstraintName("FK_DocumentDetails_Account");

            entity.HasOne(d => d.CstCtrU).WithMany(p => p.DocumentDetails)
                .HasForeignKey(d => d.CstCtrUid)
                .HasConstraintName("FK_DocumentDetails_CostCenter");

            entity.HasOne(d => d.DftAccDfinU).WithMany(p => p.DocumentDetails)
                .HasForeignKey(d => d.DftAccDfinUid)
                .HasConstraintName("FK_DocumentDetails_DefualtAccountDefinition");

            entity.HasOne(d => d.DocU).WithMany(p => p.DocumentDetails)
                .HasForeignKey(d => d.DocUid)
                .HasConstraintName("FK_DocumentDetails_Document");

            entity.HasOne(d => d.RgdObjU).WithMany(p => p.DocumentDetails)
                .HasForeignKey(d => d.RgdObjUid)
                .HasConstraintName("FK_DocumentDetails_RegardingObject");
        });

        modelBuilder.Entity<Exchange>(entity =>
        {
            entity.HasKey(e => e.ExchUid);

            entity.ToTable("Exchange");

            entity.Property(e => e.ExchUid)
                .ValueGeneratedNever()
                .HasColumnName("EXCH_UID");
            entity.Property(e => e.AccClbParentUid).HasColumnName("ACC_CLB_PARENT_UID");
            entity.Property(e => e.AccClbUid).HasColumnName("ACC_CLB_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.ExchDate)
                .HasColumnType("datetime")
                .HasColumnName("EXCH_DATE");
            entity.Property(e => e.ExchNumber)
                .HasMaxLength(10)
                .HasColumnName("EXCH_NUMBER");
            entity.Property(e => e.ExchPrintCount).HasColumnName("EXCH_PRINT_COUNT");
            entity.Property(e => e.ExchStatus).HasColumnName("EXCH_STATUS");
            entity.Property(e => e.ExchSync).HasColumnName("EXCH_SYNC");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<ExchangeDetail>(entity =>
        {
            entity.HasKey(e => e.ExchDetUid);

            entity.Property(e => e.ExchDetUid)
                .ValueGeneratedNever()
                .HasColumnName("EXCH_DET_UID");
            entity.Property(e => e.ExchDetFromAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("EXCH_DET_FROM_AMOUNT");
            entity.Property(e => e.ExchDetFromBasePrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("EXCH_DET_FROM_BASE_PRICE");
            entity.Property(e => e.ExchDetStatus).HasColumnName("EXCH_DET_STATUS");
            entity.Property(e => e.ExchDetToAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("EXCH_DET_TO_AMOUNT");
            entity.Property(e => e.ExchDetToBasePrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("EXCH_DET_TO_BASE_PRICE");
            entity.Property(e => e.ExchRateFromUid).HasColumnName("EXCH_RATE_FROM_UID");
            entity.Property(e => e.ExchRateToUid).HasColumnName("EXCH_RATE_TO_UID");
            entity.Property(e => e.ExchUid).HasColumnName("EXCH_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.ExchU).WithMany(p => p.ExchangeDetails)
                .HasForeignKey(d => d.ExchUid)
                .HasConstraintName("FK_ExchangeDetails_Exchange");
        });

        modelBuilder.Entity<ExchangeRate>(entity =>
        {
            entity.HasKey(e => e.ExchRateUid);

            entity.ToTable("ExchangeRate");

            entity.Property(e => e.ExchRateUid)
                .ValueGeneratedNever()
                .HasColumnName("EXCH_RATE_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.ExchRateImage).HasColumnName("EXCH_RATE_IMAGE");
            entity.Property(e => e.ExchRateLatinName)
                .HasMaxLength(50)
                .HasColumnName("EXCH_RATE_LATIN_NAME");
            entity.Property(e => e.ExchRateName)
                .HasMaxLength(100)
                .HasColumnName("EXCH_RATE_NAME");
            entity.Property(e => e.ExchRatePercentRisk).HasColumnName("EXCH_RATE_PERCENT_RISK");
            entity.Property(e => e.ExchRatePrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("EXCH_RATE_PRICE");
            entity.Property(e => e.ExchRateStatus).HasColumnName("EXCH_RATE_STATUS");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<Field>(entity =>
        {
            entity.HasKey(e => e.FldUid);

            entity.ToTable("Field");

            entity.Property(e => e.FldUid)
                .ValueGeneratedNever()
                .HasColumnName("FLD_UID");
            entity.Property(e => e.FldName)
                .HasMaxLength(100)
                .HasComment("نام فیلد در دیتابیس")
                .HasColumnName("FLD_NAME");
            entity.Property(e => e.FldText)
                .HasMaxLength(100)
                .HasComment("نام نمایشی فیلد دربرنامه")
                .HasColumnName("FLD_TEXT");
            entity.Property(e => e.FldType)
                .HasComment("نوع فیلد برای اعمال روی کل فاکتور یا ردیف های فاکتور")
                .HasColumnName("FLD_TYPE");
        });

        modelBuilder.Entity<FiscalPeriod>(entity =>
        {
            entity.HasKey(e => e.FisPeriodUid);

            entity.ToTable("FiscalPeriod");

            entity.Property(e => e.FisPeriodUid)
                .ValueGeneratedNever()
                .HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.FisPeriodCode)
                .HasMaxLength(50)
                .HasColumnName("FIS_PERIOD_CODE");
            entity.Property(e => e.FisPeriodEndDate)
                .HasColumnType("datetime")
                .HasColumnName("FIS_PERIOD_END_DATE");
            entity.Property(e => e.FisPeriodIsActive).HasColumnName("FIS_PERIOD_IS_ACTIVE");
            entity.Property(e => e.FisPeriodIsClosed).HasColumnName("FIS_PERIOD_IS_CLOSED");
            entity.Property(e => e.FisPeriodName)
                .HasMaxLength(100)
                .HasColumnName("FIS_PERIOD_NAME");
            entity.Property(e => e.FisPeriodStartDate)
                .HasColumnType("datetime")
                .HasColumnName("FIS_PERIOD_START_DATE");
            entity.Property(e => e.FisPeriodStatus).HasColumnName("FIS_PERIOD_STATUS");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.BusUnitU).WithMany(p => p.FiscalPeriods)
                .HasForeignKey(d => d.BusUnitUid)
                .HasConstraintName("FK_FiscalPeriod_BusinessUnits1");
        });

        modelBuilder.Entity<InOut>(entity =>
        {
            entity.HasKey(e => e.IoId);

            entity.ToTable("InOut");

            entity.Property(e => e.IoId)
                .ValueGeneratedNever()
                .HasColumnName("IO_ID");
            entity.Property(e => e.IoDate)
                .HasColumnType("date")
                .HasColumnName("IO_DATE");
            entity.Property(e => e.IoFrAccountclub).HasColumnName("IO_FR_ACCOUNTCLUB");
            entity.Property(e => e.IoFrCalender).HasColumnName("IO_FR_CALENDER");
            entity.Property(e => e.IoFrCalenderDetail).HasColumnName("IO_FR_CALENDER_DETAIL");
            entity.Property(e => e.IoFrCsp).HasColumnName("IO_FR_CSP");
            entity.Property(e => e.IoFrServiceTransactions).HasColumnName("IO_FR_SERVICE_TRANSACTIONS");
            entity.Property(e => e.IoTime).HasColumnName("IO_TIME");
            entity.Property(e => e.IoType).HasColumnName("IO_TYPE");

            entity.HasOne(d => d.IoFrAccountclubNavigation).WithMany(p => p.InOuts)
                .HasForeignKey(d => d.IoFrAccountclub)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InOut_AccountClub");

            entity.HasOne(d => d.IoFrCalenderNavigation).WithMany(p => p.InOuts)
                .HasForeignKey(d => d.IoFrCalender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InOut_Calender");

            entity.HasOne(d => d.IoFrCalenderDetailNavigation).WithMany(p => p.InOuts)
                .HasForeignKey(d => d.IoFrCalenderDetail)
                .HasConstraintName("FK_InOut_CalenderDetail");

            entity.HasOne(d => d.IoFrCspNavigation).WithMany(p => p.InOuts)
                .HasForeignKey(d => d.IoFrCsp)
                .HasConstraintName("FK_InOut_ContinuouseServicesPlaning");

            entity.HasOne(d => d.IoFrServiceTransactionsNavigation).WithMany(p => p.InOuts)
                .HasForeignKey(d => d.IoFrServiceTransactions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InOut_ServiceTransactions");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvUid);

            entity.ToTable("Invoice");

            entity.HasIndex(e => new { e.BusUnitUid, e.FisPeriodUid, e.SalCatUid, e.InvReference }, "IX_BUS_UNIT_UID_FIS_PERIOD_UID_SAL_CAT_UID_INV_REFERENCE");

            entity.HasIndex(e => e.InvDate, "IX_INV_DATE");

            entity.HasIndex(e => e.InvNumber, "IX_INV_NUMBER");

            entity.HasIndex(e => e.InvUid, "IX_INV_UID");

            entity.Property(e => e.InvUid)
                .ValueGeneratedNever()
                .HasColumnName("INV_UID");
            entity.Property(e => e.AccClbUid).HasColumnName("ACC_CLB_UID");
            entity.Property(e => e.AccUid).HasColumnName("ACC_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.CstCtrUid).HasColumnName("CST_CTR_UID");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.IncidentUid).HasColumnName("INCIDENT_UID");
            entity.Property(e => e.InvApplicantUid).HasColumnName("INV_APPLICANT_UID");
            entity.Property(e => e.InvBarcode)
                .HasMaxLength(500)
                .HasColumnName("INV_BARCODE");
            entity.Property(e => e.InvCharge).HasColumnName("INV_CHARGE");
            entity.Property(e => e.InvCurrency)
                .HasDefaultValueSql("((1))")
                .HasColumnName("INV_CURRENCY");
            entity.Property(e => e.InvDailyNumber)
                .HasMaxLength(15)
                .HasColumnName("INV_DAILY_NUMBER");
            entity.Property(e => e.InvDate)
                .HasColumnType("datetime")
                .HasColumnName("INV_DATE");
            entity.Property(e => e.InvDefaultAddress)
                .HasMaxLength(200)
                .HasDefaultValueSql("((1))")
                .HasColumnName("INV_DEFAULT_ADDRESS");
            entity.Property(e => e.InvDeposit)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("INV_DEPOSIT");
            entity.Property(e => e.InvDescribtion).HasColumnName("INV_DESCRIBTION");
            entity.Property(e => e.InvDetTotalDiscount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("INV_DET_TOTAL_DISCOUNT");
            entity.Property(e => e.InvDetTotalDiscountCrm)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("INV_DET_TOTAL_DISCOUNT_CRM");
            entity.Property(e => e.InvDiscount2)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("INV_DISCOUNT2");
            entity.Property(e => e.InvDiscountExchange)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("INV_DISCOUNT_EXCHANGE");
            entity.Property(e => e.InvDiscountType)
                .HasDefaultValueSql("((0))")
                .HasColumnName("INV_DISCOUNT_TYPE");
            entity.Property(e => e.InvDueDate)
                .HasColumnType("datetime")
                .HasColumnName("INV_DUE_DATE");
            entity.Property(e => e.InvDueTime)
                .HasMaxLength(8)
                .HasColumnName("INV_DUE_TIME");
            entity.Property(e => e.InvEndTime)
                .HasMaxLength(8)
                .HasColumnName("INV_END_TIME");
            entity.Property(e => e.InvExtendedAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("INV_EXTENDED_AMOUNT");
            entity.Property(e => e.InvExtendedExchange)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("INV_EXTENDED_EXCHANGE");
            entity.Property(e => e.InvFinalStatusControl).HasColumnName("INV_FINAL_STATUS_CONTROL");
            entity.Property(e => e.InvFormal)
                .HasDefaultValueSql("((0))")
                .HasColumnName("INV_FORMAL");
            entity.Property(e => e.InvNumber)
                .HasMaxLength(50)
                .HasColumnName("INV_NUMBER");
            entity.Property(e => e.InvParentUid).HasColumnName("INV_PARENT_UID");
            entity.Property(e => e.InvPaymentStatus).HasColumnName("INV_PAYMENT_STATUS");
            entity.Property(e => e.InvPercentDiscount).HasColumnName("INV_PERCENT_DISCOUNT");
            entity.Property(e => e.InvReference)
                .HasMaxLength(100)
                .HasColumnName("INV_REFERENCE");
            entity.Property(e => e.InvSection).HasColumnName("INV_SECTION");
            entity.Property(e => e.InvShareDiscount).HasColumnName("INV_SHARE_DISCOUNT");
            entity.Property(e => e.InvStartTime)
                .HasMaxLength(8)
                .HasColumnName("INV_START_TIME");
            entity.Property(e => e.InvStatus).HasColumnName("INV_STATUS");
            entity.Property(e => e.InvStatusControl).HasColumnName("INV_STATUS_CONTROL");
            entity.Property(e => e.InvStep)
                .HasDefaultValueSql("((4))")
                .HasColumnName("INV_STEP");
            entity.Property(e => e.InvSync).HasColumnName("INV_SYNC");
            entity.Property(e => e.InvTotalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("INV_TOTAL_AMOUNT");
            entity.Property(e => e.InvTotalAmountCrm)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("INV_TOTAL_AMOUNT_CRM");
            entity.Property(e => e.InvTotalCost)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("INV_TOTAL_COST");
            entity.Property(e => e.InvTotalDiscount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("INV_TOTAL_DISCOUNT");
            entity.Property(e => e.InvTotalExchange)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("INV_TOTAL_EXCHANGE");
            entity.Property(e => e.InvTotalTax)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("INV_TOTAL_TAX");
            entity.Property(e => e.InvTypeOrder)
                .HasDefaultValueSql("((2))")
                .HasColumnName("INV_TYPE_ORDER");
            entity.Property(e => e.OrdUid).HasColumnName("ORD_UID");
            entity.Property(e => e.QutUid).HasColumnName("QUT_UID");
            entity.Property(e => e.SalCatUid).HasColumnName("SAL_CAT_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
            entity.Property(e => e.WrkSttUid).HasColumnName("WRK_STT_UID");

            entity.HasOne(d => d.AccClbU).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.AccClbUid)
                .HasConstraintName("FK_Invoice_AccountClub");

            entity.HasOne(d => d.AccU).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.AccUid)
                .HasConstraintName("FK_Invoice_Account");

            entity.HasOne(d => d.CstCtrU).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CstCtrUid)
                .HasConstraintName("FK_Invoice_CostCenter");

            entity.HasOne(d => d.FisPeriodU).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.FisPeriodUid)
                .HasConstraintName("FK_Invoice_FiscalPeriod");

            entity.HasOne(d => d.OrdU).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.OrdUid)
                .HasConstraintName("FK_Invoice_Order");

            entity.HasOne(d => d.QutU).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.QutUid)
                .HasConstraintName("FK_Invoice_Quote");

            entity.HasOne(d => d.SalCatU).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.SalCatUid)
                .HasConstraintName("FK_Invoice_SalesCategory");
        });

        modelBuilder.Entity<InvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.InvDetUid);

            entity.HasIndex(e => e.InvDetUid, "IX_INV_DET_UID");

            entity.Property(e => e.InvDetUid)
                .ValueGeneratedNever()
                .HasColumnName("INV_DET_UID");
            entity.Property(e => e.InvDetDescribtion).HasColumnName("INV_DET_DESCRIBTION");
            entity.Property(e => e.InvDetDiscount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("INV_DET_DISCOUNT");
            entity.Property(e => e.InvDetDiscountExchange)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("INV_DET_DISCOUNT_EXCHANGE");
            entity.Property(e => e.InvDetParentUid).HasColumnName("INV_DET_PARENT_UID");
            entity.Property(e => e.InvDetPayment).HasColumnName("INV_DET_PAYMENT");
            entity.Property(e => e.InvDetPercentDiscount).HasColumnName("INV_DET_PERCENT_DISCOUNT");
            entity.Property(e => e.InvDetPriceExchange)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("INV_DET_PRICE_EXCHANGE");
            entity.Property(e => e.InvDetPricePerUnit)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("INV_DET_PRICE_PER_UNIT");
            entity.Property(e => e.InvDetPricePerUnitExchange)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("INV_DET_PRICE_PER_UNIT_EXCHANGE");
            entity.Property(e => e.InvDetPrint)
                .HasDefaultValueSql("((0))")
                .HasColumnName("INV_DET_PRINT");
            entity.Property(e => e.InvDetQuantity).HasColumnName("INV_DET_QUANTITY");
            entity.Property(e => e.InvDetRetRefrence).HasColumnName("INV_DET_RET_REFRENCE");
            entity.Property(e => e.InvDetRowGroup).HasColumnName("INV_DET_ROW_GROUP");
            entity.Property(e => e.InvDetRowOrder).HasColumnName("INV_DET_ROW_ORDER");
            entity.Property(e => e.InvDetShareDiscountPer).HasColumnName("INV_DET_SHARE_DISCOUNT_PER");
            entity.Property(e => e.InvDetStatus).HasColumnName("INV_DET_STATUS");
            entity.Property(e => e.InvDetTax)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("INV_DET_TAX");
            entity.Property(e => e.InvDetTaxValue).HasColumnName("INV_DET_TAX_VALUE");
            entity.Property(e => e.InvDetTotalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("INV_DET_TOTAL_AMOUNT");
            entity.Property(e => e.InvDetTotalExchange)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("INV_DET_TOTAL_EXCHANGE");
            entity.Property(e => e.InvUid).HasColumnName("INV_UID");
            entity.Property(e => e.PrdUid).HasColumnName("PRD_UID");
            entity.Property(e => e.ServiceunitUid).HasColumnName("SERVICEUNIT_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
            entity.Property(e => e.UomUid).HasColumnName("UOM_UID");
            entity.Property(e => e.WarHosUid).HasColumnName("WAR_HOS_UID");

            entity.HasOne(d => d.InvU).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.InvUid)
                .HasConstraintName("FK_InvoiceDetails_Invoice");

            entity.HasOne(d => d.PrdU).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.PrdUid)
                .HasConstraintName("FK_InvoiceDetails_Product");

            entity.HasOne(d => d.UomU).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.UomUid)
                .HasConstraintName("FK_InvoiceDetails_UnitOfMeasurement");

            entity.HasOne(d => d.WarHosU).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.WarHosUid)
                .HasConstraintName("FK_InvoiceDetails_WareHouse");
        });

        modelBuilder.Entity<InvoiceDetails2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("InvoiceDetails2");

            entity.Property(e => e.InvDetDescribtion).HasColumnName("INV_DET_DESCRIBTION");
            entity.Property(e => e.InvDetDiscount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("INV_DET_DISCOUNT");
            entity.Property(e => e.InvDetDiscountExchange)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("INV_DET_DISCOUNT_EXCHANGE");
            entity.Property(e => e.InvDetParentUid).HasColumnName("INV_DET_PARENT_UID");
            entity.Property(e => e.InvDetPayment).HasColumnName("INV_DET_PAYMENT");
            entity.Property(e => e.InvDetPercentDiscount).HasColumnName("INV_DET_PERCENT_DISCOUNT");
            entity.Property(e => e.InvDetPriceExchange)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("INV_DET_PRICE_EXCHANGE");
            entity.Property(e => e.InvDetPricePerUnit)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("INV_DET_PRICE_PER_UNIT");
            entity.Property(e => e.InvDetPricePerUnitExchange)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("INV_DET_PRICE_PER_UNIT_EXCHANGE");
            entity.Property(e => e.InvDetPrint).HasColumnName("INV_DET_PRINT");
            entity.Property(e => e.InvDetQuantity).HasColumnName("INV_DET_QUANTITY");
            entity.Property(e => e.InvDetQuantity2).HasColumnName("INV_DET_QUANTITY2");
            entity.Property(e => e.InvDetRetRefrence).HasColumnName("INV_DET_RET_REFRENCE");
            entity.Property(e => e.InvDetRowGroup).HasColumnName("INV_DET_ROW_GROUP");
            entity.Property(e => e.InvDetRowOrder).HasColumnName("INV_DET_ROW_ORDER");
            entity.Property(e => e.InvDetShareDiscountPer).HasColumnName("INV_DET_SHARE_DISCOUNT_PER");
            entity.Property(e => e.InvDetStatus).HasColumnName("INV_DET_STATUS");
            entity.Property(e => e.InvDetTax)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("INV_DET_TAX");
            entity.Property(e => e.InvDetTaxValue).HasColumnName("INV_DET_TAX_VALUE");
            entity.Property(e => e.InvDetTotalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("INV_DET_TOTAL_AMOUNT");
            entity.Property(e => e.InvDetTotalExchange)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("INV_DET_TOTAL_EXCHANGE");
            entity.Property(e => e.InvDetUid).HasColumnName("INV_DET_UID");
            entity.Property(e => e.InvUid).HasColumnName("INV_UID");
            entity.Property(e => e.PrdUid).HasColumnName("PRD_UID");
            entity.Property(e => e.ServiceunitUid).HasColumnName("SERVICEUNIT_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
            entity.Property(e => e.UomUid).HasColumnName("UOM_UID");
            entity.Property(e => e.WarHosUid).HasColumnName("WAR_HOS_UID");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.Property(e => e.JobId).HasColumnName("JOB_ID");
            entity.Property(e => e.JobName)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("JOB_NAME");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.LangUid);

            entity.ToTable("Language", tb => tb.HasTrigger("trgForInsertLanguage"));

            entity.Property(e => e.LangUid)
                .ValueGeneratedNever()
                .HasColumnName("LANG_UID");
            entity.Property(e => e.LangCode)
                .HasMaxLength(50)
                .HasColumnName("LANG_CODE");
            entity.Property(e => e.LangEnglishName)
                .HasMaxLength(100)
                .HasColumnName("LANG_ENGLISH_NAME");
            entity.Property(e => e.LangPersianName)
                .HasMaxLength(100)
                .HasColumnName("LANG_PERSIAN_NAME");
            entity.Property(e => e.LangStatus).HasColumnName("LANG_STATUS");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MnuUid);

            entity.ToTable("Menu");

            entity.Property(e => e.MnuUid)
                .ValueGeneratedNever()
                .HasColumnName("MNU_UID");
            entity.Property(e => e.MnuName)
                .HasMaxLength(200)
                .HasColumnName("MNU_NAME");
            entity.Property(e => e.MnuParentUid).HasColumnName("MNU_PARENT_UID");
            entity.Property(e => e.MnuPeriority)
                .HasMaxLength(10)
                .HasColumnName("MNU_PERIORITY");
            entity.Property(e => e.MnuStatus).HasColumnName("MNU_STATUS");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<MenuUser>(entity =>
        {
            entity.HasKey(e => e.MnuUsrUid);

            entity.ToTable("MenuUser");

            entity.Property(e => e.MnuUsrUid)
                .ValueGeneratedNever()
                .HasColumnName("MNU_USR_UID");
            entity.Property(e => e.MnuUid).HasColumnName("MNU_UID");
            entity.Property(e => e.SysUsrUid).HasColumnName("SYS_USR_UID");

            entity.HasOne(d => d.MnuU).WithMany(p => p.MenuUsers)
                .HasForeignKey(d => d.MnuUid)
                .HasConstraintName("FK_MenuUser_Menu");

            entity.HasOne(d => d.SysUsrU).WithMany(p => p.MenuUsers)
                .HasForeignKey(d => d.SysUsrUid)
                .HasConstraintName("FK_MenuUser_SystemUsers");
        });

        modelBuilder.Entity<ObjectDescription>(entity =>
        {
            entity.HasKey(e => e.DscUid);

            entity.ToTable("ObjectDescription");

            entity.Property(e => e.DscUid)
                .ValueGeneratedNever()
                .HasColumnName("DSC_UID");
            entity.Property(e => e.DscDescription)
                .HasMaxLength(500)
                .HasColumnName("DSC_DESCRIPTION");
            entity.Property(e => e.ObjUid).HasColumnName("OBJ_UID");
        });

        modelBuilder.Entity<Operator>(entity =>
        {
            entity.HasKey(e => e.OprUid);

            entity.ToTable("Operator");

            entity.Property(e => e.OprUid)
                .ValueGeneratedNever()
                .HasColumnName("OPR_UID");
            entity.Property(e => e.OprName)
                .HasMaxLength(30)
                .HasComment("عملگر")
                .HasColumnName("OPR_NAME");
            entity.Property(e => e.OprText)
                .HasMaxLength(50)
                .HasComment("نام نمایشی فیلد در برنامه")
                .HasColumnName("OPR_TEXT");
            entity.Property(e => e.OprType).HasColumnName("OPR_TYPE");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrdUid);

            entity.ToTable("Order");

            entity.Property(e => e.OrdUid)
                .ValueGeneratedNever()
                .HasColumnName("ORD_UID");
            entity.Property(e => e.AccUid).HasColumnName("ACC_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.OrdDate)
                .HasColumnType("datetime")
                .HasColumnName("ORD_DATE");
            entity.Property(e => e.OrdDescribtion).HasColumnName("ORD_DESCRIBTION");
            entity.Property(e => e.OrdExtendedAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ORD_EXTENDED_AMOUNT");
            entity.Property(e => e.OrdFinalStatusControl).HasColumnName("ORD_FINAL_STATUS_CONTROL");
            entity.Property(e => e.OrdNumber)
                .HasMaxLength(50)
                .HasColumnName("ORD_NUMBER");
            entity.Property(e => e.OrdStatus).HasColumnName("ORD_STATUS");
            entity.Property(e => e.OrdStatusControl).HasColumnName("ORD_STATUS_CONTROL");
            entity.Property(e => e.OrdTotalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ORD_TOTAL_AMOUNT");
            entity.Property(e => e.OrdTotalCost)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ORD_TOTAL_COST");
            entity.Property(e => e.OrdTotalDiscount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ORD_TOTAL_DISCOUNT");
            entity.Property(e => e.OrdTotalTax)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ORD_TOTAL_TAX");
            entity.Property(e => e.QutUid).HasColumnName("QUT_UID");
            entity.Property(e => e.SalCatUid).HasColumnName("SAL_CAT_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.AccU).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AccUid)
                .HasConstraintName("FK_Order_Account");

            entity.HasOne(d => d.FisPeriodU).WithMany(p => p.Orders)
                .HasForeignKey(d => d.FisPeriodUid)
                .HasConstraintName("FK_Order_FiscalPeriod");

            entity.HasOne(d => d.SalCatU).WithMany(p => p.Orders)
                .HasForeignKey(d => d.SalCatUid)
                .HasConstraintName("FK_Order_SalesCategory");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrdDetUid);

            entity.Property(e => e.OrdDetUid)
                .ValueGeneratedNever()
                .HasColumnName("ORD_DET_UID");
            entity.Property(e => e.OrdDetDescribtion).HasColumnName("ORD_DET_DESCRIBTION");
            entity.Property(e => e.OrdDetDiscount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ORD_DET_DISCOUNT");
            entity.Property(e => e.OrdDetPricePerUnit)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ORD_DET_PRICE_PER_UNIT");
            entity.Property(e => e.OrdDetQuantity).HasColumnName("ORD_DET_QUANTITY");
            entity.Property(e => e.OrdDetStatus).HasColumnName("ORD_DET_STATUS");
            entity.Property(e => e.OrdDetTax)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ORD_DET_TAX");
            entity.Property(e => e.OrdDetTotalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ORD_DET_TOTAL_AMOUNT");
            entity.Property(e => e.OrdUid).HasColumnName("ORD_UID");
            entity.Property(e => e.PrdUid).HasColumnName("PRD_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
            entity.Property(e => e.UomUid).HasColumnName("UOM_UID");
            entity.Property(e => e.WarHosUid).HasColumnName("WAR_HOS_UID");

            entity.HasOne(d => d.OrdU).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrdUid)
                .HasConstraintName("FK_OrderDetails_Order");

            entity.HasOne(d => d.PrdU).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.PrdUid)
                .HasConstraintName("FK_OrderDetails_Product");

            entity.HasOne(d => d.UomU).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.UomUid)
                .HasConstraintName("FK_OrderDetails_UnitOfMeasurement");

            entity.HasOne(d => d.WarHosU).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.WarHosUid)
                .HasConstraintName("FK_OrderDetails_WareHouse");
        });

        modelBuilder.Entity<OrderType>(entity =>
        {
            entity.HasKey(e => e.OrdTypUid);

            entity.ToTable("OrderType");

            entity.Property(e => e.OrdTypUid)
                .ValueGeneratedNever()
                .HasColumnName("ORD_TYP_UID");
            entity.Property(e => e.OrdTypCode).HasColumnName("ORD_TYP_CODE");
            entity.Property(e => e.OrdTypColor)
                .HasMaxLength(15)
                .HasColumnName("ORD_TYP_COLOR");
            entity.Property(e => e.OrdTypFile)
                .HasMaxLength(300)
                .HasColumnName("ORD_TYP_FILE");
            entity.Property(e => e.OrdTypFile2)
                .HasMaxLength(300)
                .HasColumnName("ORD_TYP_FILE2");
            entity.Property(e => e.OrdTypName)
                .HasMaxLength(100)
                .HasColumnName("ORD_TYP_NAME");
            entity.Property(e => e.OrdTypPriority).HasColumnName("ORD_TYP_PRIORITY");
            entity.Property(e => e.OrdTypStatus).HasColumnName("ORD_TYP_STATUS");
            entity.Property(e => e.OrdTypType).HasColumnName("ORD_TYP_TYPE");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<PaymentReceiptRelatedPurchaseInvoice>(entity =>
        {
            entity.HasKey(e => e.PayRciptRelUid);

            entity.ToTable("PaymentReceiptRelatedPurchaseInvoice");

            entity.Property(e => e.PayRciptRelUid)
                .ValueGeneratedNever()
                .HasColumnName("PAY_RCIPT_REL_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.InvUid).HasColumnName("INV_UID");
            entity.Property(e => e.PayRciptRelStatus).HasColumnName("PAY_RCIPT_REL_STATUS");
            entity.Property(e => e.PayRciptSheetUid).HasColumnName("PAY_RCIPT_SHEET_UID");
            entity.Property(e => e.PurchUid).HasColumnName("PURCH_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.InvU).WithMany(p => p.PaymentReceiptRelatedPurchaseInvoices)
                .HasForeignKey(d => d.InvUid)
                .HasConstraintName("FK_PaymentReceiptRelatedPurchaseInvoice_Invoice");

            entity.HasOne(d => d.PayRciptSheetU).WithMany(p => p.PaymentReceiptRelatedPurchaseInvoices)
                .HasForeignKey(d => d.PayRciptSheetUid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentReceiptRelatedPurchaseInvoice_PaymentRecieptSheet");

            entity.HasOne(d => d.PurchU).WithMany(p => p.PaymentReceiptRelatedPurchaseInvoices)
                .HasForeignKey(d => d.PurchUid)
                .HasConstraintName("FK_PaymentReceiptRelatedPurchaseInvoice_Purchase");
        });

        modelBuilder.Entity<PaymentRecieptDetail>(entity =>
        {
            entity.HasKey(e => e.PayRciptDetUid);

            entity.ToTable("PaymentRecieptDetail");

            entity.HasIndex(e => e.PayRciptDetUid, "IX_PAY_RCIPT_DET_UID");

            entity.Property(e => e.PayRciptDetUid)
                .ValueGeneratedNever()
                .HasColumnName("PAY_RCIPT_DET_UID");
            entity.Property(e => e.AccUid).HasColumnName("ACC_UID");
            entity.Property(e => e.BankUid).HasColumnName("BANK_UID");
            entity.Property(e => e.CheqSheetUid).HasColumnName("CHEQ_SHEET_UID");
            entity.Property(e => e.CutomerClubDetailUid).HasColumnName("CUTOMER_CLUB_DETAIL_UID");
            entity.Property(e => e.ExchRatePrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("EXCH_RATE_PRICE");
            entity.Property(e => e.ExchRateUid).HasColumnName("EXCH_RATE_UID");
            entity.Property(e => e.ExchUid).HasColumnName("EXCH_UID");
            entity.Property(e => e.PayRciptDetDescribtion).HasColumnName("PAY_RCIPT_DET_DESCRIBTION");
            entity.Property(e => e.PayRciptDetDraft)
                .HasMaxLength(100)
                .HasColumnName("PAY_RCIPT_DET_DRAFT");
            entity.Property(e => e.PayRciptDetPayer).HasColumnName("PAY_RCIPT_DET_PAYER");
            entity.Property(e => e.PayRciptDetStatus).HasColumnName("PAY_RCIPT_DET_STATUS");
            entity.Property(e => e.PayRciptDetStatusControl).HasColumnName("PAY_RCIPT_DET_STATUS_CONTROL");
            entity.Property(e => e.PayRciptDetSync).HasColumnName("PAY_RCIPT_DET_SYNC");
            entity.Property(e => e.PayRciptDetTotalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PAY_RCIPT_DET_TOTAL_AMOUNT");
            entity.Property(e => e.PayRciptDetTotalAmountEchange)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PAY_RCIPT_DET_TOTAL_AMOUNT_ECHANGE");
            entity.Property(e => e.PayRciptDetType)
                .HasComment("[1 - نقد]-[2 - کارت خوان]-[3 - بن]-[4 - باشگاه]-[5 - اعتباری]")
                .HasColumnName("PAY_RCIPT_DET_TYPE");
            entity.Property(e => e.PayRciptSheetUid).HasColumnName("PAY_RCIPT_SHEET_UID");
            entity.Property(e => e.SalCatUid).HasColumnName("SAL_CAT_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.AccU).WithMany(p => p.PaymentRecieptDetails)
                .HasForeignKey(d => d.AccUid)
                .HasConstraintName("FK_PaymentRecieptDetail_Account");

            entity.HasOne(d => d.PayRciptSheetU).WithMany(p => p.PaymentRecieptDetails)
                .HasForeignKey(d => d.PayRciptSheetUid)
                .HasConstraintName("FK_PaymentRecieptDetail_PaymentRecieptSheet");

            entity.HasOne(d => d.SalCatU).WithMany(p => p.PaymentRecieptDetails)
                .HasForeignKey(d => d.SalCatUid)
                .HasConstraintName("FK_PaymentRecieptDetail_SalesCategory");
        });

        modelBuilder.Entity<PaymentRecieptSheet>(entity =>
        {
            entity.HasKey(e => e.PayRciptSheetUid);

            entity.ToTable("PaymentRecieptSheet");

            entity.HasIndex(e => new { e.BusUnitUid, e.FisPeriodUid, e.PayRciptSheetType, e.PayRciptSheetStatus }, "IX_BUS_UNIT_UID_FIS_PERIOD_UID_PAY_RCIPT_SHEET_TYPE_PAY_RCIPT_SHEET_STATUS");

            entity.HasIndex(e => e.PayRciptSheetUid, "IX_PAY_RCIPT_SHEET_UID");

            entity.Property(e => e.PayRciptSheetUid)
                .ValueGeneratedNever()
                .HasColumnName("PAY_RCIPT_SHEET_UID");
            entity.Property(e => e.AccClbUid).HasColumnName("ACC_CLB_UID");
            entity.Property(e => e.AccUid).HasColumnName("ACC_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.InvUid).HasColumnName("INV_UID");
            entity.Property(e => e.OrdUid).HasColumnName("ORD_UID");
            entity.Property(e => e.PayRciptSheetDate)
                .HasColumnType("datetime")
                .HasColumnName("PAY_RCIPT_SHEET_DATE");
            entity.Property(e => e.PayRciptSheetDescribtion).HasColumnName("PAY_RCIPT_SHEET_DESCRIBTION");
            entity.Property(e => e.PayRciptSheetNumber)
                .HasMaxLength(50)
                .HasColumnName("PAY_RCIPT_SHEET_NUMBER");
            entity.Property(e => e.PayRciptSheetStatus).HasColumnName("PAY_RCIPT_SHEET_STATUS");
            entity.Property(e => e.PayRciptSheetStatusControl).HasColumnName("PAY_RCIPT_SHEET_STATUS_CONTROL");
            entity.Property(e => e.PayRciptSheetTotalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PAY_RCIPT_SHEET_TOTAL_AMOUNT");
            entity.Property(e => e.PayRciptSheetType)
                .HasComment("1- برگه دریافت 2- برگه پرداخت")
                .HasColumnName("PAY_RCIPT_SHEET_TYPE");
            entity.Property(e => e.PurchUid).HasColumnName("PURCH_UID");
            entity.Property(e => e.StkTrnsUid).HasColumnName("STK_TRNS_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
            entity.Property(e => e.WarHosRecUid).HasColumnName("WAR_HOS_REC_UID");

            entity.HasOne(d => d.AccU).WithMany(p => p.PaymentRecieptSheets)
                .HasForeignKey(d => d.AccUid)
                .HasConstraintName("FK_PaymentRecieptSheet_Account");

            entity.HasOne(d => d.InvU).WithMany(p => p.PaymentRecieptSheets)
                .HasForeignKey(d => d.InvUid)
                .HasConstraintName("FK_PaymentRecieptSheet_Invoice");

            entity.HasOne(d => d.OrdU).WithMany(p => p.PaymentRecieptSheets)
                .HasForeignKey(d => d.OrdUid)
                .HasConstraintName("FK_PaymentRecieptSheet_Order");

            entity.HasOne(d => d.PurchU).WithMany(p => p.PaymentRecieptSheets)
                .HasForeignKey(d => d.PurchUid)
                .HasConstraintName("FK_PaymentRecieptSheet_Purchase");

            entity.HasOne(d => d.StkTrnsU).WithMany(p => p.PaymentRecieptSheets)
                .HasForeignKey(d => d.StkTrnsUid)
                .HasConstraintName("FK_PaymentRecieptSheet_StockTransfer");

            entity.HasOne(d => d.WarHosRecU).WithMany(p => p.PaymentRecieptSheets)
                .HasForeignKey(d => d.WarHosRecUid)
                .HasConstraintName("FK_PaymentRecieptSheet_WarehouseReciept");
        });

        modelBuilder.Entity<PersonelCalender>(entity =>
        {
            entity.HasKey(e => e.PcId);

            entity.ToTable("Personel_Calender");

            entity.Property(e => e.PcId)
                .ValueGeneratedNever()
                .HasColumnName("PC_ID");
            entity.Property(e => e.PcFrAccountclub).HasColumnName("PC_FR_ACCOUNTCLUB");
            entity.Property(e => e.PcFrCalender).HasColumnName("PC_FR_CALENDER");

            entity.HasOne(d => d.PcFrAccountclubNavigation).WithMany(p => p.PersonelCalenders)
                .HasForeignKey(d => d.PcFrAccountclub)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Personel_Calender_AccountClub");

            entity.HasOne(d => d.PcFrCalenderNavigation).WithMany(p => p.PersonelCalenders)
                .HasForeignKey(d => d.PcFrCalender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Personel_Calender_Calender");
        });

        modelBuilder.Entity<Personnel>(entity =>
        {
            entity.HasKey(e => e.PrsUid);

            entity.Property(e => e.PrsUid)
                .ValueGeneratedNever()
                .HasColumnName("PRS_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.PrsDescription)
                .HasMaxLength(400)
                .HasColumnName("PRS_DESCRIPTION");
            entity.Property(e => e.PrsFirstName)
                .HasMaxLength(50)
                .HasColumnName("PRS_FIRST_NAME");
            entity.Property(e => e.PrsFixed)
                .HasDefaultValueSql("((0))")
                .HasColumnName("PRS_FIXED");
            entity.Property(e => e.PrsId)
                .HasMaxLength(50)
                .HasColumnName("PRS_ID");
            entity.Property(e => e.PrsJobtitle)
                .HasMaxLength(100)
                .HasColumnName("PRS_JOBTITLE");
            entity.Property(e => e.PrsLastName)
                .HasMaxLength(100)
                .HasColumnName("PRS_LAST_NAME");
            entity.Property(e => e.PrsPhone1)
                .HasMaxLength(20)
                .HasColumnName("PRS_PHONE1");
            entity.Property(e => e.PrsPhone2)
                .HasMaxLength(20)
                .HasColumnName("PRS_PHONE2");
            entity.Property(e => e.PrsSex).HasColumnName("PRS_SEX");
            entity.Property(e => e.PrsStatus).HasColumnName("PRS_STATUS");
            entity.Property(e => e.PrsType)
                .HasDefaultValueSql("((0))")
                .HasColumnName("PRS_TYPE");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<PhoneBook>(entity =>
        {
            entity.HasKey(e => e.PhbUid);

            entity.ToTable("PhoneBook");

            entity.Property(e => e.PhbUid)
                .ValueGeneratedNever()
                .HasColumnName("PHB_UID");
            entity.Property(e => e.CityUid).HasColumnName("CITY_UID");
            entity.Property(e => e.PhbAddress).HasColumnName("PHB_ADDRESS");
            entity.Property(e => e.PhbBrithday)
                .HasColumnType("datetime")
                .HasColumnName("PHB_BRITHDAY");
            entity.Property(e => e.PhbDescribtion).HasColumnName("PHB_DESCRIBTION");
            entity.Property(e => e.PhbEconomicCode)
                .HasMaxLength(20)
                .HasColumnName("PHB_ECONOMIC_CODE");
            entity.Property(e => e.PhbFatherName)
                .HasMaxLength(100)
                .HasColumnName("PHB_FATHER_NAME");
            entity.Property(e => e.PhbMobile)
                .HasMaxLength(20)
                .HasColumnName("PHB_MOBILE");
            entity.Property(e => e.PhbName)
                .HasMaxLength(100)
                .HasColumnName("PHB_NAME");
            entity.Property(e => e.PhbNationalCode)
                .HasMaxLength(10)
                .HasColumnName("PHB_NATIONAL_CODE");
            entity.Property(e => e.PhbNationalId)
                .HasMaxLength(20)
                .HasColumnName("PHB_NATIONAL_ID");
            entity.Property(e => e.PhbPhone1)
                .HasMaxLength(20)
                .HasColumnName("PHB_PHONE1");
            entity.Property(e => e.PhbPhone2)
                .HasMaxLength(20)
                .HasColumnName("PHB_PHONE2");
            entity.Property(e => e.PhbPostalCode)
                .HasMaxLength(20)
                .HasColumnName("PHB_POSTAL_CODE");
            entity.Property(e => e.PhbStatus).HasColumnName("PHB_STATUS");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.CityU).WithMany(p => p.PhoneBooks)
                .HasForeignKey(d => d.CityUid)
                .HasConstraintName("FK_PhoneBook_City");
        });

        modelBuilder.Entity<PhotoDetail>(entity =>
        {
            entity.HasKey(e => e.PhtDetUid);

            entity.ToTable("PhotoDetail");

            entity.Property(e => e.PhtDetUid)
                .ValueGeneratedNever()
                .HasColumnName("PHT_DET_UID");
            entity.Property(e => e.AccPhtUid).HasColumnName("ACC_PHT_UID");
            entity.Property(e => e.InvDetUid).HasColumnName("INV_DET_UID");
            entity.Property(e => e.PhtDetCode)
                .HasMaxLength(50)
                .HasColumnName("PHT_DET_CODE");
            entity.Property(e => e.PhtDetCount).HasColumnName("PHT_DET_COUNT");
            entity.Property(e => e.PhtDetGetFileType).HasColumnName("PHT_DET_GET_FILE_TYPE");
            entity.Property(e => e.PhtDetKindPrint).HasColumnName("PHT_DET_KIND_PRINT");
            entity.Property(e => e.PhtDetName)
                .HasMaxLength(150)
                .HasColumnName("PHT_DET_NAME");
            entity.Property(e => e.PhtDetPath)
                .HasMaxLength(500)
                .HasColumnName("PHT_DET_PATH");
            entity.Property(e => e.PhtDetSize)
                .HasMaxLength(50)
                .HasColumnName("PHT_DET_SIZE");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.PrdUid);

            entity.ToTable("Product");

            entity.HasIndex(e => e.PrdCode, "IX_PRD_CODE");

            entity.HasIndex(e => e.PrdLvlUid3, "IX_PRD_LVL_UID3");

            entity.HasIndex(e => e.PrdUid, "IX_PRD_UID");

            entity.Property(e => e.PrdUid)
                .ValueGeneratedNever()
                .HasColumnName("PRD_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.FkProductUnit).HasColumnName("FK_ProductUnit");
            entity.Property(e => e.FkProductUnit2).HasColumnName("FK_ProductUnit2");
            entity.Property(e => e.PrdBarcode)
                .HasMaxLength(50)
                .HasColumnName("PRD_BARCODE");
            entity.Property(e => e.PrdBaseCost)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PRD_BASE_COST");
            entity.Property(e => e.PrdBaseTime).HasColumnName("PRD_BASE_TIME");
            entity.Property(e => e.PrdCode)
                .HasMaxLength(50)
                .HasColumnName("PRD_CODE");
            entity.Property(e => e.PrdCoefficient)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PRD_COEFFICIENT");
            entity.Property(e => e.PrdCoefficient2)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PRD_COEFFICIENT2");
            entity.Property(e => e.PrdContinuouseType).HasColumnName("PRD_CONTINUOUSE_TYPE");
            entity.Property(e => e.PrdDiscount)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PRD_DISCOUNT");
            entity.Property(e => e.PrdDiscountType)
                .HasDefaultValueSql("((0))")
                .HasColumnName("PRD_DISCOUNT_TYPE");
            entity.Property(e => e.PrdExtraCost)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PRD_EXTRA_COST");
            entity.Property(e => e.PrdExtraTime).HasColumnName("PRD_EXTRA_TIME");
            entity.Property(e => e.PrdHasPersonel).HasColumnName("PRD_HAS_PERSONEL");
            entity.Property(e => e.PrdHasTiming).HasColumnName("PRD_HAS_TIMING");
            entity.Property(e => e.PrdImage).HasColumnName("PRD_IMAGE");
            entity.Property(e => e.PrdImageShow)
                .HasDefaultValueSql("((0))")
                .HasColumnName("PRD_IMAGE_SHOW");
            entity.Property(e => e.PrdIranCode)
                .HasMaxLength(50)
                .HasColumnName("PRD_IRAN_CODE");
            entity.Property(e => e.PrdIsContonuouse).HasColumnName("PRD_IS_CONTONUOUSE");
            entity.Property(e => e.PrdIsUnit1Bigger).HasColumnName("PRD_IsUnit1Bigger");
            entity.Property(e => e.PrdLatinName)
                .HasMaxLength(100)
                .HasColumnName("PRD_LATIN_NAME");
            entity.Property(e => e.PrdLvlUid1).HasColumnName("PRD_LVL_UID1");
            entity.Property(e => e.PrdLvlUid2).HasColumnName("PRD_LVL_UID2");
            entity.Property(e => e.PrdLvlUid3).HasColumnName("PRD_LVL_UID3");
            entity.Property(e => e.PrdMaxQuantityOnHand).HasColumnName("PRD_MAX_QUANTITY_ON_HAND");
            entity.Property(e => e.PrdMaxSale).HasColumnName("PRD_MAX_SALE");
            entity.Property(e => e.PrdMaxTime).HasColumnName("PRD_MAX_TIME");
            entity.Property(e => e.PrdMemory).HasColumnName("PRD_MEMORY");
            entity.Property(e => e.PrdMemory2).HasColumnName("PRD_MEMORY2");
            entity.Property(e => e.PrdMinCharge)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PRD_MIN_CHARGE");
            entity.Property(e => e.PrdMinQuantityOnHand).HasColumnName("PRD_MIN_QUANTITY_ON_HAND");
            entity.Property(e => e.PrdMinTime).HasColumnName("PRD_MIN_TIME");
            entity.Property(e => e.PrdName)
                .HasMaxLength(100)
                .HasColumnName("PRD_NAME");
            entity.Property(e => e.PrdNameInPrint)
                .HasMaxLength(100)
                .HasColumnName("PRD_NAME_IN_PRINT");
            entity.Property(e => e.PrdNameInPrintTouchActive)
                .HasDefaultValueSql("((0))")
                .HasColumnName("PRD_NAME_IN_PRINT_TOUCH_ACTIVE");
            entity.Property(e => e.PrdNameShow)
                .HasDefaultValueSql("((1))")
                .HasColumnName("PRD_NAME_SHOW");
            entity.Property(e => e.PrdPercentDiscount).HasColumnName("PRD_PERCENT_DISCOUNT");
            entity.Property(e => e.PrdPersonelCommission)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("PRD_PERSONEL_COMMISSION");
            entity.Property(e => e.PrdPersonelPayment)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PRD_PERSONEL_PAYMENT");
            entity.Property(e => e.PrdPriceInPrint)
                .HasDefaultValueSql("((1))")
                .HasColumnName("PRD_PRICE_IN_PRINT");
            entity.Property(e => e.PrdPricePerUnit1)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PRD_PRICE_PER_UNIT1");
            entity.Property(e => e.PrdPricePerUnit2)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PRD_PRICE_PER_UNIT2");
            entity.Property(e => e.PrdPricePerUnit3)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PRD_PRICE_PER_UNIT3");
            entity.Property(e => e.PrdPricePerUnit4)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PRD_PRICE_PER_UNIT4");
            entity.Property(e => e.PrdPricePerUnit5)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PRD_PRICE_PER_UNIT5");
            entity.Property(e => e.PrdPricePerUnitExchange)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PRD_PRICE_PER_UNIT_EXCHANGE");
            entity.Property(e => e.PrdRemain).HasColumnName("PRD_REMAIN");
            entity.Property(e => e.PrdSalegroupid)
                .HasMaxLength(50)
                .HasColumnName("PRD_SALEGROUPID");
            entity.Property(e => e.PrdSerial)
                .HasDefaultValueSql("((0))")
                .HasColumnName("PRD_SERIAL");
            entity.Property(e => e.PrdStamp).HasColumnName("PRD_STAMP");
            entity.Property(e => e.PrdStatus).HasColumnName("PRD_STATUS");
            entity.Property(e => e.PrdStatusApp)
                .HasDefaultValueSql("((1))")
                .HasColumnName("PRD_STATUS_APP");
            entity.Property(e => e.PrdTarazoId).HasColumnName("PRD_TARAZO_ID");
            entity.Property(e => e.PrdTax).HasColumnName("PRD_TAX");
            entity.Property(e => e.PrdTaxValue)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PRD_TAX_VALUE");
            entity.Property(e => e.PrdTechnicalDescription).HasColumnName("PRD_TECHNICAL_DESCRIPTION");
            entity.Property(e => e.PrdUniqid)
                .ValueGeneratedOnAdd()
                .HasColumnName("PRD_UNIQID");
            entity.Property(e => e.PrdUnit)
                .HasMaxLength(10)
                .HasColumnName("PRD_UNIT");
            entity.Property(e => e.PrdUnit2)
                .HasMaxLength(10)
                .HasColumnName("PRD_UNIT2");
            entity.Property(e => e.PrdWareHouse).HasColumnName("PRD_WARE_HOUSE");
            entity.Property(e => e.ShortDescription).HasMaxLength(500);
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
            entity.Property(e => e.TaxUid).HasColumnName("TAX_UID");
            entity.Property(e => e.UomUid1).HasColumnName("UOM_UID1");
            entity.Property(e => e.UomUid2).HasColumnName("UOM_UID2");
            entity.Property(e => e.Volume).HasMaxLength(128);
            entity.Property(e => e.Weight).HasMaxLength(128);

            entity.HasOne(d => d.FkProductUnitNavigation).WithMany(p => p.ProductFkProductUnitNavigations)
                .HasForeignKey(d => d.FkProductUnit)
                .HasConstraintName("FK_Product_UnitOfMeasurement2");

            entity.HasOne(d => d.FkProductUnit2Navigation).WithMany(p => p.ProductFkProductUnit2Navigations)
                .HasForeignKey(d => d.FkProductUnit2)
                .HasConstraintName("FK_Product_UnitOfMeasurement3");

            entity.HasOne(d => d.PrdLvlUid3Navigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.PrdLvlUid3)
                .HasConstraintName("FK_Product_ProductLevel");

            entity.HasOne(d => d.TaxU).WithMany(p => p.Products)
                .HasForeignKey(d => d.TaxUid)
                .HasConstraintName("FK_Product_Tax");

            entity.HasOne(d => d.UomUid1Navigation).WithMany(p => p.ProductUomUid1Navigations)
                .HasForeignKey(d => d.UomUid1)
                .HasConstraintName("FK_Product_UnitOfMeasurement");

            entity.HasOne(d => d.UomUid2Navigation).WithMany(p => p.ProductUomUid2Navigations)
                .HasForeignKey(d => d.UomUid2)
                .HasConstraintName("FK_Product_UnitOfMeasurement1");
        });

        modelBuilder.Entity<ProductLevel>(entity =>
        {
            entity.HasKey(e => e.PrdLvlUid);

            entity.ToTable("ProductLevel");

            entity.HasIndex(e => new { e.PrdLvlParentUid, e.BusUnitUid, e.FisPeriodUid, e.PrdLvlStatus }, "IX_PRD_LVL_PARENT_UID_BUS_UNIT_UID_FIS_PERIOD_UID_PRD_LVL_STATUS");

            entity.Property(e => e.PrdLvlUid)
                .ValueGeneratedNever()
                .HasColumnName("PRD_LVL_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.PrdLvlAllowPrinter2)
                .HasDefaultValueSql("((1))")
                .HasColumnName("PRD_LVL_ALLOW_PRINTER2");
            entity.Property(e => e.PrdLvlBooth).HasColumnName("PRD_LVL_BOOTH");
            entity.Property(e => e.PrdLvlCode)
                .HasMaxLength(50)
                .HasColumnName("PRD_LVL_CODE");
            entity.Property(e => e.PrdLvlCodeValue)
                .HasMaxLength(50)
                .HasColumnName("PRD_LVL_CODE_VALUE");
            entity.Property(e => e.PrdLvlCustomButton).HasColumnName("PRD_LVL_CUSTOM_BUTTON");
            entity.Property(e => e.PrdLvlCustomTab).HasColumnName("PRD_LVL_CUSTOM_TAB");
            entity.Property(e => e.PrdLvlExpButton).HasColumnName("PRD_LVL_EXP_BUTTON");
            entity.Property(e => e.PrdLvlName)
                .HasMaxLength(100)
                .HasColumnName("PRD_LVL_NAME");
            entity.Property(e => e.PrdLvlParentUid).HasColumnName("PRD_LVL_PARENT_UID");
            entity.Property(e => e.PrdLvlPrinter)
                .HasMaxLength(150)
                .HasColumnName("PRD_LVL_PRINTER");
            entity.Property(e => e.PrdLvlStatus).HasColumnName("PRD_LVL_STATUS");
            entity.Property(e => e.PrdLvlTouchKeyNumber).HasColumnName("PRD_LVL_TOUCH_KEY_NUMBER");
            entity.Property(e => e.PrdLvlType).HasColumnName("PRD_LVL_TYPE");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.FisPeriodU).WithMany(p => p.ProductLevels)
                .HasForeignKey(d => d.FisPeriodUid)
                .HasConstraintName("FK_ProductLevel_FiscalPeriod");
        });

        modelBuilder.Entity<ProductLevelAccess>(entity =>
        {
            entity.HasKey(e => e.PrdLvlAcsUid);

            entity.ToTable("ProductLevelAccess");

            entity.Property(e => e.PrdLvlAcsUid)
                .ValueGeneratedNever()
                .HasColumnName("PRD_LVL_ACS_UID");
            entity.Property(e => e.PrdLvlAcsSectionInt).HasColumnName("PRD_LVL_ACS_SECTION_INT");
            entity.Property(e => e.PrdLvlAcsSectionUid).HasColumnName("PRD_LVL_ACS_SECTION_UID");
            entity.Property(e => e.PrdLvlAcsStatus).HasColumnName("PRD_LVL_ACS_STATUS");
            entity.Property(e => e.PrdLvlAcsTabNumber).HasColumnName("PRD_LVL_ACS_TAB_NUMBER");
            entity.Property(e => e.PrdLvlUid2).HasColumnName("PRD_LVL_UID2");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<ProductPicture>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Image).IsRequired();

            entity.HasOne(d => d.Product).WithMany(p => p.ProductPictures)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ProductPictures_Product");
        });

        modelBuilder.Entity<ProductProperty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ProductProperty1");

            entity.ToTable("ProductProperty");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Value)
                .IsRequired()
                .HasMaxLength(200);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductProperties)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductProperty1_Product");

            entity.HasOne(d => d.Property).WithMany(p => p.ProductProperties)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductProperty1_Property");
        });

        modelBuilder.Entity<ProductQuantity>(entity =>
        {
            entity.HasKey(e => e.PrdQuanUid).HasName("PK_StartWork");

            entity.ToTable("ProductQuantity");

            entity.Property(e => e.PrdQuanUid)
                .ValueGeneratedNever()
                .HasColumnName("PRD_QUAN_UID");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.PrdQuanDate)
                .HasColumnType("datetime")
                .HasColumnName("PRD_QUAN_DATE");
            entity.Property(e => e.PrdQuanStatus).HasColumnName("PRD_QUAN_STATUS");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<ProductQuantityOnHand>(entity =>
        {
            entity.HasKey(e => e.PrdQuanHndUid);

            entity.ToTable("ProductQuantityOnHand");

            entity.Property(e => e.PrdQuanHndUid)
                .ValueGeneratedNever()
                .HasColumnName("PRD_QUAN_HND_UID");
            entity.Property(e => e.PrdQuanHndPrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PRD_QUAN_HND_PRICE");
            entity.Property(e => e.PrdQuanHndQuantityOnHand).HasColumnName("PRD_QUAN_HND_QUANTITY_ON_HAND");
            entity.Property(e => e.PrdQuanHndStatus).HasColumnName("PRD_QUAN_HND_STATUS");
            entity.Property(e => e.PrdQuanHndType).HasColumnName("PRD_QUAN_HND_TYPE");
            entity.Property(e => e.PrdQuanUid).HasColumnName("PRD_QUAN_UID");
            entity.Property(e => e.PrdUid).HasColumnName("PRD_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
            entity.Property(e => e.WarHosUid).HasColumnName("WAR_HOS_UID");

            entity.HasOne(d => d.PrdQuanU).WithMany(p => p.ProductQuantityOnHands)
                .HasForeignKey(d => d.PrdQuanUid)
                .HasConstraintName("FK_ProductQuantityOnHand_StartWork");

            entity.HasOne(d => d.PrdU).WithMany(p => p.ProductQuantityOnHands)
                .HasForeignKey(d => d.PrdUid)
                .HasConstraintName("FK_ProductQuantityOnHand_Product");

            entity.HasOne(d => d.WarHosU).WithMany(p => p.ProductQuantityOnHands)
                .HasForeignKey(d => d.WarHosUid)
                .HasConstraintName("FK_ProductQuantityOnHand_WareHouse");
        });

        modelBuilder.Entity<ProductSubset>(entity =>
        {
            entity.HasKey(e => e.PrdSubUid);

            entity.ToTable("ProductSubset");

            entity.Property(e => e.PrdSubUid)
                .ValueGeneratedNever()
                .HasColumnName("PRD_SUB_UID");
            entity.Property(e => e.PrdParentUid).HasColumnName("PRD_PARENT_UID");
            entity.Property(e => e.PrdSubQuantity).HasColumnName("PRD_SUB_QUANTITY");
            entity.Property(e => e.PrdSubStatus).HasColumnName("PRD_SUB_STATUS");
            entity.Property(e => e.PrdUid).HasColumnName("PRD_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<Property>(entity =>
        {
            entity.ToTable("Property");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.PurchUid);

            entity.ToTable("Purchase");

            entity.Property(e => e.PurchUid)
                .ValueGeneratedNever()
                .HasColumnName("PURCH_UID");
            entity.Property(e => e.AccClbUid).HasColumnName("ACC_CLB_UID");
            entity.Property(e => e.AccUid).HasColumnName("ACC_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.OrdUid).HasColumnName("ORD_UID");
            entity.Property(e => e.PurchDate)
                .HasColumnType("datetime")
                .HasColumnName("PURCH_DATE");
            entity.Property(e => e.PurchDescribtion).HasColumnName("PURCH_DESCRIBTION");
            entity.Property(e => e.PurchDetTotalDiscount)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PURCH_DET_TOTAL_DISCOUNT");
            entity.Property(e => e.PurchDueDate)
                .HasColumnType("datetime")
                .HasColumnName("PURCH_DUE_DATE");
            entity.Property(e => e.PurchExtendedAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PURCH_EXTENDED_AMOUNT");
            entity.Property(e => e.PurchFinalStatusControl).HasColumnName("PURCH_FINAL_STATUS_CONTROL");
            entity.Property(e => e.PurchNumber)
                .HasMaxLength(50)
                .HasColumnName("PURCH_NUMBER");
            entity.Property(e => e.PurchParentUid).HasColumnName("PURCH_PARENT_UID");
            entity.Property(e => e.PurchReference)
                .HasMaxLength(100)
                .HasColumnName("PURCH_REFERENCE");
            entity.Property(e => e.PurchStatus).HasColumnName("PURCH_STATUS");
            entity.Property(e => e.PurchStatusControl).HasColumnName("PURCH_STATUS_CONTROL");
            entity.Property(e => e.PurchSync).HasColumnName("PURCH_SYNC");
            entity.Property(e => e.PurchTotalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PURCH_TOTAL_AMOUNT");
            entity.Property(e => e.PurchTotalCost)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PURCH_TOTAL_COST");
            entity.Property(e => e.PurchTotalDiscount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PURCH_TOTAL_DISCOUNT");
            entity.Property(e => e.PurchTotalTax)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PURCH_TOTAL_TAX");
            entity.Property(e => e.SalCatUid).HasColumnName("SAL_CAT_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
            entity.Property(e => e.WrkSttUid).HasColumnName("WRK_STT_UID");

            entity.HasOne(d => d.AccU).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.AccUid)
                .HasConstraintName("FK_Purchase_Account");

            entity.HasOne(d => d.FisPeriodU).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.FisPeriodUid)
                .HasConstraintName("FK_Purchase_FiscalPeriod");

            entity.HasOne(d => d.OrdU).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.OrdUid)
                .HasConstraintName("FK_Purchase_Order");

            entity.HasOne(d => d.SalCatU).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.SalCatUid)
                .HasConstraintName("FK_Purchase_SalesCategory");
        });

        modelBuilder.Entity<PurchaseDetail>(entity =>
        {
            entity.HasKey(e => e.PurchDetUid);

            entity.Property(e => e.PurchDetUid)
                .ValueGeneratedNever()
                .HasColumnName("PURCH_DET_UID");
            entity.Property(e => e.PrdUid).HasColumnName("PRD_UID");
            entity.Property(e => e.PurchDetDescribtion).HasColumnName("PURCH_DET_DESCRIBTION");
            entity.Property(e => e.PurchDetDiscount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PURCH_DET_DISCOUNT");
            entity.Property(e => e.PurchDetPricePerUnit)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PURCH_DET_PRICE_PER_UNIT");
            entity.Property(e => e.PurchDetQuantity).HasColumnName("PURCH_DET_QUANTITY");
            entity.Property(e => e.PurchDetRowOrder).HasColumnName("PURCH_DET_ROW_ORDER");
            entity.Property(e => e.PurchDetStatus).HasColumnName("PURCH_DET_STATUS");
            entity.Property(e => e.PurchDetTax)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PURCH_DET_TAX");
            entity.Property(e => e.PurchDetTotalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PURCH_DET_TOTAL_AMOUNT");
            entity.Property(e => e.PurchUid).HasColumnName("PURCH_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
            entity.Property(e => e.UomUid).HasColumnName("UOM_UID");
            entity.Property(e => e.WarHosUid).HasColumnName("WAR_HOS_UID");

            entity.HasOne(d => d.PrdU).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.PrdUid)
                .HasConstraintName("FK_PurchaseDetails_Product");

            entity.HasOne(d => d.PurchU).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.PurchUid)
                .HasConstraintName("FK_PurchaseDetails_Purchase");

            entity.HasOne(d => d.UomU).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.UomUid)
                .HasConstraintName("FK_PurchaseDetails_UnitOfMeasurement");

            entity.HasOne(d => d.WarHosU).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.WarHosUid)
                .HasConstraintName("FK_PurchaseDetails_WareHouse");
        });

        modelBuilder.Entity<Quote>(entity =>
        {
            entity.HasKey(e => e.QutUid);

            entity.ToTable("Quote");

            entity.Property(e => e.QutUid)
                .ValueGeneratedNever()
                .HasColumnName("QUT_UID");
            entity.Property(e => e.AccUid).HasColumnName("ACC_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.QutDate)
                .HasColumnType("datetime")
                .HasColumnName("QUT_DATE");
            entity.Property(e => e.QutDescribtion).HasColumnName("QUT_DESCRIBTION");
            entity.Property(e => e.QutExtendedAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("QUT_EXTENDED_AMOUNT");
            entity.Property(e => e.QutFinalStatusControl).HasColumnName("QUT_FINAL_STATUS_CONTROL");
            entity.Property(e => e.QutNumber)
                .HasMaxLength(50)
                .HasColumnName("QUT_NUMBER");
            entity.Property(e => e.QutStatus).HasColumnName("QUT_STATUS");
            entity.Property(e => e.QutStatusControl).HasColumnName("QUT_STATUS_CONTROL");
            entity.Property(e => e.QutTotalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("QUT_TOTAL_AMOUNT");
            entity.Property(e => e.QutTotalCost)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("QUT_TOTAL_COST");
            entity.Property(e => e.QutTotalDiscount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("QUT_TOTAL_DISCOUNT");
            entity.Property(e => e.QutTotalTax)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("QUT_TOTAL_TAX");
            entity.Property(e => e.SalCatUid).HasColumnName("SAL_CAT_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.AccU).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.AccUid)
                .HasConstraintName("FK_Quote_Account");

            entity.HasOne(d => d.FisPeriodU).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.FisPeriodUid)
                .HasConstraintName("FK_Quote_FiscalPeriod");

            entity.HasOne(d => d.SalCatU).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.SalCatUid)
                .HasConstraintName("FK_Quote_SalesCategory");
        });

        modelBuilder.Entity<QuoteDetail>(entity =>
        {
            entity.HasKey(e => e.QutDetUid);

            entity.Property(e => e.QutDetUid)
                .ValueGeneratedNever()
                .HasColumnName("QUT_DET_UID");
            entity.Property(e => e.PrdUid).HasColumnName("PRD_UID");
            entity.Property(e => e.QutDetDescribtion).HasColumnName("QUT_DET_DESCRIBTION");
            entity.Property(e => e.QutDetDiscount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("QUT_DET_DISCOUNT");
            entity.Property(e => e.QutDetPricePerUnit)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("QUT_DET_PRICE_PER_UNIT");
            entity.Property(e => e.QutDetQuantity).HasColumnName("QUT_DET_QUANTITY");
            entity.Property(e => e.QutDetStatus).HasColumnName("QUT_DET_STATUS");
            entity.Property(e => e.QutDetTax)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("QUT_DET_TAX");
            entity.Property(e => e.QutDetTotalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("QUT_DET_TOTAL_AMOUNT");
            entity.Property(e => e.QutUid).HasColumnName("QUT_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
            entity.Property(e => e.UomUid).HasColumnName("UOM_UID");
            entity.Property(e => e.WarHosUid).HasColumnName("WAR_HOS_UID");

            entity.HasOne(d => d.PrdU).WithMany(p => p.QuoteDetails)
                .HasForeignKey(d => d.PrdUid)
                .HasConstraintName("FK_QuoteDetails_Product");

            entity.HasOne(d => d.QutU).WithMany(p => p.QuoteDetails)
                .HasForeignKey(d => d.QutUid)
                .HasConstraintName("FK_QuoteDetails_Quote");

            entity.HasOne(d => d.UomU).WithMany(p => p.QuoteDetails)
                .HasForeignKey(d => d.UomUid)
                .HasConstraintName("FK_QuoteDetails_UnitOfMeasurement");

            entity.HasOne(d => d.WarHosU).WithMany(p => p.QuoteDetails)
                .HasForeignKey(d => d.WarHosUid)
                .HasConstraintName("FK_QuoteDetails_WareHouse");
        });

        modelBuilder.Entity<RegardingObject>(entity =>
        {
            entity.HasKey(e => e.RgdObjUid);

            entity.ToTable("RegardingObject", tb => tb.HasTrigger("trgForInsertRegardingObject"));

            entity.Property(e => e.RgdObjUid)
                .ValueGeneratedNever()
                .HasColumnName("RGD_OBJ_UID");
            entity.Property(e => e.RgdObjCode)
                .HasMaxLength(50)
                .HasColumnName("RGD_OBJ_CODE");
            entity.Property(e => e.RgdObjName)
                .HasMaxLength(100)
                .HasColumnName("RGD_OBJ_NAME");
            entity.Property(e => e.RgdObjStatus).HasColumnName("RGD_OBJ_STATUS");
            entity.Property(e => e.RgdObjUidName)
                .HasMaxLength(100)
                .HasColumnName("RGD_OBJ_UID_NAME");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<RelatedPersonnel>(entity =>
        {
            entity.HasKey(e => e.RelPrsUid);

            entity.Property(e => e.RelPrsUid)
                .ValueGeneratedNever()
                .HasColumnName("REL_PRS_UID");
            entity.Property(e => e.InvUid).HasColumnName("INV_UID");
            entity.Property(e => e.PrsUid).HasColumnName("PRS_UID");
            entity.Property(e => e.RelPrsStatus).HasColumnName("REL_PRS_STATUS");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.InvU).WithMany(p => p.RelatedPersonnel)
                .HasForeignKey(d => d.InvUid)
                .HasConstraintName("FK_RelatedPersonnel_Invoice");

            entity.HasOne(d => d.PrsU).WithMany(p => p.RelatedPersonnel)
                .HasForeignKey(d => d.PrsUid)
                .HasConstraintName("FK_RelatedPersonnel_Personnel");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolUid);

            entity.Property(e => e.RolUid)
                .ValueGeneratedNever()
                .HasColumnName("ROL_UID");
            entity.Property(e => e.RolName)
                .HasMaxLength(50)
                .HasColumnName("ROL_NAME");
            entity.Property(e => e.RolType)
                .HasComment("1- admin 2 - supervisor 3 - user")
                .HasColumnName("ROL_TYPE");
        });

        modelBuilder.Entity<RoleAccess>(entity =>
        {
            entity.HasKey(e => e.AcsUid);

            entity.ToTable("RoleAccess");

            entity.Property(e => e.AcsUid)
                .ValueGeneratedNever()
                .HasColumnName("ACS_UID");
            entity.Property(e => e.AcsAppSection)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACS_APP_SECTION");
            entity.Property(e => e.AcsBon)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACS_BON");
            entity.Property(e => e.AcsCash)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACS_CASH");
            entity.Property(e => e.AcsClub)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACS_CLUB");
            entity.Property(e => e.AcsCrediting)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACS_CREDITING");
            entity.Property(e => e.AcsDelete).HasColumnName("ACS_DELETE");
            entity.Property(e => e.AcsExchange)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACS_EXCHANGE");
            entity.Property(e => e.AcsFull).HasColumnName("ACS_FULL");
            entity.Property(e => e.AcsInvoiceDateEdit)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACS_INVOICE_DATE_EDIT");
            entity.Property(e => e.AcsInvoiceDiscount)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACS_INVOICE_DISCOUNT");
            entity.Property(e => e.AcsPosBank)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACS_POS_BANK");
            entity.Property(e => e.AcsPrdPercentDiscountEdit)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACS_PRD_PERCENT_DISCOUNT_EDIT");
            entity.Property(e => e.AcsPrdPriceEdit)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACS_PRD_PRICE_EDIT");
            entity.Property(e => e.AcsPreInvoice)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACS_PRE_INVOICE");
            entity.Property(e => e.AcsRead).HasColumnName("ACS_READ");
            entity.Property(e => e.AcsReturn)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACS_RETURN");
            entity.Property(e => e.AcsTempDelete)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACS_TEMP_DELETE");
            entity.Property(e => e.AcsTempRead)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACS_TEMP_READ");
            entity.Property(e => e.AcsTempUpdate)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACS_TEMP_UPDATE");
            entity.Property(e => e.AcsTempWrite)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACS_TEMP_WRITE");
            entity.Property(e => e.AcsUpdate).HasColumnName("ACS_UPDATE");
            entity.Property(e => e.AcsWrite).HasColumnName("ACS_WRITE");
            entity.Property(e => e.RolUid).HasColumnName("ROL_UID");

            entity.HasOne(d => d.RolU).WithMany(p => p.RoleAccesses)
                .HasForeignKey(d => d.RolUid)
                .HasConstraintName("FK_RoleAccess_RoleAccess");
        });

        modelBuilder.Entity<SalesCategory>(entity =>
        {
            entity.HasKey(e => e.SalCatUid);

            entity.ToTable("SalesCategory", tb => tb.HasTrigger("trgForInsertSalesCategory"));

            entity.Property(e => e.SalCatUid)
                .ValueGeneratedNever()
                .HasColumnName("SAL_CAT_UID");
            entity.Property(e => e.SalCatCode)
                .HasMaxLength(50)
                .HasColumnName("SAL_CAT_CODE");
            entity.Property(e => e.SalCatName)
                .HasMaxLength(100)
                .HasColumnName("SAL_CAT_NAME");
            entity.Property(e => e.SalCatStatus).HasColumnName("SAL_CAT_STATUS");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<Salon>(entity =>
        {
            entity.HasKey(e => e.SlnId);

            entity.ToTable("Salon");

            entity.Property(e => e.SlnId).HasColumnName("SLN_ID");
            entity.Property(e => e.FrWarHosUid).HasColumnName("FR_WAR_HOS_UID");
            entity.Property(e => e.SlnName)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("SLN_NAME");
            entity.Property(e => e.SlnType).HasColumnName("SLN_TYPE");

            entity.HasOne(d => d.FrWarHosU).WithMany(p => p.Salons)
                .HasForeignKey(d => d.FrWarHosUid)
                .HasConstraintName("FK_Salon_WareHouse");
        });

        modelBuilder.Entity<SalonDetail>(entity =>
        {
            entity.HasKey(e => e.SdId);

            entity.ToTable("SalonDetail");

            entity.Property(e => e.SdId).HasColumnName("SD_ID");
            entity.Property(e => e.SdFrAccountclub).HasColumnName("SD_FR_ACCOUNTCLUB");
            entity.Property(e => e.SdFrSalon).HasColumnName("SD_FR_SALON");

            entity.HasOne(d => d.SdFrAccountclubNavigation).WithMany(p => p.SalonDetails)
                .HasForeignKey(d => d.SdFrAccountclub)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalonDetail_AccountClub");

            entity.HasOne(d => d.SdFrSalonNavigation).WithMany(p => p.SalonDetails)
                .HasForeignKey(d => d.SdFrSalon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalonDetail_Salon");
        });

        modelBuilder.Entity<SalonProduct>(entity =>
        {
            entity.HasKey(e => e.SpId).HasName("PK_SalonProduct_1");

            entity.ToTable("SalonProduct");

            entity.Property(e => e.SpId)
                .ValueGeneratedNever()
                .HasColumnName("SP_ID");
            entity.Property(e => e.SpFrProduct).HasColumnName("SP_FR_PRODUCT");
            entity.Property(e => e.SpFrSalon).HasColumnName("SP_FR_SALON");

            entity.HasOne(d => d.SpFrProductNavigation).WithMany(p => p.SalonProducts)
                .HasForeignKey(d => d.SpFrProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalonProduct_Product");

            entity.HasOne(d => d.SpFrSalonNavigation).WithMany(p => p.SalonProducts)
                .HasForeignKey(d => d.SpFrSalon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalonProduct_Salon");
        });

        modelBuilder.Entity<SelectDeliverer>(entity =>
        {
            entity.HasKey(e => e.SlcPrsUid);

            entity.ToTable("SelectDeliverer");

            entity.Property(e => e.SlcPrsUid)
                .ValueGeneratedNever()
                .HasColumnName("SLC_PRS_UID");
            entity.Property(e => e.InvUid).HasColumnName("INV_UID");
            entity.Property(e => e.PrsUid).HasColumnName("PRS_UID");
            entity.Property(e => e.SlcPrsActive).HasColumnName("SLC_PRS_ACTIVE");
            entity.Property(e => e.SlcPrsDeliver).HasColumnName("SLC_PRS_DELIVER");
            entity.Property(e => e.SlcPrsSendSms)
                .HasDefaultValueSql("((0))")
                .HasColumnName("SLC_PRS_SEND_SMS");
            entity.Property(e => e.SlcPrsStatus).HasColumnName("SLC_PRS_STATUS");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<SerialDetail>(entity =>
        {
            entity.HasKey(e => e.SerDetUid);

            entity.ToTable("SerialDetail");

            entity.Property(e => e.SerDetUid)
                .ValueGeneratedNever()
                .HasColumnName("SER_DET_UID");
            entity.Property(e => e.InvDetUid).HasColumnName("INV_DET_UID");
            entity.Property(e => e.PurchDetUid).HasColumnName("PURCH_DET_UID");
            entity.Property(e => e.SerDetNumber)
                .HasMaxLength(50)
                .HasColumnName("SER_DET_NUMBER");
            entity.Property(e => e.SerDetState).HasColumnName("SER_DET_STATE");
            entity.Property(e => e.SerDetStatus).HasColumnName("SER_DET_STATUS");
            entity.Property(e => e.SerDetSync).HasColumnName("SER_DET_SYNC");
            entity.Property(e => e.SerUid).HasColumnName("SER_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.InvDetU).WithMany(p => p.SerialDetails)
                .HasForeignKey(d => d.InvDetUid)
                .HasConstraintName("FK_SerialDetail_InvoiceDetails");

            entity.HasOne(d => d.PurchDetU).WithMany(p => p.SerialDetails)
                .HasForeignKey(d => d.PurchDetUid)
                .HasConstraintName("FK_SerialDetail_PurchaseDetails");
        });

        modelBuilder.Entity<ServiceTransaction>(entity =>
        {
            entity.HasKey(e => e.StrId);

            entity.Property(e => e.StrId)
                .ValueGeneratedNever()
                .HasColumnName("STR_ID");
            entity.Property(e => e.StrAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("STR_AMOUNT");
            entity.Property(e => e.StrCheckoutType).HasColumnName("STR_CHECKOUT_TYPE");
            entity.Property(e => e.StrCreateOn)
                .HasColumnType("date")
                .HasColumnName("STR_CREATE_ON");
            entity.Property(e => e.StrDesc)
                .HasMaxLength(200)
                .HasColumnName("STR_DESC");
            entity.Property(e => e.StrDiscount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("STR_DISCOUNT");
            entity.Property(e => e.StrFrAccountclub).HasColumnName("STR_FR_ACCOUNTCLUB");
            entity.Property(e => e.StrFrContract).HasColumnName("STR_FR_CONTRACT");
            entity.Property(e => e.StrFrCreateBy).HasColumnName("STR_FR_CREATE_BY");
            entity.Property(e => e.StrFrCsp).HasColumnName("STR_FR_CSP");
            entity.Property(e => e.StrFrModifiedBy).HasColumnName("STR_FR_MODIFIED_BY");
            entity.Property(e => e.StrFrProduct).HasColumnName("STR_FR_PRODUCT");
            entity.Property(e => e.StrFrRecharge).HasColumnName("STR_FR_RECHARGE");
            entity.Property(e => e.StrFrSalon).HasColumnName("STR_FR_SALON");
            entity.Property(e => e.StrFrTicketDetail).HasColumnName("STR_FR_TICKET_DETAIL");
            entity.Property(e => e.StrFullName)
                .HasMaxLength(200)
                .HasColumnName("STR_FULL_NAME");
            entity.Property(e => e.StrIndicator).HasColumnName("STR_INDICATOR");
            entity.Property(e => e.StrMobile)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STR_MOBILE");
            entity.Property(e => e.StrModifiedOn)
                .HasColumnType("date")
                .HasColumnName("STR_MODIFIED_ON");
            entity.Property(e => e.StrStatus).HasColumnName("STR_STATUS");
            entity.Property(e => e.StrType).HasColumnName("STR_TYPE");
            entity.Property(e => e.StrYear).HasColumnName("STR_YEAR");

            entity.HasOne(d => d.StrFrAccountclubNavigation).WithMany(p => p.ServiceTransactions)
                .HasForeignKey(d => d.StrFrAccountclub)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceTransactions_AccountClub");

            entity.HasOne(d => d.StrFrContractNavigation).WithMany(p => p.ServiceTransactions)
                .HasForeignKey(d => d.StrFrContract)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceTransactions_Contract");

            entity.HasOne(d => d.StrFrCreateByNavigation).WithMany(p => p.ServiceTransactionStrFrCreateByNavigations)
                .HasForeignKey(d => d.StrFrCreateBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceTransactions_SystemUsers_CreateBy");

            entity.HasOne(d => d.StrFrCspNavigation).WithMany(p => p.ServiceTransactions)
                .HasForeignKey(d => d.StrFrCsp)
                .HasConstraintName("FK_ServiceTransactions_ContinuouseServicesPlaning");

            entity.HasOne(d => d.StrFrModifiedByNavigation).WithMany(p => p.ServiceTransactionStrFrModifiedByNavigations)
                .HasForeignKey(d => d.StrFrModifiedBy)
                .HasConstraintName("FK_ServiceTransactions_SystemUsers_ModifiedBy");

            entity.HasOne(d => d.StrFrProductNavigation).WithMany(p => p.ServiceTransactions)
                .HasForeignKey(d => d.StrFrProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceTransactions_Product");

            entity.HasOne(d => d.StrFrRechargeNavigation).WithMany(p => p.ServiceTransactions)
                .HasForeignKey(d => d.StrFrRecharge)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceTransactions_CardRechage");

            entity.HasOne(d => d.StrFrSalonNavigation).WithMany(p => p.ServiceTransactions)
                .HasForeignKey(d => d.StrFrSalon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceTransactions_Salon");

            entity.HasOne(d => d.StrFrTicketDetailNavigation).WithMany(p => p.ServiceTransactions)
                .HasForeignKey(d => d.StrFrTicketDetail)
                .HasConstraintName("FK_ServiceTransactions_TicketDetail");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.SetUid);

            entity.ToTable("Setting", tb => tb.HasTrigger("trgForInsertSetting"));

            entity.Property(e => e.SetUid)
                .ValueGeneratedNever()
                .HasColumnName("SET_UID");
            entity.Property(e => e.SetBase).HasColumnName("SET_BASE");
            entity.Property(e => e.SetKey)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SET_KEY");
            entity.Property(e => e.SetValue)
                .HasMaxLength(255)
                .HasColumnName("SET_VALUE");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.ShfId);

            entity.Property(e => e.ShfId).HasColumnName("SHF_ID");
            entity.Property(e => e.ShfEndTime).HasColumnName("SHF_END_TIME");
            entity.Property(e => e.ShfName)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("SHF_NAME");
            entity.Property(e => e.ShfStartTime).HasColumnName("SHF_START_TIME");
            entity.Property(e => e.ShfTelorance).HasColumnName("SHF_TELORANCE");
        });

        modelBuilder.Entity<SmsDetail>(entity =>
        {
            entity.HasKey(e => e.SmsDetUid);

            entity.Property(e => e.SmsDetUid)
                .ValueGeneratedNever()
                .HasColumnName("SMS_DET_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.FldUid).HasColumnName("FLD_UID");
            entity.Property(e => e.SmsDetMessage).HasColumnName("SMS_DET_MESSAGE");
            entity.Property(e => e.SmsDetMessageType).HasColumnName("SMS_DET_MESSAGE_TYPE");
            entity.Property(e => e.SmsDetNewline).HasColumnName("SMS_DET_NEWLINE");
            entity.Property(e => e.SmsHedUid).HasColumnName("SMS_HED_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.SmsHedU).WithMany(p => p.SmsDetails)
                .HasForeignKey(d => d.SmsHedUid)
                .HasConstraintName("FK_SmsDetails_SmsDetails");
        });

        modelBuilder.Entity<SmsHeader>(entity =>
        {
            entity.HasKey(e => e.SmsHedUid);

            entity.ToTable("SmsHeader");

            entity.Property(e => e.SmsHedUid)
                .ValueGeneratedNever()
                .HasColumnName("SMS_HED_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.SmsHedName)
                .HasMaxLength(500)
                .HasColumnName("SMS_HED_NAME");
            entity.Property(e => e.SmsHedStatus).HasColumnName("SMS_HED_STATUS");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.SttUid);

            entity.ToTable("State", tb => tb.HasTrigger("trgForInsertState"));

            entity.Property(e => e.SttUid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("STT_UID");
            entity.Property(e => e.SttCode)
                .HasMaxLength(50)
                .HasColumnName("STT_CODE");
            entity.Property(e => e.SttName)
                .HasMaxLength(50)
                .HasColumnName("STT_NAME");
            entity.Property(e => e.SttStatus).HasColumnName("STT_STATUS");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<StockTransfer>(entity =>
        {
            entity.HasKey(e => e.StkTrnsUid);

            entity.ToTable("StockTransfer");

            entity.Property(e => e.StkTrnsUid)
                .ValueGeneratedNever()
                .HasColumnName("STK_TRNS_UID");
            entity.Property(e => e.AccUid).HasColumnName("ACC_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.CstCtrUid).HasColumnName("CST_CTR_UID");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.OrdUid).HasColumnName("ORD_UID");
            entity.Property(e => e.QutUid).HasColumnName("QUT_UID");
            entity.Property(e => e.SalCatUid).HasColumnName("SAL_CAT_UID");
            entity.Property(e => e.StkTrnsDate)
                .HasColumnType("datetime")
                .HasColumnName("STK_TRNS_DATE");
            entity.Property(e => e.StkTrnsDescribtion).HasColumnName("STK_TRNS_DESCRIBTION");
            entity.Property(e => e.StkTrnsDueDate)
                .HasColumnType("datetime")
                .HasColumnName("STK_TRNS_DUE_DATE");
            entity.Property(e => e.StkTrnsExtendedAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("STK_TRNS_EXTENDED_AMOUNT");
            entity.Property(e => e.StkTrnsFinalStatusControl).HasColumnName("STK_TRNS_FINAL_STATUS_CONTROL");
            entity.Property(e => e.StkTrnsNumber)
                .HasMaxLength(50)
                .HasColumnName("STK_TRNS_NUMBER");
            entity.Property(e => e.StkTrnsParentUid).HasColumnName("STK_TRNS_PARENT_UID");
            entity.Property(e => e.StkTrnsReference)
                .HasMaxLength(100)
                .HasColumnName("STK_TRNS_REFERENCE");
            entity.Property(e => e.StkTrnsStatus).HasColumnName("STK_TRNS_STATUS");
            entity.Property(e => e.StkTrnsStatusControl).HasColumnName("STK_TRNS_STATUS_CONTROL");
            entity.Property(e => e.StkTrnsTotalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("STK_TRNS_TOTAL_AMOUNT");
            entity.Property(e => e.StkTrnsTotalCost)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("STK_TRNS_TOTAL_COST");
            entity.Property(e => e.StkTrnsTotalDiscount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("STK_TRNS_TOTAL_DISCOUNT");
            entity.Property(e => e.StkTrnsTotalTax)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("STK_TRNS_TOTAL_TAX");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.AccU).WithMany(p => p.StockTransfers)
                .HasForeignKey(d => d.AccUid)
                .HasConstraintName("FK_StockTransfer_Account");
        });

        modelBuilder.Entity<StockTransferDetail>(entity =>
        {
            entity.HasKey(e => e.StkTrnsDetUid);

            entity.ToTable("StockTransferDetail");

            entity.Property(e => e.StkTrnsDetUid)
                .ValueGeneratedNever()
                .HasColumnName("STK_TRNS_DET_UID");
            entity.Property(e => e.PrdUid).HasColumnName("PRD_UID");
            entity.Property(e => e.StkTrnsDetDescribtion).HasColumnName("STK_TRNS_DET_DESCRIBTION");
            entity.Property(e => e.StkTrnsDetDiscount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("STK_TRNS_DET_DISCOUNT");
            entity.Property(e => e.StkTrnsDetPricePerUnit)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("STK_TRNS_DET_PRICE_PER_UNIT");
            entity.Property(e => e.StkTrnsDetQuantity).HasColumnName("STK_TRNS_DET_QUANTITY");
            entity.Property(e => e.StkTrnsDetStatus).HasColumnName("STK_TRNS_DET_STATUS");
            entity.Property(e => e.StkTrnsDetTax)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("STK_TRNS_DET_TAX");
            entity.Property(e => e.StkTrnsDetTotalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("STK_TRNS_DET_TOTAL_AMOUNT");
            entity.Property(e => e.StkTrnsUid).HasColumnName("STK_TRNS_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
            entity.Property(e => e.UomUid).HasColumnName("UOM_UID");
            entity.Property(e => e.WarHosUid).HasColumnName("WAR_HOS_UID");

            entity.HasOne(d => d.PrdU).WithMany(p => p.StockTransferDetails)
                .HasForeignKey(d => d.PrdUid)
                .HasConstraintName("FK_StockTransferDetail_Product");

            entity.HasOne(d => d.StkTrnsU).WithMany(p => p.StockTransferDetails)
                .HasForeignKey(d => d.StkTrnsUid)
                .HasConstraintName("FK_StockTransferDetail_StockTransferDetail");

            entity.HasOne(d => d.UomU).WithMany(p => p.StockTransferDetails)
                .HasForeignKey(d => d.UomUid)
                .HasConstraintName("FK_StockTransferDetail_UnitOfMeasurement");

            entity.HasOne(d => d.WarHosU).WithMany(p => p.StockTransferDetails)
                .HasForeignKey(d => d.WarHosUid)
                .HasConstraintName("FK_StockTransferDetail_WareHouse");
        });

        modelBuilder.Entity<SyncLog>(entity =>
        {
            entity.HasKey(e => e.SynUid);

            entity.HasIndex(e => e.SysUsrCreatedon, "IX_Table_CREATEDON");

            entity.Property(e => e.SynUid)
                .ValueGeneratedNever()
                .HasColumnName("SYN_UID");
            entity.Property(e => e.SynSuccessful).HasColumnName("SYN_SUCCESSFUL");
            entity.Property(e => e.SynType)
                .HasComment("[1-kala][2-hesab][3-moshtari][4-factor][5-karbar]")
                .HasColumnName("SYN_TYPE");
            entity.Property(e => e.SynUnsuccessful).HasColumnName("SYN_UNSUCCESSFUL");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<SystemGame>(entity =>
        {
            entity.HasKey(e => e.SysUid).HasName("PK_System");

            entity.ToTable("SystemGame");

            entity.Property(e => e.SysUid)
                .ValueGeneratedNever()
                .HasColumnName("SYS_UID");
            entity.Property(e => e.AccClbUid).HasColumnName("ACC_CLB_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.PrdUid).HasColumnName("PRD_UID");
            entity.Property(e => e.SysActive).HasColumnName("SYS_ACTIVE");
            entity.Property(e => e.SysAditionalNumber).HasColumnName("SYS_ADITIONAL_NUMBER");
            entity.Property(e => e.SysChairCount)
                .HasDefaultValueSql("((0))")
                .HasColumnName("SYS_CHAIR_COUNT");
            entity.Property(e => e.SysFromTime).HasColumnName("SYS_FROM_TIME");
            entity.Property(e => e.SysFromTimePercent).HasColumnName("SYS_FROM_TIME_PERCENT");
            entity.Property(e => e.SysFromTimePrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("SYS_FROM_TIME_PRICE");
            entity.Property(e => e.SysGamepadAditionalPercent).HasColumnName("SYS_GAMEPAD_ADITIONAL_PERCENT");
            entity.Property(e => e.SysGamepadAditionalPrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("SYS_GAMEPAD_ADITIONAL_PRICE");
            entity.Property(e => e.SysLastEndTime)
                .HasColumnType("datetime")
                .HasColumnName("SYS_LAST_END_TIME");
            entity.Property(e => e.SysLastStartTime)
                .HasColumnType("datetime")
                .HasColumnName("SYS_LAST_START_TIME");
            entity.Property(e => e.SysNumber)
                .HasMaxLength(50)
                .HasColumnName("SYS_NUMBER");
            entity.Property(e => e.SysOnline).HasColumnName("SYS_ONLINE");
            entity.Property(e => e.SysOnlinePercent).HasColumnName("SYS_ONLINE_PERCENT");
            entity.Property(e => e.SysOnlinePrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("SYS_ONLINE_PRICE");
            entity.Property(e => e.SysReserve)
                .HasDefaultValueSql("((0))")
                .HasColumnName("SYS_RESERVE");
            entity.Property(e => e.SysStatus).HasColumnName("SYS_STATUS");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");

            entity.HasOne(d => d.PrdU).WithMany(p => p.SystemGames)
                .HasForeignKey(d => d.PrdUid)
                .HasConstraintName("FK_System_Product");
        });

        modelBuilder.Entity<SystemGameDetail>(entity =>
        {
            entity.HasKey(e => e.SysDetUid);

            entity.ToTable("SystemGameDetail");

            entity.Property(e => e.SysDetUid)
                .ValueGeneratedNever()
                .HasColumnName("SYS_DET_UID");
            entity.Property(e => e.InvDetUid).HasColumnName("INV_DET_UID");
            entity.Property(e => e.InvUid).HasColumnName("INV_UID");
            entity.Property(e => e.SysDetActive)
                .HasDefaultValueSql("((0))")
                .HasColumnName("SYS_DET_ACTIVE");
            entity.Property(e => e.SysDetEndTime)
                .HasColumnType("datetime")
                .HasColumnName("SYS_DET_END_TIME");
            entity.Property(e => e.SysDetGamepad).HasColumnName("SYS_DET_GAMEPAD");
            entity.Property(e => e.SysDetOnline).HasColumnName("SYS_DET_ONLINE");
            entity.Property(e => e.SysDetStartTime)
                .HasColumnType("datetime")
                .HasColumnName("SYS_DET_START_TIME");
            entity.Property(e => e.SysDetStatus).HasColumnName("SYS_DET_STATUS");
            entity.Property(e => e.SysUid).HasColumnName("SYS_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
        });

        modelBuilder.Entity<SystemUser>(entity =>
        {
            entity.HasKey(e => e.SysUsrUid);

            entity.Property(e => e.SysUsrUid)
                .ValueGeneratedNever()
                .HasColumnName("SYS_USR_UID");
            entity.Property(e => e.AccUid).HasColumnName("ACC_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.RolUid).HasColumnName("ROL_UID");
            entity.Property(e => e.SysUsrBackgroundImage).HasColumnName("SYS_USR_BACKGROUND_IMAGE");
            entity.Property(e => e.SysUsrCode)
                .HasMaxLength(50)
                .HasColumnName("SYS_USR_CODE");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrEmail)
                .HasMaxLength(50)
                .HasColumnName("SYS_USR_EMAIL");
            entity.Property(e => e.SysUsrFirstName)
                .HasMaxLength(100)
                .HasColumnName("SYS_USR_FIRST_NAME");
            entity.Property(e => e.SysUsrForecolor)
                .HasMaxLength(50)
                .HasColumnName("SYS_USR_FORECOLOR");
            entity.Property(e => e.SysUsrIsVisible).HasColumnName("SYS_USR_IS_VISIBLE");
            entity.Property(e => e.SysUsrLastName)
                .HasMaxLength(200)
                .HasColumnName("SYS_USR_LAST_NAME");
            entity.Property(e => e.SysUsrMobile)
                .HasMaxLength(20)
                .HasColumnName("SYS_USR_MOBILE");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
            entity.Property(e => e.SysUsrParentUid).HasColumnName("SYS_USR_PARENT_UID");
            entity.Property(e => e.SysUsrPassword)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SYS_USR_PASSWORD");
            entity.Property(e => e.SysUsrPhone)
                .HasMaxLength(20)
                .HasColumnName("SYS_USR_PHONE");
            entity.Property(e => e.SysUsrStatus).HasColumnName("SYS_USR_STATUS");
            entity.Property(e => e.SysUsrUsername)
                .HasMaxLength(30)
                .HasColumnName("SYS_USR_USERNAME");
            entity.Property(e => e.SysUsrWesite)
                .HasMaxLength(50)
                .HasColumnName("SYS_USR_WESITE");

            entity.HasOne(d => d.RolU).WithMany(p => p.SystemUsers)
                .HasForeignKey(d => d.RolUid)
                .HasConstraintName("FK_SystemUsers_Roles");
        });

        modelBuilder.Entity<Tab>(entity =>
        {
            entity.HasKey(e => e.TabUid);

            entity.ToTable("Tab");

            entity.HasIndex(e => e.TabOrder, "IX_Tab");

            entity.Property(e => e.TabUid)
                .ValueGeneratedNever()
                .HasColumnName("TAB_UID");
            entity.Property(e => e.TabName)
                .HasMaxLength(100)
                .HasColumnName("TAB_NAME");
            entity.Property(e => e.TabOrder).HasColumnName("TAB_ORDER");
            entity.Property(e => e.TabType).HasColumnName("TAB_TYPE");
        });

        modelBuilder.Entity<Tax>(entity =>
        {
            entity.HasKey(e => e.TaxUid).HasName("PK_TaxType");

            entity.ToTable("Tax");

            entity.Property(e => e.TaxUid)
                .ValueGeneratedNever()
                .HasColumnName("TAX_UID");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
            entity.Property(e => e.TaxAccUid).HasColumnName("TAX_ACC_UID");
            entity.Property(e => e.TaxCode)
                .HasMaxLength(50)
                .HasColumnName("TAX_CODE");
            entity.Property(e => e.TaxName)
                .HasMaxLength(100)
                .HasColumnName("TAX_NAME");
            entity.Property(e => e.TaxStatus).HasColumnName("TAX_STATUS");
            entity.Property(e => e.TaxTaxesAccUid).HasColumnName("TAX_TAXES_ACC_UID");
            entity.Property(e => e.TaxTaxesValue)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("TAX_TAXES_VALUE");
            entity.Property(e => e.TaxValue)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("TAX_VALUE");

            entity.HasOne(d => d.TaxAccU).WithMany(p => p.TaxTaxAccUs)
                .HasForeignKey(d => d.TaxAccUid)
                .HasConstraintName("FK_Tax_Account");

            entity.HasOne(d => d.TaxTaxesAccU).WithMany(p => p.TaxTaxTaxesAccUs)
                .HasForeignKey(d => d.TaxTaxesAccUid)
                .HasConstraintName("FK_Tax_Account1");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TktId);

            entity.Property(e => e.TktId).HasColumnName("TKT_ID");
            entity.Property(e => e.TktAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("TKT_AMOUNT");
            entity.Property(e => e.TktCreateOn)
                .HasColumnType("date")
                .HasColumnName("TKT_CREATE_ON");
            entity.Property(e => e.TktDiscountPercent)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("TKT_DISCOUNT_PERCENT");
            entity.Property(e => e.TktDiscountRial)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("TKT_DISCOUNT_RIAL");
            entity.Property(e => e.TktExpireDate)
                .HasColumnType("date")
                .HasColumnName("TKT_EXPIRE_DATE");
            entity.Property(e => e.TktFrCreateBy).HasColumnName("TKT_FR_CREATE_BY");
            entity.Property(e => e.TktFrSalon).HasColumnName("TKT_FR_SALON");
            entity.Property(e => e.TktName)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("TKT_NAME");
            entity.Property(e => e.TktNumber).HasColumnName("TKT_NUMBER");
            entity.Property(e => e.TktSaleAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("TKT_SALE_AMOUNT");
            entity.Property(e => e.TktType).HasColumnName("TKT_TYPE");

            entity.HasOne(d => d.TktFrCreateByNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TktFrCreateBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tickets_SystemUsers");

            entity.HasOne(d => d.TktFrSalonNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TktFrSalon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tickets_Salon");
        });

        modelBuilder.Entity<TicketDetail>(entity =>
        {
            entity.HasKey(e => e.TdId);

            entity.ToTable("TicketDetail");

            entity.Property(e => e.TdId)
                .ValueGeneratedNever()
                .HasColumnName("TD_ID");
            entity.Property(e => e.TdExpireDate)
                .HasColumnType("date")
                .HasColumnName("TD_EXPIRE_DATE");
            entity.Property(e => e.TdFrTicket).HasColumnName("TD_FR_TICKET");
            entity.Property(e => e.TdSerial)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TD_SERIAL");
            entity.Property(e => e.TdStatus).HasColumnName("TD_STATUS");

            entity.HasOne(d => d.TdFrTicketNavigation).WithMany(p => p.TicketDetails)
                .HasForeignKey(d => d.TdFrTicket)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TicketDetail_Tickets");
        });

        modelBuilder.Entity<TicketProduct>(entity =>
        {
            entity.HasKey(e => e.TpId);

            entity.ToTable("TicketProduct");

            entity.Property(e => e.TpId)
                .ValueGeneratedNever()
                .HasColumnName("TP_ID");
            entity.Property(e => e.TpFrProduct).HasColumnName("TP_FR_PRODUCT");
            entity.Property(e => e.TpFrTicket).HasColumnName("TP_FR_TICKET");

            entity.HasOne(d => d.TpFrProductNavigation).WithMany(p => p.TicketProducts)
                .HasForeignKey(d => d.TpFrProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TicketProduct_Product");

            entity.HasOne(d => d.TpFrTicketNavigation).WithMany(p => p.TicketProducts)
                .HasForeignKey(d => d.TpFrTicket)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TicketProduct_Tickets");
        });

        modelBuilder.Entity<UnitOfMeasurement>(entity =>
        {
            entity.HasKey(e => e.UomUid);

            entity.ToTable("UnitOfMeasurement");

            entity.Property(e => e.UomUid)
                .ValueGeneratedNever()
                .HasColumnName("UOM_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
            entity.Property(e => e.UomCode)
                .HasMaxLength(50)
                .HasColumnName("UOM_CODE");
            entity.Property(e => e.UomName)
                .HasMaxLength(100)
                .HasColumnName("UOM_NAME");
            entity.Property(e => e.UomStatus).HasColumnName("UOM_STATUS");

            entity.HasOne(d => d.BusUnitU).WithMany(p => p.UnitOfMeasurements)
                .HasForeignKey(d => d.BusUnitUid)
                .HasConstraintName("FK_UnitOfMeasurement_BusinessUnits");
        });

        modelBuilder.Entity<WareHouse>(entity =>
        {
            entity.HasKey(e => e.WarHosUid);

            entity.ToTable("WareHouse");

            entity.Property(e => e.WarHosUid)
                .ValueGeneratedNever()
                .HasColumnName("WAR_HOS_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
            entity.Property(e => e.WarHosCode)
                .HasMaxLength(50)
                .HasColumnName("WAR_HOS_CODE");
            entity.Property(e => e.WarHosName)
                .HasMaxLength(100)
                .HasColumnName("WAR_HOS_NAME");
            entity.Property(e => e.WarHosStatus).HasColumnName("WAR_HOS_STATUS");

            entity.HasOne(d => d.FisPeriodU).WithMany(p => p.WareHouses)
                .HasForeignKey(d => d.FisPeriodUid)
                .HasConstraintName("FK_WareHouse_FiscalPeriod");
        });

        modelBuilder.Entity<WarehouseReciept>(entity =>
        {
            entity.HasKey(e => e.WarHosRecUid);

            entity.ToTable("WarehouseReciept");

            entity.Property(e => e.WarHosRecUid)
                .ValueGeneratedNever()
                .HasColumnName("WAR_HOS_REC_UID");
            entity.Property(e => e.AccUid).HasColumnName("ACC_UID");
            entity.Property(e => e.BusUnitUid).HasColumnName("BUS_UNIT_UID");
            entity.Property(e => e.CstCtrUid).HasColumnName("CST_CTR_UID");
            entity.Property(e => e.FisPeriodUid).HasColumnName("FIS_PERIOD_UID");
            entity.Property(e => e.OrdUid).HasColumnName("ORD_UID");
            entity.Property(e => e.QutUid).HasColumnName("QUT_UID");
            entity.Property(e => e.SalCatUid).HasColumnName("SAL_CAT_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
            entity.Property(e => e.WarHosRecDate)
                .HasColumnType("datetime")
                .HasColumnName("WAR_HOS_REC_DATE");
            entity.Property(e => e.WarHosRecDescribtion).HasColumnName("WAR_HOS_REC_DESCRIBTION");
            entity.Property(e => e.WarHosRecDueDate)
                .HasColumnType("datetime")
                .HasColumnName("WAR_HOS_REC_DUE_DATE");
            entity.Property(e => e.WarHosRecExtendedAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("WAR_HOS_REC_EXTENDED_AMOUNT");
            entity.Property(e => e.WarHosRecFinalStatusControl).HasColumnName("WAR_HOS_REC_FINAL_STATUS_CONTROL");
            entity.Property(e => e.WarHosRecNumber)
                .HasMaxLength(50)
                .HasColumnName("WAR_HOS_REC_NUMBER");
            entity.Property(e => e.WarHosRecParentUid).HasColumnName("WAR_HOS_REC_PARENT_UID");
            entity.Property(e => e.WarHosRecReference)
                .HasMaxLength(100)
                .HasColumnName("WAR_HOS_REC_REFERENCE");
            entity.Property(e => e.WarHosRecStatus).HasColumnName("WAR_HOS_REC_STATUS");
            entity.Property(e => e.WarHosRecStatusControl).HasColumnName("WAR_HOS_REC_STATUS_CONTROL");
            entity.Property(e => e.WarHosRecTotalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("WAR_HOS_REC_TOTAL_AMOUNT");
            entity.Property(e => e.WarHosRecTotalCost)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("WAR_HOS_REC_TOTAL_COST");
            entity.Property(e => e.WarHosRecTotalDiscount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("WAR_HOS_REC_TOTAL_DISCOUNT");
            entity.Property(e => e.WarHosRecTotalTax)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("WAR_HOS_REC_TOTAL_TAX");

            entity.HasOne(d => d.AccU).WithMany(p => p.WarehouseReciepts)
                .HasForeignKey(d => d.AccUid)
                .HasConstraintName("FK_WarehouseReciept_Account");

            entity.HasOne(d => d.BusUnitU).WithMany(p => p.WarehouseReciepts)
                .HasForeignKey(d => d.BusUnitUid)
                .HasConstraintName("FK_WarehouseReciept_BusinessUnits");

            entity.HasOne(d => d.OrdU).WithMany(p => p.WarehouseReciepts)
                .HasForeignKey(d => d.OrdUid)
                .HasConstraintName("FK_WarehouseReciept_Order");

            entity.HasOne(d => d.QutU).WithMany(p => p.WarehouseReciepts)
                .HasForeignKey(d => d.QutUid)
                .HasConstraintName("FK_WarehouseReciept_Quote");

            entity.HasOne(d => d.SalCatU).WithMany(p => p.WarehouseReciepts)
                .HasForeignKey(d => d.SalCatUid)
                .HasConstraintName("FK_WarehouseReciept_SalesCategory");
        });

        modelBuilder.Entity<WarehouseRecieptDetail>(entity =>
        {
            entity.HasKey(e => e.WarHosRecDetUid);

            entity.ToTable("WarehouseRecieptDetail");

            entity.Property(e => e.WarHosRecDetUid)
                .ValueGeneratedNever()
                .HasColumnName("WAR_HOS_REC_DET_UID");
            entity.Property(e => e.PrdUid).HasColumnName("PRD_UID");
            entity.Property(e => e.SysUsrCreatedby).HasColumnName("SYS_USR_CREATEDBY");
            entity.Property(e => e.SysUsrCreatedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_CREATEDON");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
            entity.Property(e => e.UomUid).HasColumnName("UOM_UID");
            entity.Property(e => e.WarHosRecDetDescribtion).HasColumnName("WAR_HOS_REC_DET_DESCRIBTION");
            entity.Property(e => e.WarHosRecDetDiscount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("WAR_HOS_REC_DET_DISCOUNT");
            entity.Property(e => e.WarHosRecDetPricePerUnit)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("WAR_HOS_REC_DET_PRICE_PER_UNIT");
            entity.Property(e => e.WarHosRecDetQuantity).HasColumnName("WAR_HOS_REC_DET_QUANTITY");
            entity.Property(e => e.WarHosRecDetStatus).HasColumnName("WAR_HOS_REC_DET_STATUS");
            entity.Property(e => e.WarHosRecDetTax)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("WAR_HOS_REC_DET_TAX");
            entity.Property(e => e.WarHosRecDetTotalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("WAR_HOS_REC_DET_TOTAL_AMOUNT");
            entity.Property(e => e.WarHosRecUid).HasColumnName("WAR_HOS_REC_UID");
            entity.Property(e => e.WarHosUid).HasColumnName("WAR_HOS_UID");

            entity.HasOne(d => d.PrdU).WithMany(p => p.WarehouseRecieptDetails)
                .HasForeignKey(d => d.PrdUid)
                .HasConstraintName("FK_WarehouseRecieptDetail_Product");

            entity.HasOne(d => d.UomU).WithMany(p => p.WarehouseRecieptDetails)
                .HasForeignKey(d => d.UomUid)
                .HasConstraintName("FK_WarehouseRecieptDetail_UnitOfMeasurement");

            entity.HasOne(d => d.WarHosU).WithMany(p => p.WarehouseRecieptDetails)
                .HasForeignKey(d => d.WarHosUid)
                .HasConstraintName("FK_WarehouseRecieptDetail_WareHouse");
        });

        modelBuilder.Entity<WorkStation>(entity =>
        {
            entity.HasKey(e => e.WrkSttUid);

            entity.ToTable("WorkStation");

            entity.Property(e => e.WrkSttUid)
                .ValueGeneratedNever()
                .HasColumnName("WRK_STT_UID");
            entity.Property(e => e.SysUsrModifiedby).HasColumnName("SYS_USR_MODIFIEDBY");
            entity.Property(e => e.SysUsrModifiedon)
                .HasColumnType("datetime")
                .HasColumnName("SYS_USR_MODIFIEDON");
            entity.Property(e => e.WrkSttActiveCallerid)
                .HasDefaultValueSql("((0))")
                .HasColumnName("WRK_STT_ACTIVE_CALLERID");
            entity.Property(e => e.WrkSttActivePosEghtesad)
                .HasDefaultValueSql("((0))")
                .HasColumnName("WRK_STT_ACTIVE_POS_EGHTESAD");
            entity.Property(e => e.WrkSttActivePosIranKish)
                .HasDefaultValueSql("((0))")
                .HasColumnName("WRK_STT_ACTIVE_POS_IRAN_KISH");
            entity.Property(e => e.WrkSttActivePosMellat)
                .HasDefaultValueSql("((0))")
                .HasColumnName("WRK_STT_ACTIVE_POS_MELLAT");
            entity.Property(e => e.WrkSttActivePosMelli)
                .HasDefaultValueSql("((0))")
                .HasColumnName("WRK_STT_ACTIVE_POS_MELLI");
            entity.Property(e => e.WrkSttActivePosParsian)
                .HasDefaultValueSql("((0))")
                .HasColumnName("WRK_STT_ACTIVE_POS_PARSIAN");
            entity.Property(e => e.WrkSttActivePosSamanKish)
                .HasDefaultValueSql("((0))")
                .HasColumnName("WRK_STT_ACTIVE_POS_SAMAN_KISH");
            entity.Property(e => e.WrkSttBranchuid).HasColumnName("WRK_STT_BRANCHUID");
            entity.Property(e => e.WrkSttCalleridLine)
                .HasDefaultValueSql("((1))")
                .HasColumnName("WRK_STT_CALLERID_LINE");
            entity.Property(e => e.WrkSttCalleridNumber)
                .HasDefaultValueSql("((0))")
                .HasColumnName("WRK_STT_CALLERID_NUMBER");
            entity.Property(e => e.WrkSttCode)
                .HasMaxLength(5)
                .HasColumnName("WRK_STT_CODE");
            entity.Property(e => e.WrkSttConnectionTypeEghtesad)
                .HasMaxLength(20)
                .HasDefaultValueSql("('Serial')")
                .HasColumnName("WRK_STT_CONNECTION_TYPE_EGHTESAD");
            entity.Property(e => e.WrkSttConnectionTypeIranKish)
                .HasMaxLength(20)
                .HasDefaultValueSql("('Serial')")
                .HasColumnName("WRK_STT_CONNECTION_TYPE_IRAN_KISH");
            entity.Property(e => e.WrkSttConnectionTypeParsian)
                .HasMaxLength(20)
                .HasDefaultValueSql("('Serial')")
                .HasColumnName("WRK_STT_CONNECTION_TYPE_PARSIAN");
            entity.Property(e => e.WrkSttConnectionTypeSamanKish)
                .HasMaxLength(20)
                .HasDefaultValueSql("('Serial')")
                .HasColumnName("WRK_STT_CONNECTION_TYPE_SAMAN_KISH");
            entity.Property(e => e.WrkSttDatabase)
                .HasMaxLength(150)
                .HasColumnName("WRK_STT_DATABASE");
            entity.Property(e => e.WrkSttEghtesadBank)
                .HasDefaultValueSql("('00000000-0000-0000-0000-000000000000')")
                .HasColumnName("WRK_STT_EGHTESAD_BANK");
            entity.Property(e => e.WrkSttFormalPosEghtesad)
                .HasDefaultValueSql("((0))")
                .HasColumnName("WRK_STT_FORMAL_POS_EGHTESAD");
            entity.Property(e => e.WrkSttFormalPosIranKish)
                .HasDefaultValueSql("((0))")
                .HasColumnName("WRK_STT_FORMAL_POS_IRAN_KISH");
            entity.Property(e => e.WrkSttFormalPosMellat)
                .HasDefaultValueSql("((0))")
                .HasColumnName("WRK_STT_FORMAL_POS_MELLAT");
            entity.Property(e => e.WrkSttFormalPosMelli)
                .HasDefaultValueSql("((0))")
                .HasColumnName("WRK_STT_FORMAL_POS_MELLI");
            entity.Property(e => e.WrkSttFormalPosParsian)
                .HasDefaultValueSql("((0))")
                .HasColumnName("WRK_STT_FORMAL_POS_PARSIAN");
            entity.Property(e => e.WrkSttFormalPosSamanKish)
                .HasDefaultValueSql("((0))")
                .HasColumnName("WRK_STT_FORMAL_POS_SAMAN_KISH");
            entity.Property(e => e.WrkSttIpAddress)
                .HasMaxLength(15)
                .HasColumnName("WRK_STT_IP_ADDRESS");
            entity.Property(e => e.WrkSttIpMellat)
                .HasMaxLength(20)
                .HasColumnName("WRK_STT_IP_MELLAT");
            entity.Property(e => e.WrkSttIranKishBank)
                .HasDefaultValueSql("('00000000-0000-0000-0000-000000000000')")
                .HasColumnName("WRK_STT_IRAN_KISH_BANK");
            entity.Property(e => e.WrkSttIsConnected)
                .HasDefaultValueSql("((0))")
                .HasColumnName("WRK_STT_IS_CONNECTED");
            entity.Property(e => e.WrkSttMellatBank)
                .HasDefaultValueSql("('00000000-0000-0000-0000-000000000000')")
                .HasColumnName("WRK_STT_MELLAT_BANK");
            entity.Property(e => e.WrkSttMelliBank)
                .HasDefaultValueSql("('00000000-0000-0000-0000-000000000000')")
                .HasColumnName("WRK_STT_MELLI_BANK");
            entity.Property(e => e.WrkSttName)
                .HasMaxLength(100)
                .HasColumnName("WRK_STT_NAME");
            entity.Property(e => e.WrkSttParsianBank)
                .HasDefaultValueSql("('00000000-0000-0000-0000-000000000000')")
                .HasColumnName("WRK_STT_PARSIAN_BANK");
            entity.Property(e => e.WrkSttPcPosAcceptorIdIranKish)
                .HasMaxLength(20)
                .HasDefaultValueSql("('')")
                .HasColumnName("WRK_STT_PC_POS_ACCEPTOR_ID_IRAN_KISH");
            entity.Property(e => e.WrkSttPcPosIpMelli)
                .HasMaxLength(20)
                .HasColumnName("WRK_STT_PC_POS_IP_MELLI");
            entity.Property(e => e.WrkSttPcPosPortMelli)
                .HasMaxLength(20)
                .HasColumnName("WRK_STT_PC_POS_PORT_MELLI");
            entity.Property(e => e.WrkSttPcPosSerialNoIranKish)
                .HasMaxLength(20)
                .HasDefaultValueSql("('')")
                .HasColumnName("WRK_STT_PC_POS_SERIAL_NO_IRAN_KISH");
            entity.Property(e => e.WrkSttPcPosSerialNoMelli)
                .HasMaxLength(20)
                .HasColumnName("WRK_STT_PC_POS_SERIAL_NO_MELLI");
            entity.Property(e => e.WrkSttPcPosTcpIpEghtesad)
                .HasMaxLength(20)
                .HasColumnName("WRK_STT_PC_POS_TCP_IP_EGHTESAD");
            entity.Property(e => e.WrkSttPcPosTcpIpIranKish)
                .HasMaxLength(20)
                .HasColumnName("WRK_STT_PC_POS_TCP_IP_IRAN_KISH");
            entity.Property(e => e.WrkSttPcPosTcpIpParsian)
                .HasMaxLength(20)
                .HasColumnName("WRK_STT_PC_POS_TCP_IP_PARSIAN");
            entity.Property(e => e.WrkSttPcPosTcpIpSamanKish)
                .HasMaxLength(20)
                .HasColumnName("WRK_STT_PC_POS_TCP_IP_SAMAN_KISH");
            entity.Property(e => e.WrkSttPcPosTcpPortEghtesad)
                .HasMaxLength(20)
                .HasColumnName("WRK_STT_PC_POS_TCP_PORT_EGHTESAD");
            entity.Property(e => e.WrkSttPcPosTcpPortIranKish)
                .HasMaxLength(20)
                .HasColumnName("WRK_STT_PC_POS_TCP_PORT_IRAN_KISH");
            entity.Property(e => e.WrkSttPcPosTcpPortParsian)
                .HasMaxLength(20)
                .HasColumnName("WRK_STT_PC_POS_TCP_PORT_PARSIAN");
            entity.Property(e => e.WrkSttPcPosTerminalIdIranKish)
                .HasMaxLength(20)
                .HasDefaultValueSql("('')")
                .HasColumnName("WRK_STT_PC_POS_TERMINAL_ID_IRAN_KISH");
            entity.Property(e => e.WrkSttPortMellat)
                .HasMaxLength(20)
                .HasDefaultValueSql("('1024')")
                .HasColumnName("WRK_STT_PORT_MELLAT");
            entity.Property(e => e.WrkSttPosPortParsian)
                .HasMaxLength(20)
                .HasColumnName("WRK_STT_POS_PORT_PARSIAN");
            entity.Property(e => e.WrkSttPosPortSamanKish)
                .HasMaxLength(20)
                .HasColumnName("WRK_STT_POS_PORT_SAMAN_KISH");
            entity.Property(e => e.WrkSttPrinter)
                .HasMaxLength(150)
                .HasColumnName("WRK_STT_PRINTER");
            entity.Property(e => e.WrkSttPrinter2)
                .HasMaxLength(150)
                .HasColumnName("WRK_STT_PRINTER2");
            entity.Property(e => e.WrkSttReadTimeoutMellat)
                .HasMaxLength(20)
                .HasDefaultValueSql("('180000')")
                .HasColumnName("WRK_STT_READ_TIMEOUT_MELLAT");
            entity.Property(e => e.WrkSttSamanKishBank)
                .HasDefaultValueSql("('00000000-0000-0000-0000-000000000000')")
                .HasColumnName("WRK_STT_SAMAN_KISH_BANK");
            entity.Property(e => e.WrkSttSerialPortEghtesad)
                .HasMaxLength(20)
                .HasColumnName("WRK_STT_SERIAL_PORT_EGHTESAD");
            entity.Property(e => e.WrkSttSerialPortIranKish)
                .HasMaxLength(20)
                .HasColumnName("WRK_STT_SERIAL_PORT_IRAN_KISH");
            entity.Property(e => e.WrkSttStatus).HasColumnName("WRK_STT_STATUS");
        });

        modelBuilder.Entity<WorkYear>(entity =>
        {
            entity.HasKey(e => e.WyId);

            entity.Property(e => e.WyId).HasColumnName("WY_ID");
            entity.Property(e => e.WyStatus).HasColumnName("WY_STATUS");
            entity.Property(e => e.WyYear).HasColumnName("WY_YEAR");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
