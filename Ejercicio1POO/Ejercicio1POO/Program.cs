using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio1POO.Clases;

namespace Ejercicio1POO
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Transporte> transportes = new List<Transporte> 
            {
                new Avion(100),
                new Avion(30),
                new Avion(10),
                new Avion(5),
                new Avion(200),
                new Automovil(4),
                new Automovil(3),
                new Automovil(5),
                new Automovil(2),
                new Automovil(3)
            };

            Console.WriteLine("Mostrando información sobre los transportes:");
            foreach (var transporte in transportes)
            {
                Console.WriteLine(transporte.MostrarInfo());
            }

        }
    }
}
