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

    public partial class GestionAnimales : Window
    {
        private List<Perros> listaPerros;
        public GestionAnimales()
        {
            InitializeComponent();
            listaPerros = CargarListaPerros();
            DataContext = listaPerros;
        }

        private List<Perros> CargarListaPerros()
        {
            List<Perros> lista = new List<Perros>();
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("resources/Perros.xml", UriKind.Relative));
            doc.Load(fichero.Stream);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoPerro = new Perros("", "", "", 0, 0, 0, "", "", "", null);

                nuevoPerro.Nombre = node.Attributes["Nombre"].Value;
                nuevoPerro.Sexo = node.Attributes["Sexo"].Value;
                nuevoPerro.Raza = node.Attributes["Raza"].Value;
                nuevoPerro.Tamanio = Convert.ToInt32(node.Attributes["Tamanio"].Value);
                nuevoPerro.Peso = Convert.ToInt32(node.Attributes["Peso"].Value);
                nuevoPerro.Edad = Convert.ToInt32(node.Attributes["Edad"].Value);
                nuevoPerro.PPP = node.Attributes["PPP"].Value;
                nuevoPerro.Vacunado = node.Attributes["Vacunado"].Value;
                nuevoPerro.Enfermo = node.Attributes["Enfermo"].Value;
                nuevoPerro.Foto = new Uri(node.Attributes["Foto"].Value, UriKind.Relative);

                lista.Add(nuevoPerro);
            }

            return lista;

        }

    }
}
