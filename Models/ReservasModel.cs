
using System;
using System.ComponentModel;



namespace WpfAppIntermodular.Models
{
    public class ReservasModel : INotifyPropertyChanged
    {

        private string? __id;
        private string? _customerName;
        private string? _customerEmail;
        private int? _roomNumber;
        private double? _pricePerNight;
        private DateTime? _checkIn;
        private DateTime? _checkOut;
        private bool? _reserved;

        public string? _Id
        {
            get { return __id; }
            set
            {
                if (__id != value)
                {
                    __id = value;
                    OnPropertyChanged(nameof(_Id));
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

        public DateTime? CheckIn
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
        public DateTime? CheckOut
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
