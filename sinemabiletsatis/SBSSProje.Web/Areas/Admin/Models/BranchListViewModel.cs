using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBSSProje.Web.Areas.Admin.Models
{
    public class BranchListViewModel
    {
        public int BranchId { get; set; }

        [Display(Name = "Şube Ad")]
        public string BranchName { get; set; }

        [Display(Name = "Şehir")]
        public string City { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }
    }
}
