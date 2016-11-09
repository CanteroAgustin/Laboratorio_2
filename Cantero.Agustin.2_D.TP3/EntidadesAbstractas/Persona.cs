using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        
        public enum ENacionalidad {Argentino, Extranjero }

        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        #region constructores

        public Persona()
        {
            
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.Dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }

        #endregion

        #region propiedades

        /// <summary>
        /// Devuelve un apellido valido
        /// </summary>
        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = Persona.ValidarNombreApellido(value); }
        }

        /// <summary>
        /// Devuelve un dni valido
        /// </summary>
        public int Dni
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = Persona.ValidarDni(this.Nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get { return _nacionalidad; }
            set { _nacionalidad = value; }
        }

        /// <summary>
        /// Devuelve un nombre valido
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { this._nombre = Persona.ValidarNombreApellido(value); }
        }

        /// <summary>
        /// Devuelve un dni valido
        /// </summary>
        public  string StringToDni
        {
            set
            {
                this._dni = Persona.ValidarDni(this.Nacionalidad, value);
            }
        }

        #endregion

        #region metodos

        /// <summary>
        /// valida que la nacionalidad ingresada se corresponda
        /// con el dni ingresado
        /// </summary>
        /// <param name="nacionalidad">nacionalidad ingresada</param>
        /// <param name="dato">dni ingresado</param>
        /// <returns>devuelve el dni si es valido, sino nacionalidadInvalidaException</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                        throw new NacionalidadInvalidaException(dato.ToString());
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 89999999 || dato > 99999999)
                        throw new NacionalidadInvalidaException();
                    break;
            }
            return dato;
        }

        /// <summary>
        /// Valida que el dni ingresado sea un numero valido
        /// </summary>
        /// <param name="nacionalidad">nacionalidad</param>
        /// <param name="dato">dni</param>
        /// <returns>le pasa a ValidarDni el dni validado</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            dato = dato.Replace(".", "");
            if (dato.Length < 1 || dato.Length > 8)
                throw new DniInvalidoException(dato.ToString());
            int numeroDni;
            try
            {
                numeroDni = Int32.Parse(dato);
            }
            catch (SystemException e)
            {
                throw new DniInvalidoException(dato.ToString(), e);
            }

            return Persona.ValidarDni(nacionalidad, numeroDni);
        }

        /// <summary>
        /// Valida nombre o apellido
        /// </summary>
        /// <param name="dato"> nombre o apellido a validar</param>
        /// <returns> devuelve la cadena validada sino devuelve una cadena vacia</returns>
        private static string ValidarNombreApellido(string dato)
        {
            Regex regex = new Regex(@"[a-zA-Z]*");
            Match match = regex.Match(dato);

            if (match.Success)
                return match.Value;
            else
                return "";
        }

        /// <summary>
        /// Hace publicos los datos de persona
        /// </summary>
        /// <returns> devuelve un string con los datos de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("NOMBRE COMPLETO: ");
            sb.Append(Apellido);
            sb.Append(", ");
            sb.AppendLine(Nombre);
            sb.Append("NACIONALIDAD: ");
            sb.AppendLine(Nacionalidad.ToString());
            sb.AppendLine();
            return sb.ToString();
        }
        
        #endregion

    }
}
