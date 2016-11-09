﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        static string mensajeBase = "Alumno repetido.";

        public AlumnoRepetidoException()
            : base(mensajeBase)
        {

        }
    }
}
