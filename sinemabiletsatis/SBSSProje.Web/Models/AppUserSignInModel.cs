using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBSSProje.Web.Models
{
    public class AppUserSignInModel
    {
        [Display(Name = "Kullanıcı Adı :")]
        [Required(ErrorMessage = "Kullanıcı Adı boş geçilemez")]
        public string UserName { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Şifre :")]
        [Required(ErrorMessage = "Şifre boş geçilemez")]
        public string Password { get; set; }


        [Display(Name = "Beni Hatırla")]
        public bool Remember { get; set; }
    }
}
