using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using Archivos;
using System.Xml.Serialization;
using System.IO;

namespace EntidadesInstanciables
{
    [Serializable]
    [XmlInclude(typeof(Jornada))]
    [XmlInclude(typeof(Instructor))]
    [XmlInclude(typeof(Alumno))]

    public class Gimnasio
    {
        public enum EClases { Pilates, Natacion, CrossFit, Yoga }

        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornada;

        /// <summary>
        /// Devuelve una jornada especifica de la lista
        /// </summary>
        /// <param name="index">indice de la lista</param>
        /// <returns>jornada en el indice recibido por parametro</returns>
        public Jornada this[int index]
        {
            get
            {
                return this.Jornada[index];
            }
        }

        #region constructores

        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }

        #endregion

        #region propiedades

        public List<Alumno> Alumnos
        {
            get { return _alumnos; }
        }

        public List<Instructor> Instructores
        {
            get { return _instructores; }
        }

        public List<Jornada> Jornada
        {
            get { return _jornada; }
        }

        #endregion
        
        #region metodos
        
        /// <summary>
        /// Muestra los datos del gimnasio
        /// </summary>
        /// <param name="gim">gimnasio</param>
        /// <returns>cadena  con los datos del gimnasio</returns>
        private static string MostrarDatos(Gimnasio gim)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            foreach(Jornada j in gim.Jornada)
            {
                sb.Append(j.ToString());
                sb.AppendLine("<------------------------------------------>");
                sb.AppendLine();
            }
            
            return sb.ToString();
        }

        /// <summary>
        /// hace publico el metodo mostrarDatos
        /// </summary>
        /// <returns>Metodo MostrarDatos</returns>
        public override string ToString()
        {
                return Gimnasio.MostrarDatos(this);
        }

        /// <summary>
        /// serializa un gimnasio en formato xml
        /// </summary>
        /// <param name="gim">gimnasio</param>
        /// <returns>true si se serializo correctamente</returns>
        public static bool Guardar(Gimnasio gim)
        {
            Xml<Gimnasio> xml = new Xml<Gimnasio>();
            xml.Guardar("../../../Gimnasio.xml", gim);
            return true;
        }

        /// <summary>
        /// Deserializa un gimnasio
        /// </summary>
        /// <param name="gim">gimnasio</param>
        /// <returns>true si salio bien</returns>
        public static bool Leer(Gimnasio gim)
        {
            Xml<Gimnasio> xml = new Xml<Gimnasio>();
            xml.Leer("../../../Gimnasio.xml",out gim);
            return true;
        }
        #endregion
        
        #region sobrecargas

        /// <summary>
        /// Valida si un  alumno esta en la lista del Gimnasio
        /// </summary>
        /// <param name="g">gimnasio</param>
        /// <param name="a">alumno</param>
        /// <returns>true si esta en la lista</returns>
        public static bool operator ==(Gimnasio g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno al in g.Alumnos)
            {
                if (al == a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Valida si un  instructor esta en la lista del Gimnasio
        /// </summary>
        /// <param name="g">gimnasio</param>
        /// <param name="i">instructor</param>
        /// <returns>true si esta en la lista</returns>
        public static bool operator ==(Gimnasio g, Instructor i)
        {
            bool retorno = true;

            foreach (Instructor inst in g.Instructores)
            {
                if (inst == i)
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// busca un instructor para la clase
        /// </summary>
        /// <param name="g">gimnasio</param>
        /// <param name="c">clase</param>
        /// <returns>el primer instructor disponible</returns>
        public static Instructor operator ==(Gimnasio g, Gimnasio.EClases c)
        {
            foreach (Instructor i in g.Instructores)
            {
                if (i == c) // i==c devuelve true si i._clasesdeldia == c
                {
                    return i;
                }
            }
            throw new SinInstructorException();
        }

        /// <summary>
        /// Valida que no haya ningun instructor que pueda dar la clase
        /// </summary>
        /// <param name="g">gimnasio</param>
        /// <param name="c">clase</param>
        /// <returns>el primer instructor que no pueda dar la clase</returns>
        public static Instructor operator !=(Gimnasio g, Gimnasio.EClases c)
        {
            foreach (Instructor i in g.Instructores)
            {
                if (i != c)
                {
                    return i;
                }
            }
            throw new SinInstructorException();
        }

        /// <summary>
        /// Instancia una nueva jornada y le carga la clase,
        /// el primer instructor disponible y
        /// la lista de alumnos
        /// </summary>
        /// <param name="g">gimnasio</param>
        /// <param name="c">clase</param>
        /// <returns>el gimnasio con la nueva jornada</returns>
        public static Gimnasio operator +(Gimnasio g, Gimnasio.EClases c)
        {
            Jornada j = new Jornada(c, g==c);//g==c (devuelve el primer instructor que pueda dar la clase)
            foreach(Alumno a in g.Alumnos)
            {
                if(a == c) // a == c devuelve true si el alumno asiste a la clase
                {
                    j += a;
                }
            }
            g.Jornada.Add(j);
            return g;           
        }

        /// <summary>
        /// Agrega un alumno al gimnasio si es que no esta en  la lista
        /// </summary>
        /// <param name="g">gimnasio</param>
        /// <param name="a">alumno</param>
        /// <returns>el gimnasio con  el nuevo alumno</returns>
        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            if (g == a)
            {
                throw new AlumnoRepetidoException();
            }
            g.Alumnos.Add(a);
            return g;
        }

        /// <summary>
        /// Agrega un instructor al gimnasio si es que no esta en  la lista
        /// </summary>
        /// <param name="g">gimnasio</param>
        /// <param name="i">instructor</param>
        /// <returns>el gimnasio con  el nuevo instructor</returns>
        public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            if (g == i)
            {
                g.Instructores.Add(i);
            }
            return g;
        }

        #endregion
    }
}
