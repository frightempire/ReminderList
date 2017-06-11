using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderList
{
    public interface ISQLite
    {
        string GetDbPath(string filename);
    }
}
