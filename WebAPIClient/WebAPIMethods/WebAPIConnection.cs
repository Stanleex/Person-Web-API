using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPIClient.Models;

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

        public async Task CrateNewPerson()
        {
            using (var client = new HttpClient())
            {
                await client.PostAsJsonAsync(_url, new Person() {Id = 4, FirstName = "Kamil", LastName ="Hareza" });

            }
        }
    }
}
