using bookingadvisor.Models.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using static bookingadvisor.Models.Currency;

namespace bookingadvisor.Models.Services
{
    public class CurrencyService : ICurrency
    {
        private static readonly HttpClient client = new HttpClient();
        private IConfiguration _config;

        public CurrencyService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public Rates GetRates()
        {
            string api_key = _config["currency_API"];
            string baseURL = @$"https://api.currencyfreaks.com/latest?apikey={api_key}&format=json";

            HttpResponseMessage response = client.GetAsync(baseURL).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;

            var getRate = JsonSerializer.Deserialize<Rootobject>(stringData);

            return getRate.rates;
        }
    }
}
