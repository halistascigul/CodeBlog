using AutoMapper;
using CodeBlog.BLL.Repositories.Abstract;
using CodeBlog.DOMAIN.Entities;
using CodeBlog.DTO.UserDTOs;
using CodeBlog.Web.MVC.UI.Manage.Sessions;
using CodeBlog.Web.MVC.UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeBlog.Web.MVC.UI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private readonly IUserService userService;
        private readonly IRoleService roleService;

        public AccountController(IUserService userService, IRoleService roleService)
        {
            this.userService = userService;
            this.roleService = roleService;
        }

        public ActionResult MyAccount()
        {
            PageSessions.ActivePage = "MyAccount";
            var user = userService.Get(x => x.Id == UserSessions.CurrentUser.Id,"Blogs").Data;
            return View(Mapper.Map<UserProfileDto>(user));
        }
        public ActionResult Index()
        {
            PageSessions.ActivePage = "Register";
            return View(new RegisterDto());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var user = Mapper.Map<ApplicationUser>(registerDto);
                user.RoleId = roleService.Get(x => x.Name == "Member").Data.Id;
                var result = userService.Insert(user);
                switch (result.State)
                {
                    case CORE.Constants.ResultState.Success:
                        // login
                        return Login(new LoginViewModel { LoginDto = new LoginDto { Email=registerDto.Email,Password=registerDto.Password },From=Constants.LoginFrom.Menu });
                    default:
                        ViewBag.InsertError = "Ekleme sırasında bir hata oluştu. Tekrar deneyiniz. Hata devam ederse bizimle iletişime geçebilirsiniz.";
                        return View(registerDto);
                }
            }
            return View(registerDto);
        }


        public ActionResult Login()
        {
            PageSessions.ActivePage = "Login";
            return View(new LoginViewModel());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = userService.Login(vm.LoginDto.Email, vm.LoginDto.Password);
                if (user!=null)
                {
                    UserSessions.CurrentUser = user;
                    if (BlogSessions.ActiveBlogUrl!=null)
                    {
                        return RedirectToAction("SingleBlog", "Blog", new { url = BlogSessions.ActiveBlogUrl });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("Giriş yapılamadı", "Hatalı kullanıcı adı veya şifre, lütfen tekrar deneyiniz.");
                    return View(vm);
                }
            }
            return View(vm);
        }

        public ActionResult Logout()
        {
            UserSessions.CurrentUser = null;
            return RedirectToAction("Index", "Home");
        }
    }
}