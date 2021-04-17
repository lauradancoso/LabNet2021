using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Extensions
{
    public static class IntegerExtensions
    {
        //Esto va a romper, pero esa es la idea
        public static int DividirPorCero(this int valor) => valor / 0;

        public static int DividirPor(this int dividendo, int divisor)=> dividendo / divisor;
        
    }
}
