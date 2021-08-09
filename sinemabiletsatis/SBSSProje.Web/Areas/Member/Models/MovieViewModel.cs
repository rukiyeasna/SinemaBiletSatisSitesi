using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBSSProje.Web.Areas.Member.Models
{
    public class MovieViewModel
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public DateTime Date { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string Time { get; set; }
        public string Type { get; set; }
        public string Explanation { get; set; }
        public string Picture { get; set; }
        public string Trailer { get; set; }
    }
}
