using Application.Common;
using Application.Interfaces;
using Domain.SaleInModels;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace SaleInWeb.Pages
{
    public class SelectBranchModel : PageModel
    {
        private readonly IAuthHelper _authHelper;
        private readonly IConfiguration _configuration;
        public SelectBranchModel(IAuthHelper authHelper, IConfiguration configuration)
        {
            _authHelper = authHelper;
            _configuration = configuration;
        }

        public List<BusinessUnit> Branch;

        [IgnoreFilter]
        public IActionResult OnGet(string returnUrl)
        {
            var database = HttpContext.Session.GetConnectionString("Branch");
            if (database != null)
                return RedirectToPage("Index");
            ViewData["ReturnUrl"] = returnUrl;
            Branch = _authHelper.SelectBranch();
            return Page();
        }

        [IgnoreFilter]
        public IActionResult OnPost(string branchId, string returnUrl)
        {
            var databaseName = _authHelper.SetBranch(branchId);
            var database = HttpContext.Session.GetConnectionString("Branch") ?? databaseName.ToString();
            var connectionString = _configuration.GetConnectionString("shopConnection");
            var connection = new SqlConnectionStringBuilder(connectionString)
            {
                InitialCatalog = database
            };
            HttpContext.Session.SetStringText("Branch", connection);
            var baseConfig = HttpContext.Session.GetJson<BaseConfigDto>("BaseConfig") ?? new BaseConfigDto()
            {
                FisPeriodUId = new Guid(database),
                BusUnitUId = new Guid(branchId)
            };
            HttpContext.Session.SetJson("BaseConfig", baseConfig);

            return returnUrl != null ? Redirect(returnUrl) : RedirectToPage("Index");

        }
    }
}



