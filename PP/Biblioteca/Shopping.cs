using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Biblioteca
{
    [XmlInclude(typeof(Exportador))]
    [XmlInclude(typeof(Importador))]
    [XmlInclude(typeof(Comerciante))]

    public class Shopping
    {
        private int _capacidadMaxima;
        private List<Comercio> _comercios;

        private Shopping()
        {
            _comercios = new List<Comercio>();
        }
        private Shopping(int capacidadMaxima) : this() {
            this._capacidadMaxima = capacidadMaxima;
        }

        public int CapacidadMaxima { get => _capacidadMaxima; set => _capacidadMaxima = value; }
        public List<Comercio> Comercios { get => _comercios; set => _comercios = value; }

        /// <summary>
        /// Las siguientes propiedades llaman al metodo obtener precio para calcular según el parametro que se les inserte. Los set son para poder serializar y deserializar
        /// </summary>
        public double PrecioDeExportadores { get => ObtenerPrecio(EComercios.Exportador); set { } }
        public double PrecioDeImportadores { get => ObtenerPrecio(EComercios.Importador); set { } }
        public double PrecioTotal { get => ObtenerPrecio(EComercios.Ambos); set { } }



        public static string Mostrar(Shopping shopping)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Capacidad del Shopping: {shopping._capacidadMaxima}");
            sb.AppendLine($"Total de importadores: ${shopping.PrecioDeImportadores}");
            sb.AppendLine($"Total de Exportadores: ${shopping.PrecioDeExportadores}");
            sb.AppendLine($"Total: ${shopping.PrecioTotal}");
            sb.AppendLine("\n-------------------LISTA DE COMERCIOS--------------------------");
            foreach (var item in shopping.Comercios)
            {
                if (item is Importador)
                {
                    sb.AppendLine(((Importador)item).Mostrar());
                }
                else if (item is Exportador)
                {
                    sb.AppendLine(((Exportador)item).Mostrar());
                }
            }


            return sb.ToString();
        }
        public static implicit operator Shopping(int capacidad) { 
            return new Shopping(capacidad);    
        }

        public static bool operator ==(Shopping shopping, Comercio comercio) { 
            return shopping._comercios.Contains(comercio);
        }

        public static bool operator !=(Shopping shopping, Comercio comercio) { 
            return !(shopping == comercio);
        }
        /// <summary>
        /// Agrega un comercio a la lista de shopping en caso de que no esté y que no se haya superado la capacidad maxima de la lista
        /// </summary>
        /// <param name="shopping"></param>
        /// <param name="comercio"></param>
        /// <returns></returns>
        public static Shopping operator +(Shopping shopping, Comercio comercio) {
            if (shopping != comercio && shopping._capacidadMaxima > shopping._comercios.Count)
            {
                

                    shopping._comercios.Add(comercio);
 
                return shopping;
            }
            else {
                return shopping;
            }
        }
        /// <summary>
        /// Recorre toda la lista de la instancia de shopping acumulando el precio de alquiler de la clase Comercio según el tipo que se le mande por parametro
        /// </summary>
        /// <param name="tipo">Especifica el criterio de busqueda</param>
        /// <returns> Retorno la acumulación al recorrer la lista</returns>
        private double ObtenerPrecio(EComercios tipo)
        {   double retorno=0;
            

            foreach (Comercio item in this._comercios) {
                if (tipo == EComercios.Ambos) {

                    retorno = item.PrecioAlquiler+ retorno;

                }else if (item.GetType().Name == tipo.ToString()) {
                    if (item is Exportador)
                    {
                        retorno = retorno + item.PrecioAlquiler;
                    }
                    else {
                        retorno = retorno + item.PrecioAlquiler;
                    }
                }
            }

    
            return retorno;
        }
        /// <summary>
        /// Crea un archivo(en caso de que no exista, si no sobreescribe) y guarda una instancia de shopping
        /// </summary>
        /// <param name="rutaArchivo"></param>
        public void GuardarShopping(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
            {
                using (FileStream fileStream = File.Create(rutaArchivo))
                {


                    fileStream.Close();
                }
            }

            using (StreamWriter streamWriter = new StreamWriter(rutaArchivo))
            {
                streamWriter.WriteLine(Mostrar(this));

            }
        }
        /// <summary>
        /// Serializa una instancia de shopping y la guarda en un archivo XML
        /// </summary>
        /// <param name="rutaArchivo"></param>
        public void SerializarShopping(string rutaArchivo)
        {

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Shopping));
            using (StreamWriter streamWriter = new StreamWriter(rutaArchivo))
            {

                xmlSerializer.Serialize(streamWriter, this)
;

            }
        }
        /// <summary>
        /// Abre un archivo XML
        /// </summary>
        /// <param name="rutaArchivo"></param>
        /// <returns>Retorna la clase Shopping</returns>
        public static Shopping DeserializarShopping(string rutaArchivo)
        {

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Shopping));
            using (StreamReader streamReader = new StreamReader(rutaArchivo))
            {

                return (Shopping)xmlSerializer.Deserialize(streamReader);

            }

        }


    }
}
