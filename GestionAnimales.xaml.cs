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
            DataContext=listaPerros;
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

                nuevoPerro.nombre = node.Attributes["nombre"].Value;
                nuevoPerro.sexo = node.Attributes["sexo"].Value;
                nuevoPerro.raza = node.Attributes["raza"].Value;
                nuevoPerro.tamanio = Convert.ToInt32(node.Attributes["tamanio"].Value);
                nuevoPerro.peso = Convert.ToInt32(node.Attributes["peso"].Value);
                nuevoPerro.edad = Convert.ToInt32(node.Attributes["edad"].Value);
                nuevoPerro.ppp = node.Attributes["ppp"].Value;
                nuevoPerro.vacunado = node.Attributes["vacunado"].Value;
                nuevoPerro.enfermo = node.Attributes["enfermo"].Value;
                nuevoPerro.foto = new Uri(node.Attributes["foto"].Value, UriKind.Relative);

                lista.Add(nuevoPerro);
            }

            return lista;

        }


    }
}
