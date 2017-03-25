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
            
            Calculator c =new Calculator(null,new MenuClient());
            c.GetPrediction("ecefda4d-0a1e-11e7-946d-00155d400817");

            List<MenuPrediction> predictions = new List<MenuPrediction>();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
