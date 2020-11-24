using bookingadvisor.Models.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static bookingadvisor.Models.Travel;

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
        public async Task<Travel.Region[]> GetInfo()
        {
            string api_key = _config["amadeus_token"];
            string baseURL = @$"https://test.api.amadeus.com/v1//reference-data/locations/pois?latitude=41.39165&longitude=2.164772";
            var tokens = await GetToken();
            string tokenString = tokens.access_token;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenString);
            HttpResponseMessage response = client.GetAsync(baseURL).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;

            var travel_info = JsonSerializer.Deserialize<TravelInfo>(stringData);

            return travel_info.data.ToArray();
        }

        private async Task<Token> GetToken()
        {
            string url = @"https://test.api.amadeus.com/v1/security/oauth2/token";
            string clientId = _config["amadeus_ID"];
            string clientSecret = _config["amadeus_secret"];
            HttpClient client1 = new HttpClient();
            client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            var token = await client1.PostAsync(url, new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret)
            }));
            string outputData = token.Content.ReadAsStringAsync().Result;
            var travel_info = JsonSerializer.Deserialize<Token>(outputData);

            return travel_info;
        }
    }
}
