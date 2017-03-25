﻿using System;
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
          
        }

        private IEnumerable<T> GetIEnumerable<T>(HttpClient client, string path)
        {
            HttpResponseMessage response = client.GetAsync(CreateOperation(GET_USERS)).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                return  response.Content.ReadAsAsync<IEnumerable<T>>().Result;
            }
            MessageBox.Show($"{(int)response.StatusCode}, {response.ReasonPhrase}");
            return null;
        }

        private async Task<IEnumerable<User>> GetProductAsync(HttpClient client, string path)
        {
            IEnumerable<User> users = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                users = await response.Content.ReadAsAsync<IEnumerable<User>>();
            }
            return users;
        }




        private string CreateOperation(string method)
        {
            return method.Replace("{apiKey}", KEY);
        }
    }

    public class User
    {
        public string UID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
    }
}
