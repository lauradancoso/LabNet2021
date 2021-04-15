using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1POO.Clases
{
    public class Automovil : Transporte
    {
        public Automovil(int pasajeros): base(pasajeros) { }

        public override string Avanzar()
        {
            return $"Avanzando...";
        }

        public override string Detenerse()
        {
            return $"Detenémndose...";
        }
        public override string MostrarInfo()
        {
            return $"El automovil tiene {this.Pasajeros} pasajero/s";
        }
    }
}
