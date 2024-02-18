using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using DocumentFormat.OpenXml.Spreadsheet;
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
            return true;
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

        public async Task<bool> UpdateRoomApi(string description, int number, double pricePerNight, int beds)
        {
                if(description == null)
            {
                description = string.Empty;
            }

            var data = new { number, description, pricePerNight, beds };
            _httpClient.DefaultRequestHeaders.Add("Cookie", Settings1.Default.JWTTokenCookie);
            var response = await _httpClient.PutAsJsonAsync("/api/admin/room/update", data);
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
            var response = await _httpClient.GetAsync("/api/admin/room/all");
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
            var response = await _httpClient.GetAsync("/api/admin/reservation/all");
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
                MessageBox.Show("Error al mostrar las reservas ", "Error");
                return reservas;
            }
        }

        public async Task<bool> CreateRoomApi(string description, int number,
            double pricePerNight, int beds)
        {
            ReservedDays[] reservedDays = new ReservedDays[0];
            var data = new { number, description, pricePerNight, beds, reservedDays };
            _httpClient.DefaultRequestHeaders.Add("Cookie", Settings1.Default.JWTTokenCookie);
            var response = await _httpClient.PostAsJsonAsync("/api/admin/room/new", data);
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
            var response = await _httpClient.DeleteAsync($"/api/admin/room/delete/{number}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<HabitacionModel>> BuscarHabitaciones(double? precioBuscador, int? camasBuscador, string checkIn, string checkOut)
        {
            HttpClient h = new HttpClient();
            string longurl = _httpClient.BaseAddress + "api/admin/room/search?";
            var uriBuilder = new UriBuilder(longurl);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            if (camasBuscador != null) { query["beds"] = camasBuscador.ToString(); }
            if (checkIn != null) { query["checkIn"] = checkIn.ToString(); }
            if (checkOut != null) { query["checkOut"] = checkOut.ToString(); }
            if (precioBuscador != null) { query["pricePerNight"] = precioBuscador.ToString(); }
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


            List<UsuarioModel> users = new List<UsuarioModel>()
            {
                new UsuarioModel() { Name = "John", Surname = "Doe", Email = "john@example.com", Password = "password1" },
                new UsuarioModel() { Name = "Jane", Surname = "Smith", Email = "jane@example.com", Password = "password2" },
            };

            // return users;

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
            // return true;

            var data = new {name, surname, email, password};
            _httpClient.DefaultRequestHeaders.Add("Cookie", Settings1.Default.JWTTokenCookie);
            var response = await _httpClient.PutAsJsonAsync("/api/admin/guest", data);
            var responseCode = response.EnsureSuccessStatusCode();
            if (responseCode.IsSuccessStatusCode)
            {
                MessageBox.Show("El usuario se ha actualizado correctamente", "Ok");
                return true;
            }
            else
            {
                MessageBox.Show("El usuario no se ha podido actualizar", "Error");
                return false;
            }
        }

        public async Task<Boolean> EliminarUsuario(string email)
        {
            // return true;

            _httpClient.DefaultRequestHeaders.Add("Cookie", Settings1.Default.JWTTokenCookie);
            var response = await _httpClient.DeleteAsync($"/api/admin/guest/{email}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<ReservasModel>> BuscarReservasApi(string checkInBuscador, string checkOutBuscador, string correoClienteBuscador)
        {
            HttpClient h = new HttpClient();
            string longurl = _httpClient.BaseAddress + "api/admin/reservation/search?";
            var uriBuilder = new UriBuilder(longurl);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            if (checkInBuscador != null) { query["checkIn"] = checkInBuscador.ToString(); }
            if (checkOutBuscador != null) { query["checkOut"] = checkOutBuscador.ToString(); }
            if (correoClienteBuscador != null) { query["email"] = correoClienteBuscador; }
            uriBuilder.Query = query.ToString();
            longurl = uriBuilder.ToString();
            List<ReservasModel> reservas = new List<ReservasModel>();
            h.DefaultRequestHeaders.Add("Cookie", Settings1.Default.JWTTokenCookie);
            var response = await _httpClient.GetAsync(longurl);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                dynamic result = JObject.Parse(responseBody);
                JArray reservasArray = result.data;
                reservas = JsonConvert.DeserializeObject<List<ReservasModel>>(reservasArray.ToString());
                return reservas;
            }
            else if(response.StatusCode == HttpStatusCode.NotFound)
            {
                MessageBox.Show("No existen reservas con esos parametros ", "404", MessageBoxButton.OK, MessageBoxImage.Information);
                return reservas;
            }
            return reservas;
        }
        public async Task<bool> DeleteReservationApi(string? id)
        { 
            _httpClient.DefaultRequestHeaders.Add("Cookie", Settings1.Default.JWTTokenCookie);
            var response = await _httpClient.DeleteAsync($"/api/admin/reservation/delete/{id}");
            if (response.StatusCode==HttpStatusCode.OK)
            {

                MessageBox.Show("La reserva se ha eliminado correctamente", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Error al eliminar la reserva", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        public async Task<bool> GuardarReservaApi(ReservasModel nuevaReserva)
        {
            var data = new {nuevaReserva};
            _httpClient.DefaultRequestHeaders.Add("Cookie", Settings1.Default.JWTTokenCookie);
            var response = await _httpClient.PostAsJsonAsync("$/api/admin/reservation/create/{id}", data);
            MessageBox.Show(response.ToString());
            if (response.StatusCode==HttpStatusCode.OK)
            {

                MessageBox.Show("La reserva se ha creado correctamente", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Error al crear la reserva", "Error",  MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

        }
        public async Task<bool> EditarReservaApi(ReservasModel reserva )
        {
            string[] checkInArray = reserva.CheckIn.Split("T");
            string checkIn = checkInArray[0];
            string[] checkOutArray = reserva.CheckOut.Split("T");
            string checkOut = checkOutArray[0];

            var data = new
            {
                checkIn,
                checkOut
            };
            _httpClient.DefaultRequestHeaders.Add("Cookie", Settings1.Default.JWTTokenCookie);
            var response = await _httpClient.PutAsJsonAsync($"api/admin/reservation/update/{reserva._Id}", data);

            MessageBox.Show(response.ToString());
            if (response.StatusCode== HttpStatusCode.OK)
            {

                MessageBox.Show("La reserva se ha acctualizado correctamente", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Error al actualizar la reserva", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

        }

       
    }
}
