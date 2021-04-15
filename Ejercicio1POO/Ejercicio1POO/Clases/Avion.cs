using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1POO.Clases
{
    public class Avion : Transporte
    {
        public Avion(int pasajeros) : base(pasajeros) { }

        public override string Avanzar()
        {
            return $"Despegando...";
        }

        public override string Detenerse()
        {
            return $"Aterrizando...";
        }

        public override string MostrarInfo()
        {
            return $"El avión tiene {this.getPasajeros()} pasajero/s";
        }
    }
}