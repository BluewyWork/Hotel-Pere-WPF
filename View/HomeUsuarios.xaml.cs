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
            DataContext = new HomeUsuariosVM();

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
            List<UsuarioModel> users = ListBoxCustomers.ItemsSource.Cast<UsuarioModel>().ToList();

            if (!string.IsNullOrEmpty(NameTextBox.Text) || !string.IsNullOrEmpty(SurnameTextBox.Text) || !string.IsNullOrEmpty(EmailTextBox.Text))
            {
                // At least one field is not empty
                if (!string.IsNullOrEmpty(NameTextBox.Text) && !string.IsNullOrEmpty(SurnameTextBox.Text) && !string.IsNullOrEmpty(EmailTextBox.Text))
                {
                    // All three fields are not empty, do something
                    ListBoxCustomers.ItemsSource = FilterByName(users, NameTextBox.Text)
                        .Intersect(FilterBySurname(users, SurnameTextBox.Text))
                        .Intersect(FilterByEmail(users, EmailTextBox.Text))
                        .ToList();
                }
                else if (!string.IsNullOrEmpty(NameTextBox.Text) && !string.IsNullOrEmpty(SurnameTextBox.Text))
                {
                    // Name and Surname are filled, do something
                    ListBoxCustomers.ItemsSource = FilterByName(users, NameTextBox.Text)
                        .Intersect(FilterBySurname(users, SurnameTextBox.Text))
                        .ToList();
                }
                else if (!string.IsNullOrEmpty(NameTextBox.Text) && !string.IsNullOrEmpty(EmailTextBox.Text))
                {
                    // Name and Email are filled, do something
                    ListBoxCustomers.ItemsSource = FilterByName(users, NameTextBox.Text)
                        .Intersect(FilterByEmail(users, EmailTextBox.Text))
                        .ToList();
                }
                else if (!string.IsNullOrEmpty(SurnameTextBox.Text) && !string.IsNullOrEmpty(EmailTextBox.Text))
                {
                    // Surname and Email are filled, do something
                    ListBoxCustomers.ItemsSource = FilterBySurname(users, SurnameTextBox.Text)
                        .Intersect(FilterByEmail(users, EmailTextBox.Text))
                        .ToList();
                }
                else if (!string.IsNullOrEmpty(NameTextBox.Text))
                {
                    // Only Name is filled, do something
                    ListBoxCustomers.ItemsSource = FilterByName(users, NameTextBox.Text);
                }
                else if (!string.IsNullOrEmpty(SurnameTextBox.Text))
                {
                    // Only Surname is filled, do something
                    ListBoxCustomers.ItemsSource = FilterBySurname(users, SurnameTextBox.Text);
                }
                else if (!string.IsNullOrEmpty(EmailTextBox.Text))
                {
                    // Only Email is filled, do something
                    ListBoxCustomers.ItemsSource = FilterByEmail(users, EmailTextBox.Text);
                }
            }
            else
            {
                MessageBox.Show("At least one of the fields must be filled");
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

        // Filter by surname
        public static List<UsuarioModel> FilterBySurname(List<UsuarioModel> usuarios, string surname)
        {
            return usuarios.Where(u => u.Surname == surname).ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // button editar
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // button eliminar
            UsuarioModel selectedItem = (UsuarioModel) ListBoxCustomers.SelectedItem;

            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //ListBoxCustomers.ItemsSource = homeUsuariosVM.CustomersList;
        }
    }
}
