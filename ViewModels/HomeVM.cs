
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Microsoft.OData.Edm;
using wpfappintermodular.api;
using WpfAppIntermodular.Models;
using WpfAppIntermodular.rsc;

namespace WpfAppIntermodular.ViewModels
{
    class HomeVM : INotifyPropertyChanged
    {
        private ObservableCollection<HabitacionModel> _habitacionesHome;
        private ApiService apiService;
        private int? _camasBuscador;
        private int[] _camasDisponibles= {1,2,3};
        private double? _precioNocheBuscador;
        private string? _checkInBuscador;
        private string? _checkOutBuscador;

        private string? _guestname; 
        private string? _guestsurname;
        private string? _guestemail;
        private int? _roomnumber;
        private double? _pricepernight;
        private string? _checkin;
        private string? _checkout;

        public string? GuestName
        {
            get { return _guestname; }
            set
            {
                if (_guestname != value)
                {
                    _guestname = value;
                    OnPropertyChanged(nameof(GuestName));
                }
            }
        }   

        public string? GuestSurname
        {
            get { return _guestsurname; }
            set
            {
                if (_guestsurname != value)
                {
                    _guestsurname = value;
                    OnPropertyChanged(nameof(GuestSurname));
                }
            }
        }

        public string? GuestEmail
        {
            get { return _guestemail; }
            set
            {
                if (_guestemail != value)
                {
                    _guestemail = value;
                    OnPropertyChanged(nameof(GuestEmail));
                }
            }
        }

        public int? RoomNumber
        {
            get { return _roomnumber; }
            set
            {
                if (_roomnumber != value)
                {
                    _roomnumber = value;
                    OnPropertyChanged(nameof(RoomNumber));
                }
            }
        }

        public double? PricePerNight
        {
            get { return _pricepernight; }
            set
            {
                if (_pricepernight != value)
                {
                    _pricepernight = value;
                    OnPropertyChanged(nameof(PricePerNight));
                }
            }
        }

        public string? CheckIn
        {
            get { return _checkin; }
            set
            {
                if (_checkin != value)
                {
                    _checkin = value;
                    OnPropertyChanged(nameof(CheckIn));
                }
            }
        }

        public string? CheckOut
        {
            get { return _checkout; }
            set
            {
                if (_checkout != value)
                {
                    _checkout = value;
                    OnPropertyChanged(nameof(CheckOut));
                }
            }
        }

           


        private HabitacionModel _habitacionSeleccionada;
        private Home ventana;
        public ICommand EditarHabitacionCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand CreateRoomCommand { get; }

        public ICommand CreateBookingCommand { get; }
        public ICommand BuscarCommand { get; }
        public ICommand LimpiarCommand { get; }

        public HomeVM(Home ventana)
        {
            MostrarHabitaciones();
            EditarHabitacionCommand = new RelayCommand(EditarHabitacion, () => HabitacionSeleccionada != null);
            DeleteCommand = new RelayCommand(DeleteRoom, () => HabitacionSeleccionada != null);
            BuscarCommand = new RelayCommand(Buscar);
            LimpiarCommand = new RelayCommand(Limpiar);
            CreateRoomCommand = new RelayCommand(CreateRoom);
            CreateBookingCommand = new RelayCommand(CreateBooking);
            this.ventana = ventana;
        }      

        public ObservableCollection<HabitacionModel> HabitacionesHome
        {
            get { return _habitacionesHome; }
            set
            {
                _habitacionesHome = value;
                OnPropertyChanged(nameof(HabitacionesHome));
            }
        }

        public HabitacionModel HabitacionSeleccionada
        {
            get { return _habitacionSeleccionada; }
            set
            {
                if (_habitacionSeleccionada != value)
                {
                    _habitacionSeleccionada = value;
                    OnPropertyChanged(nameof(HabitacionSeleccionada));
                }
            }
        }
        public string? CheckInBuscador
        {
            get { return _checkInBuscador; }
            set
            {
                if (_checkInBuscador != value)
                {
                    _checkInBuscador = value;
                    OnPropertyChanged(nameof(CheckInBuscador));
                }
            }
        }
        public string? CheckOutBuscador
        {
            get { return _checkOutBuscador; }
            set
            {
                if (_checkOutBuscador != value)
                {
                    _checkOutBuscador = value;
                    OnPropertyChanged(nameof(CheckOutBuscador));
                }
            }
        }

        public int? CamasBuscador
        {
            get { return _camasBuscador; }
            set
            {
                if (_camasBuscador != value)
                {
                    _camasBuscador = value;
                    OnPropertyChanged(nameof(CamasBuscador));
                }
            }
        }
        public int[]? CamasDisponibles
        {
            get { return _camasDisponibles; }
            set
            {
                if (_camasDisponibles != value)
                {
                    _camasDisponibles = value;
                    OnPropertyChanged(nameof(CamasDisponibles));
                }
            }
        }
        public double? PrecioNocheBuscador
        {
            get { return _precioNocheBuscador; }
            set
            {
                if (_precioNocheBuscador != value)
                {
                    _precioNocheBuscador = value;
                    OnPropertyChanged(nameof(PrecioNocheBuscador));
                }
            }
        }
        private void EditarHabitacion()
        {      
            EditarHabitacion editarHabitacion= new EditarHabitacion(HabitacionSeleccionada);
            ventana.Close();
            editarHabitacion.Show();
        }

        private async void DeleteRoom()
        {
            if (HabitacionSeleccionada != null)
            {
                int number = (int)HabitacionSeleccionada.Number;
                apiService = new ApiService();
                bool borrada = await apiService.DeleteRoomApi(number);
                if (borrada)
                {
                    HabitacionesHome.Remove(HabitacionSeleccionada);
                    MessageBox.Show("La habitacion se ha eliminado correctamente", "Ok");
                }
                else
                {
                    MessageBox.Show("No se ha podido eleminar", "Error");
                }
            }
        }
        private async void MostrarHabitaciones()
        {
            try
            {
                apiService = new ApiService();
                List<HabitacionModel> habitaciones = await apiService.MostrarHabitacionesApiAsync();
                HabitacionesHome = new ObservableCollection<HabitacionModel>(habitaciones);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar habitaciones: {ex.Message}");
            }
        }
        private void CreateRoom()
        {
            EditarHabitacion editarHabitacion = new EditarHabitacion();
            ventana.Close();
            editarHabitacion.Show();
        }

        public async void CreateBooking()
        {
            ReservasModel reserva = new ReservasModel();
            reserva.GuestName = GuestName;
            reserva.GuestSurname = GuestSurname;
            reserva.GuestEmail = GuestEmail;
            reserva.RoomNumber = RoomNumber;
            reserva.PricePerNight = PricePerNight;
            reserva.CheckIn = CheckIn;
            reserva.CheckOut = CheckOut;
            apiService = new ApiService();
           await apiService.GuardarReservaApi(reserva);
            
        }
        private void Limpiar()
        {
            CamasBuscador = null;
            PrecioNocheBuscador = null;
            CheckInBuscador = null;
            CheckOutBuscador=null;
            MostrarHabitaciones();

        }

        private async void Buscar()
        {
            try
            {
                List<HabitacionModel> habitaciones = await apiService.BuscarHabitaciones(PrecioNocheBuscador,CamasBuscador, CheckInBuscador, CheckOutBuscador);
                HabitacionesHome = new ObservableCollection<HabitacionModel>(habitaciones);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar habitaciones: {ex.Message}");
            }             
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
