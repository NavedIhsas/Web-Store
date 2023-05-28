using Application.Product.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Application.Product.Category.ProductCategory;

namespace SaleInAdmin.Pages.Products
{
    public class CategoryModel : PageModel
    {
        private readonly IProductCategory _category;

        public CategoryModel(IProductCategory category)
        {
            _category = category;
        }

        public List<ProductCategory.ProductLevelDto> List;
        public List<ProductCategory.ProductLevelDto> SelectList;
        [BindProperty]
        public CreateProductLevel Command { get; set; }
        public int MainCodeCount;
        public int SubCodeCount;
        public string ProductLvlCode { get; set; }
        public void OnGet()
        {
            List = _category.GetLevelList();
            SelectList = _category.GetParentLevelList();
            MainCodeCount = _category.GetMainCodeCount();
            SubCodeCount = _category.GetSubCodeCount();
            ProductLvlCode = _category.GetMaxProductLvlCodeVal(false);
        }


        public JsonResult OnPost(CreateProductLevel command)
        {
            var result = _category.CreatePrdCategory(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetCode(string proLvlId)
        {
            var result = _category.GetPrdLvlCheck(proLvlId);
            return new JsonResult(result);
        }
        public IActionResult OnGetMaxCode(bool noMax,string proLvlId = null)
        {
            var result = _category.GetMaxProductLvlCodeVal(noMax,proLvlId);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(Guid id)
        {
            return new JsonResult(_category.Remove(id));
        }


        public IActionResult OnGetCheckCode(string id,string code)
        {
            return new JsonResult(_category.CheckExistCode(id, code));
        }
    }
}
