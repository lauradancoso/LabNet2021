using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ejercicio2.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Exceptions.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod()]
        public void ThrowExceptionTest_ShouldThrowIndexOutOfRange()
        {
            //arrange
            int[] array = { 1, 2 };
            //act
            Console.WriteLine(array[3]);
            //assert
        }
    }
}