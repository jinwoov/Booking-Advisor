using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static bookingadvisor.Models.Currency;

namespace bookingadvisor.Models.Interfaces
{
    public interface ICurrency
    {
        public Rates GetRates();
    }
}
