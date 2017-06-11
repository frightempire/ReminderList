using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace ReminderList
{
    [Table("Profile")]
    public class Profile
    {
        [PrimaryKey, AutoIncrement, Column("_id")] // попробовать без _id
        public int Id { get; set; }

        public string Name { get; set; }
        public string Photo { get; set; }
    }
}
