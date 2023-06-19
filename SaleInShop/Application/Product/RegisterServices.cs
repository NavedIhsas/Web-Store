using Application.BaseData;
using Application.BaseData.Dto;
using Application.Interfaces;
using Application.Product.Category;
using Application.Product.ProductDto;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Product;

public class RegisterServices
{
    public static void Configure(IServiceCollection services)
    {
        services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient<IAuthHelper, AuthHelper>();
        services.AddTransient<IProductService, ProductService>();
        services.AddScoped<IProductCategory, ProductCategory>();
        services.AddScoped<IBaseDataService, BaseDataService>();


        services.AddScoped<IValidator<ProductCategory.CreateProductLevel>, CategoryPrdValidator>();
        services.AddScoped<IValidator<CreateProduct>, CreateProductValidate>();
        services.AddScoped<IValidator<CreateProperty>, CreatePropertyValidate>();
        services.AddScoped<IValidator<CreateUnit>, BaseDataValidator>();
       
        
        services.AddScoped<IValidator<CreateWareHouse>, WareHouseValidator>();
        services.AddScoped<IValidator<UpdateWareHouse>, WareHouseValidator>();
       
        services.AddScoped<IValidator<CreateAccountClubType>, AccountClupTypeValidator>();
        services.AddScoped<IValidator<UpdateAccountClubType>, AccountClupTypeValidator>();
     
        
        services.AddScoped<IValidator<CreateAccountRating>, AccountRatingValidator>();
        services.AddScoped<IValidator<UpdateAccountRating>, AccountRatingValidator>();

        services.AddAutoMapper(typeof(CategoryPrdMap));
        services.AddAutoMapper(typeof(ProductMapping));
    }
}