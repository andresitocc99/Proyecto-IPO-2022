using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    class Animal
    {
        public Animal(string nombre, string sexo, string raza, int tamanio, int peso, int edad, string chip, string vacunado, string estado_animal, string enfermo)
        {
            this.nombre = nombre;
            this.sexo = sexo;
            this.raza = raza;
            this.tamanio = tamanio;
            this.peso = peso;
            this.edad = edad;
            this.chip = chip;
            this.vacunado = vacunado ;
            this.estado_animal = estado_animal;
            this.enfermo = enfermo;
        }

        public string nombre { get; set; }
        public string sexo { get; set; }
        public string raza { get; set; }
        public int tamanio { get; set; }
        public int peso { get; set; }
        public int edad { get; set; } 
        public string chip { get; set; }
        public string vacunado { get; set; }
        public string estado_animal { get; set; }
        public string enfermo { get; set; }


    }
}
