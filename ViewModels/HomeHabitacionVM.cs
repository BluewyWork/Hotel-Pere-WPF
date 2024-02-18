using DocumentFormat.OpenXml.Spreadsheet;
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
    public class HomeHabitacionVM : INotifyPropertyChanged
    {
        private ObservableCollection<ReservasModel> _reservas;
        private ApiService apiService;
        private ReservasModel _reservaSeleccionada;
        private string _checkInBuscador; 
        private string _checkOutBuscador;
        private string _correoClienteBuscador;

        public ICommand EditarReservaCommand { get; }
        public ICommand EliminarReservaCommand { get; }
        public ICommand BuscarReservaCommand { get; }
        public ICommand LimpiarReservaCommand { get; }

        public ObservableCollection<ReservasModel> Reservas
        {
            get { return _reservas; }
            set
            {
                _reservas = value;
                OnPropertyChanged(nameof(Reservas));
            }
        }
        

        public string CheckInBuscador
        {
            get { return _checkInBuscador; }
            set
            {
                _checkInBuscador = value;
                OnPropertyChanged(nameof(CheckInBuscador));
            }
        }

        public string CheckOutBuscador
        {
            get { return _checkOutBuscador; }
            set
            {
                _checkOutBuscador = value;
                OnPropertyChanged(nameof(CheckOutBuscador));
            }
        }
        public string CorreoClienteBuscador
        {
            get { return _correoClienteBuscador; }
            set
            {
                _correoClienteBuscador = value;
                OnPropertyChanged(nameof(CorreoClienteBuscador));
            }
        }

        public ReservasModel ReservaSeleccionada
        {
            get { return _reservaSeleccionada; }
            set
            {
                _reservaSeleccionada = value;
                OnPropertyChanged(nameof(ReservaSeleccionada));
            }
        }

        public HomeHabitacionVM()
        {
            MostrarReservas();
            EditarReservaCommand = new RelayCommand(EditarReserva, () => ReservaSeleccionada != null);
            EliminarReservaCommand = new RelayCommand(EliminarReserva, () => ReservaSeleccionada != null);
            BuscarReservaCommand = new RelayCommand(BuscarReserva);
            LimpiarReservaCommand = new RelayCommand(LimpiarReserva);
        }

        private async void EditarReserva()
        {
            if (ReservaSeleccionada != null)
            {
                ReservasModel reserva = ReservaSeleccionada;
                apiService = new ApiService();
                bool borrada = await apiService.EditarReservaApi(reserva);
                if (borrada)
                {
                    Reservas.Remove(ReservaSeleccionada);
                    MessageBox.Show("La reserva se ha eliminado correctamente", "Ok");
                    
                }
                else
                {
                    MessageBox.Show("No se ha podido eleminar", "Error");
                }
            }

        }

        /*private void CrearReserva()
        {
            Reservas.Add(NuevaReserva);
            GuardarReserva(NuevaReserva);
            NuevaReserva = new ReservasModel();
            OnPropertyChanged(nameof(NuevaReserva));
        }*/

       /* private async void GuardarReserva(ReservasModel nuevaReserva)
        {
            await apiService.GuardarReservaApi(nuevaReserva);
        }*/

        private async void MostrarReservas()
        {
            try
            {
                apiService = new ApiService();
                List<ReservasModel> reservas = await apiService.MostrarReservasApiAsync();
                Reservas = new ObservableCollection<ReservasModel>(reservas);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar habitaciones: {ex.Message}");
            }
        }
        private async void EliminarReserva()
        {
            if (ReservaSeleccionada != null)
            {
                string id = ReservaSeleccionada._Id;
                apiService = new ApiService();
                bool borrada = await apiService.DeleteReservationApi(id);
                if (borrada)
                {
                    Reservas.Remove(ReservaSeleccionada);
                }
            }
        }

        private void LimpiarReserva()
        {
            CheckInBuscador = null;
            CheckOutBuscador = null;
            CorreoClienteBuscador = null;
          
        }

        private async void BuscarReserva()
        {
            try
            {
                List<ReservasModel> reservas = await apiService.BuscarReservasApi(CheckInBuscador, CheckOutBuscador, CorreoClienteBuscador);
                Reservas = new ObservableCollection<ReservasModel>(reservas);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar reservas: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
