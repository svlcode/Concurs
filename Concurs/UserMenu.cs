using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurs
{
    public class UserMenu
    {
        public string UserId { get; set; }
        public List<DayMenu> DayMenu { get; set; }


        public UserMenu()
        {
            DayMenu = new List<DayMenu>();
        }
    }

    public class DayMenu
    {
        public DateTime Day { get; set; }
        public string F1 { get; set; }
        public string F2 { get; set; }
    }
}
