using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebServices_XF.Views;
using Xamarin.Forms;

namespace WebServices_XF
{
    public partial class App : Application
    {
        public static string API_KEY = "f0259f5f3c5d18527d64dea308033f2b";
        public static string API_URL = "http://api.openweathermap.org/data/2.5/weather";
        public static string API_URLBASE = "{YOUR_API_BASE_URL}";

        public App()
        {
            InitializeComponent();

            MainPage = new WeatherDetailPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
