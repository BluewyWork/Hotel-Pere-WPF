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
        private ApiService apiService;
        private PerfilUsuario view;
        public event PropertyChangedEventHandler PropertyChanged;

        public PerfilUsuarioVM(PerfilUsuario view)
        {
            this.view = view;
            apiService = new ApiService(); 
            GuardarCommand = new RelayCommand(Guardar);
        }

        public ICommand GuardarCommand { get; }
        public ICommand AtrasCommand { get; }

         
        private async void Guardar()
        {
            
             await apiService.UpdateEmployee(view.VName.Text, view.VSurname.Text, view.VEmail.Text);
        }

   
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}