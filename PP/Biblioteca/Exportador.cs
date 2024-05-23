using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Exportador : Comercio
    {
        private ETipoProducto _tipo;

        public Exportador() { }

        /// <summary>
        /// Constructor que utiliza la palabra reservada base para llamar al constructor de la clase padre. Y También asigna el atributo tipo de la clase
        /// </summary>
        /// <param name="nombreComercio"></param>
        /// <param name="precioAlquiler"></param>
        /// <param name="comerciante"></param>
        /// <param name="tipo"></param>
        public Exportador(string nombreComercio, float precioAlquiler, Comerciante comerciante, ETipoProducto tipo) :base(nombreComercio, comerciante, precioAlquiler)
        { 
            this._tipo = tipo;
        }

        public string Mostrar() { 
            StringBuilder sb = new StringBuilder();
            sb.Append((string)this);   
            sb.AppendLine($"Tipo: {_tipo}");
            return sb.ToString();
        }

        /// <summary>
        /// Compara 2 exportadores por tipo y usando el equals para comparar los objetos
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator ==(Exportador e1, Exportador e2) { 
            return e1._tipo==e2._tipo && e1.Equals(e2);   
        }

        public static bool operator !=(Exportador e1, Exportador e2) { 
            return !(e1 == e2);
        }
        /// <summary>
        /// Conversion implicita que al recibir un Exportador retorna su unico atributo
        /// </summary>
        /// <param name="exportador"></param>
        public static implicit operator ETipoProducto(Exportador exportador) {
            return exportador._tipo;
        }
    }
}
