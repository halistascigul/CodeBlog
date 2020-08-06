using System.Web.Mvc;

namespace CodeBlog.Web.MVC.UI.Areas.Moderator
{
    public class ModeratorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Moderator";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Moderator_default",
                "Moderator/{controller}/{action}/{id}",
                new {controller="Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "CodeBlog.Web.MVC.UI.Areas.Moderator.Controllers" }
            );
        }
    }
}