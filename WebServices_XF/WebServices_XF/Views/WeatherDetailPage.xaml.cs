using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServices_XF.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebServices_XF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherDetailPage : ContentPage
    {
        private readonly WeatherViewModel _weatherViewModel;
        public WeatherDetailPage()
        {
            InitializeComponent();
            BindingContext = _weatherViewModel = new WeatherViewModel();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            
            if (PickerCity.SelectedIndex == -1)
            {
                await DisplayAlert("Alerta", "Escoja la Ciudad!!", "OK");
            }
            else
            {
                await _weatherViewModel.GetWeatherAsync(PickerCity.Items[PickerCity.SelectedIndex].ToLower());
            }
        }
    }
}
