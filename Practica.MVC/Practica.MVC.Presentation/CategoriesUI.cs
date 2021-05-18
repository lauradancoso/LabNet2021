using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica.MVC.Logic;
using Practica.MVC.Entities;

namespace Practica.MVC.Presentation
{
    public class CategoriesUI : BaseUI, IUI
    {

        CategoriesLogic logic = new CategoriesLogic();

        public bool Menu()
        {

            Console.Clear();
            Console.WriteLine("Ingrese:");
            Console.WriteLine("0. Salir");
            Console.WriteLine("1. Mostrar todas las categorias");
            Console.WriteLine("2. Agregar categoria");
            Console.WriteLine("3. Eliminar categoria");
            Console.WriteLine("4. Modificar categoria");
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
                    case 5:
                        return true;
                    case 0:
                        return false;

                    default:
                        break;
                }
                if (GoBack("categorias"))
                {
                    Menu();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Error");
                if (GoBack("categorias"))
                {
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
            Console.WriteLine("Mostrando todas las categorias");
            logic.GetAll().ForEach(c => Console.WriteLine($"{c.CategoryID} - {c.CategoryName}"));
            Console.WriteLine("--------------------------------------------------------------------------------");
        }
        public void Add()
        {
            Console.Clear();
            string name;
            string description;
            Console.WriteLine("Ingrese nombre de la categoria");
            name = Console.ReadLine();
            Console.WriteLine("Ingrese descripcion de la categoria");
            description = Console.ReadLine();

            try
            {
                logic.Add(new Categories
                {
                    CategoryName = name,
                    Description = description
                });
                Console.WriteLine("Categoria agregada!");
            }
            catch (Exception)
            {
                Console.WriteLine("No se pudo agregar la categoria");
            }
        }
        public void Delete()
        {
            loop = true;

            do
            {
                Console.WriteLine("Ingrese el id de la categoria a eliminar");
                inputString = Console.ReadLine();
                if (Int32.TryParse(inputString, out input))
                {
                    input = Int32.Parse(inputString);
                    try
                    {
                        logic.Delete(input);
                        Console.WriteLine("Categoria elminada!");
                        loop = false;
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("No existe ese ID, intente nuevamente, de lo contrario, presione 0 para salir");
                        if (Console.ReadLine().Equals("0"))
                            loop = false;

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No se pudo eliminar la categoria por un problema en la base de datos, intente nuevamente");
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
                Console.WriteLine("Ingrese el id de la categoria a modificar");
                inputString = Console.ReadLine();
                if (Int32.TryParse(inputString, out input))
                {
                    input = Int32.Parse(inputString);
                    try
                    {
                        string name;
                        string description;
                        Console.WriteLine("Ingrese nombre de la categoria");
                        name = Console.ReadLine();
                        Console.WriteLine("Ingrese descripcion de la categoria");
                        description = Console.ReadLine();
                        logic.Update(new Categories
                        {
                            CategoryID = input,
                            CategoryName = name,
                            Description = description
                        });
                        Console.WriteLine("Categoria modificada!");
                        loop = false;
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("No existe ese ID, intente nuevamente, de lo contrario, presione 0 para salir");
                        if (Console.ReadLine().Equals("0"))
                            loop = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No se pudo modificar la categoria, intente nuevamente");
                        loop = false;
                    }
                }
            } while (loop);
        }
    }
}