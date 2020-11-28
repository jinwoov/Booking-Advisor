using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static bookingadvisor.Models.Unsplash;

namespace bookingadvisor.Models.Interfaces
{
    public interface IUnsplashManager
    {
        public Task<List<Results>> GetPic(string pp);
    }
}
