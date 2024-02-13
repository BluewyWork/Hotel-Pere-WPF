
using System.ComponentModel;

namespace WpfAppIntermodular.Models
{
    public class ReservasModel : INotifyPropertyChanged
    {

        private string? _id;
        private string? _customerName;
        private string? _customerEmail;
        private int? _roomNumber;
        private double? _pricePerNight;
        private string? _checkIn;
        private string? _checkOut;
        private bool? _reserved;
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
        public string? CustomerName
        {
            get { return _customerName; }
            set
            {
                if (_customerName != value)
                {
                    _customerName = value;
                    OnPropertyChanged(nameof(CustomerName));
                }
            }
        }

        public string? CustomerEmail
        {
            get { return _customerEmail; }
            set
            {
                if (_customerEmail != value)
                {
                    _customerEmail = value;
                    OnPropertyChanged(nameof(CustomerEmail));
                }
            }
        }

        public int? RoomNumber
        {
            get { return _roomNumber; }
            set
            {
                if (_roomNumber != value)
                {
                    _roomNumber = value;
                    OnPropertyChanged(nameof(RoomNumber));
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

        public string? CheckIn
        {
            get { return _checkIn; }
            set
            {
                if (_checkIn != value)
                {
                    _checkIn = value;
                    OnPropertyChanged(nameof(CheckIn));
                }
            }
        }
        public string? CheckOut
        {
            get { return _checkOut; }
            set
            {
                if (_checkOut != value)
                {
                    _checkOut = value;
                    OnPropertyChanged(nameof(CheckOut));
                }
            }
        }

        public bool? Reserved
        {
            get { return _reserved; }
            set
            {
                if (_reserved != value)
                {
                    _reserved = value;
                    OnPropertyChanged(nameof(Reserved));
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
