using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClient.Repositories;
using WebClient.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace WebClient.Services
{
    public class GenericRepository<T> : IGenericRepository<T>
    {
        private string apiUrl = "http://localhost:6480/api/Users";
        HttpClient _client;
        public GenericRepository()
        {
            _client = new HttpClient();
        }
        public void Create(T entity)
        {
            string jsoncustomer = JsonConvert.SerializeObject(entity);
            StringContent stringContent = new StringContent(jsoncustomer, System.Text.Encoding.UTF8, "application/json");
            var result = _client.PostAsync(apiUrl, stringContent).Result;
        }

        public void Delete(int id)
        {
            var result = _client.DeleteAsync(apiUrl + "/" + id).Result;
        }

        public List<T> GetAll(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var result = _client.GetStringAsync(apiUrl).Result;
            List<T> list = JsonConvert.DeserializeObject<List<T>>(result);
            return list;
        }

        public T GetbyId(int id)
        {
            var result = _client.GetStringAsync(apiUrl + "/" + id).Result;
            T resulT = JsonConvert.DeserializeObject<T>(result);
            return resulT;
            
        }

        public void Update(T entity)
        {
            var jsoncustomer = JsonConvert.SerializeObject(entity);
            StringContent stringContent = new StringContent(jsoncustomer, System.Text.Encoding.UTF8, "application/json");
            //var result = _client.PutAsync(apiUrl + "/" + users.ID, stringContent).Result;
        }
    }
}
