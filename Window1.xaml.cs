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
        private Socio socioLogeado;
        private string username;
        private string password;
        
        public Window1 (string txtUsuario, string txtPassword)
        {
            socioLogeado = get_Socio (CargarListaSocios(),txtUsuario, txtPassword);
            InitializeComponent();
            username = txtUsuario;
            password = txtPassword;
            DataContext = socioLogeado;
           
        }

        private Socio get_Socio (List<Socio> socios, string TextoUsuario, string password)
        {
            Socio socio = null;
            for (int i = 0; i < socios.Count; i++)
            {
                if (TextoUsuario.Equals(socios[i].username) && password.Equals(socios[i].password))
                {
                    socio = socios[i];
                }
            }

            return socio;
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private List<Socio> CargarListaSocios()
        {
            List<Socio> lista = new List<Socio>();
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("resources/Socios.xml", UriKind.Relative));
            doc.Load(fichero.Stream);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoSocio = new Socio("", "", "", "", "", "",null);

                nuevoSocio.username = node.Attributes["Username"].Value;
                nuevoSocio.password = node.Attributes["Contrasenia"].Value;
                nuevoSocio.Nombre = node.Attributes["Nombre"].Value;
                nuevoSocio.Apellidos = node.Attributes["Apellidos"].Value;
                nuevoSocio.dni = node.Attributes["DNI"].Value;
                nuevoSocio.tlf = node.Attributes["Telefono"].Value;
                nuevoSocio.Foto_Perfil = new Uri(node.Attributes["Foto_Perfil"].Value, UriKind.Relative);

                lista.Add(nuevoSocio);
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
    }
}
