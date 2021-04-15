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
            List<Transporte> transportes = new List<Transporte>();

            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                transportes.Add(new Automovil(random.Next(1, 4)));
                transportes.Add(new Avion(random.Next(10, 200)));
            }
            
            Console.WriteLine("Mostrando información sobre los transportes:");
            foreach (var transporte in transportes)
            {
                Console.WriteLine(transporte.MostrarInfo());
            }

        }
    }
}
