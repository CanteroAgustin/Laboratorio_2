using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1_LAB_II
{
    class Calculadora
    {

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
