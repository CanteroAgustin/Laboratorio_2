using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : PersonaGimnacio
    {
        public enum EEstadoCuenta { AlDia, Deudor, MesPrueba }

        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoDeCuenta;

        #region constructores

        public Alumno()
        {
                
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoDeCuenta)
            :this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoDeCuenta = estadoDeCuenta;
        }

        #endregion

        #region propiedades

        public Gimnasio.EClases ClaseQueToma
        {
            get { return _claseQueToma; }
            set { _claseQueToma = value; }
        }

        public EEstadoCuenta EstadoDeCuenta
        {
            get { return _estadoDeCuenta; }
            set { _estadoDeCuenta = value; }
        }

        #endregion

        #region metodos

        /// <summary>
        /// Imprime los datos del alumno
        /// </summary>
        /// <returns>cadena con los datos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.Append("ESTADO DE LA CUENTA: ");
            sb.AppendLine(EstadoDeCuenta.ToString());
            sb.AppendLine(ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Devuelve  una cadena con la clase que toma el alumno
        /// </summary>
        /// <returns> cadena con la clase que toma el  alumno </returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE "+ClaseQueToma;
        }

        /// <summary>
        /// Hace publico el metodo mostrarDatos
        /// </summary>
        /// <returns>metodo MostrarDatos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        } 

        #endregion
        
        #region sobrecargas

        /// <summary>
        /// Valida si el alumno participa de la clase recibida
        /// y si tiene cuota al dia
        /// </summary>
        /// <param name="a">alumno</param>
        /// <param name="clase">clase</param>
        /// <returns>true si asiste a la clase y no debe</returns>
        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            bool retorno = false;

            if (a.ClaseQueToma == clase && a.EstadoDeCuenta != EEstadoCuenta.Deudor)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            bool retorno = false;

            if (a.ClaseQueToma != clase)
            {
                retorno = true;
            }

            return retorno;
        }

        #endregion

        
    }
}
