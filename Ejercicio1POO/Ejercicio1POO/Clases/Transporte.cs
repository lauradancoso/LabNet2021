using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1POO.Clases
{
    public abstract class Transporte
    {
        private int pasajeros;

        protected Transporte(int pasajeros)
        {
            this.pasajeros = pasajeros;
        }

        public abstract string Avanzar();
        public abstract string Detenerse();
        public abstract string MostrarInfo();
        public int getPasajeros()
        {
            return pasajeros;
        }

    }
}
