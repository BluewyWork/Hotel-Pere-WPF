using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using wpfappintermodular.api;
using WpfAppIntermodular.Models;
using WpfAppIntermodular.rsc;

namespace WpfAppIntermodular.ViewModels
{
    class HomeUsuariosVM : INotifyPropertyChanged
    {
        private ApiService apiService = new ApiService();
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<UsuarioModel> _customers;
        private string _searchName;
        private string _searchSurname;
        private string _searchEmail;
        private UsuarioModel _selectedUser;
        private HomeUsuarios view;

        public ICommand EditUserCommand { get; }
        public ICommand DeleteUserCommand { get; }

        private void EditUser()
        {
            UsuarioModel x = (UsuarioModel)view.ListBoxCustomers.SelectedItem;

            if (x == null)
            {
                System.Windows.MessageBox.Show("NULL");
            }

            System.Windows.MessageBox.Show($"{x.Name}  {x.Email}");

            PerfilUsuario p = new PerfilUsuario(x);
            p.Show();
        }

        private async void DeleteUser()
        {
            if (SelecteUser == null )
            {
                return;
            }

            if (SelecteUser.Email == null)
            {
                return;
            }

            await apiService.EliminarUsuario(SelecteUser.Email);
        }

        public HomeUsuariosVM(HomeUsuarios x)
        {
            showUsers();
            EditUserCommand = new RelayCommand(EditUser);
            DeleteUserCommand = new RelayCommand(DeleteUser, () => SelecteUser != null);
            view = x;
        }

        private async void showUsers()
        {
            List<UsuarioModel> c = await apiService.GetAllUsersApi();
            CustomersList = new ObservableCollection<UsuarioModel>(c);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<UsuarioModel> CustomersList
        {
            get { return _customers; }
            set
            {
                if (_customers != value)
                {
                    _customers = value;
                    OnPropertyChanged(nameof(CustomersList));
                }
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

        public UsuarioModel SelecteUser
        {
            get { return _selectedUser; }
            set
            {
                if (_selectedUser != value)
                {
                    _selectedUser = value;
                    OnPropertyChanged(nameof(SelecteUser));
                }
            }
        }
    }
}
