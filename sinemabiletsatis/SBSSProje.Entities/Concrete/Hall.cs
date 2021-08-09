using SBSSProje.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBSSProje.Entities.Concrete
{
    public class Hall : ITablo
    {
        public int HallId { get; set; }
        public string HallName { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public List<MBH> mBHs { get; set; }
    }
}
