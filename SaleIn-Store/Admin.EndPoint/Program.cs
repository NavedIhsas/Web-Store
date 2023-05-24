using Microsoft.EntityFrameworkCore;
using Serilog;
using Application.Product.Category;
using Domain.SaleInModels;
using Domain.ShopModels;
using infrastructure.Mapping;

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .CreateLogger();
Log.Information("شروع راه اندازی");

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog();
    var configuration = builder.Configuration;
    builder.Services.AddRazorPages();
    builder.Services.AddAutoMapper(typeof(MappingProfile));
    #region IOC

    builder.Services.AddScoped<IProductCategory, ProductCategory>();

    #endregion


    #region connection string

    var saleInConnection = configuration.GetConnectionString("SaleInConnection");
    builder.Services.AddDbContext<SaleInContext>(option => option.UseSqlServer(saleInConnection));
    
    var shopConnection = configuration.GetConnectionString("ShopConnection");
    builder.Services.AddDbContext<ShopContext>(option => option.UseSqlServer(shopConnection));

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

