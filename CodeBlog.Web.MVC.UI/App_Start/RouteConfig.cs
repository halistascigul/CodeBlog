using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CodeBlog.Web.MVC.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(name:"rtHome", url:"",defaults: new { controller = "Home", action = "Index" }, namespaces: new[] { "CodeBlog.Web.MVC.UI.Controllers" });

            routes.MapRoute("rtRenderHeader", "RenderHeader", new { controller = "Common", action = "RenderHeader" });

            routes.MapRoute("rtRenderFooter", "RenderFooter", new { controller = "Common", action = "RenderFooter" });

            routes.MapRoute("rtSingleBlog", "blog/{url}", new { controller = "Blog", action = "SingleBlog" });

            routes.MapRoute("rtAbout", "hakkimizda", new { controller = "Corporate", action = "AboutUs" });
            routes.MapRoute("rtContact", "iletisim", new { controller = "Corporate", action = "Contact" });
            routes.MapRoute("rtContactForm", "iletisim-formu", new { controller = "Corporate", action = "Contact" });
            routes.MapRoute("rtThanks", "tesekkurler", new { controller = "Corporate", action = "Thanks" });
            routes.MapRoute("rtSorry", "uzgunuz", new { controller = "Corporate", action = "Sorry" });

            routes.MapRoute("rtBlogsByCategory", "kategoriler/{catName}", new { controller = "Blog", action = "BlogsByCategory" });

            routes.MapRoute("rtLike", "singleblog/likeit", new { controller = "Blog", action = "LikeIt" });

            routes.MapRoute("rtRegisterView", "kayit-ol", new { controller = "Account", action = "Index" });

            routes.MapRoute("rtRegister", "kayit-ol", new { controller = "Account", action = "Index" });

            routes.MapRoute("rtLoginView", "giris-yap", new { controller = "Account", action = "Login" });
            routes.MapRoute("rtLogin", "giris-yap", new { controller = "Account", action = "Login" });

            routes.MapRoute("rtLogout", "cikis-yap", new { controller = "Account", action = "Logout" });

            routes.MapRoute("rtNewComment", "yorum-yap", new { controller = "Blog", action = "NewComment" });

            routes.MapRoute("rtMyAccount", "hesabim", new { controller = "Account", action = "MyAccount" });

        }
    }
}
