using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Media.Imaging;

namespace WpfAppIntermodular.Models
{
    public class HabitacionModel : INotifyPropertyChanged
    {
        private int? _number;
        private string? _section;
        private double? _pricePerNight;
        private bool? _reserved;
        //private BitmapImage? _image;
        //private string? _image64;
        private int? _beds;
        private string? _reservado;

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

        /*public BitmapImage? Image
        {
            get { return _image; }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanged(nameof(Beds));
                }
            }
        }

        public string? Image64
        {
            get { return _image64; }
            set
            {
                if (_image64 != value)
                    OnPropertyChanged(nameof(Beds));
                {
                    _image64 = value;
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

        public string? Reservado
        {
            get { return _reservado; }
            set
            {
                if (_reservado != value)
                {
                    _reservado = value;
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
        /*public void ConvertirImagenDesdeBase64()
        {
            byte[] imageBytes = Convert.FromBase64String(Image64);

            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = ms;
                bitmapImage.EndInit();

                Image = bitmapImage;
            }
        }*/


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}

