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
        public async Task<List<Results>> GetPic(string keyword)
        {
            string api = _config["unsplash-api"];
            var baseURL = @$"https://api.unsplash.com/search/photos?client_id={api}&query={keyword}";
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            var response = await client.GetAsync(baseURL);
            string stringData = await response.Content.ReadAsStringAsync();

            var getRate = JsonSerializer.Deserialize<UnsplashPicture>(stringData);

            return getRate.results.ToList();
        }
    }
}
