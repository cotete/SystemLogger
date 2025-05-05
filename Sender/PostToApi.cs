using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace SystemLogger.Sender
{
    internal static class PostToApi
    {

        private static HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://minhaapi.exemplo.com/evento-")
        };

        /// <summary>
        /// Método utilizado para enviar o objeto (dados do usuário) para a api do sistema.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static async Task Post(Object obj)
        {
            StringContent json = new (JsonSerializer.Serialize(obj), Encoding.UTF8,"application/json");
            try
            {
                HttpResponseMessage res = await _httpClient.PostAsync("Data", json);
                res.EnsureSuccessStatusCode();
                var jsonResponse = await res.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Erro de conexão: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            
        }
    }
}
