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
using WpfAppIntermodular.Models;
using WpfAppIntermodular.ViewModels;

namespace WpfAppIntermodular
{
    /// <summary>
    /// Lógica de interacción para PerfilUsuario.xaml
    /// </summary>
    public partial class PerfilUsuario : Window
    {
        public PerfilUsuario()
        {
            InitializeComponent();
        }

        public PerfilUsuario(UsuarioModel u)
        {
            PerfilUsuarioVM r = new PerfilUsuarioVM(this);
            DataContext = r;
            InitializeComponent();
            VName.Text = u.Name;
            VSurname.Text = u.Surname;
            VEmail.Text = u.Email;
        }

       
        private void Atras_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
