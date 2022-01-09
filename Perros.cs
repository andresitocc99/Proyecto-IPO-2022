using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    class Perros
    {
        public Perros(string nombre, string sexo, string raza, int tamanio, int peso, int edad, string ppp, string vacunado, string enfermo,Uri foto)
        {
            this.nombre = nombre;
            this.sexo = sexo;
            this.raza = raza;
            this.tamanio = tamanio;
            this.peso = peso;
            this.edad = edad;
            this.ppp = ppp;
            this.vacunado = vacunado ;
            this.enfermo = enfermo;
            this.foto = foto;
        }

        public string nombre { get; set; }
        public string sexo { get; set; }
        public string raza { get; set; }
        public int tamanio { get; set; }
        public int peso { get; set; }
        public int edad { get; set; } 
        public string ppp { get; set; }
        public string vacunado { get; set; }
        public string enfermo { get; set; }
        public Uri foto { get; set; }


    }
}
