using CodeBlog.Web.MVC.UI.Manage.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CodeBlog.Web.MVC.UI.Filters
{
    public class AuthenticationAttribute : FilterAttribute,IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (UserSessions.CurrentUser==null)
            {
                RouteValueDictionary route = new RouteValueDictionary();
                route.Add("controller", "Account");
                route.Add("action", "Login");
                filterContext.Result = new RedirectToRouteResult(route);
            }
        }
    }
}