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



namespace Concurs
{
    public partial class Form1 : Form
    {
        private const string URL = "http://codechefapi.netrom.live/swagger";
        private const string KEY = "xVr5ahyyNNoHl1XaKwCw";
        private const string GET_USERS = "/api/{apiKey}/users";
        private const string GET_RECIPES = "/api/{apiKey}/recipes";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            var users = GetIEnumerable<User>(client, CreateOperation(GET_USERS));
            var recipes = GetIEnumerable<Recipe>(client, CreateOperation(GET_RECIPES));
        }

        private IEnumerable<T> GetIEnumerable<T>(HttpClient client, string path)
        {
            HttpResponseMessage response = client.GetAsync(path).Result;  
            if (response.IsSuccessStatusCode)
            {
                return  response.Content.ReadAsAsync<IEnumerable<T>>().Result;
            }
            MessageBox.Show(string.Format("{0}, {1}", (int)response.StatusCode, response.ReasonPhrase));
            return null;
        }

        private string CreateOperation(string method)
        {
            return method.Replace("{apiKey}", KEY);
        }
    }
}
