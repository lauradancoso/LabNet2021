using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Exceptions
{
    public static class Logic
    {
        public static void ThrowException()
        {
            int[] array = {1,2};

            Console.WriteLine(array[3]);

            //En principio solo había escrito esta linea que simplemente lanza la exception,
            //pero viendo que todos hicieron muchas cosas distintas a eso finalmente escribí esas 2 lineas que al ejecutarse generar una exception
            //throw new Exception();

        }
        //Pregunta: es necesario testear un método que unicamente arroja una exception? o qué es lo correcto?
        public static void ThrowCustomException()
        {
            throw new CustomException("Esta es una excepcion del tipo Custom exception");
        }
    }
}
