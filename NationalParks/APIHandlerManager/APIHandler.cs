using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using NationalParks.Models;
using Newtonsoft.Json;

namespace NationalParks.APIHandlerManager
{
    public class APIHandler
    {
        static string BASE_URL = "https://developer.nps.gov/api/v1/";
        static string API_KEY = ""; //Add your API key here inside ""

        HttpClient httpClient;

        public APIHandler()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Parks GetParks()
        {
            string NATIONAL_PARK_API_PATH = BASE_URL + "/parks?limit=20";
            string parksData = "";

            Parks parks = null;

            httpClient.BaseAddress = new Uri(NATIONAL_PARK_API_PATH);
            HttpResponseMessage response = httpClient.GetAsync(NATIONAL_PARK_API_PATH).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                parksData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            if (!parksData.Equals(""))
            {
                parks = JsonConvert.DeserializeObject<Parks>(parksData);
            }
            return parks;
        }
    }
}
