using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookingadvisor.Models.Interfaces
{
    public interface IUnsplashManager
    {
        public string GetPic(string keyword);
    }
}
