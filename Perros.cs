using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    class Perros
    {
        public Perros(string nombre, string sexo, string raza, int tamanio, int peso, int edad, string pPP, string vacunado, string enfermo, Uri foto)
        {
            this.Nombre = nombre;
            this.Sexo = sexo;
            this.Raza = raza;
            this.Tamanio = tamanio;
            this.Peso = peso;
            this.Edad = edad;
            this.PPP = pPP;
            this.Vacunado = vacunado;
            this.Enfermo = enfermo;
            this.Foto = foto;
        }

        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public string Raza { get; set; }
        public int Tamanio { get; set; }
        public int Peso { get; set; }
        public int Edad { get; set; } 
        public string PPP { get; set; }
        public string Vacunado { get; set; }
        public string Enfermo { get; set; }
        public Uri Foto { get; set; }


    }
}
