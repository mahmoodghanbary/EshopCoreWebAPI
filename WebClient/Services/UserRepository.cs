using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClient.Models;
using WebClient.Repositories;
using System.Net.Http;
using Newtonsoft.Json;

namespace WebClient.Services
{
    public class UserRepository : IUserRepository
    {
        private string apiUrl = "http://localhost:6480/api/Users";
        HttpClient _client;
        public UserRepository()
        {
            _client = new HttpClient();
        }

        public void Create(Users users)
        {
            string jsoncustomer = JsonConvert.SerializeObject(users);
            StringContent stringContent = new StringContent(jsoncustomer, System.Text.Encoding.UTF8, "application/json");
            var result = _client.PostAsync(apiUrl, stringContent).Result;
        }

        public void Delete(int userid)
        {
            var result = _client.DeleteAsync(apiUrl + "/" + userid).Result;

        }

        public List<Users> GetAll(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var result = _client.GetStringAsync(apiUrl).Result;
            List<Users> list = JsonConvert.DeserializeObject<List<Users>>(result);
            return list;
        }

        public Users GetbyId(int userid)
        {
            var result = _client.GetStringAsync(apiUrl +"/"+ userid).Result;
            Users customer = JsonConvert.DeserializeObject<Users>(result);
            return customer;
        }

        public void Update(Users users)
        {
            var jsoncustomer = JsonConvert.SerializeObject(users);
            StringContent stringContent = new StringContent(jsoncustomer, System.Text.Encoding.UTF8, "application/json");
            var result = _client.PutAsync(apiUrl + "/" + users.ID, stringContent).Result;

        }
        public Task<Users> LoginUser(string name, string password)
        {
          return  null;
        }
    }
}
