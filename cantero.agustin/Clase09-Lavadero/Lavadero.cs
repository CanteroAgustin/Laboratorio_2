using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase09_Lavadero
{
    class Lavadero
    {
        private List<Vehiculo> _vehiculos;
        private float _precioAuto;
        private float _precioCamion;
        float _precioMoto;

        public List<Vehiculo> Vehiculos
        {
            get { return _vehiculos; }
        }

        public string Lavadero
        {
            get {
                StringBuilder sb = new StringBuilder();

                sb.Append("- Precio por auto: ");
                sb.Append(_precioAuto);
                sb.Append("- Precio por camion: ");
                sb.Append(_precioCamion);
                sb.Append("- Precio por moto: ");
                sb.Append(_precioMoto);

                foreach(Vehiculo v in _vehiculos){
                    if (v is Auto)
                    {
                        sb.AppendLine(((Auto)v).MostrarAuto());
                    }
                    else if (v is Camion)
                    {
                        sb.AppendLine(((Camion)v).MostrarCamion());
                    }
                    else
                    {
                        sb.AppendLine(((Moto)v).MostrarMoto());
                    }
                }

                return sb.ToString(); 
            }
        }

        
        public Lavadero()
        {
            _vehiculos = new List<Vehiculo>();
        }

        public Lavadero(float precioAuto, float precioCamion, float precioMoto)
        {
            this._precioAuto = precioAuto;
            this._precioCamion = precioCamion;
            this._precioMoto = precioMoto;
        }

        public Double MostrarTotalFacturado()
        {
            double total = 0;
            int contAuto = 0;
            int contCamion = 0;
            int contMoto = 0;

            foreach (Vehiculo v in _vehiculos)
            {
                if (v is Auto)
                {
                    contAuto++;
                }
                else if (v is Camion)
                {
                    contCamion++;
                }
                else
                {
                    contMoto++;
                }
            }
            total = (contAuto * _precioAuto) + (contCamion * _precioCamion) + (contMoto * _precioMoto);
            return total;
        }

        public Double MostrarTotalFacturado(EVehiculos vehiculo)
        {
            double total = 0;
            int contAuto = 0;
            int contCamion = 0;
            int contMoto = 0;

            foreach (Vehiculo v in _vehiculos)
            {
                if (v is Auto)
                {
                    contAuto++;
                }
                else if (v is Camion)
                {
                    contCamion++;
                }
                else
                {
                    contMoto++;
                }
            }
            if (vehiculo == EVehiculos.Auto)
            {
                total = (contAuto * _precioAuto);
            }
            else if (vehiculo == EVehiculos.Camion)
            {
                total = (contCamion * _precioCamion);
            }
            else
            {
                total = (contMoto * _precioMoto);
            }

            return total;
        }

        public static bool operator ==(Lavadero l, Vehiculo v)
        {
            bool retorno = false;

            foreach (Vehiculo v1 in l._vehiculos)
            {
                if (v1 == v)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Lavadero l, Vehiculo v)
        {
            return !(l==v);
        }

        public static Lavadero operator +(Lavadero l, Vehiculo v)
        {
            if (l != v)
            {
                l._vehiculos.Add(v);
            }
            return l;
        }

        public static Lavadero operator -(Lavadero l, Vehiculo v)
        {
            if (l == v)
            {
                l._vehiculos.Remove(v);
            }
            return l;
        }

        public static int OrdenarVehiculosPorPatente(Vehiculo v1, Vehiculo v2)
        {
            return string.Compare(v1.Patente, v2.Patente);
        }

        public int OrdenarVehiculosPorMarca(Vehiculo v1, Vehiculo v2)
        {
            return string.Compare(v1.Marca.ToString(), v2.Marca.ToString());
        }
    } 
}
