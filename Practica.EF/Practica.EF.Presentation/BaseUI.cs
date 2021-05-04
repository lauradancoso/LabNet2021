using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.Presentation
{
    public class BaseUI
    {
        public int input;
        public string inputString;
        public bool loop;

        public bool GoBack(String to)
        {
            loop = true;
            do
            {
                Console.WriteLine($"Para volver al menú de {to} presione 1, para salir 0");
                inputString = Console.ReadLine();
                if (Int32.TryParse(inputString, out input))
                {
                    input = Int32.Parse(inputString);
                    loop = (input == 1 || input == 0) ? false : true;
                }
            } while (loop);

            return (input == 1);

        }
    }
}
