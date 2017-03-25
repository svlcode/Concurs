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
        UserMenuPredictions _userMenuPredictions;

        WeekMenu _weekMenu;
        List<UserMenu> _pastUserMenus;
        List<RatedMnItem> _ratedMenuItems = new List<RatedMnItem>();

        public Predict(WeekMenu weekMenu, List<UserMenu> pastUserMenus)
        {
            _weekMenu = weekMenu;
            _pastUserMenus = pastUserMenus;
        }

        public UserMenuPredictions Generate()
        {
            var result = new UserMenuPredictions();

            RateDayMenu();
            result = RunPrediction();

            return result;
        }

        public void RateDayMenu()
        {
            foreach (var dayMenu in _weekMenu.DayMenus)
            {
                var menuPrediction = new MenuPrediction();
                menuPrediction.Day = dayMenu.Date;

                var ratedMenus = new List<RatedMnItem>();
                foreach (var menuItem in dayMenu.MenuItems)
                {
                    var ratedMenu = new RatedMnItem();
                    ratedMenu.MenuItem = menuItem;
                    ratedMenu.IsF1 = menuItem.Type == "1";

                    if (ratedMenu.IsF1)
                    {
                        ratedMenu.CiorbaScore = RateCiorba();
                        ratedMenu.SweetScore = RateSweets();

                        if (menuItem.Description.Contains("fruct"))
                        {
                            ratedMenu.FructScore = RateFruct();
                        }
                    }
                    else
                    {
                        ratedMenu.IngredientsScore = RateIngredients();
                    }

                    ratedMenus.Add(ratedMenu);
                }
                menuPrediction.F1 = GetF1FromRatedMenus(ratedMenus);
                menuPrediction.F2 = GetF2FromRatedMenus(ratedMenus);

                _userMenuPredictions.MenuPredictionList.Add(menuPrediction);
            }
        }

        string GetF1FromRatedMenus(List<RatedMnItem> ratedMenus)
        {
            var f1RatedMenus = ratedMenus.Where(m => m.IsF1);

            //not ok yet!!!!
            var bestChoice = f1RatedMenus.Max(m => m.CiorbaScore + m.FructScore + m.IngredientsScore + m.FructScore);

            return "";
        }

        string GetF2FromRatedMenus(List<RatedMnItem> ratedMenus)
        {
            return "";
        }

        UserMenuPredictions RunPrediction()
        {
            return new UserMenuPredictions();
        }
        

        int RateCiorba()
        {
            

            return 1;
        }

        int RateSweets()
        {


            return 1;
        }

        int RateIngredients()
        {


            return 1;
        }

        int RateFruct()
        {


            return 1;
        }
    }
}
