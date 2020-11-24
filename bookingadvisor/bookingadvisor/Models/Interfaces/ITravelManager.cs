using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static bookingadvisor.Models.Travel;

namespace bookingadvisor.Models.Interfaces
{
    public interface ITravelManager
    {
        public Task<Travel.Region[]> GetInfo();
    }
}
