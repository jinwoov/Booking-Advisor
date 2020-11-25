﻿using bookingadvisor.Models.Interfaces;
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
        public string GetPic(string keyword)
        {
            string api = _config["unsplash-api"];
            var baseURL = @$"https://api.unsplash.com/search/photos?client_id={api}&query={keyword}";
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            HttpResponseMessage response = client.GetAsync(baseURL).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;

            var getRate = JsonSerializer.Deserialize<UnsplashPicture>(stringData);
            Random r = new Random();
            int ind= r.Next(0, getRate.results.Count);
            string picture = getRate.results[ind].urls.regular;
            return picture;
        }
    }
}