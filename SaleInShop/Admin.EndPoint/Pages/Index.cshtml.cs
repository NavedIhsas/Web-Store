using System.Security.Cryptography;
using Application.Common;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SaleInWeb.Pages;

public class IndexModel : PageModel
{
    private readonly IAuthHelper _authHelper;

    public IndexModel(IAuthHelper authHelper)
    {
        _authHelper = authHelper;
    }

    public void OnGet()
    {
    }
}