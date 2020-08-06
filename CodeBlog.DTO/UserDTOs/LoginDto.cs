﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DTO.UserDTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage ="Email alanı boş bırakılamaz")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Şifre alanı boş bırakılamaz")]
        public string Password { get; set; }
    }
}
