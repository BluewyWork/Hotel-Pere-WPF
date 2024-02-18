
using System.ComponentModel;

namespace WpfAppIntermodular.Models
{
    public class HabitacionModel : INotifyPropertyChanged
    {
        private string _id;
        private int? _number;
        private string? _description;
        private double? _pricePerNight;
        private string? _image;
        private int? _beds;
        private ReservedDays[] _reservedDays;

        public HabitacionModel() { }

        public string? Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public int? Beds
        {
            get { return _beds; }
            set
            {
                if (_beds != value)
                {
                    _beds = value;
                    OnPropertyChanged(nameof(Beds));
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

        public int? Number
        {
            get { return _number; }
            set
            {
                if (_number != value)
                {
                    _number = value;
                    OnPropertyChanged(nameof(Number));
                }
            }
        }

        public double? PricePerNight
        {
            get { return _pricePerNight; }
            set
            {
                if (_pricePerNight != value)
                {
                    _pricePerNight = value;
                    OnPropertyChanged(nameof(PricePerNight));
                }
            }
        }

        public string? Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        

        public ReservedDays[]? ReservedDays
        {
            get { return _reservedDays; }
            set
            {
                if (_reservedDays != value)
                {
                    _reservedDays = value;
                    OnPropertyChanged(nameof(ReservedDays));
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



