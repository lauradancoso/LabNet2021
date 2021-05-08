using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica.EF.Logic;
using Practica.EF.Entities;

namespace Practica.EF.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoriesUI categoriesUI = new CategoriesUI();
            EmployeesUI employeesUI = new EmployeesUI();

            string input;
            bool loop = false;

            do
            {
                Console.WriteLine("Escriba:");
                Console.WriteLine("1. Para operar con las categorias");
                Console.WriteLine("2. Para operar con los empleados");
                Console.WriteLine("3. Para Salir");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        loop = categoriesUI.Menu();
                        break;
                    case "2":
                        loop = employeesUI.Menu();
                        break;
                    case "3":
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Error");
                        loop = true;
                        break;
                }
            } while (loop);

            Console.WriteLine("Adiós!");
            Console.ReadLine();
        }
    }
}
