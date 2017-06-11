using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;
using Xamarin.Forms;

namespace ReminderList
{
    public class ProfileRepository
    {
        SQLiteConnection database;

        public ProfileRepository(string filename)
        {
            string filePath = DependencyService.Get<ISQLite>().GetDbPath(filename);
            database = new SQLiteConnection(new SQLitePlatformAndroid(), filePath);
            database.CreateTable<Profile>();
            database.CreateTable<MerchGroup>();
        }

        public IEnumerable<Profile> GetProfiles()
        {
            return (from row in database.Table<Profile>() select row).ToList();
        }

        public int SaveProfile(Profile item)
        {
            return item.Id != 0 ? database.Update(item) : database.Insert(item);
        }

        public int DeleteProfile(Profile item)
        {
            return database.Delete(item);
        }

        public IEnumerable<MerchGroup> GetGroups(Profile profile)
        {
            return (from row in database.Table<MerchGroup>() where row.Profile_Id==profile.Id select row).ToList();
        }

        public int SaveGroup(MerchGroup item)
        {
            return item.Id != 0 ? database.Update(item) : database.Insert(item);
        }

        public int DeleteGroup(MerchGroup item)
        {
            return database.Delete(item);
        }

    }
}
