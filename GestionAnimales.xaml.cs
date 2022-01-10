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

    public partial class GestionAnimales : Window
    {

        private List<Perros> listaPerros;
        private int counter;
        private string foto;
        private string username;
        private string password;
        
        public GestionAnimales(string txtUsername, string txtPassword)
        {
            InitializeComponent();
            listaPerros = CargarListaPerros();
            username = txtUsername;
            password = txtPassword;
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

               var nuevoPerro = new Perros("", "", "", 0, 0, 0, false, false, false, null, false, "",0, "",0, "");

                nuevoPerro.Nombre = node.Attributes["Nombre"].Value;
                nuevoPerro.Sexo = node.Attributes["Sexo"].Value;
                nuevoPerro.Raza = node.Attributes["Raza"].Value;
                nuevoPerro.Tamanio = Convert.ToInt32(node.Attributes["Tamanio"].Value);
                nuevoPerro.Peso = Convert.ToInt32(node.Attributes["Peso"].Value);
                nuevoPerro.Edad = Convert.ToInt32(node.Attributes["Edad"].Value);
                nuevoPerro.PPP = Convert.ToBoolean(node.Attributes["PPP"].Value);
                nuevoPerro.Vacunado = Convert.ToBoolean(node.Attributes["Vacunado"].Value);
                nuevoPerro.Enfermo = Convert.ToBoolean(node.Attributes["Enfermo"].Value);
                nuevoPerro.Foto = new Uri(node.Attributes["Foto"].Value, UriKind.Relative);
                nuevoPerro.Padrino = Convert.ToBoolean(node.Attributes["Padrino"].Value);
                nuevoPerro.Nombre_Padrino= node.Attributes["Nombre_Padrino"].Value;
                nuevoPerro.Edad_Padrino = Convert.ToInt32(node.Attributes["Edad_Padrino"].Value);
                nuevoPerro.Contacto = node.Attributes["Contacto"].Value;
                nuevoPerro.Aportacion = Convert.ToInt32(node.Attributes["Aportacion_Mensual"].Value);
                nuevoPerro.Fecha_Apadrinamiento = node.Attributes["Fecha_Apadrinamiento"].Value;
               
                lista.Add(nuevoPerro);
                
            }

            return lista;

        }

        private void lstPerros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // DATOS PERRO
            txtNombre.IsReadOnly = true;
            txtEdad.IsReadOnly = true;
            txtSexo.IsReadOnly = true;
            txtRaza.IsReadOnly = true;
            txtTamanio.IsReadOnly = true;
            txtPeso.IsReadOnly = true;
            checkBoxVacunado.IsEnabled = false;
            CheckBoxEnfermo.IsEnabled = false;
            CheckBoxPPP.IsEnabled = false;
            CheckBoxPadrino.IsEnabled = false;
            btnFotoAnadir.IsEnabled = false;

            // DATOS PADRINO
            txtNombrePadrino.IsReadOnly = true;
            txtEdadPadrino.IsReadOnly=true;
            txtContacto.IsReadOnly = true;
            txtAportacion.IsReadOnly = true;
            txtFechaApadrinamiento.IsReadOnly = true;

            // BOTONES GESTIÓN
            btnEditarAnimal.IsEnabled = true;
            btnAnadirAnimal.IsEnabled = false;
            btnEliminarAnimal.IsEnabled = true;

            if (lstPerros.SelectedIndex==-1) {

                // DATOS PERRO
                txtNombre.IsReadOnly = false;
                txtEdad.IsReadOnly = false;
                txtSexo.IsReadOnly = false;
                txtRaza.IsReadOnly = false;
                txtTamanio.IsReadOnly = false;
                txtPeso.IsReadOnly = false;
                checkBoxVacunado.IsEnabled = true;
                CheckBoxEnfermo.IsEnabled = true;
                CheckBoxPPP.IsEnabled = true;
                CheckBoxPadrino.IsEnabled = true;
                btnFotoAnadir.IsEnabled = true;

                // DATOS PADRINO
                txtAportacion.IsEnabled = true;
                txtNombrePadrino.IsEnabled = false;
                txtFechaApadrinamiento.IsEnabled = false;
                txtEdadPadrino.IsEnabled = false;
                txtContacto.IsEnabled = false;

                // BOTONES GESTIÓN
                btnEditarAnimal.IsEnabled = false;
                btnAnadirAnimal.IsEnabled = true;
                btnEliminarAnimal.IsEnabled = false;
                lstPerros.IsEnabled = true;
            }
            
        }

        private void bbtnBorrar_Click(object sender, RoutedEventArgs e)
        {
            Borrar();
            txtEditarAnimal.Text = "Editar";
            btnEditarAnimal.IsEnabled=false;
            btnEliminarAnimal.IsEnabled = false;
            btnAnadirAnimal.IsEnabled = true;
                    
        }

        private void Borrar ()
        {
            // BORRADO DE DATOS DE TODOS LOS CAMPOS

            txtNombre.Text = "";
            txtEdad.Text = "";
            txtSexo.Text = "";
            txtRaza.Text = "";
            txtTamanio.Text = "";
            txtPeso.Text = "";
            checkBoxVacunado.IsChecked = false;
            CheckBoxEnfermo.IsChecked = false;
            CheckBoxPadrino.IsChecked = false;
            CheckBoxPPP.IsChecked = false;
            txtNombrePadrino.Text = "";
            txtEdadPadrino.Text = "";
            txtContacto.Text = "";
            txtAportacion.Text = "";
            txtFechaApadrinamiento.Text = "";


            lstPerros.SelectedIndex = -1;
            btnEditarAnimal.IsEnabled = false;
            btnEliminarAnimal.IsEnabled = false;
            btnAnadirAnimal.IsEnabled = true;
            btnFotoAnadir.IsEnabled = true;

            // DATOS PERRO
            txtNombre.IsReadOnly = false;
            txtEdad.IsReadOnly = false;
            txtSexo.IsReadOnly = false;
            txtRaza.IsReadOnly = false;
            txtTamanio.IsReadOnly = false;
            txtPeso.IsReadOnly = false;
            checkBoxVacunado.IsEnabled = true;
            CheckBoxEnfermo.IsEnabled = true;
            CheckBoxPPP.IsEnabled = true;
            CheckBoxPadrino.IsEnabled = true;
            btnFotoAnadir.IsEnabled = true;

            // DATOS PADRINO
            txtAportacion.IsEnabled = true;
            txtNombrePadrino.IsEnabled = false;
            txtFechaApadrinamiento.IsEnabled = false;
            txtEdadPadrino.IsEnabled = false;
            txtContacto.IsEnabled = false;
        }

        private void btnEditarAnimal_Click(object sender, RoutedEventArgs e)
        {
            counter += 1;
            if (counter % 2 != 0)
            {
                
                txtEditarAnimal.Text = "Guardar";
                lstPerros.IsEnabled = false;
                txtNombre.IsReadOnly = false;
                txtSexo.IsReadOnly = false;
                txtRaza.IsReadOnly = false;
                txtTamanio.IsReadOnly = false;
                txtPeso.IsReadOnly = false;
                txtEdad.IsReadOnly = false;
                CheckBoxEnfermo.IsEnabled = true;
                checkBoxVacunado.IsEnabled = true;
                CheckBoxPPP.IsEnabled = true;
                CheckBoxPadrino.IsEnabled = true;
                btnFotoAnadir.IsEnabled = true;
                
                btnEditarAnimal.ToolTip = "Pulse para guardar la edición";
                if (CheckBoxPadrino.IsChecked == true)
                {
                   
                    txtNombrePadrino.IsReadOnly = false;
                    txtAportacion.IsReadOnly = false;
                    txtContacto.IsReadOnly = false;
                }
                else
                {
                    
                    txtNombrePadrino.IsReadOnly = true;
                    txtAportacion.IsReadOnly = true;
                    txtContacto.IsReadOnly = true;
                }
            }
            else if (counter % 2 == 0)
            {
                if (Check())
                {
                    var nuevoPerro = new Perros("", "", "", 0, 0, 0, false, false, false, null, false, "", 0, "", 0, "");
                    
                    txtEditarAnimal.Text = "Editar";
                    lstPerros.IsEnabled = true;
                    txtNombre.IsReadOnly = false;
                    txtSexo.IsReadOnly = false;
                    txtRaza.IsReadOnly = false;
                    txtTamanio.IsReadOnly = false;
                    txtPeso.IsReadOnly = false;
                    txtEdad.IsReadOnly = false;
                    checkBoxVacunado.IsEnabled = false;
                    CheckBoxEnfermo.IsEnabled = false;
                    CheckBoxPPP.IsEnabled = false;
                    CheckBoxPadrino.IsEnabled = false;
                   
                    txtNombrePadrino.IsReadOnly = false;
                    txtAportacion.IsReadOnly = false;
                    txtContacto.IsReadOnly = false;
                    btnFotoAnadir.IsEnabled = false;

                    if (CheckBoxPadrino.IsChecked == true)
                    {
                        if (txtNombrePadrino.Text != "" && txtAportacion.Text != "" && txtContacto.Text != "")
                        {
                            if (foto == null)
                            {
                                nuevoPerro = new Perros(txtNombre.Text, txtSexo.Text, txtRaza.Text, Convert.ToInt32(txtTamanio.Text), Convert.ToInt32(txtPeso.Text), Convert.ToInt32(txtEdad.Text), 
                                                        Convert.ToBoolean(CheckBoxPPP.IsChecked), Convert.ToBoolean(checkBoxVacunado.IsChecked), Convert.ToBoolean(CheckBoxEnfermo.IsChecked), 
                                                        new Uri(txtHide.Text, UriKind.Relative), Convert.ToBoolean(CheckBoxPadrino.IsChecked), txtNombrePadrino.Text, Convert.ToInt32(txtEdadPadrino.Text), 
                                                        txtContacto.Text, Convert.ToInt32(txtAportacion.Text), txtFechaApadrinamiento.Text);
                                
                            }
                            else
                            {
                                nuevoPerro = new Perros(txtNombre.Text, txtSexo.Text, txtRaza.Text, Convert.ToInt32(txtTamanio.Text), Convert.ToInt32(txtPeso.Text), Convert.ToInt32(txtEdad.Text),
                                                        Convert.ToBoolean(CheckBoxPPP.IsChecked), Convert.ToBoolean(checkBoxVacunado.IsChecked), Convert.ToBoolean(CheckBoxEnfermo.IsChecked),
                                                        new Uri(foto, UriKind.Relative), Convert.ToBoolean(CheckBoxPadrino.IsChecked), txtNombrePadrino.Text, Convert.ToInt32(txtEdadPadrino.Text),
                                                        txtContacto.Text, Convert.ToInt32(txtAportacion), txtFechaApadrinamiento.Text);

                            }
                            listaPerros.RemoveAt(lstPerros.SelectedIndex);
                            listaPerros.Insert(lstPerros.SelectedIndex, nuevoPerro);
                            lstPerros.Items.Refresh();
                        }

                    }
                    else
                    {
                        if (foto == null)
   
                        {
                            nuevoPerro = new Perros(txtNombre.Text, txtSexo.Text, txtRaza.Text, Convert.ToInt32(txtTamanio.Text), Convert.ToInt32(txtPeso.Text), Convert.ToInt32(txtEdad.Text),
                                                        Convert.ToBoolean(CheckBoxPPP.IsChecked), Convert.ToBoolean(checkBoxVacunado.IsChecked), Convert.ToBoolean(CheckBoxEnfermo.IsChecked),
                                                        new Uri(txtHide.Text, UriKind.Relative), Convert.ToBoolean(CheckBoxPadrino.IsChecked), "", 0, "", 0, "");       
                        }
                            else
                        {
                            nuevoPerro = new Perros(txtNombre.Text, txtSexo.Text, txtRaza.Text, Convert.ToInt32(txtTamanio.Text), Convert.ToInt32(txtPeso.Text), Convert.ToInt32(txtEdad.Text),
                                                        Convert.ToBoolean(CheckBoxPPP.IsChecked), Convert.ToBoolean(checkBoxVacunado.IsChecked), Convert.ToBoolean(CheckBoxEnfermo.IsChecked),
                                                        new Uri(foto, UriKind.Relative), Convert.ToBoolean(CheckBoxPadrino.IsChecked), "", 0, "", 0, "");
                        }
                        listaPerros.RemoveAt(lstPerros.SelectedIndex);
                        listaPerros.Insert(lstPerros.SelectedIndex, nuevoPerro);
                        lstPerros.Items.Refresh();
                    }

                }
                else
                {
                    MessageBox.Show("No se llevarán a cabo los cambios");
                }
            }
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

        private void btnAnadirFoto_Click(object sender, RoutedEventArgs e)
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

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Window1 ventana = new Window1(username, password);
            ventana.Show();
            this.Hide();
        }

        private void btnAnadirAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text != "" && txtSexo.Text != "" && txtRaza.Text != "" && txtPeso.Text != "" && txtTamanio.Text != "" &&
                txtEdad.Text != "" && foto != "")
            {
                if (CheckBoxPadrino.IsChecked== true && Check())
                {
                    var nuevoPerro = new Perros(txtNombre.Text, txtSexo.Text, txtRaza.Text, Convert.ToInt32(txtTamanio.Text), Convert.ToInt32(txtPeso.Text), Convert.ToInt32(txtEdad.Text),
                                                        Convert.ToBoolean(CheckBoxPPP.IsChecked), Convert.ToBoolean(checkBoxVacunado.IsChecked), Convert.ToBoolean(CheckBoxEnfermo.IsChecked),
                                                        new Uri(foto, UriKind.Relative), Convert.ToBoolean(CheckBoxPadrino.IsChecked), txtNombrePadrino.Text, Convert.ToInt32(txtEdadPadrino.Text),
                                                        txtContacto.Text, Convert.ToInt32(txtAportacion), txtFechaApadrinamiento.Text);
                    listaPerros.Add(nuevoPerro);
                    lstPerros.Items.Refresh();
                } else
                {
                    var nuevoPerro = new Perros(txtNombre.Text, txtSexo.Text, txtRaza.Text, Convert.ToInt32(txtTamanio.Text), Convert.ToInt32(txtPeso.Text), Convert.ToInt32(txtEdad.Text),
                                                        Convert.ToBoolean(CheckBoxPPP.IsChecked), Convert.ToBoolean(checkBoxVacunado.IsChecked), Convert.ToBoolean(CheckBoxEnfermo.IsChecked),
                                                        new Uri(foto, UriKind.Relative), Convert.ToBoolean(CheckBoxPadrino.IsChecked), "", 0, "", 0, "");
                    listaPerros.Add(nuevoPerro);
                    lstPerros.Items.Refresh();
                }
            } else
            {
                MessageBox.Show("ERROR. Campos sin rellenar", "Advertencia");
            }
        }

        private void btnEliminarAnimales_Click(object sender, RoutedEventArgs e)
        {
            if (lstPerros.SelectedIndex >= 0)
            {
                
                if (Check())
                {
                    listaPerros.RemoveAt(lstPerros.SelectedIndex);
                    lstPerros.Items.Refresh();
                    Borrar();
                } else
                {
                    MessageBox.Show("No se eliminará al perro", "Advertencia");
                }
            } else
            {
                MessageBox.Show("Debe elegir un perro antes de eliminar uno", "Advertencia");
            }
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
