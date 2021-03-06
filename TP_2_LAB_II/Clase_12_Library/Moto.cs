﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Clase_12_Library_2; //Se agrego directiva using necesarias

namespace Clase_12_Library
{
    public class Moto : Vehiculo //Se hereda de vehiculo y se hace publica
    {
        public Moto(Vehiculo.EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }
        /// <summary>
        /// Las motos tienen 2 ruedas
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return 2;
            }
        }

        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("RUEDAS : {0}", this.CantidadRuedas);//Se utiliza appendformat
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString(); //Se castea a string
        }
    }
}
