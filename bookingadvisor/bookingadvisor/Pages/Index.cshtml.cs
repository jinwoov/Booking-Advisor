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
        public Rates Rate = new Rates();
        public List<Travel.Region> Data = new List<Travel.Region>();
        public IndexModel(ICurrency currencyM, ITravelManager travelManager)
        {
            _currencyM = currencyM;
            _travelM = travelManager;
        }
        public async Task OnGet()
        {
            Rate = _currencyM.GetRates();
            Data = await _travelM.GetInfo();
        }
    }
}
