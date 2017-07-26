using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebServices_XF.Models;
using WebServices_XF.Models.DTO;

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
        /// <summary>
        /// Este es un ejemplo de POST no funcional. Debido que no existe Servicio 
        /// util para sustituir en tu propia solución
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        public async Task<UserResponse> PostUserAsync(UserRequest userRequest)
        {
            var uri = new Uri(App.API_URLBASE + "customer/account"); // esto es un ejemplo
            var userResponse = new UserResponse();
            try
            {
                var json = JsonConvert.SerializeObject(userRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content); //POST CALL
                string content1;
                switch (response.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                        content1 = await response.Content.ReadAsStringAsync();
                        userResponse = JsonConvert.DeserializeObject<UserResponse>(content1);
                        Debug.WriteLine(@"				Error received.");
                        break;
                    case HttpStatusCode.BadRequest:
                        content1 = await response.Content.ReadAsStringAsync();
                        userResponse = JsonConvert.DeserializeObject<UserResponse>(content1);
                        Debug.WriteLine(@"				Error received.");
                        break;
                    case HttpStatusCode.InternalServerError:
                        content1 = await response.Content.ReadAsStringAsync();
                        userResponse = JsonConvert.DeserializeObject<UserResponse>(content1);
                        Debug.WriteLine(@"				Error received.");
                        break;
                    case HttpStatusCode.OK:
                        content1 = await response.Content.ReadAsStringAsync();
                        userResponse = JsonConvert.DeserializeObject<UserResponse>(content1);
                        Debug.WriteLine(@"				Response successfully saved.");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return userResponse;
        }

    }
}
