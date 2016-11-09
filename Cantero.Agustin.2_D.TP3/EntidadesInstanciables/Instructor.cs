using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Instructor : PersonaGimnacio
    {
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;

        #region constructores

        public Instructor()
        {
                
        }

        static Instructor()
        {
            _random = new Random();
        }

        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClases(); 
        }

        #endregion

        #region metodos

        /// <summary>
        /// Muestra los datos del  instructor
        /// </summary>
        /// <returns>cadena con los datos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append(base.MostrarDatos());
            sb.AppendLine(ParticiparEnClase());
            
            return sb.ToString();
        }


        /// <summary>
        /// Hace publico el metodo MostrarDatos
        /// </summary>
        /// <returns>MostrarDatos()</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Imprime las clases del dia
        /// </summary>
        /// <returns>clases del dia</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA: ");
            foreach (Gimnasio.EClases c in this._clasesDelDia)
            {
                sb.AppendLine(c.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Carga el atributo _clasesDelDia con dos clases al azar
        /// </summary>
        private void _randomClases()
        {
            int r;
            for (int i = 0; i < 2; i++)
            {
                r = _random.Next(1,5);
                switch (r)
                {
                    case 1:
                        this._clasesDelDia.Enqueue(Gimnasio.EClases.Natacion);
                        break;
                    case 2:
                        this._clasesDelDia.Enqueue(Gimnasio.EClases.Pilates);
                        break;
                    case 3:
                        this._clasesDelDia.Enqueue(Gimnasio.EClases.CrossFit);                        
                        break;
                    case 4:
                        this._clasesDelDia.Enqueue(Gimnasio.EClases.Yoga);
                        break;
                }
            }
        }
        #endregion

        #region sobrecargas

        /// <summary>
        /// Una clase es igual al instructor si el mismo es capaz de darla
        /// </summary>
        /// <param name="i">instructor</param>
        /// <param name="clase">clase</param>
        /// <returns>true si son iguales</returns>
        public static bool operator ==(Instructor i, Gimnasio.EClases clase)
        {
            bool retorno = false;

            foreach (Gimnasio.EClases c in i._clasesDelDia)
            {
                if (c == clase)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator !=(Instructor i, Gimnasio.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
