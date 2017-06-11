using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReminderList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var profile = (Profile) BindingContext;
            GroupsList.ItemsSource = App.Repository.GetGroups(profile);
            if(profile.Photo == null)
                Photo.Source = ImageSource.FromFile("defaultavatar.jpg");
            base.OnAppearing();
        }

        public void SaveProfile(object sender, EventArgs e)
        {
            var profile = (Profile)BindingContext;
            if (!String.IsNullOrEmpty(profile.Name))
                App.Repository.SaveProfile(profile);
            this.Navigation.PopAsync();
        }

        public void DeleteProfile(object sender, EventArgs e)
        {
            var profile = (Profile)BindingContext;
            var groups = App.Repository.GetGroups(profile);
            foreach (var item in groups)
            {
                App.Repository.DeleteGroup(item);
            }
            App.Repository.DeleteProfile(profile);
            this.Navigation.PopAsync();
        }

        public void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private async void GroupsList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MerchGroup selectedGroup = (MerchGroup) e.SelectedItem;
            GroupPage groupPage = new GroupPage()
            {
                BindingContext = selectedGroup
            };
            await Navigation.PushAsync(groupPage);
        }

        private async void AddGroup(object sender, EventArgs e)
        {
            var profile = (Profile)BindingContext;
            if (!String.IsNullOrEmpty(profile.Name))
                App.Repository.SaveProfile(profile);
            MerchGroup group = new MerchGroup()
            {
                Profile_Id = profile.Id
            };
            GroupPage groupPage = new GroupPage()
            {
                BindingContext = group
            };
            await Navigation.PushAsync(groupPage);
        }

        private async void PickImage(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported) return;
            MediaFile photo = await CrossMedia.Current.PickPhotoAsync();

            var profile = (Profile) BindingContext;
            profile.Photo = photo.Path;

            // Привязка фото, отображает фото во время выполнения
            Photo.Source = ImageSource.FromFile(profile.Photo);
        }

        private async void MakeImage(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported) return;

            //string picFolder = DependencyService.Get<IPicture>().GetImagePath();
            MediaFile photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                SaveToAlbum = true,
                Directory = "ReminderListApp",
                Name = $"{DateTime.Now:dd.MM.yyyy_hh.mm.ss}.jpg"
            });

            if (photo == null)
                return;

            var profile = (Profile)BindingContext;
            profile.Photo = photo.Path;

            // Привязка фото, отображает фото во время выполнения
            Photo.Source = ImageSource.FromFile(profile.Photo);
        }
    }
}