using System;
using System.Collections.Generic;

namespace Concurs.BO
{
    public class WeekMenu
    {
        private string ID { get; set; }
        public string Monday { get; set; }
        List<DayMenu> DayMenus { get; set; }
    }
}