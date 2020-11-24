using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookingadvisor.Models
{
    public class Travel
    {

        public class TravelInfo
        {
            public List<Region> data { get; set; }
        }

        public class Region
        {
            public string type { get; set; }
            public string subType { get; set; }
            public string id { get; set; }
            public Self self { get; set; }
            public string name { get; set; }
            public string category { get; set; }
            public int rank { get; set; }
            public string[] tags { get; set; }
        }

        public class Self
        {
            public string href { get; set; }
            public string[] methods { get; set; }
        }

    }
}
