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

namespace Proyecto_final
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string usuario = "admin";
        private string pass = "1234";

        private Voluntario voluntario1 = new Voluntario("JuanCarlos", "Pérez", "Pérez", "12345678F", 123456789);
        public MainWindow()
        {
            InitializeComponent();
            DataContext = voluntario1;
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

    }
}
