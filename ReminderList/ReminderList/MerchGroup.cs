using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace ReminderList
{
    [Table("MerchGroup")]
    public class MerchGroup
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string GroupName { get; set; }
        public string Merch { get; set; }

        [Indexed]
        public int Profile_Id { get; set; }
    }
}
