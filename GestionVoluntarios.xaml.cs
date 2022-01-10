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
    /// Lógica de interacción para GestionVoluntarios.xaml
    /// </summary>
    public partial class GestionVoluntarios : Window
    {

        private List<Voluntarios> listaVoluntarios;
        private int counter;
        private string foto;
        private string username;
        private string password;

        public GestionVoluntarios(string txtUsuario, string txtPassword)
        {
            InitializeComponent();
            listaVoluntarios = CargarListaVoluntarios();
            DataContext = listaVoluntarios;
            username = txtUsuario;
            password = txtPassword;
        }

        private List<Voluntarios> CargarListaVoluntarios()
        {
            List<Voluntarios> lista = new List<Voluntarios>();
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("resources/Voluntarios.xml", UriKind.Relative));
            doc.Load(fichero.Stream);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoVoluntario = new Voluntarios("", "", 0, "", null, "", "", "", "");
                nuevoVoluntario.Nombre = node.Attributes["Nombre"].Value;
                nuevoVoluntario.Apellidos = node.Attributes["Apellidos"].Value;
                nuevoVoluntario.Edad = Convert.ToInt32(node.Attributes["Edad"].Value);
                nuevoVoluntario.DNI = node.Attributes["DNI"].Value;
                nuevoVoluntario.Foto_Perfil = new Uri(node.Attributes["Foto_Perfil"].Value, UriKind.Relative);
                nuevoVoluntario.Email = node.Attributes["Email"].Value;
                nuevoVoluntario.Telefono = node.Attributes["Telefono"].Value;
                nuevoVoluntario.Zona = node.Attributes["Zona"].Value;
                nuevoVoluntario.Horario = node.Attributes["Horario"].Value;

                lista.Add(nuevoVoluntario);

            }

                return lista;
        }

        private void lstVoluntarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // DATOS VOLUNTARIOS
            txtNombre.IsReadOnly = true;
            txtApellidos.IsReadOnly = true;
            txtEdad.IsReadOnly = true;
            txtDNI.IsReadOnly = true;
            btnFotoAnadir.IsEnabled = false;
            txtEmail.IsReadOnly = true;
            txtTelefono.IsReadOnly = true;
            txtZona.IsReadOnly = true;
            txtHorario.IsReadOnly = true;

            // BOTONES GESTIÓN
            btnEditarVoluntario.IsEnabled = true;
            btnAnadirVoluntario.IsEnabled = false;
            btnEliminarVoluntario.IsEnabled = true;
            

            if (lstVoluntarios.SelectedIndex==-1)
            {
                // DATOS VOLUNTARIOS
                txtNombre.IsReadOnly = false;
                txtApellidos.IsReadOnly = false;
                txtEdad.IsReadOnly = false;
                txtDNI.IsReadOnly = false;
                btnFotoAnadir.IsEnabled = true;
                txtEmail.IsReadOnly = false;
                txtTelefono.IsReadOnly = false;
                txtZona.IsReadOnly = false;
                txtHorario.IsReadOnly = false;

                // BOTONES GESTIÓN
                btnEditarVoluntario.IsEnabled = false;
                btnAnadirVoluntario.IsEnabled = true;
                btnEliminarVoluntario.IsEnabled = false;
                lstVoluntarios.IsEnabled = true;
            }
        }

        private void btnBorrarCampos_Click(object sender, RoutedEventArgs e)
        {
            Borrar();
            txtEditarVoluntario.Text = "Editar";
            btnEditarVoluntario.IsEnabled = false;
            btnEliminarVoluntario.IsEnabled = false;
            btnAnadirVoluntario.IsEnabled = true;
        }

        private void Borrar ()
        {
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtEdad.Text = "";
            txtDNI.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtZona.Text = "";
            txtHorario.Text = "";


            // DATOS VOLUNTARIOS
            
            txtNombre.IsReadOnly = false;
            txtApellidos.IsReadOnly = false;
            txtEdad.IsReadOnly = false;
            txtDNI.IsReadOnly = false;
            btnFotoAnadir.IsEnabled = true;
            txtEmail.IsReadOnly = false;
            txtTelefono.IsReadOnly = false;
            txtZona.IsReadOnly = false;
            txtHorario.IsReadOnly = false;

            // BOTONES GESTIÓN
            lstVoluntarios.SelectedIndex = -1;
            btnEditarVoluntario.IsEnabled = false;
            btnAnadirVoluntario.IsEnabled = true;
            btnEliminarVoluntario.IsEnabled = false;
            lstVoluntarios.IsEnabled = true;

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

        private void btnEditarVoluntario_Click(object sender, RoutedEventArgs e)
        {
            counter += 1;
            if (counter % 2 != 0)
            {

                txtEditarVoluntario.Text = "Guardar";
                txtNombre.IsReadOnly = false;
                txtApellidos.IsReadOnly = false;
                txtEdad.IsReadOnly = false;
                txtDNI.IsReadOnly = false;
                btnFotoAnadir.IsEnabled = true;
                txtEmail.IsReadOnly = false;
                txtTelefono.IsReadOnly = false;
                txtZona.IsReadOnly = false;
                txtHorario.IsReadOnly = false;
                btnEditarVoluntario.ToolTip = "Pulse para guardar la edición";
               
            }
            else if (counter % 2 == 0)
            {
                if (Check())
                {
                    var nuevoVoluntario = new Voluntarios("", "", 0, "", null, "", "", "", "");

                    txtEditarVoluntario.Text = "Editar";
                    lstVoluntarios.IsEnabled = true;
                    txtNombre.IsReadOnly = false;
                    txtApellidos.IsReadOnly = false;
                    txtEdad.IsReadOnly = false;
                    txtDNI.IsReadOnly = false;
                    btnFotoAnadir.IsEnabled = true;
                    txtEmail.IsReadOnly = false;
                    txtTelefono.IsReadOnly = false;
                    txtZona.IsReadOnly = false;
                    txtHorario.IsReadOnly = false;

                    if (foto == null)
                    {
                        nuevoVoluntario = new Voluntarios(txtNombre.Text, txtApellidos.Text, Convert.ToInt32(txtEdad.Text), txtDNI.Text, new Uri(txtHide.Text, UriKind.Relative), txtEmail.Text, txtTelefono.Text, txtZona.Text, txtHorario.Text);
                                                

                    }
                    else
                    {
                        nuevoVoluntario = new Voluntarios(txtNombre.Text, txtApellidos.Text, Convert.ToInt32(txtEdad.Text), txtDNI.Text, new Uri(foto, UriKind.Relative), txtEmail.Text, txtTelefono.Text, txtZona.Text, txtHorario.Text);

                    }
                    listaVoluntarios.RemoveAt(lstVoluntarios.SelectedIndex);
                    listaVoluntarios.Insert(lstVoluntarios.SelectedIndex, nuevoVoluntario);
                    lstVoluntarios.Items.Refresh();
  

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

        private void btnAnadirVoluntario_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text != "" && txtApellidos.Text != "" && txtEdad.Text != "" && txtDNI.Text != "" &&  foto != "" && txtEmail.Text != "" && txtTelefono.Text != "" && txtZona.Text != "" && txtHorario.Text != "")
            {
                var nuevoVoluntario = new Voluntarios(txtNombre.Text, txtApellidos.Text, Convert.ToInt32(txtEdad.Text), txtDNI.Text, new Uri(foto, UriKind.Relative), txtEmail.Text, txtTelefono.Text, txtZona.Text, txtHorario.Text);
                listaVoluntarios.Add(nuevoVoluntario);
                lstVoluntarios.Items.Refresh();
            
            }
            else
            {
                MessageBox.Show("ERROR. Campos sin rellenar", "Advertencia");
            }
        }

        private void btnEliminarVoluntario_Click(object sender, RoutedEventArgs e)
        {
            if (lstVoluntarios.SelectedIndex >= 0)
            {

                if (Check())
                {
                    listaVoluntarios.RemoveAt(lstVoluntarios.SelectedIndex);
                    lstVoluntarios.Items.Refresh();
                    Borrar();
                }
                else
                {
                    MessageBox.Show("No se eliminará al perro", "Advertencia");
                }
            }
            else
            {
                MessageBox.Show("Debe elegir un voluntario antes de eliminar uno", "Advertencia");
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Window1 ventana = new Window1(username, password);
            ventana.Show();
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
    }
}

    


