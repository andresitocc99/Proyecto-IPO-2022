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
        
        public Window1 (string txtUsuario, string txtPassword)
        {
            socioLogeado = get_Socio (CargarListaSocios(),txtUsuario, txtPassword);
            InitializeComponent();
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
                var nuevoVoluntario = new Socio("", "", "", "", "", "",null);

                nuevoVoluntario.username = node.Attributes["Username"].Value;
                nuevoVoluntario.password = node.Attributes["Contrasenia"].Value;
                nuevoVoluntario.Nombre = node.Attributes["Nombre"].Value;
                nuevoVoluntario.Apellidos = node.Attributes["Apellidos"].Value;
                nuevoVoluntario.dni = node.Attributes["DNI"].Value;
                nuevoVoluntario.tlf = node.Attributes["Telefono"].Value;
                nuevoVoluntario.Foto_Perfil = new Uri(node.Attributes["Foto_Perfil"].Value, UriKind.Relative);

                lista.Add(nuevoVoluntario);
            }

            return lista;
        }

        private void btnGestionAnimales_Click(object sender, RoutedEventArgs e)
        {
            GestionAnimales windowAnimales= new GestionAnimales();
            windowAnimales.Show();
            this.Hide();
        }
    }
}
