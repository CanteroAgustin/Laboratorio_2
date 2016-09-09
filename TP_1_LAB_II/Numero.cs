using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1_LAB_II
{
    class Numero
    {
        private double numero;

        public Numero()
        {
            this.numero = 0;

        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string numero)
        {
            setNumero(numero);
        }

        private void setNumero(string numero)
        {
            this.numero = validarNumero(numero);
        }

        public double getNumero()
        {
            return this.numero;
        }

        /// <summary>
        /// Recibe una cadena y valida que el contenido sea un double valido,
        /// lo castea lo guarda en otra variable y lo devuelve.
        /// </summary>
        /// <param name="numeroString">Cadena a validar</param>
        /// <returns>Contenido de la cadena casteado a double</returns>
        private static double validarNumero(string numeroString)
        {
            double numeroDouble = 0;
            double.TryParse(numeroString, out numeroDouble);
            return numeroDouble;
        }
    }
}
