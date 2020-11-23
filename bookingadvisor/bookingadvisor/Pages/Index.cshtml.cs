using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookingadvisor.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static bookingadvisor.Models.Currency;

namespace bookingadvisor.Pages
{
    public class IndexModel : PageModel
    {
        private ICurrency _currencyM;
        public Rates rate = new Rates();
        public IndexModel(ICurrency currencyM)
        {
            _currencyM = currencyM;
        }
        public void OnGet()
        {
            rate = _currencyM.GetRates();
        }
    }
}
