using Application.Interfaces.Context;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Product.Category;
using FluentValidation;

namespace Application.Product
{
    public class RegisterServices
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IAuthHelper, AuthHelper>();
            services.AddTransient<IProductService, ProductService>();
            services.AddScoped<IProductCategory, ProductCategory>();


            services.AddScoped<IValidator<ProductCategory.CreateProductLevel>, CategoryPrdValidator>();
            services.AddScoped<IValidator<CreateProduct>, CreateProductValidate>();
            services.AddScoped<IValidator<CreateProperty>, CreatePropertyValidate>();

            services.AddAutoMapper(typeof(CategoryPrdMap));
            services.AddAutoMapper(typeof(ProductMapping));
        }
    }
}
