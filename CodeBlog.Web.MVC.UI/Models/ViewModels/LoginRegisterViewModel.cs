using CodeBlog.DTO.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeBlog.Web.MVC.UI.Models.ViewModels
{
    public class LoginRegisterViewModel
    {
        public LoginDto LoginDto { get; set; }
        public RegisterDto RegisterDto { get; set; }
    }
}