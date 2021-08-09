using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBSSProje.Web.Models
{
    public class AppUserAddViewModel
    {
        [Display(Name = "Kullanıcı Adı :")]
        [Required(ErrorMessage = "Kullanıcı Adı boş geçilemez")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Şifre :")]
        [Required(ErrorMessage = "Şifre boş geçilemez")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Şifre :")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor")]
        public string ConfirmPassword { get; set; }

        [EmailAddress(ErrorMessage = "Geçersiz email")]
        [Display(Name = "Email :")]
        [Required(ErrorMessage = "Email boş geçilemez")]
        public string Email { get; set; }

        [Display(Name = "Ad :")]
        [Required(ErrorMessage = "Ad boş geçilemez")]
        public string Name { get; set; }

        [Display(Name = "Soyad :")]
        [Required(ErrorMessage = "Soyad boş geçilemez")]
        public string Surname { get; set; }
    }
}
