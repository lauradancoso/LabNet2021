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
            throw new Exception();
        }
        public static void ThrowCustomException()
        {
            throw new CustomException("Esta es una excepcion del tipo Custom exception");
        }
    }
}
