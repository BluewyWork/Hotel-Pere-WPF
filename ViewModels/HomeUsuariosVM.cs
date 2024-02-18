using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WpfAppIntermodular.Models;
using wpfappintermodular.api;
using WpfAppIntermodular.rsc;

namespace WpfAppIntermodular.ViewModels
{
    class HomeUsuariosVM : INotifyPropertyChanged
    {
        private ApiService apiService = new ApiService();
        private ObservableCollection<EmpleadoModel> _empleados;
        private string _searchName;
        private string _searchSurname;
        private string _searchEmail;
        private EmpleadoModel _empleadoSelecionado;

        public ICommand EditUserCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand FilterListCommand { get; }

        public HomeUsuariosVM()
        {
            ShowEmployee();
            FilterListCommand = new RelayCommand(FilterEmpleados);
            // EditUserCommand = new RelayCommand(EditUser);
            // DeleteUserCommand = new RelayCommand(DeleteUser, () => SelecteUser != null);
        }

        public ObservableCollection<EmpleadoModel> Empleados
        {
            get { return _empleados; }
            set
            {
                if (_empleados != value)
                {
                    _empleados = value;
                    OnPropertyChanged(nameof(Empleados));
                }
            }
        }

        public void FilterEmpleados()
        {

            IEnumerable<EmpleadoModel> filteredEmpleados = Empleados;

            if (!string.IsNullOrEmpty(SearchName))
                filteredEmpleados = filteredEmpleados.Where(e => e.Name.Contains(SearchName));

            if (!string.IsNullOrEmpty(SearchSurname))
                filteredEmpleados = filteredEmpleados.Where(e => e.Surname.Contains(SearchSurname));

            if (!string.IsNullOrEmpty(SearchEmail))
                filteredEmpleados = filteredEmpleados.Where(e => e.Email.Contains(SearchEmail));

            Empleados = new ObservableCollection<EmpleadoModel>(filteredEmpleados);
        }

        private async void ShowEmployee()
        {
            try
            {
                List<EmpleadoModel> empleados = await apiService.GetEmployeeApi();
                Empleados = new ObservableCollection<EmpleadoModel>(empleados);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mostrar empleados: {ex.Message}");
            }

        }

        public string SearchName
        {
            get { return _searchName; }
            set
            {
                if (_searchName != value)
                {
                    _searchName = value;
                    OnPropertyChanged(nameof(SearchName));
                    FilterEmpleados();
                }
            }
        }

        public string SearchSurname
        {
            get { return _searchSurname; }
            set
            {
                if (_searchSurname != value)
                {
                    _searchSurname = value;
                    OnPropertyChanged(nameof(SearchSurname));
                    FilterEmpleados();
                }
            }
        }

        public string SearchEmail
        {
            get { return _searchEmail; }
            set
            {
                if (_searchEmail != value)
                {
                    _searchEmail = value;
                    OnPropertyChanged(nameof(SearchEmail));
                    FilterEmpleados();
                }
            }
        }

        public EmpleadoModel EmpleadoSelecionado
        {
            get { return _empleadoSelecionado; }
            set
            {
                if (_empleadoSelecionado != value)
                {
                    _empleadoSelecionado = value;
                    OnPropertyChanged(nameof(EmpleadoSelecionado));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
