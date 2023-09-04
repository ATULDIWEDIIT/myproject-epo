using Digital.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital.Web.Code
{
    public class CustomActionFilterAdminAttribute : ActionFilterAttribute
    {
        private UserRoles[] UserRoless;
        public CustomActionFilterAdminAttribute()
        {
        
        }
        protected virtual CustomPrincipal CurrentUser
        {
            get { return new CustomPrincipal(ContextProvider.HttpContext.User); }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (CurrentUser != null && CurrentUser.IsAuthenticated && CurrentUser.RoleID > 0)
            {
                string url = $"{ContextProvider.AbsoluteUri}";
                string urlToCheck = url.ToLower().Replace(SiteKeys.DomainName.ToLower(), "").ToLower();

            }
            else
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "error",
                        action = "SessionOut"
                    }));
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/home");
                }
            }
        }

        private void ReturnAccessDenied(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "error",
                    action = "accessDeniedAjax"
                }));
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "error",
                    action = "accessDenied"
                }));
            }
        }
    }
}
