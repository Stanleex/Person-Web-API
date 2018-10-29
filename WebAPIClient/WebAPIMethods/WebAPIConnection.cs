using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPIClient.Models;
using System.Net.Http.Formatting;

namespace WebAPIClient.WebAPIMethods
{
    public class WebAPIConnection
    {
        private Uri _url;
        public WebAPIConnection(string url)
        {
            _url = new Uri(url);
        }

        public async Task<List<Person>> Get()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(_url);

                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }

                return JsonConvert.DeserializeObject<List<Person>>(json);
            }
        }
        public async Task<Person> GetPersonById(int id)
        {
            using (var client = new HttpClient())
            {

                var response = await client.GetAsync(_url+"/"+id);
                
                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }

                return JsonConvert.DeserializeObject<Person>(json);
            }
        }
        public async Task CrateNewPerson(int id, string firstName, string lastName)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(new Person() { Id = id, FirstName = firstName, LastName = lastName });
                var stringContent = new StringContent(json, System.Text.UnicodeEncoding.UTF8, "application/json");

                var response = await client.PostAsync(_url, stringContent);
            }
        }
        public async Task UpdatePersonData(int id, string firstName, string lastName)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(new Person() {FirstName = firstName, LastName = lastName });
                var stringContent = new StringContent(json, System.Text.UnicodeEncoding.UTF8, "application/json");

                var response = await client.PutAsync(_url + "/" + id, stringContent);
            }
        }
        public async Task DeletePerson(int id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync(_url + "/" + id);
            }
        }
    }
}
