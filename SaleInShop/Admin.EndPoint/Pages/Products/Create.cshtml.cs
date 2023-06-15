using Application.Common;
using Application.Interfaces;
using Application.Product;
using Application.Product.Category;
using Application.Product.ProductDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Application.Product.Category.ProductCategory;

namespace SaleInWeb.Pages.Products;

public class CreateModel : PageModel
{
    private readonly IAuthHelper _authHelper;
    private readonly IProductCategory _category;
    private readonly IProductService _product;

    public List<SelectOption> Category;
    public bool GenerateCode;
    public List<PropertySelectOptionDto> Properties;
    public CreateProperty Property;
    public List<TaxSelectOptionDto> Tax;
    public List<UnitOfMeasurementDto> Unit;

    public CreateModel(IProductCategory category, IProductService product, IAuthHelper authHelper)
    {
        _category = category;
        _product = product;
        _authHelper = authHelper;
    }

    public CreateProduct Command { get; set; }

    public void OnGet()
    {
        Category = _category.SelectOptions();
        Tax = _category.TaxSelectOption();
        GenerateCode = _authHelper.AutoCodeProduct();
        Properties = _product.PropertySelectOption();
        //HttpContext.Session.Remove("Product-Property");
        Unit = _product.UnitOfMeasurement();
    }

    public IActionResult OnPost(CreateProduct command)
    {
        if (!ModelState.IsValid)
        {
            ViewData["ErrorMessage"] = true;
            return Page();
        }

        if (_authHelper.AutoCodeProduct())
            command.PrdCode = _authHelper.AutoGenerateCode(command.PrdLvlUid3);
        return new JsonResult(_product.CreateProduct(command));
    }

    public IActionResult OnGetProperty(CreateProperty property)
    {
        var getProperty = HttpContext.Session.GetJson<List<PropertySelectOptionDto>>("Product-Property") ??
                          new List<PropertySelectOptionDto>();
        if (getProperty.Any(x => x.Id == property.Id))
            return new JsonResult("Duplicate");
        getProperty.Add(new PropertySelectOptionDto
        {
            Name = property.Name,
            Id = property.Id,
            Value = property.Value
        });
        HttpContext.Session.SetJson("Product-Property", getProperty);
        return new JsonResult(getProperty);
    }

    public IActionResult OnGetRemoveProperty(Guid id)
    {
        var getProperty = HttpContext.Session.GetJson<List<PropertySelectOptionDto>>("Product-Property") ??
                          new List<PropertySelectOptionDto>();
        var get = getProperty.SingleOrDefault(x => x.Id == id);
        if (get != null)
            getProperty.Remove(get);

        HttpContext.Session.SetJson("Product-Property", getProperty);
        return new JsonResult(getProperty);
    }


    public IActionResult OnGetCheckCode(string code)
    {
        var isNumeric = int.TryParse(code, out _);
        if (!isNumeric) return new JsonResult("کد معتبر نیست");
        var result = _authHelper.CheckLength(code);
        return result == true ? new JsonResult("") : new JsonResult("کد کالا بیش از حد مجاز هست");
    }
}