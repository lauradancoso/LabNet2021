using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica.EF.Logic;
using Practica.EF.Entities;

namespace Practica.EF.Presentation
{
    public class EmployeesUI
    {
        EmployeesContext employeesContext = new EmployeesContext();
        int input;
        string inputString;
        bool loop;

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Ingrese:");
            Console.WriteLine("1. Mostrar todos los empleados");
            Console.WriteLine("2. Agregar empleados");
            Console.WriteLine("3. Eliminar empleados");
            Console.WriteLine("4. Modificar empleados");
            Console.WriteLine("0. Salir");

            inputString = Console.ReadLine();
            if (Int32.TryParse(inputString, out input))
            {
                input = Int32.Parse(inputString);
                switch (input)
                {
                    case 1:
                        ShowAllEmployees();
                        break;
                    case 2:
                        AddEmployee();
                        break;
                    case 3:
                        DeleteEmployee();
                        break;
                    case 4:
                        UpdateEmployee();
                        break;
                    case 0:
                        return;
                    default:
                        GoBack();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Error");
                GoBack();
            }


        }
        private void ShowAllEmployees()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Mostrando todos los empleados");
            employeesContext.GetAll().ForEach(c => Console.WriteLine($"{c.EmployeeID} - {c.LastName}, {c.LastName}"));
            Console.WriteLine("--------------------------------------------------------------------------------");
            GoBack();
        }
        private void GoBack()
        {
            loop = true;
            do
            {
                Console.WriteLine("Para volver al menú de Empleados presione 1, para salir 0");
                inputString = Console.ReadLine();
                if (Int32.TryParse(inputString, out input))
                {
                    input = Int32.Parse(inputString);
                    loop = (input == 1 || input == 0) ? false : true;
                }
            } while (loop);
            if (input == 1)
            {
                Menu();
            }
            else if (input == 0)
            {
                return;
            }

        }
        private void AddEmployee()
        {
            Console.Clear();
            string name;
            string lastname;
            Console.WriteLine("Ingrese nombre del empleado");
            name = Console.ReadLine();
            Console.WriteLine("Ingrese apellido del empleado");
            lastname = Console.ReadLine();

            //TODO: ingresar el resto de los campos
            try
            {
                employeesContext.Add(new Employees
                {
                    FirstName = name,
                    LastName = lastname
                });
                Console.WriteLine("Empleado agregado!");
            }
            catch (Exception)
            {
                Console.WriteLine("No se pudo agregar el empleado");
            }
            GoBack();
        }
        private void DeleteEmployee()
        {
            loop = true;

            do
            {
                Console.WriteLine("Ingrese el id del empleado a eliminar");
                inputString = Console.ReadLine();
                if (Int32.TryParse(inputString, out input))
                {
                    input = Int32.Parse(inputString);
                    try
                    {
                        employeesContext.Delete(input);
                        Console.WriteLine("Empleado elminado!");
                        loop = false;
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("No existe ese ID, intente nuevamente");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No se pudo eliminar el empleado, intente nuevamente");
                        loop = false;
                    }
                }
            } while (loop);
            GoBack();
        }

        private void UpdateEmployee()
        {
            Console.Clear();

            loop = true;

            do
            {
                Console.WriteLine("Ingrese el id del empleado a modificar");
                inputString = Console.ReadLine();
                if (Int32.TryParse(inputString, out input))
                {
                    input = Int32.Parse(inputString);
                    try
                    {
                        string name;
                        string lastname;
                        Console.WriteLine("Ingrese nombre del empleado");
                        name = Console.ReadLine();
                        Console.WriteLine("Ingrese apellido del empleado");
                        lastname = Console.ReadLine();

                        //TODO: ingresar el resto de los campos

                        employeesContext.Add(new Employees
                        {
                            EmployeeID = input,
                            FirstName = name,
                            LastName = lastname
                        });
                        Console.WriteLine("Empleado modificado!");
                        loop = false;
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("No existe ese ID, intente nuevamente");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No se pudo modificar el empleado, intente nuevamente");
                        loop = false;
                    }
                }
            } while (loop);
            GoBack();
        }
    }
}
