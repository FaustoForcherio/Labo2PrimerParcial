using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Comerciante
    {
        private string _apellido;
        private string _nombre;

        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }

        public Comerciante() { }
        public Comerciante(string apellido, string nombre) { 
            this._apellido = apellido;
            this._nombre = nombre;
        }
        /// <summary>
        /// Compara comerciantes por nombre y apellidos
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns>Retorna true si son iguales, false caso contrario</returns>
        public static bool operator ==(Comerciante c1, Comerciante c2) { 
            return c1.Nombre== c2.Nombre&&c1.Apellido==c2.Apellido;
        }

        public static bool operator !=(Comerciante c1, Comerciante c2) { 
            return !(c1 == c2);
        }



    }
}
