using SBSSProje.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBSSProje.Entities.Concrete
{
    public class Sales : ITablo
    {
        public int SalesId { get; set; }
        public int Id { get; set; }
        public string Seat { get; set; }
        public string MovieName { get; set; }
        public DateTime Date { get; set; }
        public string Hour { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public float Price { get; set; }
        public DateTime Date2 { get; set; }

    }
}
