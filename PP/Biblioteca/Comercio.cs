using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public abstract class Comercio
    {
        protected static Random _generadorDeEmpleados;
        protected int _cantidadDeEmpleados;
        protected Comerciante _comerciante;
        protected string _nombre;
        protected float _precioAlquiler;

        protected int CantidadDeEmpleados { get {
                if (_cantidadDeEmpleados == 0) {
                    _cantidadDeEmpleados = _generadorDeEmpleados.Next(1,100);
                }
                return _cantidadDeEmpleados;
            }  
            
            set => _cantidadDeEmpleados = value; }
        public Comerciante Comerciante { get => _comerciante; set => _comerciante = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public float PrecioAlquiler { get => _precioAlquiler; set => _precioAlquiler = value; }

        /// <summary>
        /// Constructor que inicializa el atributo estatico _Generadodeempleados
        /// </summary>
        static Comercio() {
            _generadorDeEmpleados = new Random();
        }
        public Comercio() { }
        public Comercio(float precioAlquiler, string nombreComercio, string nombre, string apellido)
        {
            this._comerciante = new Comerciante(apellido, nombre);
            this._nombre = nombreComercio;
            this._precioAlquiler = precioAlquiler;
        }

        /// <summary>
        /// Constructor que hace uso de la palabra reservada this para reutilizar codigo
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="comerciante"></param>
        /// <param name="precioAlquiler"></param>
        public Comercio(string nombre, Comerciante comerciante, float precioAlquiler) : this(precioAlquiler, nombre, comerciante.Nombre, comerciante.Apellido)
        {
        }
        /// <summary>
        /// Crea un stringbuilder donde va concatenando strings
        /// 
        /// </summary>
        /// <returns>Retorna un string de todo</returns>
        private string Mostrar() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre: {Nombre}");
            sb.AppendLine($"Comerciante: {Comerciante.Apellido}, {Comerciante.Nombre}");
            sb.AppendLine($"Cantidad de Empleados: {CantidadDeEmpleados}");

            return sb.ToString();
        }
        /// <summary>
        /// Compara comercios por nombre y por el objeto Comerciante
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns>retorna true si son iguales</returns>
        public static bool operator ==(Comercio c1, Comercio c2) {
            return c1.Nombre == c2.Nombre && c1.Comerciante == c2.Comerciante;
        }
        /// <summary>
        /// Compara que los comercios sean distintos usando sobrecarga de ==
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool operator !=(Comercio c1, Comercio c2) { return !(c1 == c2); }

        /// <summary>
        /// Retorna string con atributos
        /// </summary>
        /// <param name="comercio"></param>
        public static explicit operator string(Comercio comercio){
            
            return comercio.Mostrar();    
        }
        /// <summary>
        /// Compara objetos de tipo Comercio
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Comercio && this == (Comercio)obj;
        }

    }
}
