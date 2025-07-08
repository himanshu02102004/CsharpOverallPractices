using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MVC_PART1.Services;
using NuGet.Common;

namespace MVC_PART1.Filters
{
    public class AuthorizeSessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Access session via HttpContext
            var token = context.HttpContext.Session.GetString("JWTToken");

            if (string.IsNullOrEmpty(token))
            {
                // Redirect to Login if not authenticated
                //context.Result = new RedirectToActionResult("Login", "Account", null);
                

            }

            base.OnActionExecuting(context);
        }
    }
}
