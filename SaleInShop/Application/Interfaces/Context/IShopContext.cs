using Domain.ShopModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Interfaces.Context;

public interface IShopContext
{
    int SaveChanges(bool acceptAllChangesOnSuccess);
    int SaveChanges();
    public  DatabaseFacade Database { get; }

    DbSet<AccountClubPhoto> AccountClubPhotos { get; set; }
    DbSet<AccountClub> AccountClubs { get; set; }
    DbSet<AccountClubType> AccountClubTypes { get; set; }
    DbSet<AccountLevel> AccountLevels { get; set; }
    DbSet<AccountRating> AccountRatings { get; set; }
    DbSet<AccountRemainCredit> AccountRemainCredits { get; set; }
    DbSet<Account> Accounts { get; set; }
    DbSet<AccountType> AccountTypes { get; set; }
    DbSet<AgreementAtelierLog> AgreementAtelierLogs { get; set; }
    DbSet<AgreementAtelier> AgreementAteliers { get; set; }
    DbSet<Agreement> Agreements { get; set; }
    DbSet<AtelierCategory> AtelierCategories { get; set; }
    DbSet<Bank> Banks { get; set; }
    DbSet<Barcode> Barcodes { get; set; }
    DbSet<BusinessUnit> BusinessUnits { get; set; }
    DbSet<BusinessUnitType> BusinessUnitTypes { get; set; }
    DbSet<Car> Cars { get; set; }
    DbSet<ChequeSheet> ChequeSheets { get; set; }
    DbSet<Chequ> Chequs { get; set; }
    DbSet<ChequSheet> ChequSheets { get; set; }
    DbSet<ChequSheetStatus> ChequSheetStatuses { get; set; }
    DbSet<City> Cities { get; set; }
    DbSet<ClassProperty> ClassProperties { get; set; }
    DbSet<ConditionDetail> ConditionDetails { get; set; }
    DbSet<ConditionHidden> ConditionHiddens { get; set; }
    DbSet<ConditionLog> ConditionLogs { get; set; }
    DbSet<Condition> Conditions { get; set; }
    DbSet<CostCenter> CostCenters { get; set; }
    DbSet<CostDetail> CostDetails { get; set; }
    DbSet<Cost> Costs { get; set; }
    DbSet<Country> Countries { get; set; }
    DbSet<DefualtAccountDefinition> DefualtAccountDefinitions { get; set; }
    DbSet<DocumentDetail> DocumentDetails { get; set; }
    DbSet<Document> Documents { get; set; }
    DbSet<ExchangeDetail> ExchangeDetails { get; set; }
    DbSet<ExchangeRate> ExchangeRates { get; set; }
    DbSet<Exchange> Exchanges { get; set; }
    DbSet<Field> Fields { get; set; }
    DbSet<FiscalPeriod> FiscalPeriods { get; set; }
    DbSet<InvoiceDetail> InvoiceDetails { get; set; }
    DbSet<Invoice> Invoices { get; set; }
    DbSet<Language> Languages { get; set; }
    DbSet<Menu> Menus { get; set; }
    DbSet<MenuUser> MenuUsers { get; set; }
    DbSet<ObjectDescription> ObjectDescriptions { get; set; }
    DbSet<Operator> Operators { get; set; }
    DbSet<OrderDetail> OrderDetails { get; set; }
    DbSet<Order> Orders { get; set; }
    DbSet<OrderType> OrderTypes { get; set; }
    DbSet<PaymentReceiptRelatedPurchaseInvoice> PaymentReceiptRelatedPurchaseInvoices { get; set; }
    DbSet<PaymentRecieptDetail> PaymentRecieptDetails { get; set; }
    DbSet<PaymentRecieptSheet> PaymentRecieptSheets { get; set; }
    DbSet<Personnel> Personnel { get; set; }
    DbSet<PhoneBook> PhoneBooks { get; set; }
    DbSet<PhotoDetail> PhotoDetails { get; set; }
    DbSet<ProductLevelAccess> ProductLevelAccesses { get; set; }
    DbSet<ProductLevel> ProductLevels { get; set; }
    DbSet<ProductQuantity> ProductQuantities { get; set; }
    DbSet<ProductQuantityOnHand> ProductQuantityOnHands { get; set; }
    DbSet<Domain.ShopModels.Product> Products { get; set; }
    DbSet<ProductSubset> ProductSubsets { get; set; }
    DbSet<PurchaseDetail> PurchaseDetails { get; set; }
    DbSet<Purchase> Purchases { get; set; }
    DbSet<QuoteDetail> QuoteDetails { get; set; }
    DbSet<Quote> Quotes { get; set; }
    DbSet<RegardingObject> RegardingObjects { get; set; }
    DbSet<RelatedPersonnel> RelatedPersonnel { get; set; }
    DbSet<RoleAccess> RoleAccesses { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<SalesCategory> SalesCategories { get; set; }
    DbSet<SelectDeliverer> SelectDeliverers { get; set; }
    DbSet<SerialDetail> SerialDetails { get; set; }
    DbSet<Setting> Settings { get; set; }
    DbSet<SmsDetail> SmsDetails { get; set; }
    DbSet<SmsHeader> SmsHeaders { get; set; }
    DbSet<State> States { get; set; }
    DbSet<StockTransferDetail> StockTransferDetails { get; set; }
    DbSet<StockTransfer> StockTransfers { get; set; }
    DbSet<SyncLog> SyncLogs { get; set; }
    DbSet<SystemGameDetail> SystemGameDetails { get; set; }
    DbSet<SystemGame> SystemGames { get; set; }
    DbSet<SystemUser> SystemUsers { get; set; }
    DbSet<Tab> Tabs { get; set; }
    DbSet<Tax> Taxes { get; set; }
    DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; }
    DbSet<WarehouseRecieptDetail> WarehouseRecieptDetails { get; set; }
    DbSet<WarehouseReciept> WarehouseReciepts { get; set; }
    DbSet<WareHouse> WareHouses { get; set; }
    DbSet<WorkStation> WorkStations { get; set; }
}