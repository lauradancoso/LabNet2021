using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio1POO.Interfaces;

namespace Ejercicio1POO.Clases
{
    public class Avion : Transporte, ITransporte, IAvion
    {
        public Avion(int pasajeros) : base(pasajeros) { }

        public string Alabeo()
        {
            return "Realizando movimiento del eje longitudinal";
        }

        public string Avanzar()
        {
            return $"Despegando...";
        }

        public string Cabeceo()
        {
            return "Realizando movimiento del eje transversal";
        }

        public string Detenerse()
        {
            return $"Aterrizando...";
        }

        public string Guiñada()
        {
            return "Realizando movimiento del eje vertical";
        }

        public override string MostrarInfo()
        {
            return $"El avión tiene {this.Pasajeros} pasajero/s";
        }
    }
}