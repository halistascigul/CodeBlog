using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DTO.UserDTOs
{
    public class RegisterDto
    {
        [Display(Name ="Ad soyad")]
        [Required(ErrorMessage ="Ad soyad alanı boş geçilemez")]
        public string FullName { get; set; }
        [Display(Name ="Şifre")]
        [Required(ErrorMessage ="Şifre alanı boş geçilemez")]
        public string Password { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre tekrar alanı boş geçilemez")]
        [Compare("Password",ErrorMessage ="Şifreler eşleşmiyor")]
        public string PasswordConfirm { get; set; }
        [Display(Name ="Email")]
        [Required(ErrorMessage ="Email alanı boş geçilemez")]
        public string Email { get; set; }
    }
}
