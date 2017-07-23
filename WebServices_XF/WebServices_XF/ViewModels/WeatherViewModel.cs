using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WebServices_XF.Business;
using WebServices_XF.Models;
using WebServices_XF.Services;

namespace WebServices_XF.ViewModels
{
    public class WeatherViewModel:INotifyPropertyChanged
    {
        private readonly WeatherBl _weatherBl;
        public WeatherResponse WeatherResponse { get; set; }
        public WeatherViewModel()
        {
            _weatherBl = new WeatherBl();
            WeatherResponse = new WeatherResponse();
        }

        public async Task GetWeatherAsync(string city)
        {
            try
            {
                IsBusy = true;

                WeatherResponse = await _weatherBl.GetWeatherByCityBl(city);
                if (WeatherResponse != null)
                {
                    Temperature = WeatherResponse.Main.Temp;
                    Pressure = WeatherResponse.Main.Pressure;
                    Humidity = WeatherResponse.Main.Humidity;
                }

            }
            finally
            {
                IsBusy = false;
            }
        }

        private double _temp;
        public double Temperature
        {
            get { return _temp; }
            set
            {
                _temp = value;
                OnPropertyChanged();
            }
        }

        private double _pressure;
        public double Pressure
        {
            get { return _pressure; }
            set
            {
                _pressure = value; 
                OnPropertyChanged();
            }
        }

        private double _humidity;
        public double Humidity
        {
            get { return _humidity; }
            set
            {
                _humidity = value;
                OnPropertyChanged();
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
