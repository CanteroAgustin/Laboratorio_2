using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntidadesAbstractas
{
    public abstract class PersonaGimnacio : Persona
    {

        private int _identificador;

        #region constructores

        public PersonaGimnacio()
        {

        }

        public PersonaGimnacio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._identificador = id;
        }

        #endregion

        #region propiedades

        public int Identificador
        {
            get { return _identificador; }
        }

        #endregion
        
        #region metodos

        /// <summary>
        /// Compara que dos objetos sean del mismo tipo
        /// </summary>
        /// <param name="obj">objeto a comparar</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this.GetType() == obj.GetType();
        }

        /// <summary>
        /// Muestra los datos del personaGimnasio
        /// </summary>
        /// <returns>cadena con los datos de personaGimnasio</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append("CARNET NUMERO: ");
            sb.AppendLine(Identificador.ToString());
            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        #endregion
        
        #region sobrecargas
        /// <summary>
        /// Compara dos personaGimnasioen base al tipo y el identificador o el dni
        /// </summary>
        /// <param name="pg1">primer personaGimnasio</param>
        /// <param name="pg2">segundo personaGimnasio</param>
        /// <returns>true si son iguales</returns>
        public static bool operator == (PersonaGimnacio pg1, PersonaGimnacio pg2)
        {
            bool retorno = false;

            if (pg1.Equals(pg2) && (pg1.Identificador == pg2.Identificador || pg1.Dni == pg2.Dni))
            {
                retorno = true;
            }
            
            return retorno;
        }

        public static bool operator !=(PersonaGimnacio pg1, PersonaGimnacio pg2)
        {
            return !(pg1==pg2);
        }

        #endregion
    }
}
