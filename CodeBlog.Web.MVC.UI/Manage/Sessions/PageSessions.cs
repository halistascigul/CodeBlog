using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeBlog.Web.MVC.UI.Manage.Sessions
{
    public static class PageSessions
    {
        public static string ActivePage
        {
            get { return HttpContext.Current.Session["ActivePage"] as string; }
            set { HttpContext.Current.Session["ActivePage"] = value; }
        }
    }
}