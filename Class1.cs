using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    class Voluntario
    {
        public string Nombre { set; get; }
        public string Apellido1 { set; get; }
        public string Apellido2 { set; get; }
        public string dni { set; get; }
        public int tlf { set; get; }
        public string Horario { set; get; }

        public Voluntario(string name, string A1, string A2, string dni, int tlf)
        {
            Nombre = name;
            Apellido1 = A1;
            Apellido2 = A2;
            this.dni = dni;
            this.tlf = tlf;
        }
    }
}
