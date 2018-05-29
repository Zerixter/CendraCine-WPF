using CendraCineDesktop.Models;
using CendraCineDesktop.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CendraCineDesktop.Services
{
    public class ApiService
    {
        private readonly HttpClient Client;
        private string Token;
        private readonly string Format = "application/json";

        public ApiService()
        {
            Client = new HttpClient();
        }

        public async Task<bool> Login()
        {
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("Accept", Format);
            Client.BaseAddress = new Uri(Resources.baseURL);

            User user = new User
            {
                Email = Resources.Email,
                Password = Resources.Password
            };

            var user_json = JsonConvert.SerializeObject(user);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "account/login")
            {
                Content = new StringContent(user_json, Encoding.UTF8, Format)
            };

            var x = await Client.SendAsync(request);
            if (x.StatusCode == HttpStatusCode.OK)
            {
                string json_txt = await x.Content.ReadAsStringAsync();
                User user_get = JsonConvert.DeserializeObject<User>(json_txt);
                Client.DefaultRequestHeaders.Add("Authorization", String.Concat("Bearer ", user_get.Token.Replace("\"", "")));
                return true;
            }
            return false;
        }

        public async Task<List<Movie>> GetMovies()
        {
            List<Movie> Movies = new List<Movie>();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "movie");

            var x = await Client.SendAsync(request);
            if (x.StatusCode == HttpStatusCode.OK)
            {
                string json_txt = await x.Content.ReadAsStringAsync();
                Movies = JsonConvert.DeserializeObject<List<Movie>>(json_txt);
            }
            return Movies;
        }

        public async Task<bool> DeleteMovie(string id)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, $"movie/{id}");
            var x = await Client.SendAsync(request);
            return x.StatusCode == HttpStatusCode.OK;
        }
    }
}
