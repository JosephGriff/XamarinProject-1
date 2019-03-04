using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                case Device.Android:
                    mapImage.Source = (ImageSource)ImageSource.FromFile("map.png");
                    break;
                case Device.UWP:
                    mapImage.Source = (ImageSource)ImageSource.FromFile("Images/map.png");
                    break;
                default:
                    break;
            }
        }

        private void NotesListPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NotesListPage());
        }

        private void ContactsListPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContactsListPage());
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MapPage());
        }
    }
}
