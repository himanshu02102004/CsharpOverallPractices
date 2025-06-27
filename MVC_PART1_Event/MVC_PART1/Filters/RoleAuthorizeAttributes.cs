using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MVC_PART1.Models;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace MVC_PART1.Filters
{
    public class RoleAuthorize : AuthorizeAttribute, IAuthorizationFilter
    {


        private readonly string[] _role;
        public RoleAuthorize(params string[] role)
        {
            _role = role;
        }

       

      

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var sessionobj = context.HttpContext.Session.GetString("logindetail");
            if (string.IsNullOrEmpty(sessionobj))
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
                return;
            }

            var loginDetail = JsonConvert.DeserializeObject<Register>(sessionobj);


            if (!_role.Contains(loginDetail.Role))
            {
                
                context.Result = new RedirectToActionResult("AccessDenied", "Account", null);
            }
        }
    }
}