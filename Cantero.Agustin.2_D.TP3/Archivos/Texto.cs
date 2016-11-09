using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;
using System.Xml.Serialization;
using EntidadesAbstractas;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda en archivo de texto una jornada especifica
        /// </summary>
        /// <param name="archivo">path del archivo</param>
        /// <param name="datos">datos de la jornada</param>
        /// <returns>Devuelve true si pudo guardar, sino archivosException</returns>
        public bool Guardar(string archivo, string datos)
        {
            string line = "<------------------------------------------>";
            try
            {
                StreamWriter sw = new StreamWriter(archivo);
                sw.Write(datos.ToString(), Encoding.UTF8);
                sw.Write(line, Encoding.UTF8);
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Lee un archivo de texto
        /// </summary>
        /// <param name="archivo">path del archivo</param>
        /// <param name="datos">cadena donde se guardaran los datos leidos</param>
        /// <returns>Devuelve true si pudo leer, sino archivosException</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                StreamReader sr = new StreamReader(archivo);
                datos = sr.ReadToEnd();
                sr.Close();
                return true;
            }   
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
