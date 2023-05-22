using Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using Application.Product.Category;
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

    var connection = configuration.GetConnectionString("SaleInConnection");
    builder.Services.AddDbContext<SaleInContext>(option => option.UseSqlServer(connection));

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

