using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppIntermodular.api
{
    public class ApiService
    {
        private readonly HttpClient httpClient;

        public ApiService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localHost:3000/api/");
        }

        public async Task<string> AutenticarUsuarioAsync(string email, string password)
        {
            var data = new { Email = email, Password = password };
    //        var response = await httpClient.PostAsJsonAsync("/login", data);

   //         response.EnsureSuccessStatusCode(); 

    //        return await response.Content.ReadAsStringAsync();
                return "OK";
        }
    }
}
