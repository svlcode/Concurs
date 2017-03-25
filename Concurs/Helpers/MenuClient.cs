using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using Concurs.BO;

namespace Concurs.Helpers
{
    public class MenuClient
    {
        private readonly HttpClient _client;
        private const string URL = "http://codechefapi.netrom.live/swagger";
        private const string KEY = "xVr5ahyyNNoHl1XaKwCw";
        private const string GET_USERS = "/api/{apiKey}/users";
        private const string GET_RECIPES = "/api/{apiKey}/recipes";
        private const string GET_WEEK_MENU = "/api/{apiKey}/weekmenu/{anyDateofWeek}";
        private const string GET_USER_MENUS = "/api/{apiKey}/usermenu/{uid}/{startDate}/{endDate}";

        public MenuClient()
        {
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

        private IEnumerable<T> GetIEnumerable<T>(string path)
        {
            HttpResponseMessage response = _client.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<IEnumerable<T>>().Result;
            }
            MessageBox.Show(string.Format("{0}, {1}", (int)response.StatusCode, response.ReasonPhrase));
            return null;
        }

        private string CreateOperation(string method)
        {
            return method.Replace("{apiKey}", KEY);
        }

        private T GetObject<T>(string path) where T : class
        {
            HttpResponseMessage response = _client.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<T>().Result;
            }
            MessageBox.Show(string.Format("{0}, {1}", (int)response.StatusCode, response.ReasonPhrase));
            return null;
        }

        public IEnumerable<User> GetUsers()
        {
            return GetIEnumerable<User>(CreateOperation(GET_USERS));
        }


        public WeekMenu GetWeekMenu(DateTime date)
        {
            var dateString = date.ToString("yyyy-M-d");

            return GetObject<WeekMenu>(CreateOperation(GET_WEEK_MENU).Replace("{anyDateofWeek}", dateString));
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            return GetIEnumerable<Recipe>(CreateOperation(GET_RECIPES));
        }

        public IEnumerable<UserMenu> GetUserMenus(string userId, DateTime startDate, DateTime endDate)
        {
            var startDate2 = startDate.ToString("yyyy-M-d");
            var endDate2 = endDate.ToString("yyyy-M-d");

            GET_USERS.Replace("{uid}", userId);
            GET_USERS.Replace("{startDate}", startDate2);
            GET_USERS.Replace("{endDate}", endDate2);

            return GetIEnumerable<UserMenu>(CreateOperation(GET_USER_MENUS));
        }

    }
}