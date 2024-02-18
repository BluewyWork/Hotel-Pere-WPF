
using System.Windows;

using WpfAppIntermodular.ViewModels;

namespace WpfAppIntermodular
{
    /// <summary>
    /// Lógica de interacción para HomeHabitacion.xaml
    /// </summary>
    public partial class HomeHabitacion : Window
    {
        public HomeHabitacion()
        {
            InitializeComponent();
            DataContext= new HomeHabitacionVM();
        }

       

        private void Usuarios_Click(object sender, RoutedEventArgs e)
        {
            HomeUsuarios homeUsuarios = new HomeUsuarios();
            homeUsuarios.Show();
            this.Close();
        }

        private void Reserva_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void CrearEmpleado_Click(object sender, RoutedEventArgs e)
        {
            RegistroEmpleado registro = new RegistroEmpleado();
            registro.ShowDialog();
        }
        private void CrearUsuario_Click(object sender, RoutedEventArgs e)
        {
            RegistroUsuario registro = new RegistroUsuario();
            registro.ShowDialog();
        }
        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            PerfilUsuario perfil = new PerfilUsuario();
            perfil.ShowDialog();
        }
        private void Cerrar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Clientes_Click(object sender, RoutedEventArgs e)
        {
    

        }
    }
}
