using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Concurs.Extensions;
using Concurs.Helpers;

namespace Concurs.Forms
{
    public partial class PastRecords : Form
    {
        public PastRecords()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var date = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            //var lastWeek = date.AddDays(-1).StartOfWeek(DayOfWeek.Thursday);
            //var twoWeeksAgo = lastWeek.AddDays(-1).StartOfWeek(DayOfWeek.Monday);

            //var weekMenu = GetObject<WeekMenu>(CreateOperation(GET_WEEK_MENU).Replace("{anyDateofWeek}", date));

            var calc = new Calculator(null, new MenuClient());
            calc.GetNextWeekMenu();
        }
    }
}
