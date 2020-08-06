using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeBlog.Web.MVC.UI.Manage.Sessions
{
    public static class BlogSessions
    {
        public static string ActiveBlogUrl
        {
            get { return HttpContext.Current.Session["ActiveBlogUrl"] as string; }
            set { HttpContext.Current.Session["ActiveBlogUrl"] = value; }
        }
    }
}