using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBSSProje.Web.Areas.Admin.Models
{
    public class Class
    {
        public IEnumerable<SelectListItem> branches { get; set; }
        public IEnumerable<SelectListItem> halls { get; set; }
        //public string MovieName { get; set; } 
    }
}
