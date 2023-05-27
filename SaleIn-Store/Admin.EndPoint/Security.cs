using Application.Common;
using Application.Interfaces;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SaleInAdmin
{
    public class Security: IPageFilter
    {
        private readonly IAuthHelper _authHelper;

        public Security(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            
            var ignoreFilter = context.HandlerMethod?.MethodInfo.GetCustomAttributes(typeof(IgnoreFilter), true);

            if (ignoreFilter != null && ignoreFilter.Any()) return;// for use branch UnComment this
           // if (ignoreFilter != null && !ignoreFilter.Any()) return; //for use branch comment this line
            var database = context.HttpContext.Session.GetConnectionString("Branch");
            if (database == null)
            {
                if (!_authHelper.BaseServerConnect())
                {
                    context.Result = new RedirectResult("Error?value=saleIn&handler=Server");
                    return;
                }

                context.Result = new RedirectToPageResult("/SelectBranch");
                return;
            }

            if (!_authHelper.ServerConnect())
                context.Result = new RedirectResult("Error?value=branch&handler=Server");


        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            
        }
    }
}
