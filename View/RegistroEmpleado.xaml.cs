using System;
using System.Collections.Generic;
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
using WpfAppIntermodular.ViewModels;

namespace WpfAppIntermodular
{
    /// <summary>
    /// Lógica de interacción para RegistroEmpleado.xaml
    /// </summary>
    public partial class RegistroEmpleado : Window
    {
        public RegistroEmpleado()
        {
            InitializeComponent();
            DataContext = new RegistroEmpleadoVM();
        }

        private void Atras_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
