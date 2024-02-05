using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WpfAppIntermodular;
using WpfAppIntermodular.Models;

namespace wpfappintermodular.api
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string cokie;

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:8000");
        }

        public async Task<bool> AutenticarUsuarioAsync(string email, string password)
        {
            var data = new { email, password };
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/auth/employee/login", data);
            if (response.IsSuccessStatusCode)
            {
                string jwtCookie = response.Headers.GetValues("Set-Cookie").FirstOrDefault();
                string[] cookies = jwtCookie.Split(';');
                Settings1.Default.JWTTokenCookie = cookies[0];
                return true;
            }
            else
            {
                MessageBox.Show("Las credenciales no son correctas", "Error");
                return false;
            }
          
        }

        public async Task<bool> UpdateRoomApi(bool reserved, string section, int number, double pricePerNight, int beds, string image)
        {
            var data = new { reserved, section, number, pricePerNight, beds, image };
            _httpClient.BaseAddress = new Uri("http://localhost:8000/api/admin/room");
            _httpClient.DefaultRequestHeaders.Add("Cookie", Settings1.Default.JWTTokenCookie);
            var response = await _httpClient.PutAsJsonAsync("", data);
            var responseCode = response.EnsureSuccessStatusCode();
            return responseCode.IsSuccessStatusCode;
        }

        public async Task<List<HabitacionModel>> BuscarHabitacionesAsync()
        {
            List<HabitacionModel> habitaciones= new List<HabitacionModel>();
            _httpClient.BaseAddress = new Uri("http://localhost:8000/api/admin/room");
            _httpClient.DefaultRequestHeaders.Add("Cookie", Settings1.Default.JWTTokenCookie);
            var response = await _httpClient.GetAsync("");
            if(response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                dynamic result = JObject.Parse(responseBody);
                JArray habitacionesArray = result.data;
                habitaciones = JsonConvert.DeserializeObject<List<HabitacionModel>>(habitacionesArray.ToString());
                return habitaciones;
            }
            else
            {
                return habitaciones;
            }         
        }

        public async Task<List<HabitacionModel>> MostrarHabitacionesApiAsync()
        {
            _httpClient.DefaultRequestHeaders.Add("Cookie", Settings1.Default.JWTTokenCookie);
            var response = await _httpClient.GetAsync("/api/admin/room");
            string responseBody = await response.Content.ReadAsStringAsync();
            dynamic result = JObject.Parse(responseBody);
            JArray habitacionesArray = result.data;
            List<HabitacionModel> habitaciones = JsonConvert.DeserializeObject<List<HabitacionModel>>(habitacionesArray.ToString());
            return habitaciones;
        }
    }
}
