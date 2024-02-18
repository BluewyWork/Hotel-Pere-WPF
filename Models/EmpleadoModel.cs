
using System.ComponentModel;


namespace WpfAppIntermodular.Models
{
    public class EmpleadoModel: INotifyPropertyChanged
    {
        private string? _name;
        private string? _surname;
        private bool? _admin;
        private string? _password;
        private string? _image;
        private string? _email;

        public string? Surname
        {
            get { return _surname; }
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    OnPropertyChanged(nameof(Surname));
                }
            }
        }

        public string? Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public string? Image
        {
            get { return _image; }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanged(nameof(Image));
                }
            }
        }

        public bool? Admin
        {
            get { return _admin; }
            set
            {
                if (_admin != value)
                {
                    _admin = value;
                    OnPropertyChanged(nameof(Admin));
                }
            }
        }

        public string? Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public string? Email
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

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
