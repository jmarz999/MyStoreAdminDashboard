using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace MyStoreAdminDashboard.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Session.TryGetValue("Token", out byte[] value))
            {
                context.HttpContext.Response.Redirect("https://localhost:44331", true);
                context.Result = null;
            }
        }
    }
}
