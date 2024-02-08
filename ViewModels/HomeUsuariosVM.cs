using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppIntermodular.Models;

namespace WpfAppIntermodular.ViewModels
{
    class HomeUsuariosVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<UsuarioModel> _customers;
        private string _searchName;
        private string _searchSurname;
        private string _searchEmail;

        public HomeUsuariosVM(HomeUsuarios x)
        {

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
    }
}
