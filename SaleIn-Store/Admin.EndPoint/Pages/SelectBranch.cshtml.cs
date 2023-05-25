using Application;
using Application.Interfaces;
using Domain.SaleInModels;
using infrastructure.Attribute;
using infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Serilog.Parsing;

namespace SaleInAdmin.Pages
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
        public IActionResult OnGet()
        {
            var database = HttpContext.Session.GetConnectionString("Branch");
            if (database != null)
               return RedirectToPage("Index");

            Branch = _authHelper.SelectBranch();
            return Page();
        }

        [IgnoreFilter]
        public IActionResult OnPost(string branchId, string returnUrl)
        {
            var databaseName = _authHelper.SetBranch(branchId);
            var database = HttpContext.Session.GetConnectionString("Branch") ?? databaseName.ToString();
            var connectionString = _configuration.GetConnectionString("shopConnection");
            var connection= new SqlConnectionStringBuilder(connectionString)
            {
                InitialCatalog = database
            };
            HttpContext.Session.SetStringText("Branch", connection);
            return RedirectToPage("Index");
        }
    }
}



