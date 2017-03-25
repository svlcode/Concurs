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
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Concurs
{
    public partial class Form1 : Form
    {
        private const string URL = "http://codechefapi.netrom.live/swagger";
        private const string KEY = "xVr5ahyyNNoHl1XaKwCw";
        private const string GET_USERS = "/api/{apiKey}/users";
        private const string GET_RECIPES = "/api/{apiKey}/recipes";
        private const string GET_WEEK_MENU = "/api/{apiKey}/weekmenu/{anyDateofWeek}";


        private readonly HttpClient _client;

        public Form1()
        {
            InitializeComponent();
            _client = CreateHttpClient();
        }

        private HttpClient CreateHttpClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        private void btnRetrieveUsers_Click(object sender, EventArgs e)
        {
            PopulateUsersListBox();
        }

        private void PopulateUsersListBox()
        {
            var users = GetIEnumerable<User>(CreateOperation(GET_USERS));
            if (users != null)
            {
                foreach (var user in users)
                {
                    listBoxUsers.Items.Add(user);
                }
            }

            
        }

        private IEnumerable<T> GetIEnumerable<T>(string path)
        {
            HttpResponseMessage response = _client.GetAsync(path).Result;  
            if (response.IsSuccessStatusCode)
            {
                return  response.Content.ReadAsAsync<IEnumerable<T>>().Result;
            }
            MessageBox.Show(string.Format("{0}, {1}", (int)response.StatusCode, response.ReasonPhrase));
            return null;
        }


        private T GetObject<T>(string path) where T: class 
        {
            HttpResponseMessage response = _client.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<T>().Result;
            }
            MessageBox.Show(string.Format("{0}, {1}", (int)response.StatusCode, response.ReasonPhrase));
            return null;
        }


        private string CreateOperation(string method)
        {
            return method.Replace("{apiKey}", KEY);
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
            var recipes = GetIEnumerable<Recipe>(CreateOperation(GET_RECIPES));
        }

        private void btnGetWeekMenu_Click(object sender, EventArgs e)
        {
            var date = dateTimePicker1.Value.ToString("yyyy-M-d");

            var weekMenu = GetObject<WeekMenu>(CreateOperation(GET_WEEK_MENU).Replace("{anyDateofWeek}", date));
        }
    }
}
