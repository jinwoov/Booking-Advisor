using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookingadvisor.Models
{
    public class Currency
    {
        public  DateTime Date { get; set; }
        public string Current { get; set; }
        public Rate[] Rates { get; set; }
    }
    public class Rate
    {
        public int CAD { get; set; }
        public int KRW { get; set; }
        public int PHP { get; set; }
        public int AUD { get; set; }
        public int HUF { get; set; }
        public int IDR { get; set; }
        public int NZD { get; set; }
    }
}
