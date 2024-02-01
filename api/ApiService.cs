using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using WpfAppIntermodular.Models;
using System.Net.Http.Json;

namespace WpfAppIntermodular.api
{
    public class ApiService
    {
        private readonly HttpClient httpClient;

        public ApiService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localHost:8000/api/");
        }

        public async Task<string> AutenticarUsuarioAsync(string email, string password)
        {   var data =  new {email, password};
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("employee/login", data);
            string token = await response.Content.ReadAsStringAsync();
            return token;
        }

       
        public async Task<string> InsertRoomApi(bool reserved, string? section, int number, double pricePerNight,
            int beds,  string? image)
        {
            var data = new { reserved, section, number, pricePerNight, beds, image };
            var response = await httpClient.PostAsJsonAsync("admin/rooms/", data);
    
            return "OK";
        }

        public async Task<List<HabitacionModel>> BuscarHabitacionesAsync()
        {
            var response = await httpClient.GetAsync("/client/rooms");
            List<HabitacionModel> habitaciones = await response.Content.ReadFromJsonAsync<List<HabitacionModel>>();
            return habitaciones;

        }
    }
}
