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
        public UnsplashPicture Unsplash = new UnsplashPicture();
        public IndexModel(ICurrency currencyM, ITravelManager travelManager, IUnsplashManager uManger)
        {
            _currencyM = currencyM;
            _travelM = travelManager;
            _uManager = uManger;
        }
        public void OnGet()
        {
            //Unsplash = _uManager.GetPic();
        }
    }
}
