using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    class Voluntario
    {
        public Voluntario(string username, string password, string nombre, string apellidos, string dni, string tlf)
        {
            this.username = username;
            this.password = password;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.dni = dni;
            this.tlf = tlf;
        }

        public string username { get; set; }
        public string password { get; set; }
        public string Nombre { set; get; }
        public string Apellidos { set; get; }
        public string dni { set; get; }
        public string tlf { set; get; }
        

        
    }
}
