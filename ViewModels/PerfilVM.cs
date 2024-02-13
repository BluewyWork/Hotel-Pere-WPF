using System;
using System.ComponentModel;
using System.Windows.Input;
using wpfappintermodular.api;
using WpfAppIntermodular.Models;
using WpfAppIntermodular.rsc;

namespace WpfAppIntermodular.ViewModels
{
    class PerfilUsuarioVM : INotifyPropertyChanged
    {
        private UsuarioModel _user;
        private ApiService apiService;
        public event PropertyChangedEventHandler PropertyChanged;

        public PerfilUsuarioVM(UsuarioModel user, HomeUsuariosVM homeUsuariosVM)
        {
            _user = user;
            GuardarCommand = new RelayCommand(Guardar, () => User != null);
        }

        public ICommand GuardarCommand { get; }
        public ICommand AtrasCommand { get; }

        public UsuarioModel User
        {
            get { return _user; }
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged(nameof(User));
                }
            }
        }
   
        private async void Guardar()
        {
            await apiService.UpdateUser(User.Name, User.Surname, User.Email, "");
        }

   
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}