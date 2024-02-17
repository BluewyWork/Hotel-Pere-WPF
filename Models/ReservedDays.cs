
using System;
using System.ComponentModel;

namespace WpfAppIntermodular.Models
{
    public class ReservedDays: INotifyPropertyChanged
    {
        private string _id;
        private string _checkIn;
        private string _checkOut;
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
