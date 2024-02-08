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
    /// Lógica de interacción para HomeUsuarios.xaml
    /// </summary>
    public partial class HomeUsuarios : Window
    {
        

        HomeUsuariosVM homeUsuariosVM;
        public HomeUsuarios()
        {
            InitializeComponent();
            

            homeUsuariosVM = new HomeUsuariosVM(this);
            DataContext = homeUsuariosVM;

            ListBoxCustomers.ItemsSource = GenerateUsers(10);
        }

        public List<UsuarioModel> GenerateUsers(int count)
        {
            List<UsuarioModel> users = new List<UsuarioModel>();
            for (int i = 0; i < count; i++)
            {
                UsuarioModel user = new UsuarioModel
                {
                    Email = $"user{i}@example.com",
                    Password = $"password{i}",
                    Name = $"User{i}",
                    Admin = i % 2 == 0 ? true : false
                };
                users.Add(user);
            }
            return users;
        }

        private void Habitaciones_Click(object sender, RoutedEventArgs e)
        {
            HomeHabitacion homeHabitacion = new HomeHabitacion();
            homeHabitacion.Show();
            this.Close();
        }

        private void Reserva_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void EditarUsuario_Click(object sender, RoutedEventArgs e)
        {
            RegistroUsuario registroUsuario = new RegistroUsuario();
            registroUsuario.ShowDialog();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (
                !string.IsNullOrEmpty(NameTextBox.Text) ||
                !string.IsNullOrEmpty(SurnameTextBox.Text) ||
                !string.IsNullOrEmpty(EmailTextBox.Text)
                )
            {
                // At least one field is not empty
                if (!string.IsNullOrEmpty(NameTextBox.Text) &&
                    !string.IsNullOrEmpty(SurnameTextBox.Text) &&
                    !string.IsNullOrEmpty(EmailTextBox.Text))
                {
                    // All three fields are not empty, do something
                }
                else if (!string.IsNullOrEmpty(NameTextBox.Text) &&
                         !string.IsNullOrEmpty(SurnameTextBox.Text))
                {
                    // Name and Surname are filled, do something
                }
                else if (!string.IsNullOrEmpty(NameTextBox.Text) &&
                         !string.IsNullOrEmpty(EmailTextBox.Text))
                {
                    // Name and Email are filled, do something
                }
                else if (!string.IsNullOrEmpty(SurnameTextBox.Text) &&
                         !string.IsNullOrEmpty(EmailTextBox.Text))
                {
                    // Surname and Email are filled, do something
                }
                else if (!string.IsNullOrEmpty(NameTextBox.Text))
                {
                    // Only Name is filled, do something
                    ListBoxCustomers.ItemsSource = FilterByName(GenerateUsers(10), NameTextBox.Text);

                }
                else if (!string.IsNullOrEmpty(SurnameTextBox.Text))
                {
                    // Only Surname is filled, do something
                }
                else if (!string.IsNullOrEmpty(EmailTextBox.Text))
                {
                    // Only Email is filled, do something
                }
            }
            else
            {
                // None of the fields are filled
            }
        }

        // Filter by email
        public static List<UsuarioModel> FilterByEmail(List<UsuarioModel> usuarios, string email)
        {
            return usuarios.Where(u => u.Email == email).ToList();
        }

        // Filter by password
        public static List<UsuarioModel> FilterByPassword(List<UsuarioModel> usuarios, string password)
        {
            return usuarios.Where(u => u.Password == password).ToList();
        }

        // Filter by name
        public static List<UsuarioModel> FilterByName(List<UsuarioModel> usuarios, string name)
        {
            return usuarios.Where(u => u.Name == name).ToList();
        }
    }
}
