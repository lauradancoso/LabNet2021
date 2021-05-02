using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica.EF.Logic;
using Practica.EF.Entities;

namespace Practica.EF.Presentation
{
    public class CategoriesUI
    {
        CategoriesContext categoriesContext = new CategoriesContext();
        int input;
        string inputString;
        bool loop;

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Ingrese:");
            Console.WriteLine("1. Mostrar todas las categorias");
            Console.WriteLine("2. Agregar categoria");
            Console.WriteLine("3. Eliminar categoria");
            Console.WriteLine("4. Modificar categoria");
            Console.WriteLine("0. Salir");

            inputString = Console.ReadLine();
            if (Int32.TryParse(inputString, out input))
            {
                input = Int32.Parse(inputString);
                switch (input)
                {
                    case 1:
                        ShowAllCategories();
                        break;
                    case 2:
                        AddCategory();
                        break;
                    case 3:
                        DeleteCategory();
                        break;
                    case 4:
                        UpdateCategory();
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
        private void ShowAllCategories()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Mostrando todas las categorias");
            categoriesContext.GetAll().ForEach(c => Console.WriteLine($"{c.CategoryID} - {c.CategoryName}"));
            Console.WriteLine("--------------------------------------------------------------------------------");
            GoBack();
        }
        private void GoBack()
        {
            loop = true;
            do
            {
                Console.WriteLine("Para volver al menú de Categorias presione 1, para salir 0");
                inputString = Console.ReadLine();
                if (Int32.TryParse(inputString, out input))
                {
                    input = Int32.Parse(inputString);
                    loop = (input==1 || input==0) ? false : true;
                }
            } while (loop);
            if (input == 1)
            {
                Menu();
            }else
            {
                return;
            }

        }
        private void AddCategory()
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
                categoriesContext.Add(new Categories
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
            GoBack();
        }
        private void DeleteCategory()
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
                        categoriesContext.Delete(input);
                        Console.WriteLine("Categoria elminada!");
                        loop = false;
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("No existe ese ID, intente nuevamente");
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException)
                    {
                        Console.WriteLine("No se pudo eliminar la categoria por un problema en la base de datos, intente nuevamente");
                        loop = false;
                    }
                }
            } while (loop);
            GoBack();
        }

        private void UpdateCategory()
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
                        categoriesContext.Update(new Categories
                        {
                            CategoryID = input,
                            CategoryName = name,
                            Description = description
                        });
                        Console.WriteLine("Categoria modificada!");
                        loop = false;
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("No existe ese ID, intente nuevamente");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No se pudo eliminar la categoria, intente nuevamente");
                        loop = false;
                    }
                }
            } while (loop);
            GoBack();
        }
    }
}
