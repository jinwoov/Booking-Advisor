using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookingadvisor.Models
{
    public class Unsplash
    {
        public class UnsplashPicture
        {
            public List<Results> results { get; set; }
        }
        public class Results
        {
            public URLS urls { get; set; }
        }
        public class URLS
        {
            public string regular { get; set; }
        }
    }
}
