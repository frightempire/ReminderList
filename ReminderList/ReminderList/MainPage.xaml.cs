using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace ReminderList
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var profiles = App.Repository.GetProfiles();
            ProfilesList.ItemsSource = profiles;
            base.OnAppearing();
        }

        private async void ProfilesList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Profile selectedProfile = (Profile)e.SelectedItem;
            ProfilePage profilePage = new ProfilePage()
            {
                BindingContext = selectedProfile
            };
            await Navigation.PushAsync(profilePage);
        }

        private async void AddProfile(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            ProfilePage profilePage = new ProfilePage()
            {
                BindingContext = profile
            };
            await Navigation.PushAsync(profilePage);
        }
    }
}
