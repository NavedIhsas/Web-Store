using Domain.ShopModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Interfaces.Context;

public interface IShopContext
{
    public DatabaseFacade Database { get; }

    public DbSet<Account> Accounts { get; set; }

    public DbSet<AccountClub> AccountClubs { get; set; }

    public DbSet<AccountClubPhoto> AccountClubPhotos { get; set; }

    public DbSet<AccountClubType> AccountClubTypes { get; set; }

    public DbSet<AccountLevel> AccountLevels { get; set; }

    public DbSet<AccountRating> AccountRatings { get; set; }

    public DbSet<AccountRemainCredit> AccountRemainCredits { get; set; }

    public DbSet<AccountType> AccountTypes { get; set; }

    public DbSet<Agreement> Agreements { get; set; }

    public DbSet<AgreementAtelier> AgreementAteliers { get; set; }

    public DbSet<AgreementAtelierLog> AgreementAtelierLogs { get; set; }

    public DbSet<AtelierCategory> AtelierCategories { get; set; }

    public DbSet<Bank> Banks { get; set; }

    public DbSet<Barcode> Barcodes { get; set; }

    public DbSet<BusinessUnit> BusinessUnits { get; set; }

    public DbSet<BusinessUnitType> BusinessUnitTypes { get; set; }

    public DbSet<Car> Cars { get; set; }

    public DbSet<Chequ> Chequs { get; set; }

    public DbSet<ChequSheet> ChequSheets { get; set; }

    public DbSet<ChequSheetStatus> ChequSheetStatuses { get; set; }

    public DbSet<ChequeSheet> ChequeSheets { get; set; }

    public DbSet<City> Cities { get; set; }

    public DbSet<ClassProperty> ClassProperties { get; set; }

    public DbSet<Condition> Conditions { get; set; }

    public DbSet<ConditionDetail> ConditionDetails { get; set; }

    public DbSet<ConditionHidden> ConditionHiddens { get; set; }

    public DbSet<ConditionLog> ConditionLogs { get; set; }

    public DbSet<Cost> Costs { get; set; }

    public DbSet<CostCenter> CostCenters { get; set; }

    public DbSet<CostDetail> CostDetails { get; set; }

    public DbSet<Country> Countries { get; set; }

    public DbSet<DefualtAccountDefinition> DefualtAccountDefinitions { get; set; }

    public DbSet<Document> Documents { get; set; }

    public DbSet<DocumentDetail> DocumentDetails { get; set; }

    public DbSet<Exchange> Exchanges { get; set; }

    public DbSet<ExchangeDetail> ExchangeDetails { get; set; }

    public DbSet<ExchangeRate> ExchangeRates { get; set; }

    public DbSet<Field> Fields { get; set; }

    public DbSet<FiscalPeriod> FiscalPeriods { get; set; }

    public DbSet<Domain.ShopModels.Invoice> Invoices { get; set; }

    public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public DbSet<Language> Languages { get; set; }

    public DbSet<Menu> Menus { get; set; }

    public DbSet<MenuUser> MenuUsers { get; set; }

    public DbSet<ObjectDescription> ObjectDescriptions { get; set; }

    public DbSet<Operator> Operators { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderDetail> OrderDetails { get; set; }

    public DbSet<OrderType> OrderTypes { get; set; }

    public DbSet<PaymentReceiptRelatedPurchaseInvoice> PaymentReceiptRelatedPurchaseInvoices { get; set; }

    public DbSet<PaymentRecieptDetail> PaymentRecieptDetails { get; set; }

    public DbSet<PaymentRecieptSheet> PaymentRecieptSheets { get; set; }

    public DbSet<Personnel> Personnel { get; set; }

    public DbSet<PhoneBook> PhoneBooks { get; set; }

    public DbSet<PhotoDetail> PhotoDetails { get; set; }

    public DbSet<Domain.ShopModels.Product> Products { get; set; }

    public DbSet<ProductLevel> ProductLevels { get; set; }

    public DbSet<ProductLevelAccess> ProductLevelAccesses { get; set; }

    public DbSet<ProductPicture> ProductPictures { get; set; }

    public DbSet<ProductProperty> ProductProperties { get; set; }

    public DbSet<ProductQuantity> ProductQuantities { get; set; }

    public DbSet<ProductQuantityOnHand> ProductQuantityOnHands { get; set; }

    public DbSet<ProductSubset> ProductSubsets { get; set; }

    public DbSet<Property> Properties { get; set; }

    public DbSet<Purchase> Purchases { get; set; }

    public DbSet<PurchaseDetail> PurchaseDetails { get; set; }

    public DbSet<Quote> Quotes { get; set; }

    public DbSet<QuoteDetail> QuoteDetails { get; set; }

    public DbSet<RegardingObject> RegardingObjects { get; set; }

    public DbSet<RelatedPersonnel> RelatedPersonnel { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<RoleAccess> RoleAccesses { get; set; }

    public DbSet<SalesCategory> SalesCategories { get; set; }

    public DbSet<SelectDeliverer> SelectDeliverers { get; set; }

    public DbSet<SerialDetail> SerialDetails { get; set; }

    public DbSet<Setting> Settings { get; set; }

    public DbSet<SmsDetail> SmsDetails { get; set; }

    public DbSet<SmsHeader> SmsHeaders { get; set; }

    public DbSet<State> States { get; set; }

    public DbSet<StockTransfer> StockTransfers { get; set; }

    public DbSet<StockTransferDetail> StockTransferDetails { get; set; }

    public DbSet<SyncLog> SyncLogs { get; set; }

    public DbSet<SystemGame> SystemGames { get; set; }

    public DbSet<SystemGameDetail> SystemGameDetails { get; set; }

    public DbSet<SystemUser> SystemUsers { get; set; }

    public DbSet<Tab> Tabs { get; set; }

    public DbSet<Tax> Taxes { get; set; }

    public DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; }

    public DbSet<WareHouse> WareHouses { get; set; }

    public DbSet<WarehouseReciept> WarehouseReciepts { get; set; }

    public DbSet<WarehouseRecieptDetail> WarehouseRecieptDetails { get; set; }

    public DbSet<WorkStation> WorkStations { get; set; }
    int SaveChanges(bool acceptAllChangesOnSuccess);
    int SaveChanges();
}