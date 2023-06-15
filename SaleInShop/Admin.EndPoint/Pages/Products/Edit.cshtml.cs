using Application.Common;
using Application.Product;
using Application.Product.Category;
using Application.Product.ProductDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Application.Product.Category.ProductCategory;

namespace SaleInWeb.Pages.Products;

public class EditModel : PageModel
{
    private readonly IProductCategory _category;
    private readonly IProductService _product;
    public List<SelectOption> Category;
    public EditProduct Command;
    public List<ProductPicturesDto> ProductPictures;
    public List<PropertySelectOptionDto> Properties;
    public CreateProperty Property;
    public List<TaxSelectOptionDto> Tax;
    public List<UnitOfMeasurementDto> Unit;

    public EditModel(IProductService product, IProductCategory category)
    {
        _product = product;
        _category = category;
    }

    public IActionResult OnGet(Guid productId, bool load = false)
    {
        Command = _product.GetDetailsForEdit(productId);

        ProductPictures = HttpContext.Session.GetJson<List<ProductPicturesDto>>("edit-picture") ??
                          new List<ProductPicturesDto>();
        Category = _category.SelectOptions();
        Tax = _category.TaxSelectOption();
        Properties = _product.PropertySelectOption();

        //HttpContext.Session.Remove("Product-Property");
        Unit = _product.UnitOfMeasurement();

        return Page();
    }

    public IActionResult OnPost(EditProduct command)
    {
        var result = _product.UpdateProduct(command);
        return new JsonResult(result);
    }

    public IActionResult OnGetRemovePictures(Guid id)
    {
        var getPictures = HttpContext.Session.GetJson<List<ProductPicturesDto>>("edit-picture") ??
                          new List<ProductPicturesDto>();
        var get = getPictures.SingleOrDefault(x => x.Id == id);
        if (get != null)
            getPictures.Remove(get);

        HttpContext.Session.Remove("edit-picture");
        HttpContext.Session.SetJson("edit-picture", getPictures);

        return new JsonResult(getPictures);
    }

    public IActionResult OnGetRemoveProperty(Guid id)
    {
        var getProperty = HttpContext.Session.GetJson<List<PropertySelectOptionDto>>("edit-Property") ??
                          new List<PropertySelectOptionDto>();
        var get = getProperty.SingleOrDefault(x => x.Id == id);
        if (get != null)
            getProperty.Remove(get);
        HttpContext.Session.Remove("edit-Property");
        HttpContext.Session.SetJson("edit-Property", getProperty);
        return new JsonResult(getProperty);
    }


    public IActionResult OnGetAddProperty(CreateProperty property)
    {
        var getProperty = HttpContext.Session.GetJson<List<PropertySelectOptionDto>>("edit-Property") ??
                          new List<PropertySelectOptionDto>();
        if (getProperty.Any(x => x.PropertyId == property.PropertyId))
            return new JsonResult("Duplicate");
        getProperty.Add(new PropertySelectOptionDto
        {
            PropertyId = property.PropertyId,
            Name = property.Name,
            Id = Guid.Empty,
            Value = property.Value
        });
        HttpContext.Session.SetJson("edit-Property", getProperty);
        return new JsonResult(getProperty);
    }
}