using CodeBlog.Web.MVC.UI.Manage.Sessions;
using CodeBlog.Web.MVC.UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace CodeBlog.Web.MVC.UI.Controllers
{
    public class CorporateController : Controller
    {
        // GET: Corporate
        public ActionResult AboutUs()
        {
            PageSessions.ActivePage = "AboutUs";
            return View();
        }

        public ActionResult Contact()
        {
            PageSessions.ActivePage = "Contact";
            return View(new ContactViewModel());
        }

        public ActionResult Thanks()
        {
            PageSessions.ActivePage = null;
            return View();
        }

        public ActionResult Sorry()
        {
            PageSessions.ActivePage = null;
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel model)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.Credentials = new NetworkCredential("codeblogiletisimformu@gmail.com", "codeblog123.");
                client.EnableSsl = true;
                MailMessage msg = new MailMessage("codeblogiletisimformu@gmail.com", "vektorelsoneryazilim@gmail.com");
                msg.Subject = model.Subject;
                msg.IsBodyHtml = true;
                msg.Body = $"<p><b>Gönderen: </b>{model.Name}</p><p><b>Email: </b>{model.Email}</p><p><b>Mesaj: </b>{model.Message}</p>";
                client.Send(msg);
                return RedirectToAction("Thanks");
            }
            catch (Exception)
            {
                return RedirectToAction("Sorry");
            }
        }
    }
}