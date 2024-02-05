using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

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
        private HabitacionModel _habitacionSeleccionada;
        private Home ventana;
        public ICommand EditarHabitacionCommand { get; }

        public HomeVM(Home ventana)
        {
            MostrarHabitaciones();
            EditarHabitacionCommand = new RelayCommand(EditarHabitacion, () => HabitacionSeleccionada != null);
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

        private void EditarHabitacion()
        {
          
            EditarHabitacion editarHabitacion= new EditarHabitacion(HabitacionSeleccionada);
            ventana.Close();
            editarHabitacion.Show();
        }

        private async void BuscarHabitacion()
        {

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
