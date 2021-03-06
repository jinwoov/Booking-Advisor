using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookingadvisor.Models;
using bookingadvisor.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static bookingadvisor.Models.Currency;

namespace bookingadvisor.Pages
{
    public class IndexModel : PageModel
    {        
        public string PickPlace { get; set; }
        public void OnGet()
        {
            List<string> TourPlace = new List<string>()
            {
                "Korea",
                "Germany",
                "England",
                "Japan",
                "New York",
                "India",
                "Jordan",
                "Philippines"
            };
            Random r = new Random();
            int rN = r.Next(0, TourPlace.Count);
            PickPlace = TourPlace[rN];
        }
    }
}
