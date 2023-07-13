namespace SaleInWeb.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RemoveAllCookie
    {
        private readonly RequestDelegate _next;

        public RemoveAllCookie(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var path = httpContext.Request.Path;
            if (path != "/Invoice/Pre-Invoice") return _next(httpContext);

            httpContext.Request.Headers.TryGetValue("Cookie", out var values);
            var cookies = values.ToString().Split(';').ToList();

            var result = cookies.Select(c => new
            {
                Key = c.Split('=')[0].Trim(),
                Value = c.Split('=')[1].Trim()
            }).ToList();

            foreach (var cookie in from cookie in result let dotNetCookie = cookie.Key.Contains("AspNetCore") where !dotNetCookie select cookie)
                httpContext.Response.Cookies.Delete(cookie.Key);
            
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RemoveCookieExtensions
    {
        public static IApplicationBuilder UseRemoveCookie(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RemoveAllCookie>();
        }
    }
}
