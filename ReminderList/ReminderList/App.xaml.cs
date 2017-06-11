using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ReminderList
{
    public partial class App : Application
    {
        public const string database_name = "profiles.db";

        public static ProfileRepository repository;
        public static ProfileRepository Repository => repository ?? (repository = new ProfileRepository(database_name));

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
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
