using Application.Interfaces.Context;
using Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Product.Category
{
    public class RegisterServices
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IAuthHelper, AuthHelper>();
            services.AddScoped<IValidator<ProductCategory.CreateProductLevel>, CategoryPrdValidator>();
            services.AddScoped<IProductCategory, ProductCategory>();
            services.AddAutoMapper(typeof(CategoryPrdMap));
        }
    }
}
