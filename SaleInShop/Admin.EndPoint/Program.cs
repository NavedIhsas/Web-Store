using Application.Common;
using Application.Interfaces.Context;
using Application.Product;
using FluentValidation.AspNetCore;
using infrastructure.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Connections;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SaleInWeb;
using SaleInWeb.Middleware;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .CreateLogger();

Log.Information("شروع راه اندازی");
try
{
    var builder = WebApplication.CreateBuilder(args);
    var env = builder.Environment;

    builder.Host.UseSerilog().ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.SetMinimumLevel(LogLevel.Trace);
    });
    var configuration = builder.Configuration;
    Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

    builder.Services.AddRazorPages().AddMvcOptions(x => x.Filters.Add<Security>());

    #region IOC

    builder.Services.AddTransient<IShopContext, ShopContext>();
    builder.Services.AddTransient<ISaleInContext, SaleInContext>();
    builder.Services.AddSession();
    builder.Services.AddDistributedMemoryCache();
    builder.Services.AddFluentValidationAutoValidation();
    builder.Services.AddFluentValidationClientsideAdapters();
    RegisterServices.Configure(builder.Services);

    #endregion

    builder.Services.ConfigureApplicationCookie(options => { options.Cookie.Path = "/"; });
    builder.Services.Configure<CookiePolicyOptions>(options =>
    {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
    });
    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
        {
            o.LoginPath = new PathString("/");
            o.LogoutPath = new PathString("/");
            o.AccessDeniedPath = new PathString("/Error");
            o.ExpireTimeSpan = TimeSpan.FromDays(15);
        });


    builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });
  
    #region connection string

    var saleInConnection = configuration.GetConnectionString("SaleInConnection");
    var ShopConnection = configuration.GetConnectionString("ShopConnection1"); // for use branch remove this

    builder.Services.AddDbContext<SaleInContext>(option => option.UseSqlServer(saleInConnection));

    builder.Services.AddDbContext<ShopContext>((serviceProvider, options) =>
    {
        var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;

        if (httpContext == null) return;
        string session = null;

        #region Implement Manual Select Branch

        var connectionString = configuration.GetConnectionString("shopConnection");
        var connection = new SqlConnectionStringBuilder(connectionString)
        {
            InitialCatalog = "876812d7-85ec-4706-9eef-fe26f206e794"
        };
        httpContext.Session.SetStringText("Branch", connection);
        var baseConfig = httpContext.Session.GetJson<BaseConfigDto>("BaseConfig") ?? new BaseConfigDto
        {
            FisPeriodUId = new Guid("876812d7-85ec-4706-9eef-fe26f206e794"),
            BusUnitUId = new Guid("c75701ae-e064-4718-a96f-09ae5858b0c2")
        };
        httpContext.Session.SetJson("BaseConfig", baseConfig);

        #endregion


        try
        {
            session = httpContext.Session.GetConnectionString("Branch"); //branch connection
            options.UseSqlServer(session);
        }
        catch (Exception exception)
        {
            Log.Error($"ارتباط با سرور شبعه مورد نظر برقرار نشد  {exception}");
            throw new ConnectionAbortedException($"Can't Connect to this Connection {session} because {exception}");
        }
    });

    #endregion

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    if (!app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

 
    //app.UseRemoveCookie();
    app.UseSession();
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseCookiePolicy();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapDefaultControllerRoute();
    app.MapRazorPages();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "اجرایی اپلیکشن با خطای زیر مواجه شد.");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}