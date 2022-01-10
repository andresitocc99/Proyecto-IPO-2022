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
        public partial class MainWindow : Window    {

        private List<Trabajador> trabajadores;
        private BitmapImage imgChecked = new BitmapImage(new Uri("Images/check.png", UriKind.Relative));
        private BitmapImage imgCross = new BitmapImage(new Uri("Images/cross.png", UriKind.Relative));

        public MainWindow()
        {
            InitializeComponent();
            trabajadores = CargarListaTrabajadores();
            DataContext = trabajadores;
        }

        private void TextUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                if (!String.IsNullOrEmpty(TextUsuario.Text) && ComprobarEntrada_Username(TextUsuario.Text,TextUsuario,imageCheckUsuario)) {
                    
                    PasswordBox.IsEnabled = true;
                    PasswordBox.Focus();
                    TextUsuario.IsEnabled = false;
                } else
                {
                    TextUsuario.BorderBrush = Brushes.Red;
                    imageCheckUsuario.Source = imgCross;
                    
                }
                
            }
        }

        private Trabajador get_Trabajador(List<Trabajador> trabajadores, string TextoUsuario, string password)
        {
            Trabajador trabajador = null;
            for (int i = 0; i < trabajadores.Count; i++)
            {
                if (TextoUsuario.Equals(trabajadores[i].username) && password.Equals(trabajadores[i].password))
                {
                    trabajador = trabajadores[i];
                }
            }

            return trabajador;
        }

        private Boolean ComprobarEntrada_Username (string valorIntroducido, Control componenteEntrada, Image imagenFeedBack)
        {
            Boolean valido = false;
            componenteEntrada.BorderThickness = new Thickness(2);

            for (int i = 0; i < trabajadores.Count; i++)
            {

                if (trabajadores[i].username.Equals(valorIntroducido))
                {
                    componenteEntrada.BorderBrush = Brushes.Green;
                    componenteEntrada.Background = Brushes.LightGreen;
                    imagenFeedBack.Source = imgChecked;
                    valido = true;
                }
    
            }


            return valido;
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
            VentanaSalida salida = new VentanaSalida();
            salida.Show();
        }

        public void BtnLogin_Click(object sender, RoutedEventArgs e)
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
                if (check_Login (TextUsuario.Text, PasswordBox.Password) == true) 
                {
                    
                    Window1 windowMain = new Window1(TextUsuario.Text, PasswordBox.Password);
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

        private Boolean check_Login (string TextoUsuario, string password)
        {
            Boolean check = false;
            for (int i = 0; i< trabajadores.Count; i++)
            {
                if (TextoUsuario.Equals(trabajadores[i].username) && password.Equals(trabajadores[i].password))
                {
                    check = true;
                }
            }

            return check;
        }

        private List<Trabajador> CargarListaTrabajadores()
        {
            List<Trabajador> lista = new List<Trabajador>();
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("resources/Trabajador.xml", UriKind.Relative));
            doc.Load(fichero.Stream);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoTrabajador = new Trabajador("", "", "", "", "", "",null);

                nuevoTrabajador.username = node.Attributes["Username"].Value;
                nuevoTrabajador.password = node.Attributes["Contrasenia"].Value;
                nuevoTrabajador.Nombre = node.Attributes["Nombre"].Value;
                nuevoTrabajador.Apellidos = node.Attributes["Apellidos"].Value;
                nuevoTrabajador.dni = node.Attributes["DNI"].Value;
                nuevoTrabajador.tlf = node.Attributes["Telefono"].Value;
                nuevoTrabajador.Foto_Perfil = new Uri (node.Attributes["Foto_Perfil"].Value, UriKind.Relative);

                lista.Add(nuevoTrabajador);
            }

            return lista;
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (!String.IsNullOrEmpty(TextUsuario.Text))
                {

                    PasswordBox.IsEnabled = true;
                    PasswordBox.BorderBrush = Brushes.Green;
                    BtnLogin.Focus();
                   
                }
                else
                {
                    PasswordBox.BorderBrush = Brushes.Red;
                    imageCheckPassword.Source = imgCross;

                }

            }
        }

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            Ayuda ventanaAyuda = new Ayuda();
            ventanaAyuda.Show();
        }
    }
}
