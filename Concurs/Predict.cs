using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Concurs.BO;

namespace Concurs
{
    public class Predict
    {
        UserMenuPredictions _userMenu;
        DayMenu _dayMenu;
        List<RatedMnItem> _ratedMenuItems = new List<RatedMnItem>();

        //public Predict(UserMenu usermenu, DayMenus dayMenus)
        //{
        //    _userMenu = usermenu;
        //    _dayMenus = dayMenus;
        //}

        //public UserMenu Generate()
        //{
        //    var result = new UserMenu();

        //    RateDayMenu();
        //    result = RunPrediction();

        //    return result;
        //}

        //public void RateDayMenu()
        //{
        //    foreach (var menuItem in _dayMenus.MenuItems)
        //    {
        //        RateMenuItem(menuItem);
        //    }
        //}

        //UserMenuPredictions RunPrediction()
        //{
        //    return new UserMenuPredictions();
        //}

        //void RateMenuItem(MnItem menuItem)
        //{
        //    var ratedMenu = new RatedMnItem();
        //    ratedMenu.MenuItem = menuItem;
        //    ratedMenu.CiorbaScore = RateCiorba();


        //    _ratedMenuItems.Add(ratedMenu);
        //}

        //int RateCiorba()
        //{
        //    foreach (var dayMenu in _userMenu.DayMenus)
        //    {

        //    }

        //    return 1;
        //}
    }
}
