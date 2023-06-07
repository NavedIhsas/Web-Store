using Application.Common;
using Application.Interfaces;
using Application.Product;
using Application.Product.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Application.Product.Category.ProductCategory;
using static Application.Product.ProductService;

namespace SaleInWeb.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IProductCategory _category;
        private readonly IProductService _product;
        private readonly IAuthHelper _authHelper;
        public CreateModel(IProductCategory category, IProductService product, IAuthHelper authHelper)
        {
            _category = category;
            _product = product;
            _authHelper = authHelper;
        }

        public List<ProductCategory.SelectOption> Category;
        public List<TaxSelectOptionDto> Tax;
        public CreateProduct Command { get; set; }
        public List<PropertySelectOptionDto> Properties;
        public CreateProperty Property;
        public List<UnitOfMeasurementDto> Unit;
        public bool GenerateCode;

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
            if (_authHelper.AutoCodeProduct())
                command.PrdCode = _authHelper.AutoGenerateCode(command.PrdLvlUid3??new Guid());
            return new JsonResult(_product.CreateProduct(command));
        }

        public IActionResult OnGetProperty(CreateProperty property)
        {
            var getProperty = HttpContext.Session.GetJson<List<PropertySelectOptionDto>>("Product-Property")??new List<PropertySelectOptionDto>();
            if (getProperty.Any(x => x.Id == property.Id))
                return new JsonResult("Duplicate");
            getProperty.Add(new PropertySelectOptionDto()
            {
                Name = property.Name,
                Id = property.Id,
                Value = property.Value,
            });
            HttpContext.Session.SetJson("Product-Property", getProperty);
            return new JsonResult(getProperty);
        }

        public IActionResult OnGetRemoveProperty(Guid id)
        {
            var getProperty = HttpContext.Session.GetJson<List<PropertySelectOptionDto>>("Product-Property") ?? new List<PropertySelectOptionDto>();
            var get = getProperty.SingleOrDefault(x => x.Id == id);
            if (get != null)
                getProperty.Remove(get);
            
            HttpContext.Session.SetJson("Product-Property", getProperty);
            return new JsonResult(getProperty);
        }
    }
}
