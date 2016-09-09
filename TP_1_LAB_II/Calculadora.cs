using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1_LAB_II
{
    class Calculadora
    {
        /// <summary>
        /// Realiza una operacion matematica (definida por la variable operador) 
        /// entre dos numeros recibidos por parametro.
        /// </summary>
        /// <param name="numero1">Primer Operando</param>
        /// <param name="numero2">Segundo Operando</param>
        /// <param name="operador">Operacion</param>
        /// <returns>Devuelve el resultado de la operacion entre numero1 y numero2</returns>
        public double operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado=0;
            switch (operador)
            {
                case "+":
                    resultado = numero1.getNumero() + numero2.getNumero();
                break;
                case "-":
                    resultado = numero1.getNumero() - numero2.getNumero();
                break;
                case "*":
                    resultado = numero1.getNumero() * numero2.getNumero();
                break;
                case "/":
                //Si el valor del segundo operando es 0, Se setea un 0 automaticamente en el resultado.
                if (numero2.getNumero() == 0)
                {
                    resultado = 0;
                }
                else
                {
                    resultado = numero1.getNumero() / numero2.getNumero();
                }
                    
                break;
            }
            return resultado;
        }

        /// <summary>
        /// Valida que la cadena recibida tenga un operador valido
        /// </summary>
        /// <param name="operador">Cadena que contiene al operador</param>
        /// <returns>Devuelve el operador si es valido, sino devuelve '+'</returns>
        public string validarOperador(string operador)
        {
            string retorno = operador;
            if (operador == "")
            {
                retorno = "+";
            }
            return retorno;
        }
    }
}
