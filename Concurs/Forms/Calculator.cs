using System;
using System.Collections.Generic;
using Concurs.BO;
using Concurs.Extensions;
using Concurs.Helpers;

namespace Concurs.Forms
{
    public class Calculator
    {
        private readonly User _user;
        private readonly MenuClient _menuClient;

        public Calculator(User user, MenuClient menuClient)
        {
            _user = user;
            _menuClient = menuClient;
        }

        public WeekMenu GetNextWeekMenu()
        {
            var mondayNextWeek = DateTime.Now.StartOfWeek(DayOfWeek.Monday).AddDays(7);
            var nextWeekMenu =  _menuClient.GetWeekMenu(mondayNextWeek);
            return nextWeekMenu;
        }

        private Dictionary<string, int> GetFirstCoursePreferences()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            return dictionary;
        }

        private string GetWeekPreferences()
        {
            var date = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            var weekMenu = _menuClient.GetWeekMenu(date);
            foreach (DayMenu dayMenu in weekMenu.DayMenus)
            {
                foreach (var menuItem in dayMenu.MenuItems)
                {
                    
                }
            }

            return string.Empty;
        }
    }
}