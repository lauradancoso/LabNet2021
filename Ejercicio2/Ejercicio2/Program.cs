using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio2.Extensions;
using Ejercicio2.Exceptions;

namespace Ejercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Practica ExtensionMethods + Exceptions + Unit Test (Opcional).

            //1)

            Console.WriteLine("1) DividirUnValorPorCero: ");
            DividirUnValorPorCero(0);
            Console.WriteLine("---------------------------");

            //2)

            Console.WriteLine("2) Division de dos numeros");
            Dividir();
            Console.WriteLine("---------------------------");

            //3)

            Console.WriteLine("3)");

            CapturarExceptionInLogic();
            Console.WriteLine("---------------------------");

            Console.WriteLine("4)");

            CapturarCustomExceptionInLogic();
            Console.WriteLine("---------------------------");
        }
        static void DividirUnValorPorCero(int valor)
        {
            Console.WriteLine(string.Format("Empezo la operacion de dividir el numero {0} por 0", valor));

            try
            {
                Console.WriteLine(valor.DividirPorCero());
            }
            catch (DivideByZeroException ex)
            {

                Console.WriteLine($"Ha fallado el {ex.Message}");
            }
            finally
            {
                Console.WriteLine(string.Format("Finalizo la operacion de dividir el numero {0} por 0", valor));
            }
            
        }

        static void Dividir()
        {
            Random random = new Random();

            List<string> mensajes = new List<string> 
            {
                "A Visual Studio no le gusta esto.",
                "Acaso estas intentando romperme?",
                "Mi maestra dijo que no se puede dividir por cero!"
            };


            int dividendo;
            int divisor;

            try
            {
                Console.WriteLine("Ingrese un numero (dividendo)");
                dividendo = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese otro numero (divisor)");
                divisor = Int32.Parse(Console.ReadLine());

                Console.WriteLine(string.Format("Empezo la operacion de dividir el numero {0} por {1}", dividendo, divisor));
                Console.WriteLine($"El resultado es {dividendo.DividirPor(divisor)}");
                Console.WriteLine(string.Format("Finalizo la operacion de dividir el numero {0} por {1}", dividendo, divisor));

            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(string.Format("{0} Ingresa un numero que no sea cero, pues: {1}", mensajes[random.Next(0,2)], ex.Message));
            }
            catch (Exception)
            {
                Console.WriteLine("Seguro ingreso una letra o no ingreso nada!");
            }
        }
        
        static void CapturarExceptionInLogic()
        {
            try
            {
                Logic.ThrowException();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message} - Type: {ex.GetType()}");                
            }
        }

        static void CapturarCustomExceptionInLogic()
        {
            try
            {
                Logic.ThrowCustomException("1234");
            }
            catch (CustomException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
