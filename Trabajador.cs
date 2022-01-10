using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    class Trabajador
    {
        public Trabajador(string username, string password, string nombre, string apellidos, string dni, string tlf, Uri perfil)
        {
            this.username = username;
            this.password = password;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.dni = dni;
            this.tlf = tlf;
            this.Foto_Perfil = perfil;
        }

        public string username { get; set; }
        public string password { get; set; }
        public string Nombre { set; get; }
        public string Apellidos { set; get; }
        public string dni { set; get; }
        public string tlf { set; get; }
        public Uri Foto_Perfil { set; get; }
    }
}
