using CodeBlog.DTO.UserDTOs;
using CodeBlog.Web.MVC.UI.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeBlog.Web.MVC.UI.Models.ViewModels
{
    public class LoginViewModel
    {
        public LoginDto LoginDto { get; set; }
        public LoginFrom From { get; set; }
    }
}