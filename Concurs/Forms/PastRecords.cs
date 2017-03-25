using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Concurs.BO;
using Concurs.Extensions;

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
            var date = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            var lastWeek = date.AddDays(-1).StartOfWeek(DayOfWeek.Thursday);
            var twoWeeksAgo = lastWeek.AddDays(-1).StartOfWeek(DayOfWeek.Monday);

            //var weekMenu = GetObject<WeekMenu>(CreateOperation(GET_WEEK_MENU).Replace("{anyDateofWeek}", date));
        }
    }

    public class Calculator
    {
        private readonly User _user;

        public Calculator(User user)
        {
            _user = user;
        }

        public Dictionary<string, int> GetFirstCoursePreferences()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            return dictionary;
        }

        public string GetWeekPreferences()
        {

            return string.Empty;
        }
    }
}
