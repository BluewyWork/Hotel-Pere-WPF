using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

using wpfappintermodular.api;
using WpfAppIntermodular.Models;
using WpfAppIntermodular.rsc;

namespace WpfAppIntermodular.ViewModels
{
    public class HomeHabitacionVM : INotifyPropertyChanged
    {
        private ObservableCollection<HabitacionModel> _habitaciones;
        private ApiService apiService;

        public ObservableCollection<HabitacionModel> Habitaciones
        {
            get { return _habitaciones; }
            set
            {
                _habitaciones = value;
                OnPropertyChanged(nameof(Habitaciones));
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
        public HomeHabitacionVM()
        {
            
        }

        /*private async void BuscarHabitacion()
        {
            try
            {
                apiService = new ApiService();
                List<HabitacionModel> habitaciones = await apiService.BuscarHabitacionesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar habitaciones: {ex.Message}");

            }

        }*/

       

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
