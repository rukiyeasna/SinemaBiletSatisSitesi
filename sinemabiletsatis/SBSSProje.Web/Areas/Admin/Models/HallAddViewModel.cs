using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBSSProje.Web.Areas.Admin.Models
{
    public class HallAddViewModel
    {
        [Required(ErrorMessage ="Ad alanı gereklidir")]
        public string HallName { get; set; }
        [Range(0,int.MaxValue,ErrorMessage ="Lütfen bir şube seçiniz")]
        public int BranchId { get; set; }
    }
}
