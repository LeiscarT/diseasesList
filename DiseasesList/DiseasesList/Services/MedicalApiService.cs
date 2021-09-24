using DiseasesList.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DiseasesList.Services
{
    class MedicalApiService : IMedicalApiService
    {
        private const string SessionId = "l1IvnBWkEGWBUSkd";
        public async Task<Suggests> GetSuggests()
        {
            HttpClient httpClient = new HttpClient();
           var response = await httpClient.GetAsync($"https://api.endlessmedical.com/v1/dx/GetSuggestedSpecializations?SessionID={SessionId}&NumberOfResults=60");

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var currencyResponse = JsonConvert.DeserializeObject<Suggests>(responseString);
                return currencyResponse;
            }

            return null;
        }
    }
}
