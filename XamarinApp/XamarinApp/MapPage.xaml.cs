using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace XamarinApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
			InitializeComponent ();
		}

        private async void OpenLocation_Clicked(object sender, EventArgs e)
        {
            if (!double.TryParse(latText.Text, out double lat))
            {
                latError.Text = "Latitude must be Numeric value";
                latError.TextColor = Color.Red;
                latError.FontAttributes = FontAttributes.Bold;
                return;
            }
            else
            {
                latError.Text = "";
            }

            if (!double.TryParse(lngText.Text, out double lng))
            {
                lngError.Text = "Longitude must be Numeric value";
                lngError.TextColor = Color.Red;
                lngError.FontAttributes = FontAttributes.Bold;
                return;
            }
            else
            {
                lngError.Text = "";
            }

            await Xamarin.Essentials.Map.OpenAsync(lat, lng, new MapLaunchOptions
            {

                NavigationMode = NavigationMode.None
            });
        }

        private async void GetLocation_Clicked(object sender, EventArgs e)
        {
            try
            {

                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    //Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    latText.Text = location.Latitude.ToString();
                    lngText.Text = location.Longitude.ToString();
                }
            }
            catch (Exception ex)
            {
                // Handle not supported on device exception
                Console.WriteLine(ex.ToString());
            }

        }
    }
}