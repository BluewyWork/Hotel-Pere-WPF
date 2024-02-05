using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using wpfappintermodular.api;
using WpfAppIntermodular.Models;
using WpfAppIntermodular.rsc;

namespace WpfAppIntermodular.ViewModels
{
    public class LoginVM : INotifyPropertyChanged
    {
        private UsuarioModel _usuario;
        private ApiService apiService;
        private MainWindow mw;
        private string _email;
        private string _password;

        public LoginVM(MainWindow mainWindow)
        {
            mw = mainWindow;
        }

        public UsuarioModel Usuario
        {
            get { return _usuario; }
            set
            {
                if (_usuario != value)
                {
                    _usuario = value;
                    OnPropertyChanged(nameof(Usuario));
                }
            }
        }
       


        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        private ICommand camposLoginCommand;

        public ICommand CamposLoginCommand
        {
            get
            {
                if (camposLoginCommand == null)
                {
                    camposLoginCommand = new RelayCommand(CamposLogin);
                }
                return camposLoginCommand;
            }
        }
        private void CamposLogin()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Debe rellenar todos los campos","Error");
            }
            else
            {
                Login();
            }
        }
        private async void Login()
        {
            apiService = new ApiService();
            if( await apiService.AutenticarUsuarioAsync(Email, Password))
            {
                Home home = new Home();
                home.Show();
                mw.Close();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
