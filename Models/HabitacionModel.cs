using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppIntermodular.Models
{
    public class HabitacionModel : INotifyPropertyChanged
    {
        public int? _numero;
        public string? _descripcion;
        public double? _precioNoche;
        public bool? _reservada;
        public string? _imagen;
        public int? _camas;

        public HabitacionModel() { }

        public int? Camas
        {
            get { return _camas; }
            set
            {
                if (_camas != value)
                {
                    _camas = value;
                    OnPropertyChanged(nameof(Numero));
                }
            }
        }
        public int? Numero
        {
            get { return _numero; }
            set
            {
                if (_numero != value)
                {
                    _numero = value;
                    OnPropertyChanged(nameof(Numero));
                }
            }
        }

        public double? PrecioNoche
        {
            get { return _precioNoche; }
            set
            {
                if (_precioNoche != value)
                {
                    _precioNoche = value;
                    OnPropertyChanged(nameof(PrecioNoche));
                }
            }
        }

        public string? Descripcion
        {
            get { return _descripcion; }
            set
            {
                if (_descripcion != value)
                {
                    _descripcion = value;
                    OnPropertyChanged(nameof(Descripcion));
                }
            }
        }

        public bool? Reservada
        {
            get { return _reservada; }
            set
            {
                if (!_reservada != value)
                {
                    _reservada = value;
                    OnPropertyChanged(nameof(Reservada));
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

