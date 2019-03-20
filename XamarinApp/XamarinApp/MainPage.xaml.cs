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

            //set images
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                case Device.Android:
                    mapImage.Source = (ImageSource)ImageSource.FromFile("map.png");
                    notesImage.Source = (ImageSource)ImageSource.FromFile("note.png");
                    contactImage.Source = (ImageSource)ImageSource.FromFile("contact.png");
                    break;
                case Device.UWP:
                    mapImage.Source = (ImageSource)ImageSource.FromFile("Images/map.png");
                    notesImage.Source = (ImageSource)ImageSource.FromFile("Images/note.png");
                    contactImage.Source = (ImageSource)ImageSource.FromFile("Images/contact.png");
                    break;
                default:
                    break;
            }
        }

        //push page operations
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
            Navigation.PushAsync(new SendEmailPage());
        }

        private void MapPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MapPage());
        }

        private void AddNote_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddNotesPage()
            {
                BindingContext = new Note()
            });
        }

        private void AddContact_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddContactsPage()
            {
               BindingContext = new Contact()
            });
        }
    }
}
