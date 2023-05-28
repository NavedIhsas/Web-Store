using Application.Common;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Application.Product.Category;
using Domain.ShopModels;
using Application.Interfaces;
using Application.Interfaces.Context;
using Domain.SaleInModels;
using infrastructure.Context;
using Microsoft.AspNetCore.Connections;
using SaleInAdmin;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    
    .CreateLogger();

Log.Information("شروع راه اندازی");
try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog().ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.SetMinimumLevel(LogLevel.Trace);
    });
    var configuration = builder.Configuration;
    Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

    builder.Services.AddRazorPages().AddMvcOptions(x=>x.Filters.Add<Security>());

    #region IOC

    builder.Services.AddTransient<IShopContext, ShopContext>();
    builder.Services.AddTransient<ISaleInContext, SaleInContext>();
    builder.Services.AddSession();
    builder.Services.AddDistributedMemoryCache();
    builder.Services.AddFluentValidationAutoValidation();
    builder.Services.AddFluentValidationClientsideAdapters();
    RegisterServices.Configure(builder.Services);
    #endregion




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
        var baseConfig = httpContext.Session.GetJson<BaseConfigDto>("BaseConfig") ?? new BaseConfigDto()
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

    app.UseSession();
    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

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

