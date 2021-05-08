using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica.MVC.Logic;
using Practica.MVC.Entities;

namespace Practica.MVC.Presentation
{
    public class EmployeesUI : BaseUI, IUI
    {
        EmployeesLogic logic = new EmployeesLogic();

        public bool Menu()
        {
            Console.Clear();
            Console.WriteLine("Ingrese:");
            Console.WriteLine("0. Salir");
            Console.WriteLine("1. Mostrar todos los empleados");
            Console.WriteLine("2. Agregar empleados");
            Console.WriteLine("3. Eliminar empleados");
            Console.WriteLine("4. Modificar empleados");
            Console.WriteLine("5. Volver al menú principal");

            inputString = Console.ReadLine();
            if (Int32.TryParse(inputString, out input))
            {
                input = Int32.Parse(inputString);
                switch (input)
                {
                    case 1:
                        ShowAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Delete();
                        break;
                    case 4:
                        Update();
                        break;
                    case 0:
                        return false;
                    case 5:
                        return true;
                    default:
                        break;
                }
                if (GoBack("empleados")){
                    Menu();
                    return true;
                } else {
                    return false;
                } 
            }
            else
            {
                Console.WriteLine("Error");
                if (GoBack("empleados")){
                    Menu();
                    return true;
                }
                else
                {
                    return false;
                }
            }

           
        }
        public void ShowAll()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Mostrando todos los empleados");
            logic.GetAll().ForEach(c => Console.WriteLine($"{c.EmployeeID} - {c.FirstName}, {c.LastName}"));
            Console.WriteLine("--------------------------------------------------------------------------------");
        }
        public void Add()
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
                logic.Add(new Employees
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
        }
        public void Delete()
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
                        logic.Delete(input);
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
        }
        public void Update()
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

                        logic.Update(new Employees
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
            
        }
    }
}
