using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeBlog.Web.MVC.UI.Areas.Moderator.Controllers
{
    public class HomeController : Controller
    {
        // GET: Moderator/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}