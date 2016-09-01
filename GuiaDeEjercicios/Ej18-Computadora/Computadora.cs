using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ej18_Computadora3;
using Ej18_Computadora2;

namespace Ej18_Computadora1
{
    class Computadora
    {
        private bool _estaEncendida;
        private EMarca _marca;
        private float _peso;
        private EProcesador _procesador;

        public bool getEstaEncendida()
        {
            return this._estaEncendida;
        }

        public EMarca getMarca()
        {
            return this._marca;
        }

        public float getPeso()
        {
            return this._peso;
        }

        public EProcesador getProcesador()
        {
            return this._procesador;
        }

        public void set(bool estaEncendida)
        {
            this._estaEncendida = estaEncendida;
        }

        public void set(EMarca marca)
        {
            this._marca = marca;
        }

        public void set(float peso)
        {
            this._peso = peso;
        }

        public void set(EProcesador procesador)
        {
            this._procesador = procesador;
        }
    }

    


}
