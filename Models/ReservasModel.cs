using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppIntermodular.Models
{
    public class ReservasModel : INotifyPropertyChanged
    {
        private string _idCustomer;
        private string _nameCustomer;
        private int _roomNumber;
        private double _PricePerNight;
        //private Date _PricePerDay;
        private string _description;



        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
