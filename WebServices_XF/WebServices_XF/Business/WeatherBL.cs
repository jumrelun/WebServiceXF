using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServices_XF.Models;
using WebServices_XF.Services;

namespace WebServices_XF.Business
{
    public class WeatherBl
    {
        private readonly WeatherDataService _weatherDataService;
        public WeatherBl()
        {
            _weatherDataService = new WeatherDataService();
        }

        public async Task<WeatherResponse> GetWeatherByCityBl(string city)
        {
            WeatherResponse response = null;
            try
            {
                response= await _weatherDataService.GetWeatherByCityAsync(city);
            }
            catch (Exception)
            {
                // ignored
            }
            return response;
        }

    }
}
