using bookingadvisor.Models.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace bookingadvisor.Models.Services
{
    public class TravelService : ITravelManager
    {
        private static readonly HttpClient client = new HttpClient();
        private IConfiguration _config;
        public TravelService(IConfiguration configuration)
        {
            _config = configuration;

        }
        public Travel.Region[] GetInfo()
        {
            string api_key = _config["amadeus_token"];
            string baseURL = @$"https://api.currencyfreaks.com/latest?apikey={api_key}&format=json";

            throw new NotImplementedException();
        }
    }
}
