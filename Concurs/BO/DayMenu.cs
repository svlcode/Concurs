using System;
using System.Collections.Generic;

namespace Concurs.BO
{
    public class DayMenu
    {
        public DateTime Date { get; set; }
        public IEnumerable<MnItem> MenuItems { get; set; } 
    }
}