using System;
using System.Collections.Generic;

namespace Concurs.BO
{
    public class WeekMenu
    {
        public string ID { get; set; }
        public string Monday { get; set; }
        public List<DayMenu> DayMenus { get; set; }
    }
}