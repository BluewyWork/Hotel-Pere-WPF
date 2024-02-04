
using System.Windows;
using WpfAppIntermodular.ViewModels;

namespace WpfAppIntermodular
{
    /// <summary>
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
            DataContext= new HomeVM();
        }

        private void Usuarios_Click(object sender, RoutedEventArgs e)
        {
            HomeUsuarios homeUsuarios = new HomeUsuarios();
            homeUsuarios.Show();
            this.Close();
        }

        private void Habitaciones_Click(object sender, RoutedEventArgs e)
        {
            HomeHabitacion homeHabitacion = new HomeHabitacion();
            homeHabitacion.Show();
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

        private void Reservar(object sender, RoutedEventArgs e)
        {

        }
    }
}
