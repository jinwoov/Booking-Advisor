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
        private readonly ICurrency _currencyM;
        private readonly ITravelManager _travelM;
        private readonly IUnsplashManager _uManager;
        public Rates Rate = new Rates();
        public List<Travel.Region> Data = new List<Travel.Region>();
        public List<string> TourPlace = new List<string>()
        {
            "Korea",
            "Germany",
            "England",
            "Japan",
            "New York",
            "India",
            "Jordan"
        };
        public IndexModel(ICurrency currencyM, ITravelManager travelManager, IUnsplashManager uManger)
        {
            _currencyM = currencyM;
            _travelM = travelManager;
            _uManager = uManger;
        }
        public void OnGet()
        {
            Random r = new Random();
            int rV = r.Next(0, TourPlace.Count);
            string pickedLocation = TourPlace[rV];
            string result = _uManager.GetPic(pickedLocation);
            TempData["Location"] = pickedLocation;
            TempData["imgURL"] = result;
        }
    }
}
