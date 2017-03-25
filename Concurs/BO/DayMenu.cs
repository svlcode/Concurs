using System.Collections.Generic;

namespace Concurs.BO
{
    public class DayMenu
    {
        public string Date { get; set; }
        public IEnumerable<MnItem> MenuItems { get; set; } 
    }
}