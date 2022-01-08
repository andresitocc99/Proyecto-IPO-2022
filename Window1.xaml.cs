﻿using Microsoft.Win32;
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

namespace Proyecto_final
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
  
        private Window1(List<Socio> socios,string TextUsuario, string Password)
        {
            InitializeComponent();
            DataContext = socios;
            Socio socio = get_Socio(socios, TextUsuario, Password);
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

        private void UserAvatar_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void UserAvatar_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void UserAvatar_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void EditarPerfil_Click(object sender, RoutedEventArgs e)
        {
            var abrirDialog = new OpenFileDialog();
            abrirDialog.Filter = "Images|*.jpg;*.gif;*.bmp;*.png";
            if (abrirDialog.ShowDialog() == true)
            {
                try
                {
                    var bitmap = new BitmapImage(new Uri(abrirDialog.FileName, UriKind.Absolute));
                    UserAvatar.Source = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen " + ex.Message);
                }
            }
        }
    }
}
