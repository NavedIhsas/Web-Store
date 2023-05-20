using RestSharp;
using SaleInStore.Core.Services;
using SaleInStore.Core.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddRazorPages();

var baseUrl = configuration["ApiConfig:baseUrl"];
builder.Services.AddScoped<IAuthHelper>(x => new AuthHelper(new RestClient(baseUrl)));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
