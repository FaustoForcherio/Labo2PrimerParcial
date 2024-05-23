using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Importador : Comercio
    {
        private EPaises _paisOrigen;

        public Importador() { }

        /// <summary>
        /// Constructor que hace uso de la palabra reservada base
        /// </summary>
        /// <param name="nombreComercio"></param>
        /// <param name="precioAlquiler"></param>
        /// <param name="comerciante"></param>
        /// <param name="paisOrigen"></param>
        public Importador(string nombreComercio, float precioAlquiler, Comerciante comerciante, EPaises paisOrigen) : base(nombreComercio, comerciante, precioAlquiler) {
            this._paisOrigen = paisOrigen;
        }

        /// <summary>
        /// Concatena strings
        /// </summary>
        /// <returns>Retorna una string</returns>
        public string Mostrar() { 
            StringBuilder sb = new StringBuilder();
            sb.Append((string)this);         
            sb.AppendLine($"País de Origen: {this._paisOrigen}");

            return sb.ToString();
        }

        /// <summary>
        /// Compara importadores por tipo de pais de origen y por objetos usando equals
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns>Retorna true si son iguales, caso contrario false</returns>
        public static bool operator ==(Importador i1, Importador i2)
        {
            return i1._paisOrigen == i2._paisOrigen && i1.Equals(i2);  
        }

        public static bool operator !=(Importador i1, Importador i2) {
            return !(i1 == i2);
        }

        /// <summary>
        /// Sobrecarga implicita de EPaisas, donde recibe un importador y retorna el pais de origen de ese importador
        /// </summary>
        /// <param name="i"></param>
        public static implicit operator EPaises(Importador i) {

            return i._paisOrigen;
        }

    }
}
