
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace MVC_PART1.Filters
{
    public class MvcAuthorization : ActionFilterAttribute, IAuthorizationFilter
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Session.GetString("JWToken");

            if (string.IsNullOrEmpty(token))
            {
                // Optional: log or debug here
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }

            base.OnActionExecuting(context);
        }








        public void OnAuthorization(AuthorizationFilterContext filtercontext)
        {
            var user = filtercontext.HttpContext.User;

           if(user?.Identity==null || !user.Identity.IsAuthenticated)
            {
                // Redirect to login page
                filtercontext.Result = new RedirectToActionResult("Login", "Account", new
                {
                    returnUrl = filtercontext.HttpContext.Request.Path
                });
            }
        }
    }
}
