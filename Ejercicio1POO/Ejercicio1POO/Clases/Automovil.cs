using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio1POO.Interfaces;

namespace Ejercicio1POO.Clases
{
    public class Automovil : Transporte, ITransporte,IAuto
    {
        public Automovil(int pasajeros): base(pasajeros) { }

        public string ActivarFrenoDeMano()
        {
            return "Activando freno de mano";
        }

        public string Avanzar()
        {
            return $"Avanzando...";
        }

        public string Detenerse()
        {
            return $"Detenémndose...";
        }

        public string IrDeReversa()
        {
            return "Realizando movimiento para ir en reversa";
        }

        public override string MostrarInfo()
        {
            return $"El automovil tiene {this.Pasajeros} pasajero/s";
        }

        public string TocarBocina()
        {
            return "Tocando bocina";
        }
    }
}
