using bookingadvisor.Models.Interfaces;
using bookingadvisor.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using static bookingadvisor.Models.Unsplash;

namespace bookingadvisor.Models.Services
{
    public class UnsplashService : IUnsplashManager
    {
        private readonly IConfiguration _config;
        private static readonly HttpClient client = new HttpClient();

        public UnsplashService(IConfiguration configuration)
        {
            _config = configuration;
        }
        public UnsplashPicture GetPic()
        {
            List<string> TourPlace = new List<string>()
            {
                "Korea",
                "Germany",
                "England",
                "Japan",
                "New York",
                "India",
                "Jordan"
            };
            Random r = new Random();
            int rV = r.Next(0, TourPlace.Count);
            string pickedLocation = TourPlace[rV];

            string api = _config["unsplash-api"];
            var baseURL = @$"https://api.unsplash.com/search/photos?client_id={api}&query={pickedLocation}";
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(baseURL).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;

            var getRate = JsonSerializer.Deserialize<UnsplashPicture>(stringData);
            getRate.Location = pickedLocation;
            return getRate;
        }
    }
}
