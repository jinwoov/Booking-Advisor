using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookingadvisor.Models;
using bookingadvisor.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static bookingadvisor.Models.Currency;
using static bookingadvisor.Models.Unsplash;

namespace bookingadvisor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICurrency _currencyM;
        private readonly ITravelManager _travelM;
        private readonly IUnsplashManager _uManager;
        public List<Results> Unsplash = new List<Results>();
        public string PickPlace { get; set; }
        public IndexModel(ICurrency currencyM, ITravelManager travelManager, IUnsplashManager uManger)
        {
            _currencyM = currencyM;
            _travelM = travelManager;
            _uManager = uManger;
        }
        public async Task OnGet()
        {
            List<string> TourPlace = new List<string>()
            {
                "Korea",
                "Germany",
                "England",
                "Japan",
                "New York",
                "India",
                "Jordan"
            };
            Random r = new Random();
            int rV = r.Next(0, TourPlace.Count - 1);
            string pickedLocation = TourPlace[rV];
            Unsplash = await _uManager.GetPic(pickedLocation);
            PickPlace = pickedLocation;
        }
    }
}
