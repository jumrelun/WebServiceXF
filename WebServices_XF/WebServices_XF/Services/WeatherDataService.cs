using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebServices_XF.Models;

namespace WebServices_XF.Services
{
    public class WeatherDataService
    {
        private HttpClient client;
        public WeatherDataService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<WeatherResponse> GetWeatherByCityAsync(string city)
        {
            var weatherResponse = new WeatherResponse();
            var request = new HttpRequestMessage(HttpMethod.Get, App.API_URL+"?q="+city+"&APPID="+App.API_KEY);
            try
            {
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(content);
                    Debug.WriteLine(@"				Weather successfully adquired.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($@"				ERROR {ex.Message}");
            }

            return weatherResponse;
        }

    }
}
