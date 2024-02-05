using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfAppIntermodular.Models;
using WpfAppIntermodular.ViewModels;

namespace WpfAppIntermodular
{
    /// <summary>
    /// Lógica de interacción para EditarHabitacion.xaml
    /// </summary>
    public partial class EditarHabitacion : Window
    {
        private HabitacionModel habitacionSeleccionada;

        public EditarHabitacion(HabitacionModel habitacionSeleccionada)
        {
            InitializeComponent();
            DataContext = new InsertarHabitacionVM(habitacionSeleccionada,this);
        }

        private void Atras_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
