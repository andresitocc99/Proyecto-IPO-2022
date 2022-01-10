using Microsoft.Win32;
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
using System.Xml;

namespace Proyecto_final
{
   
    public partial class Window1 : Window
    {
        private Trabajador trabajador;
        private string username;
        private string password;
        
        public Window1 (string txtUsuario, string txtPassword)
        {
            trabajador = get_Trabajador (CargarListaTrabajadores(),txtUsuario, txtPassword);
            InitializeComponent();
            username = txtUsuario;
            password = txtPassword;
            DataContext = trabajador;
           
        }

        private Trabajador get_Trabajador (List<Trabajador> trabajadores, string TextoUsuario, string password)
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

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            VentanaSalida salida = new VentanaSalida();
            salida.Show();
        }

        private List<Trabajador> CargarListaTrabajadores()
        {
            List<Trabajador> lista = new List<Trabajador>();
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("resources/Trabajador.xml", UriKind.Relative));
            doc.Load(fichero.Stream);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoTrabajador = new Trabajador("", "", "", "", "", "", null);

                nuevoTrabajador.username = node.Attributes["Username"].Value;
                nuevoTrabajador.password = node.Attributes["Contrasenia"].Value;
                nuevoTrabajador.Nombre = node.Attributes["Nombre"].Value;
                nuevoTrabajador.Apellidos = node.Attributes["Apellidos"].Value;
                nuevoTrabajador.dni = node.Attributes["DNI"].Value;
                nuevoTrabajador.tlf = node.Attributes["Telefono"].Value;
                nuevoTrabajador.Foto_Perfil = new Uri(node.Attributes["Foto_Perfil"].Value, UriKind.Relative);

                lista.Add(nuevoTrabajador);
            }

            return lista;
        }

        private void btnGestionAnimales_Click(object sender, RoutedEventArgs e)
        {
            GestionAnimales windowAnimales= new GestionAnimales(username, password);
            windowAnimales.Show();
            this.Hide();
        }

        private void btnGestionVoluntarios_Click(object sender, RoutedEventArgs e)
        {
            GestionVoluntarios windorVoluntarios = new GestionVoluntarios(username, password);
            windorVoluntarios.Show();
            this.Hide();
        }

        private void btnGestionSocios_Click(object sender, RoutedEventArgs e)
        {
            GestionSocios windowSocios = new GestionSocios(username, password);
            windowSocios.Show();
            this.Hide();
        }

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            Ayuda ventanaAyuda = new Ayuda();
            ventanaAyuda.Show();
        }
    }
}
