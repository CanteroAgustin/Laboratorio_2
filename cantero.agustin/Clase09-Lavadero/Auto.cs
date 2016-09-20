using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase09_Lavadero
{
    class Auto : Vehiculo
    {
        protected int _cantidadAsientos;
        protected float _tara;
        protected float _cilindrada;

        public Auto(int cantidadAsientos, float tara, float cilindrada, string patente, Byte cantRuedas, EMarcas marca)
            : base(patente, cantRuedas, marca)
        {
            this._cantidadAsientos = cantidadAsientos;
            this._tara = tara;
            this._cilindrada = cilindrada;
        }

        public string MostrarAuto()
        {
            return base.Mostrar();
        }
    }
}
