using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    public class Perros
    {
        public Perros(string nombre, string sexo, string raza, int tamanio, int peso, int edad, bool pPP, bool vacunado, bool enfermo, Uri foto, bool padrino, string nombre_Padrino, int edad_Padrino, string contacto, int aportacion, string fecha_Apadrinamiento)
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
            this.Padrino = padrino;
            if (padrino == true)
            {
                this.Nombre_Padrino = nombre_Padrino;
                this.Edad_Padrino = edad_Padrino;
                this.Contacto = contacto;
                this.Aportacion = aportacion;
                this.Fecha_Apadrinamiento = fecha_Apadrinamiento;
            } else
            {
                this.Nombre_Padrino = "";
                this.Edad_Padrino = 0;
                this.Contacto = "";
                this.Aportacion = 0;
                this.Fecha_Apadrinamiento = "";
            } 
        }

        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public string Raza { get; set; }
        public int Tamanio { get; set; }
        public int Peso { get; set; }
        public int Edad { get; set; } 
        public Boolean PPP { get; set; }
        public Boolean Vacunado { get; set; }
        public Boolean Enfermo { get; set; }
        public Uri Foto { get; set; }
        public Boolean Padrino { get; set; }
        public string Nombre_Padrino { get; set; }
        public int Edad_Padrino { set; get; }
        public string Contacto { set; get; }
        public int Aportacion { set; get; }
        public string Fecha_Apadrinamiento { set; get; }

    }
}
