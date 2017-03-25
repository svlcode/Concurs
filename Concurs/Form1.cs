using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Concurs.BO;
using Concurs.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Concurs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void btnRetrieveUsers_Click(object sender, EventArgs e)
        {
            PopulateUsersListBox();
        }

        private void PopulateUsersListBox()
        {
            var users = new MenuClient().GetUsers();
            if (users != null)
            {
                foreach (var user in users)
                {
                    listBoxUsers.Items.Add(user);
                }
            }
        }

        private void listBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var user = listBoxUsers.SelectedItem as User;
            if (user != null)
            {
                txtName.Text = user.Name;
                txtUID.Text = user.UID;
                txtAge.Text = user.Age.ToString();
                txtGender.Text = user.Gender;
            } 
            
        }

        private void btnGetReceipes_Click(object sender, EventArgs e)
        {
            var recipes = new MenuClient().GetRecipes();
        }

        private void btnGetWeekMenu_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var userMenues = new MenuClient().GetUserMenus(txtUID.Text, dateTimePicker2.Value, dateTimePicker3.Value);
        }
    }
}
