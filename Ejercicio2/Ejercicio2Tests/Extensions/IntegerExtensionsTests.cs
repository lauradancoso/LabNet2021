using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ejercicio2.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Extensions.Tests
{
    [TestClass()]
    public class IntegerExtensionsTests
    {
        //Method que prueba cuando la division se hace correctamente
        [TestMethod()]
        public void DividirPorTest()
        {
            //arrange

            int dividendo = 2;
            int divisor = 2;
            int resultadoEsperado = 1;

            //act

            int actual = dividendo.DividirPor(divisor);

            //assert

            Assert.AreEqual(resultadoEsperado,actual);
        }

        //Method que prueba cuando la division arroja una exception
        //Espera una excepcion de tipo DivideByZeroException
        [ExpectedException(typeof(DivideByZeroException))]
        [TestMethod()]
        public void DividirPorTest_DividePorCero_ArrojaDivideByZeroException()
        {
            //arrange

            int dividendo = 2;
            int divisor = 0;

            //act

            dividendo.DividirPor(divisor);

            //assert manejado por ExpectedException
        }

        //no puedo testear la excepcion que arrojaría si pusiera un valor que no sea cero dado que mi method no te lo permite,
        // pero si los valores se ingresan por consola capturo ese error en Program.cs
    }
}