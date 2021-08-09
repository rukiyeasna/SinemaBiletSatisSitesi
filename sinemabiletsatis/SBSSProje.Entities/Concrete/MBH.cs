using SBSSProje.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBSSProje.Entities.Concrete
{
    public class MBH : ITablo
    {
        public int Id { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public int HallId { get; set; }
        public Hall Hall { get; set; }
        public DateTime Date { get; set; }
        public string Hour { get; set; }

    }
}
