using System;
using System.ComponentModel;
using System.Windows.Input;
using wpfappintermodular.api;
using WpfAppIntermodular.rsc;

namespace WpfAppIntermodular.ViewModels
{
    public class InsertarHabitacionVM : INotifyPropertyChanged
    {
        private ApiService apiService;
        private int? _numero;
        private string? _imagen;
        private double? _precioNoche;
        private string? _descripcion;
        private bool? _reservada;
        private bool _noReservada;

        private int _selectedNumberOfBeds;
        private int _selectedRoomNumber;

        public int[] BedOptions { get; } = { 1, 2, 3, 4 };
        public int[] RoomNumberOptions { get; } = { 101, 102, 103, 104 };

        public int SelectedNumberOfBeds
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

        public int SelectedRoomNumber
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

        public string? Imagen
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
        }
        

        public bool NoReservada
        {
            get { return _noReservada; }
            set
            {
                if (_noReservada != value)
                {
                    _noReservada = value;
                    OnPropertyChanged(nameof(NoReservada));
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

        private ICommand insertRoomCommand;

        public ICommand InsertRoomCommand
        {
            get
            {
                if (insertRoomCommand == null)
                {
                    insertRoomCommand = new RelayCommand(InsertRoom);
                }
                return insertRoomCommand;
            }
        }

        public InsertarHabitacionVM()
        {
            SelectedRoomNumber = 101; 
            BedOptions = new int[] { 1, 2, 3 };
            NoReservada = true;
            SelectedNumberOfBeds = 1;
            RoomNumberOptions = new int[] { 101, 102, 103, 104 };
            PrecioNoche = 0;
        }

        private async void InsertRoom()
        {
            apiService = new ApiService();

            await apiService.InsertRoomApi(
                Reservada ?? false,
                Descripcion,
                SelectedRoomNumber,
                Math.Round(PrecioNoche ?? 0, 2),
                SelectedNumberOfBeds,
                "urlImagen"
            );
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
