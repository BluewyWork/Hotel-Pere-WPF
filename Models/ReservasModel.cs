
using System;
using System.ComponentModel;



namespace WpfAppIntermodular.Models
{
    public class ReservasModel : INotifyPropertyChanged
    {

        private string? __id;
        private string? _guestName;
        private string? _guestSurname;
        private string? _guestEmail;
        private int? _roomNumber;
        private double? _pricePerNight;
        private string? _checkIn;
        private string? _checkOut;

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
        public string? GuestName
        {
            get { return _guestName; }
            set
            {
                if (_guestName != value)
                {
                    _guestName = value;
                    OnPropertyChanged(nameof(GuestName));
                }
            }
        }

        public string? GuestEmail
        {
            get { return _guestEmail; }
            set
            {
                if (_guestEmail != value)
                {
                    _guestEmail = value;
                    OnPropertyChanged(nameof(GuestEmail));
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

        public string? GuestSurname
        {
            get { return _guestSurname; }
            set
            {
                if (_guestSurname != value)
                {
                    _guestSurname = value;
                    OnPropertyChanged(nameof(GuestSurname));
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


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
