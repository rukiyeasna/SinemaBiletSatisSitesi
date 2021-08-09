using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBSSProje.Web.Areas.Admin.Models
{
    public class SessionAddViewModel
    {
        public int MovieId { get; set; }
        public int BranchId { get; set; }
        public int HallId { get; set; }
        public DateTime Date { get; set; }
        public string Hour { get; set; }
    }
}
