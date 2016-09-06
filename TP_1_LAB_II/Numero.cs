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

        private static double validarNumero(string numeroString)
        {
            double numeroDouble = 0;
            double.TryParse(numeroString, out numeroDouble);
            return numeroDouble;
        }
    }
}
