using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static bookingadvisor.Models.Unsplash;

namespace bookingadvisor.Models.Interfaces
{
    public interface IUnsplashManager
    {
        public List<Results> GetPic(string keyword);
    }
}
