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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace Proyecto_final
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window    {

        private List<Animal> listaAnimales;
        private List<Voluntario> usuarios;
        private string usuario = "admin";
        private string pass = "1234";

        
        public MainWindow()
        {
            InitializeComponent();
            usuarios = CargarListaVoluntarios();
            //listaAnimales = CargarListaAnimales();
            //DataContext = voluntario1;
        }

        private void TextUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                PasswordBox.IsEnabled = true;
                PasswordBox.Focus();
            }
        }

        private void lblRecordarContrasena_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void lblRecordarContrasena_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void BtnLogin_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void BtnLogin_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void BtnLoginExit_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void BtnLoginExit_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void BtnLoginExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Si no se ha introducido el login
            if (String.IsNullOrEmpty(TextUsuario.Text)
            || String.IsNullOrEmpty(PasswordBox.Password))
            {
                // feedback al usuario
                MessageBox.Show("Introduzca el usuario y la contraseña");
            }
            else
            {
                if (TextUsuario.Text.Equals(usuario)
                && PasswordBox.Password.Equals(pass))
                {
                    Window1 windowMain = new Window1();
                    windowMain.Show();
                    this.Close();
                }
                else
                {
                    // feedback al usuario
                    MessageBox.Show("Combinación usuario-contraseña incorrecta");
                }
            }
        }

        public List<Voluntario> CargarListaVoluntarios()
        {
            List<Voluntario> lista = new List<Voluntario>();
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("resources/Usuarios.xml", UriKind.Relative));
            doc.Load(fichero.Stream);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoVoluntario = new Voluntario("", "", "", "", "", "");

                nuevoVoluntario.username = node.Attributes["Username"].Value;
                nuevoVoluntario.password = node.Attributes["Contrasenia"].Value;
                nuevoVoluntario.Nombre = node.Attributes["Nombre"].Value;
                nuevoVoluntario.Apellidos = node.Attributes["Apellidos"].Value;
                nuevoVoluntario.dni = node.Attributes["DNI"].Value;
                nuevoVoluntario.tlf = node.Attributes["Telefono"].Value;

                lista.Add(nuevoVoluntario);
            }

            return lista;
        }

        /*public List<Animal> CargarListaAnimales()
        {
            List<Animal> lista = new List<Animal>();
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("resources/Animales.xml", UriKind.Relative));
            doc.Load(fichero.Stream);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoAnimal = new Animal("", "", "", 0, 0, 0, "", "", "", "");

                nuevoAnimal.nombre = node.Attributes["nombre"].Value;
                nuevoAnimal.sexo = node.Attributes["sexo"].Value;
                nuevoAnimal.raza = node.Attributes["raza"].Value;
                nuevoAnimal.tamanio = Convert.ToInt32(node.Attributes["tamanio"].Value);
                nuevoAnimal.peso = Convert.ToInt32(node.Attributes["peso"].Value);
                nuevoAnimal.edad = Convert.ToInt32(node.Attributes["edad"].Value);
                nuevoAnimal.chip = node.Attributes["chip"].Value;
                nuevoAnimal.vacunado = node.Attributes["vacunado"].Value;
                nuevoAnimal.estado_animal = node.Attributes["estado_animal"].Value;
                nuevoAnimal.enfermo = node.Attributes["enfermo"].Value;

                lista.Add(nuevoAnimal);
            }

            return lista;

        }*/

        
    }
}
