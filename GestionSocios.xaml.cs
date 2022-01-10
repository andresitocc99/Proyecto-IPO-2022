using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// <summary>
    /// Lógica de interacción para GestionSocios.xaml
    /// </summary>
    public partial class GestionSocios : Window
    {

        private List<Socio> listaSocios;
        private string username;
        private string password;
        private int counter;
        private string foto;
        
        public GestionSocios(string txtUsuario, string txtPassword)
        {
            InitializeComponent();
            listaSocios = CargarListaSocios();
            username = txtUsuario;
            password = txtPassword;
            DataContext = listaSocios;
           
   
        }

        private List<Socio> CargarListaSocios()
        {
            List<Socio> lista = new List<Socio>();
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("resources/Socios.xml", UriKind.Relative));
            doc.Load(fichero.Stream);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoSocio = new Socio ("", "", "", "", "", "",0.0,null);
                nuevoSocio.Nombre = node.Attributes["Nombre"].Value;
                nuevoSocio.Apellidos = node.Attributes["Apellidos"].Value;
                nuevoSocio.DNI = node.Attributes["DNI"].Value;
                nuevoSocio.Telefono = node.Attributes["Telefono"].Value;
                nuevoSocio.Entidad_Bancaria = node.Attributes["Entidad_Bancaria"].Value;
                nuevoSocio.Cuenta_Bancaria = node.Attributes["Cuenta_Bancaria"].Value;
                nuevoSocio.Saldo_Cuenta_Bancaria = Convert.ToDouble(node.Attributes["Saldo_Cuenta_Bancaria"].Value);
                nuevoSocio.Foto_Perfil = new Uri(node.Attributes["Foto_Perfil"].Value, UriKind.Relative);
              
                lista.Add(nuevoSocio);

            }

            return lista;
        }

        private void lstSocios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtNombre.IsReadOnly = true;
            txtApellidos.IsReadOnly = true;
            txtDNI.IsReadOnly = true;
            txtTelefono.IsReadOnly = true;
            txtEntidad.IsReadOnly = true;
            txtSaldo.IsReadOnly = true;
            txtIBAN.IsReadOnly = true;
            btnFotoAnadir.IsEnabled = false;

            btnEditarSocio.IsEnabled = true;
            btnAnadirSocio.IsEnabled = false;
            btnEliminarSocio.IsEnabled = true;

            if (lstSocios.SelectedIndex == -1)
            {
                txtNombre.IsReadOnly = false;
                txtApellidos.IsReadOnly = false;
                txtDNI.IsReadOnly = false;
                txtTelefono.IsReadOnly = false;
                txtEntidad.IsReadOnly = false;
                txtSaldo.IsReadOnly = false;
                txtIBAN.IsReadOnly = false;
                btnFotoAnadir.IsEnabled = true;

                btnEditarSocio.IsEnabled = false;
                btnAnadirSocio.IsEnabled = true;
                btnEliminarSocio.IsEnabled = false;
                lstSocios.IsEnabled = true;
            }

        }

        private void btnBorrarCampos_Click(object sender, RoutedEventArgs e)
        {
            Borrar();
            txtEditarSocio.Text = "Editar";
            btnEditarSocio.IsEnabled = false;
            btnEliminarSocio.IsEnabled = false;
            btnAnadirSocio.IsEnabled = true;
        }

        private void Borrar()
        {
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtDNI.Text = "";
            txtTelefono.Text = "";
            txtIBAN.Text = "";
            txtSaldo.Text = "";
            txtEntidad.Text = "";


            txtNombre.IsReadOnly = false;
            txtApellidos.IsReadOnly = false;
            txtDNI.IsReadOnly = false;
            txtTelefono.IsReadOnly = false;
            txtEntidad.IsReadOnly = false;
            txtSaldo.IsReadOnly = false;
            txtIBAN.IsReadOnly = false;
            btnFotoAnadir.IsEnabled = true;

            btnEditarSocio.IsEnabled = false;
            btnAnadirSocio.IsEnabled = true;
            btnEliminarSocio.IsEnabled = false;
            lstSocios.IsEnabled = true;
            lstSocios.SelectedIndex = -1;   
            

        }

        private bool Check()
        {
            bool confirmacion = false;
            MessageBoxResult result = MessageBox.Show("¿Segur@ de que quiere realizar la acción? Los cambios son irreversibles", "Confirmación", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    confirmacion = true;
                    break;
                case MessageBoxResult.No:
                    confirmacion = false;
                    break;
            }
            return confirmacion;
        }

        private void btnEditarSocio_Click(object sender, RoutedEventArgs e)
        {
            counter += 1;
            if (counter % 2 != 0)
            {

                txtEditarSocio.Text = "Guardar";
                txtNombre.IsReadOnly = false;
                txtApellidos.IsReadOnly = false;
                txtDNI.IsReadOnly = false;
                txtTelefono.IsReadOnly = false;
                txtEntidad.IsReadOnly = false;
                txtSaldo.IsReadOnly = false;
                txtIBAN.IsReadOnly = false;
                btnFotoAnadir.IsEnabled = true;
                btnEditarSocio.ToolTip = "Pulse para guardar la edición";

            }
            else if (counter % 2 == 0)
            {
                if (Check())
                {
                    var nuevoSocio = new Socio("", "", "", "", "", "", 0.0, null);

                    txtEditarSocio.Text = "Editar";
                    lstSocios.IsEnabled = true;
                    txtNombre.IsReadOnly = false;
                    txtApellidos.IsReadOnly = false;
                    txtDNI.IsReadOnly = false;
                    txtTelefono.IsReadOnly = false;
                    txtEntidad.IsReadOnly = false;
                    txtSaldo.IsReadOnly = false;
                    txtIBAN.IsReadOnly = false;
                    btnFotoAnadir.IsEnabled = true;

                    if (foto == null)
                    {
                        nuevoSocio = new Socio (txtNombre.Text, txtApellidos.Text, txtDNI.Text, txtTelefono.Text, txtEntidad.Text, txtIBAN.Text, Convert.ToDouble(txtSaldo.Text), new Uri (txtHide.Text, UriKind.Relative));


                    }
                    else
                    {
                        nuevoSocio = new Socio(txtNombre.Text, txtApellidos.Text, txtDNI.Text, txtTelefono.Text, txtEntidad.Text, txtIBAN.Text, Convert.ToDouble(txtSaldo.Text), new Uri(foto, UriKind.Relative));

                    }
                    listaSocios.RemoveAt(lstSocios.SelectedIndex);
                    listaSocios.Insert(lstSocios.SelectedIndex, nuevoSocio);
                    lstSocios.Items.Refresh();


                }
                else
                {
                    MessageBox.Show("No se llevarán a cabo los cambios");
                }
            }
        }

        private void btnFotoAnadir_Click(object sender, RoutedEventArgs e)
        {
            var abrirDialog = new OpenFileDialog();
            abrirDialog.Filter = "Images|*.jpg;*.png;*.gif;*.bmp;*.jpeg";
            if (abrirDialog.ShowDialog() == true)
            {
                try
                {
                    foto = abrirDialog.FileName;
                    var bitmap = new BitmapImage(new Uri(abrirDialog.FileName, UriKind.Absolute));
                    imgRelleno.Source = new BitmapImage(new Uri("/Resources/check.png", UriKind.Relative));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen " + ex.Message);
                }
            }
        }

        private void btnAnadirSocio_Click(object sender, RoutedEventArgs e)
        {
            
            if (txtNombre.Text != "" && txtApellidos.Text != "" && txtDNI.Text != "" && txtTelefono.Text != "" && foto != "" && txtEntidad.Text != "" && txtIBAN.Text != "" && txtSaldo.Text != "")
            {
                var  nuevoSocio = new Socio(txtNombre.Text, txtApellidos.Text, txtDNI.Text, txtTelefono.Text, txtEntidad.Text, txtIBAN.Text, Convert.ToDouble(txtSaldo.Text), new Uri(foto, UriKind.Relative));
                listaSocios.Add(nuevoSocio);
                lstSocios.Items.Refresh();

            }
            else
            {
                MessageBox.Show("ERROR. Campos sin rellenar", "Advertencia");
            }
        }

        private void btnEliminarSocio_Click(object sender, RoutedEventArgs e)
        {
            if (lstSocios.SelectedIndex >= 0)
            {

                if (Check())
                {
                    listaSocios.RemoveAt(lstSocios.SelectedIndex);
                    lstSocios.Items.Refresh();
                    Borrar();
                }
                else
                {
                    MessageBox.Show("No se eliminará al socio", "Advertencia");
                }
            }
            else
            {
                MessageBox.Show("Debe elegir un socio antes de eliminar uno", "Advertencia");
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Window1 MenuPrincipal = new Window1(username, password);
            MenuPrincipal.Show();
            this.Hide();
        }

        private void txtString_PTI(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 13)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("No debe introducir números en este campo", "Error en el campo");
                e.Handled = true;
            }
        }

        private void txtInt_PTI(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            VentanaSalida salida = new VentanaSalida();
            salida.Show();
        }
    }

    
}
