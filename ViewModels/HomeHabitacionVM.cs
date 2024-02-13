using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

using wpfappintermodular.api;
using WpfAppIntermodular.Models;


namespace WpfAppIntermodular.ViewModels
{
    public class HomeHabitacionVM : INotifyPropertyChanged
    {
        private ObservableCollection<ReservasModel> _reservas;
        private ApiService apiService;

        public ObservableCollection<ReservasModel> Reservas
        {
            get { return _reservas; }
            set
            {
                _reservas = value;
                OnPropertyChanged(nameof(Reservas));
            }
        }
        public HomeHabitacionVM()
        {
            MostrarReservas();

        }

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

        /*private ICommand buscarCommand;

public ICommand BuscarCommand
{
   get
   {
       if (buscarCommand == null)
       {
           buscarCommand = new RelayCommand(BuscarHabitacion);
       }
       return buscarCommand;
   }
}*/


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
