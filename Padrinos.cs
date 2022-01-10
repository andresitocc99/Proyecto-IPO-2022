using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    class Padrinos
    {
        public Padrinos(string nombre, int edad, string contacto, int aportacion_Mensual, string fecha_Comienzo)
        {
            Nombre = nombre;
            Edad = edad;
            Contacto = contacto;
            Aportacion_Mensual = aportacion_Mensual;
            Fecha_Comienzo = fecha_Comienzo;
        }

        private string Nombre { get; set; }
        private int Edad { get; set; }
        private string Contacto { get; set; }
        private int Aportacion_Mensual { get; set; }
        private string Fecha_Comienzo { get; set; }


    
    }
}
