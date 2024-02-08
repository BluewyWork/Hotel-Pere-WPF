
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using wpfappintermodular.api;
using WpfAppIntermodular.Models;
using WpfAppIntermodular.rsc;

namespace WpfAppIntermodular.ViewModels
{
    class HomeVM : INotifyPropertyChanged
    {
        private ObservableCollection<HabitacionModel> _habitacionesHome;
        private ApiService apiService;
        private bool? _reservadaBuscador = false;
        private int? _camasBuscador;
        private int[] _camasDisponibles= {1,2,3};
        private double? _precioNocheBuscador;
 
        private HabitacionModel _habitacionSeleccionada;
        private Home ventana;
        public ICommand EditarHabitacionCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand CreateRoomCommand { get; }
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
        public bool? ReservadaBuscador
        {
            get { return _reservadaBuscador; }
            set
            {
                if (_reservadaBuscador != value)
                {
                    _reservadaBuscador = value;
                    OnPropertyChanged(nameof(ReservadaBuscador));
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
        private async void CreateRoom()
        {
            EditarHabitacion editarHabitacion = new EditarHabitacion();
            ventana.Close();
            editarHabitacion.Show();
        }
        private void Limpiar()
        {
            CamasBuscador = null;
            PrecioNocheBuscador = null;
            ReservadaBuscador= false;          
        }

        private async void Buscar()
        {
            try
            {
                List<HabitacionModel> habitaciones = await apiService.BuscarHabitaciones(ReservadaBuscador,PrecioNocheBuscador,CamasBuscador);
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
