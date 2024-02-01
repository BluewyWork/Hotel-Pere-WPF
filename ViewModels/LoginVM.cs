using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WpfAppIntermodular.api;
using WpfAppIntermodular.Models;
using WpfAppIntermodular.rsc;

namespace WpfAppIntermodular.ViewModels
{
    public class LoginVM : INotifyPropertyChanged
    {
        private UsuarioModel _usuario;
        private ApiService apiService;

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
        private string _email;


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
        private string _password;

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
        private ICommand loginCommand;

        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new RelayCommand(Login);
                }
                return loginCommand;
            }
        }

        private MainWindow xd;

        public LoginVM(MainWindow mainWindow)
        {
            xd = mainWindow;
        }

        private async void Login()
        {
            apiService = new ApiService();
            string token =await apiService.AutenticarUsuarioAsync(Email, Password);
            Console.WriteLine($"Iniciando sesión con: {Email} - {Password}");
            Settings1.Default.AccessToken = "rstenaoen";
            Settings1.Default.RefreshToken = "artnirtn";
            if(token!= null)
            {
               Home home= new Home();
               home.Show();
                xd.Close();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
