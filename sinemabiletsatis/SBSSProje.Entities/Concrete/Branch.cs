using SBSSProje.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBSSProje.Entities.Concrete
{
    public class Branch : ITablo
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
        public List<Hall> halls { get; set; }
        public List<MBH> mBHs { get; set; }
    }
}
