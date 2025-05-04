using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace SystemLogger.Sender
{
    internal class Sender
    {

        private HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://minhaapi.exemplo.com/evento-")
        };

        public async Task Post(Object obj)
        {
            StringContent json = new (JsonSerializer.Serialize(obj), Encoding.UTF8,"application/json");
            HttpResponseMessage res = await _httpClient.PostAsync("Data",json);
            res.EnsureSuccessStatusCode();
            var jsonResponse = await res.Content.ReadAsStringAsync();
            Console.WriteLine(jsonResponse);
        }
    }
}
