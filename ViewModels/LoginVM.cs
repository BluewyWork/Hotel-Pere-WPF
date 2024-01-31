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


        private ICommand canLoginCommand;

       

        public LoginVM()
        {
            
        }

        private async void Login()
        {

                apiService = new ApiService();
            MessageBox.Show(Usuario.Email.ToString());    
            
                await apiService.AutenticarUsuarioAsync(Usuario.Email, Usuario.Password);
                Console.WriteLine($"Iniciando sesión con: {Usuario.Email} - {Usuario?.Password}");
            
                
            
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
