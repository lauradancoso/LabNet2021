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

            Console.WriteLine("Escriba 'a' para operar con las categorias, o 'b' para operar con los empleados");
            input = Console.ReadLine();

            switch (input)
            {
                case "a":
                    categoriesUI.Menu();
                    break;
                case "b":
                    employeesUI.Menu();
                    break;
                default:
                    break;
            }
            Console.ReadLine();


            

        }
    }
}
