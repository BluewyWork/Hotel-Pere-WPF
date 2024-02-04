using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

using System.Windows.Input;
using wpfappintermodular.api;
using WpfAppIntermodular.Models;


namespace WpfAppIntermodular.ViewModels
{
    class HomeVM : INotifyPropertyChanged
    {
        private ObservableCollection<HabitacionModel> _habitacionesHome;
        private ApiService apiService;

        public ObservableCollection<HabitacionModel> HabitacionesHome
        {
            get { return _habitacionesHome; }
            set
            {
                _habitacionesHome = value;
                OnPropertyChanged(nameof(HabitacionesHome));
            }
        }
        public HomeVM()
        {
            MostrarHabitaciones();
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



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
