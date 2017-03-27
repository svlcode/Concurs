using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Concurs.BO;
using Concurs.Forms;
using Concurs.Helpers;

namespace Concurs
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            var users = new MenuClient().GetUsers();
            foreach (var user in users)
            {
                Test(user.UID);
            }
            // Calculator c =new Calculator(null,new MenuClient());

            // var nextWeekMenu = new Calculator(null, new MenuClient()).GetNextWeekMenu();

            // var startDate = new DateTime(2017, 2, 01);
            // var endDate = new DateTime(2017, 3, 10);
            // var userId = "ecefda4d-0a1e-11e7-946d-00155d400817";

            // var userMenues = new MenuClient().GetUserMenus(userId, startDate, endDate).ToList();

            // var pastWeekMenus = new Calculator(null, new MenuClient()).GetLastThreeWeekMenus().ToList();

            // Predict p = new Predict(nextWeekMenu, userMenues, pastWeekMenus);
            //var pred = p.Generate();

            // var menuClient =new MenuClient();
            // menuClient.CreateProductAsync(pred.MenuPredictionList, userId);

            // List<MenuPrediction> predictions = new List<MenuPrediction>();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void Test(string userId)
        {
            Calculator c = new Calculator(null, new MenuClient());

            var nextWeekMenu = new Calculator(null, new MenuClient()).GetNextWeekMenu();

            var startDate = new DateTime(2017, 2, 01);
            var endDate = new DateTime(2017, 3, 10);
            //var userId = "ecefda4d-0a1e-11e7-946d-00155d400817";

            var userMenues = new MenuClient().GetUserMenus(userId, startDate, endDate).ToList();

            var pastWeekMenus = new Calculator(null, new MenuClient()).GetLastThreeWeekMenus().ToList();

            Predict p = new Predict(nextWeekMenu, userMenues, pastWeekMenus);
            var pred = p.Generate();

            var menuClient = new MenuClient();
            menuClient.CreateProductAsync(pred.MenuPredictionList, userId);
        }
    }
}
