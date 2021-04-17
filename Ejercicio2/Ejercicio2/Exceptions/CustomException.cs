using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException (string message) :base( $"Mensaje de la excepcion: {message}") { }

    }
}
