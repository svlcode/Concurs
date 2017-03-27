using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Concurs.BO;
using Concurs.Helpers;

namespace Concurs
{
    public class Predict
    {
        UserMenuPredictions _userMenuPredictions = new UserMenuPredictions();

        WeekMenu _weekMenu;
        List<UserMenu> _pastUserMenus = new List<UserMenu>();
        List<WeekMenu> _pastWeekMenus = new List<WeekMenu>();
        List<RatedMnItem> _ratedMenuItems = new List<RatedMnItem>();
        IEnumerable<Recipe> _recipes;

        public Predict(WeekMenu weekMenu, List<UserMenu> pastUserMenus, List<WeekMenu> pastWeekMenus)
        {
            _weekMenu = weekMenu;
            _pastUserMenus = pastUserMenus;
            _pastWeekMenus = pastWeekMenus;
            _recipes = new MenuClient().GetRecipes();
        }

        public UserMenuPredictions Generate()
        {
            RateDayMenus();

            return _userMenuPredictions ?? new UserMenuPredictions();
        }

        public void RateDayMenus()
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
                        ratedMenu.CiorbaScore = RateCiorba(menuItem);
                        ratedMenu.SweetScore = RateSweets();

                        if (menuItem.Description.Contains("fruct"))
                        {
                            ratedMenu.FructScore = RateFruct();
                        }
                    }
                    else
                    {
                        ratedMenu.IngredientsScore = RateIngredients(menuItem);
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
            var f1RatedMenus = ratedMenus.Where(m => m.IsF1).ToList();

            if (f1RatedMenus.FirstOrDefault(m => m.FructScore >= 2) != null)
            {
                return f1RatedMenus.FirstOrDefault(m => m.FructScore >= 2).MenuItem.Code;
            }

            if (f1RatedMenus.FirstOrDefault(m => m.SweetScore >= 5) != null)
            {
                return f1RatedMenus.FirstOrDefault(m => m.SweetScore >= 5).MenuItem.Code;
            }

            return f1RatedMenus.OrderByDescending(m => m.CiorbaScore).FirstOrDefault().MenuItem.Code;

        }

        string GetF2FromRatedMenus(List<RatedMnItem> ratedMenus)
        {
            var f2RatedMenus = ratedMenus.Where(m => !m.IsF1);

            var bestChoice = f2RatedMenus.OrderByDescending(m => m.IngredientsScore).FirstOrDefault();

            return bestChoice.MenuItem.Code;
        }

        int RateCiorba(MnItem menuItem)
        {
            var score = 0;
            var recipe = _recipes.FirstOrDefault(r => r.Name.ToLower() == menuItem.Description.Substring(5).ToLower());


            if (recipe != null)
            {
                var ciorbaSelectedMenus = _pastUserMenus.Where(m => (m.F1 ?? string.Empty).ToLower().Contains("ciorba") || (m.F1??string.Empty).ToLower().Contains("supa") || (m.F1 ?? string.Empty).ToLower().Contains("bors"));
                if (ciorbaSelectedMenus != null)
                {
                    var pastSelectedIngredients = new List<string>();
                    foreach (var selectedMenu in ciorbaSelectedMenus)
                    {
                        pastSelectedIngredients.AddRange(_recipes.FirstOrDefault(r => selectedMenu.F1 == r.Name).Ingredients);
                    }


                    foreach (var ingredient in recipe.Ingredients)
                    {
                        if (pastSelectedIngredients.Contains(ingredient))
                        {
                            score++;
                        }
                    }
                }
            }

            return score;
        }

        int RateSweets()
        {
            int counterSweets = 0;

            foreach (var pastWeekMenu in _pastWeekMenus)
            {
                foreach (var dayMenu in pastWeekMenu.DayMenus)
                {
                    foreach (var mi in dayMenu.MenuItems)
                    {
                        if (!string.IsNullOrEmpty(mi.Description))
                        {
                            if (!mi.Description.ToLower().Contains("fruct") &&
                                !mi.Description.ToLower().Contains("ciorba") &&
                                !mi.Description.ToLower().Contains("bors") &&
                                !mi.Description.ToLower().Contains("supa"))
                            {
                                counterSweets++;
                            }
                        }
                    }
                }
            }

            int counterDaysWhenSweetsWereSelected = 0;
            foreach (var pastUserMenu in _pastUserMenus)
            {
                if (!string.IsNullOrEmpty(pastUserMenu.F1))
                {
                    if (!pastUserMenu.F1.ToLower().Contains("fruct") && !pastUserMenu.F1.ToLower().Contains("ciorba") &&
                        !pastUserMenu.F1.ToLower().Contains("supa"))
                    {
                        counterDaysWhenSweetsWereSelected++;
                    }
                }
            }


            return counterSweets - (counterSweets - counterDaysWhenSweetsWereSelected);
        }

        int RateIngredients(MnItem menuItem)
        {
            var score = 0;
            var recipe = _recipes.FirstOrDefault(r => r.Name == menuItem.Description);
            if (recipe != null)
            {
                var pastSelectedIngredients = new List<string>();
                foreach (var selectedMenu in _pastUserMenus)
                {
                    pastSelectedIngredients.AddRange(_recipes.FirstOrDefault(r => selectedMenu.F2 == r.Name).Ingredients);

                    foreach (var ingredient in recipe.Ingredients)
                    {
                        if (pastSelectedIngredients.Contains(ingredient))
                        {
                            score++;
                        }
                    }
                }
            }

            return score;
        }

        int RateFruct()
        {
            int counterSweets = 0;

            foreach (var pastWeekMenu in _pastWeekMenus)
            {
                foreach (var dayMenu in pastWeekMenu.DayMenus)
                {
                    foreach (var mi in dayMenu.MenuItems)
                    {
                        if (mi.Description.ToLower().Contains("fruct") )
                        {
                            counterSweets++;
                        }
                    }
                }
            }

            int counterDaysWhenSweetsWereSelected = 0;
            foreach (var pastUserMenu in _pastUserMenus)
            {
                if ((pastUserMenu.F1??string.Empty).ToLower().Contains("fruct"))
                {
                    counterDaysWhenSweetsWereSelected++;
                }
            }


            return counterSweets - (counterSweets - counterDaysWhenSweetsWereSelected);
        }
    }
}
