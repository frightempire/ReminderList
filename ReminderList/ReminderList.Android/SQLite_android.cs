using System;
using System.IO;
using ReminderList.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace ReminderList.Droid
{
    class SQLite_Android: ISQLite
    {
        public string GetDbPath(string filename)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), filename);
        }
    }
}