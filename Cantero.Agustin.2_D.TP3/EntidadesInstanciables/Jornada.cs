using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using Archivos;
using System.IO;

namespace EntidadesInstanciables 
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Instructor _instructor;
        private Gimnasio.EClases _clase;
        
        #region constructores

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Gimnasio.EClases clase, Instructor instructor)
            :this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        #endregion

        #region propiedades

        public List<Alumno> Alumnos
        {
            get { return _alumnos; }
        }

        public Instructor Instructor
        {
            get { return _instructor; }
        }

        public Gimnasio.EClases Clase
        {
            get { return _clase; }
        }
        #endregion

        #region sobrecargas

        /// <summary>
        /// Una jornada es igual a un alumno si
        /// el mismo esta  en la lista
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>true  si son iguales</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach(Alumno al in j.Alumnos)
            {
                if (al == a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// agrega un alumno a la jornada si el mismo
        /// no estaba previamente cargado
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>true si son iguales</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {

            foreach (Alumno al in j.Alumnos)
            {
                if (al == a)
                {
                    throw new AlumnoRepetidoException();
                }
            }
            j.Alumnos.Add(a);
            
            return j;
        }

        #endregion

        #region metodos

        /// <summary>
        /// muestra los datos de la jornada
        /// </summary>
        /// <returns>cadena con los datos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CLASE DE ");
            sb.Append(this._clase);
            sb.Append(" POR ");
            sb.Append(this.Instructor.ToString());
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno a in this.Alumnos)
            {
                sb.AppendLine(a.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Escribe e n un txt los datos de la jornada
        /// </summary>
        /// <param name="jornada">jornada</param>
        /// <returns>true si se pudo escribir</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto txt = new Texto();
            txt.Guardar("../../../jornada.txt", jornada.ToString());
            return true;
        }

        /// <summary>
        /// Lee un archivo de texto
        /// </summary>
        /// <param name="jornada">jornada</param>
        /// <returns>true si se pudo leer</returns>
        public static bool Leer()
        {
            string datos;
            Texto txt = new Texto();
            txt.Leer("../../../jornada.txt", out datos);

            /*
             * TODO borrar
             *Salida para testear la lectura de un txt
             *Console.WriteLine(datos); 
             */

            return true;
        }

        #endregion
    }
}
