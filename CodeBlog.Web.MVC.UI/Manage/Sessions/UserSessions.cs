using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeBlog.Web.MVC.UI.Manage.Sessions
{
    public static class UserSessions
    {
        public static ApplicationUser CurrentUser
        {
            get { return HttpContext.Current.Session["CurrentUser"] as ApplicationUser; }
            set { HttpContext.Current.Session["CurrentUser"] = value; }
        }
    }
}