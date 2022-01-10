using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    class Socio
    {
        public Socio(string nombre, string apellidos, string dni, string telefono, string entidad_Bancaria, string cuenta_Bancaria, double saldo_Cuenta_Bancaria, Uri foto_Perfil)
        {
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.DNI = dni;
            this.Telefono = telefono;
            this.Entidad_Bancaria = entidad_Bancaria;
            this.Cuenta_Bancaria = cuenta_Bancaria;
            this.Saldo_Cuenta_Bancaria = saldo_Cuenta_Bancaria;
            this.Foto_Perfil = foto_Perfil;
        }

        public string Nombre { set; get; }
        public string Apellidos { set; get; }
        public string DNI { set; get; }
        public string Telefono { set; get; }
        public string Entidad_Bancaria { get; set; }
        public string Cuenta_Bancaria { set; get; }    
        public double Saldo_Cuenta_Bancaria { set; get; }
        public Uri Foto_Perfil { set; get; }
        

        
    }
}
