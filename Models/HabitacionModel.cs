using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfAppIntermodular.Models
{
    public class HabitacionModel : INotifyPropertyChanged
    {
        public int? _number;
        public string? _section;
        public double? _pricePerNight;
        public bool? _reserved;
        //public BitmapImage _image;
        public int? _beds;

        public HabitacionModel() { }

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

        /*public BitmapImage Image
        {
            get { return _image; }
            set
            {
                if (_image != value)
                {
                    _image = value;
                }
            }
        }*/

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
                    OnPropertyChanged(nameof(_pricePerNight));
                }
            }
        }

        public string? Section
        {
            get { return _section; }
            set
            {
                if (_section != value)
                {
                    _section = value;
                    OnPropertyChanged(nameof(Section));
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

