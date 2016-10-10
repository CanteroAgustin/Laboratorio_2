﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_12_Library; //directiva using necesarias

namespace Clase_12_Library_2
{
    public abstract class Vehiculo
    {
        public enum EMarca //Este enumerado debe ser publico
        {
            Yamaha, Chevrolet, Ford, Iveco, Scania, BMW
        }
        protected EMarca _marca;
        protected string _patente;
        protected ConsoleColor _color;

        public Vehiculo(string patente, EMarca marca, ConsoleColor color)//Se agrega constructor
        {
            this._patente = patente;
            this._marca = marca;
            this._color = color;
        }

        /// <summary>
        /// Retornará la cantidad de ruedas del vehículo
        /// </summary>
        public virtual short CantidadRuedas { get; set; }//debe ser virtual y publico

        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("PATENTE: {0}\r\n", this._patente);
            sb.AppendFormat("MARCA  : {0}\r\n", this._marca.ToString());
            sb.AppendFormat("COLOR  : {0}\r\n", this._color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString(); //casteo a string por que el tipo de retorno del metodo es string
        }

        /// <summary>
        /// Dos vehículos son iguales si comparten la misma patente
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)//Se completo este metodo para que cumpla con la funcilonalidad esperada
        {
            bool retorno = false;
            if (v1._patente.Equals(v2._patente))
            {
                retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// Dos vehículos son distintos si su patente es distinta
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
    }
}
