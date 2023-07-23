using Application.Common;
using Application.Interfaces;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SaleInWeb;

public class Security : IPageFilter
{
    private readonly IAuthHelper _authHelper;
    private readonly ILogger<Security> _logger;
    private readonly IConfiguration _configuration;

    public Security(IAuthHelper authHelper, ILogger<Security> logger, IConfiguration configuration)
    {
        _authHelper = authHelper;
        _logger = logger;
        _configuration = configuration;
    }

    public void OnPageHandlerSelected(PageHandlerSelectedContext context)
    {
    }

    public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
    {
        var ignoreFilter = context.HandlerMethod?.MethodInfo.GetCustomAttributes(typeof(IgnoreFilter), true);

        if (ignoreFilter != null && ignoreFilter.Any()) return; // for use branch UnComment this
        // if (ignoreFilter != null && !ignoreFilter.Any()) return; //for use branch comment this line
        var database = context.HttpContext.Session.GetConnectionString("Branch");
        if (database == null)
        {
            if (!_authHelper.BaseServerConnect())
            {
                var saleInConnection = _configuration.GetConnectionString("saleInConnection");
                _logger.LogError($"saleInConnection:{saleInConnection}");
                _logger.LogError("ارتباط با سرور سالین برقرار نشد");
                context.Result = new RedirectResult("Error?value=saleIn&handler=Server");
                return;
            }

            context.Result = new RedirectToPageResult("/SelectBranch");
            return;
        }

        if (!_authHelper.ServerConnect())
        {
            _logger.LogError($"BranchConnection: {database}");
            _logger.LogError("ارتباط با سرور شعبه برقرار نشد");

            context.Result = new RedirectResult("Error?value=branch&handler=Server");
        }
    }

    public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
    {
    }
}