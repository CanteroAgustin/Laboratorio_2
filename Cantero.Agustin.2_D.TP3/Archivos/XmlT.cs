using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Excepciones;
using System.Xml;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Serializa un objeto en formato xml
        /// </summary>
        /// <param name="archivo">path del archivo</param>
        /// <param name="datos">objeto a ser serializado</param>
        /// <returns>Devuelve true si pudo guardar, sino archivosException</returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(datos.GetType());
                Stream stream = new FileStream(archivo, FileMode.Create);
                ser.Serialize(stream, datos);
                stream.Close(); 
                return true;
            }
            
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            
        }

        /// <summary>
        /// Deserializa un objeto y lo guarda en el objeto de salida
        /// </summary>
        /// <param name="archivo">path del archivo</param>
        /// <param name="datos">objeto donde se guardaran los datos deserializados</param>
        /// <returns>Devuelve true si pudo leer, sino archivosException</returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                string a =typeof(T).ToString();
                XmlSerializer ser = new XmlSerializer(typeof(T));
                StreamReader reader = new StreamReader(archivo);
                datos = (T)ser.Deserialize(reader);
                Console.Write(datos.ToString());
                reader.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
