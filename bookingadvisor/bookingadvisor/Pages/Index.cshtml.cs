using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookingadvisor.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bookingadvisor.Pages
{
    public class IndexModel : PageModel
    {
        private ICurrency _currencyM;

        public IndexModel(ICurrency currencyM)
        {
            _currencyM = currencyM;
        }
        public void OnGet()
        {
            var rates = _currencyM.GetRates();
            Console.WriteLine(rates);
        }
    }
}
