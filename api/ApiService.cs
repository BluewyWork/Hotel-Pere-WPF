using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web;
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
            var data = new { number, section, pricePerNight, reserved, image, beds };
            _httpClient.DefaultRequestHeaders.Add("Cookie", Settings1.Default.JWTTokenCookie);
            var response = await _httpClient.PutAsJsonAsync("/api/admin/room", data);
            var responseCode = response.EnsureSuccessStatusCode();
            if (responseCode.IsSuccessStatusCode)
            {
                MessageBox.Show("La habitación se ha actualizado correctamente", "Ok");
                return true;
            }
            else
            {
                MessageBox.Show("La habitación no se ha podido actualizar", "Error");
                return false;
            }
        }

        public async Task<List<HabitacionModel>> MostrarHabitacionesApiAsync()
        {
            List<HabitacionModel> habitaciones = new List<HabitacionModel>();
            _httpClient.DefaultRequestHeaders.Add("Cookie", Settings1.Default.JWTTokenCookie);
            var response = await _httpClient.GetAsync("/api/admin/room");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                dynamic result = JObject.Parse(responseBody);
                JArray habitacionesArray = result.data;
                habitaciones = JsonConvert.DeserializeObject<List<HabitacionModel>>(habitacionesArray.ToString());
                return habitaciones;
            }
            else
            {
                MessageBox.Show("Error al mostrar las habitaciones ", "Error");
                return habitaciones;
            }
        }

        public async Task<List<ReservasModel>> MostrarReservasApiAsync()
        {
            List<ReservasModel> reservas = new List<ReservasModel>();
            _httpClient.DefaultRequestHeaders.Add("Cookie", Settings1.Default.JWTTokenCookie);
            var response = await _httpClient.GetAsync("/api/admin/books");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                dynamic result = JObject.Parse(responseBody);
                JArray reservasArray = result.data;
                reservas = JsonConvert.DeserializeObject<List<ReservasModel>>(reservasArray.ToString());
                return reservas;
            }
            else
            {
                MessageBox.Show("Error al mostrar las habitaciones ", "Error");
                return reservas;
            }
        }

        public async Task<bool> CreateRoomApi(string section, int number,
            double pricePerNight, int beds, string image, bool reserved)
        {
            var data = new { number, section, pricePerNight, reserved, image, beds };
            _httpClient.DefaultRequestHeaders.Add("Cookie", Settings1.Default.JWTTokenCookie);
            var response = await _httpClient.PostAsJsonAsync("/api/admin/room", data);

            MessageBox.Show(response.ToString());
            if (!response.StatusCode.Equals("422"))
            {

                MessageBox.Show("La habitacion se ha creado correctamente", "Ok");
                return true;
            }
            else
            {
                MessageBox.Show("Error al crear la habitacion, numero duplicado", "Error");
                return false;
            }
        }

        public async Task<bool> DeleteRoomApi(int number)
        {
            _httpClient.DefaultRequestHeaders.Add("Cookie", Settings1.Default.JWTTokenCookie);
            var response = await _httpClient.DeleteAsync($"/api/admin/room/{number}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<HabitacionModel>> BuscarHabitaciones(bool? reservadaBuscador, double? precioBuscador, int? camasBuscador)
        {
            HttpClient h = new HttpClient();
            string longurl = _httpClient.BaseAddress + "api/admin/room/search?";
            var uriBuilder = new UriBuilder(longurl);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            if (camasBuscador != null) { query["bed"] = camasBuscador.ToString(); }
            if (reservadaBuscador != null) { query["reserved"] = reservadaBuscador.ToString().ToLower(); }
            if (precioBuscador != null) { query["price"] = precioBuscador.ToString(); }
            uriBuilder.Query = query.ToString();
            longurl = uriBuilder.ToString();
            List<HabitacionModel> habitaciones = new List<HabitacionModel>();
            h.DefaultRequestHeaders.Add("Cookie", Settings1.Default.JWTTokenCookie);
            var response = await h.GetAsync(longurl);
            if (response.IsSuccessStatusCode)
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

        public async Task<List<UsuarioModel>> GetAllUsersApi()
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Add("Cookie", Settings1.Default.JWTTokenCookie);
                var response = await _httpClient.GetAsync("/api/route");

                if (!response.IsSuccessStatusCode)
                    return new List<UsuarioModel>();

                string responseBody = await response.Content.ReadAsStringAsync();
                dynamic result = JObject.Parse(responseBody);
                JArray usuarioArray = result.data;
                var usuarios = JsonConvert.DeserializeObject<List<UsuarioModel>>(usuarioArray.ToString());

                return usuarios ?? new List<UsuarioModel>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<UsuarioModel>();
            }
        }

        public async Task<Boolean> UpdateUser(string name, string surname, string email, string password)
        {
            return true;
        }

        public async Task<Boolean> EliminarUsuario(string email)
        {
            return true;
        }
    }
}
