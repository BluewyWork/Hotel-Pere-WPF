using DocumentFormat.OpenXml.Wordprocessing;
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

        public HomeUsuariosVM()
        {
            showEmployee();
            //EditUserCommand = new RelayCommand(EditUser);
            //DeleteUserCommand = new RelayCommand(DeleteUser, () => SelecteUser != null);
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



        /*private void EditUser()
        {
            UsuarioModel x = (UsuarioModel)ListBoxCustomers.SelectedItem;

            if (x == null)
            {
                System.Windows.MessageBox.Show("NULL");
                return;
            }

            System.Windows.MessageBox.Show($"{x.Name}  {x.Email}");

            PerfilUsuario p = new PerfilUsuario(x);
            p.Show();
        }*/

        /*private async void DeleteUser()
        {
            if (SelecteUser == null )
            {
                return;
            }

            if (SelecteUser.Email == null)
            {
                return;
            }

            bool xx = await apiService.EliminarUsuario(SelecteUser.Email);

            if (xx)
            {
                MessageBox.Show("TODO BIE>N");
            } else
            {
                MessageBox.Show("AlGO FALLO");
            }
        }*/

       

        private async void showEmployee()
        {
            try
            {
                List<EmpleadoModel> empleados = await apiService.GetEmployeeApi();
                Empleados = new ObservableCollection<EmpleadoModel>(empleados);
            }
            catch(Exception ex)
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
