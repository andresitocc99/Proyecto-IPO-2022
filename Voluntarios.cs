using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    public class Voluntarios
    {
        public Voluntarios(string nombre, string apellidos, int edad, string dNI, Uri foto_Perfil, string email, string telefono, string zona, string horario)
        {
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Edad = edad;
            this.DNI = dNI;
            this.Foto_Perfil = foto_Perfil;
            this.Email = email;
            this.Telefono = telefono;
            this.Zona = zona;
            this.Horario = horario;
        }

        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string DNI { get; set; }
        public Uri Foto_Perfil { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Zona { get; set; }
        public string Horario { get; set; }
    }
}
