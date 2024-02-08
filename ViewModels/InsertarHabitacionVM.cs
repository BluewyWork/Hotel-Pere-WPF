using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using wpfappintermodular.api;
using WpfAppIntermodular.Models;
using WpfAppIntermodular.rsc;


namespace WpfAppIntermodular.ViewModels
{
    public class InsertarHabitacionVM : INotifyPropertyChanged
    {
        private ApiService apiService;
        private int? _numero;
        //private string? _imagen;
        private double? _precioNoche;
        private string? _descripcion;
        private bool? _reservada;
        private bool? _isEnable;
        //private string[]? _roomImages = { "Sencilla", "Doble", "Suite" };
        private int? _selectedNumberOfBeds;
        private int? _selectedRoomNumber;
        private EditarHabitacion ventana;
        public ICommand UpdateRoomCommand { get; }
        public ICommand CreateRoomCommand { get; }
        public ICommand SaveCommand { get; }
       

        public int[] BedOptions { get; }
        public List<int> RoomNumberOptions { get; } 

        public int? SelectedNumberOfBeds
        {
            get { return _selectedNumberOfBeds; }
            set
            {
                if (_selectedNumberOfBeds != value)
                {
                    _selectedNumberOfBeds = value;
                    OnPropertyChanged(nameof(SelectedNumberOfBeds));
                }
            }
        }
        /*public string[]? RoomImages
        {
            get { return _roomImages; }
            set
            {
                if (_roomImages != value)
                {
                    _roomImages = value;
                    OnPropertyChanged(nameof(RoomImages));
                }
            }
        } */      

        public int? SelectedRoomNumber
        {
            get { return _selectedRoomNumber; }
            set
            {
                if (_selectedRoomNumber != value)
                {
                    _selectedRoomNumber = value;
                    OnPropertyChanged(nameof(SelectedRoomNumber));
                }
            }
        }

        public int? Numero
        {
            get { return _numero; }
            set
            {
                if (_numero != value)
                {
                    _numero = value;
                    OnPropertyChanged(nameof(Numero));
                }
            }
        }

        public double? PrecioNoche
        {
            get { return _precioNoche; }
            set
            {
                if (_precioNoche != value)
                {
                    _precioNoche = value;
                    OnPropertyChanged(nameof(PrecioNoche));
                }
            }
        }

        public string? Descripcion
        {
            get { return _descripcion; }
            set
            {
                if (_descripcion != value)
                {
                    _descripcion = value;
                    OnPropertyChanged(nameof(Descripcion));
                }
            }
        }

       /* public string? Imagen
        {
            get { return _imagen; }
            set
            {
                if (_imagen != value)
                {
                    _imagen = value;
                    OnPropertyChanged(nameof(Imagen));
                }
            }
        }*/
        
        public bool? IsEnable
        {
            get { return _isEnable; }
            set
            {
                if (_isEnable != value)
                {
                    _isEnable = value;
                    OnPropertyChanged(nameof(IsEnable));
                }
            }
        }

        public bool? Reservada
        {
            get { return _reservada; }
            set
            {
                if (_reservada != value)
                {
                    _reservada = value;
                    OnPropertyChanged(nameof(Reservada));
                }
            }
        }
        public InsertarHabitacionVM(EditarHabitacion ventana)
        {
            this.ventana = ventana;
            SaveCommand = new RelayCommand(CreateRoom);
            List<int> listaNumeros = new List<int>();
            for (int i = 1; i < 20; i++)
            {
                listaNumeros.Add(i);
            }           
                SelectedRoomNumber = 1;
                BedOptions = new int[] { 1, 2, 3 };
                Reservada = false;
                SelectedNumberOfBeds = 1;
                RoomNumberOptions = listaNumeros;
                PrecioNoche = 0;
                Descripcion = string.Empty;
                IsEnable = true;
        }


        public InsertarHabitacionVM(HabitacionModel habitacionSeleccionada, EditarHabitacion ventana)        
        {
            this.ventana = ventana;
            SaveCommand = new RelayCommand(UpdateRoom);
            List<int> listaNumeros= new List<int>();
            for (int i=1; i<20; i++)
            {
                listaNumeros.Add(i);
            }
        
            if(habitacionSeleccionada!=null)
            {
                SelectedRoomNumber = habitacionSeleccionada.Number;
                BedOptions = new int[] { 1, 2, 3 };
                Reservada = habitacionSeleccionada.Reserved;
                SelectedNumberOfBeds = habitacionSeleccionada.Beds;
                RoomNumberOptions = listaNumeros;
                PrecioNoche = habitacionSeleccionada.PricePerNight;
                Descripcion = habitacionSeleccionada.Section;
                IsEnable = false;
            }           
        }

        

        private async void UpdateRoom()
        {
            apiService = new ApiService();

            bool actualizada = false;
            if (Reservada.HasValue && SelectedRoomNumber.HasValue && PrecioNoche.HasValue && SelectedNumberOfBeds.HasValue)
            {
                actualizada = await apiService.UpdateRoomApi(Reservada.Value, Descripcion, SelectedRoomNumber.Value,
                    Math.Round(PrecioNoche.Value, 2), SelectedNumberOfBeds.Value, "urlImagen");
                if (actualizada)
                {
                    Home home = new Home();
                    home.Show();
                    ventana.Close();
                }
            }
        }
        private async void CreateRoom()
        {
            apiService = new ApiService();
            bool actualizada = await apiService.CreateRoomApi(Descripcion, (int)SelectedRoomNumber, Math.Round(PrecioNoche ?? 0, 2),
                SelectedNumberOfBeds ?? 1, "url", (bool)Reservada);
            if (actualizada)
            {
                Home home = new Home();
                home.Show();
                ventana.Close();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

