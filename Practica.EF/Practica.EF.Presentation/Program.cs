using Practica.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica.EF.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Querys querys = new Querys();

            List<string> consignas = new List<string>() {

                "Elija:",
                "1. Query para devolver objeto customer",
                "2. Query para devolver todos los productos sin stock",
                "3. Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad",
                "4. Query para devolver todos los customers de Washington",
                "5. Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789",
                "6. Query para devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula.",
                "7. Query para devolver Join entre Customers y Orders donde los customers sean de Washington y la fecha de orden sea mayor a 1/1/1997.",
                "8. Query para devolver los primeros 3 Customers de Washington",
                "9. Query para devolver lista de productos ordenados por nombre",
                "10. Query para devolver lista de productos ordenados por unit in stock de mayor a menor.",
                "11. Query para devolver las distintas categorías asociadas a los productos",
                "12. Query para devolver el primer elemento de una lista de productos",
                "13. Query para devolver los customer con la cantidad de ordenes asociadas",
                "0. Salir"
            };

            Action<string, Action> print = (consigna, query) =>
                                                            {
                                                                Console.WriteLine($"{consigna}\n");
                                                                query();
                                                                Console.WriteLine("\n--------------------------------------------------------------------------------\n");
                                                            };


            bool loop = true;
            string inputString;

            do
            {
                consignas.ForEach(c => Console.WriteLine(c));
                inputString = Console.ReadLine();
                try
                {
                    switch(Int32.Parse(inputString)){

                        case 1:

                            print(consignas[1], () => querys.GetCustomer("ALFKI").ToList().ForEach(c => Console.WriteLine($"Customer ID:{c.CustomerID} - {c.ContactName} : {c.ContactTitle}")));
    
                            break;

                        case 2:

                            print(consignas[2], () => querys.GetProductsOutOfStock().ToList().ForEach(p => Console.WriteLine($" ID: {p.ProductID} - Nombre: {p.ProductName} - Stock: {p.UnitsInStock}")));
                            
                            break;

                        case 3:

                            print(consignas[3], () => querys.GetProductsInStockWithUnitPrice3().ToList().ForEach(p => Console.WriteLine($" ID: {p.ProductID} - Nombre: {p.ProductName} - Stock: {p.UnitsInStock} - Precio unitario: ${p.UnitPrice}")));
                            
                            break;

                        case 4:

                            print(consignas[4], () => querys.GetCustomersFromWA().ToList().ForEach(c => Console.WriteLine($"Customer ID: {c.CustomerID} - {c.ContactName} : {c.ContactTitle} - Region: {c.Region}"))));

                            break;

                        case 5:

                            print(consignas[5], () =>
                            {
                                var query5 = querys.GetFirstProductWithId789();
                                Console.WriteLine((query5 == null) ? "No existe elemento con el ID 789" : string.Format("ID: {0} - Nombre: {1}", query5.ProductID, query5.ProductName));
                            });

                            break;

                        case 6:

                            print(consignas[6], () => querys.GetCustomersName().ToList().ForEach(c => Console.WriteLine($"Customer : {c} - CUSTOMER: {c.ToUpper()} ")));

                            break;
                        case 7:

                            print(consignas[7], () => querys.GetCustomersOrdersJoin().ToList().ForEach(c => Console.WriteLine($"Customer ID: {c.CustomerID} - Customer name: {c.CompanyName} - Region: {c.Region} - Fecha de orden: {c.OrderDate}")));

                            break;

                        case 0:
                            loop = false;
                            break;

                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("No se pudo realizar la operación. Vuelva a intentar");
                }

            } while (loop);
            //print(consignas[1], ()=> querys.GetCustomer("ALFKI").ToList().ForEach(c => Console.WriteLine($"Customer ID:{c.CustomerID} - {c.ContactName} : {c.ContactTitle}")));

            //print(consignas[2], ()=> querys.GetProductsOutOfStock().ToList().ForEach(p=>Console.WriteLine($" ID: {p.ProductID} - Nombre: {p.ProductName} - Stock: {p.UnitsInStock}")));

            //print(consignas[3], ()=> querys.GetProductsInStockWithUnitPrice3().ToList().ForEach(p => Console.WriteLine($" ID: {p.ProductID} - Nombre: {p.ProductName} - Stock: {p.UnitsInStock} - Precio unitario: ${p.UnitPrice}")));

            //print(consignas[4], ()=> querys.GetCustomersFromWA().ToList().ForEach(c => Console.WriteLine($"Customer ID: {c.CustomerID} - {c.ContactName} : {c.ContactTitle} - Region: {c.Region}"))));

            //print(consignas[5], () =>
            //{
            //    var query5 = querys.GetFirstProductWithId789();
            //    Console.WriteLine((query5 == null) ? "No existe elemento con el ID 789" : string.Format("ID: {0} - Nombre: {1}", query5.ProductID, query5.ProductName));
            //});

            //print(consignas[6], () => querys.GetCustomersName().ToList().ForEach(c => Console.WriteLine($"Customer : {c} - CUSTOMER: {c.ToUpper()} ")));

            //print(consignas[7], ()=> querys.GetCustomersOrdersJoin().ToList().ForEach(c => Console.WriteLine($"Customer ID: {c.CustomerID} - Customer name: {c.CompanyName} - Region: {c.Region} - Fecha de orden: {c.OrderDate}")));

            //print(consignas[8], () => querys.Get3CustomersFromWA().ToList().ForEach(c => Console.WriteLine($"Customer ID: {c.CustomerID} - {c.ContactName} : {c.ContactTitle} - Region: {c.Region}")));

            //print(consignas[9], () => querys.GetProductsOrderedByName().ToList().ForEach(p => Console.WriteLine(string.Format("ID: {0} - Nombre: {1}", p.ProductID, p.ProductName))));

            //print(consignas[10], () => querys.GetProductsOrderedByUnitInStock().ToList().ForEach(p => Console.WriteLine(string.Format("ID: {0} - Nombre: {1} - Stock: {2}", p.ProductID, p.ProductName, p.UnitsInStock))));

            //print(consignas[11], () => querys.GetCategoriesWithProductsAsociated().ToList().ForEach(c => Console.WriteLine(string.Format("Nombre categoria: {0}", c))));

            //print(consignas[12], () => querys.GetFirstProduct().ToList().ForEach(p => Console.WriteLine(string.Format("ID Producto: {0} - Nombre: {1}", p.ProductID, p.ProductName))));

            //print(consignas[13], () => querys.GetCustomersOrdersCount().ToList().ForEach(c => Console.WriteLine(string.Format("ID Customer: {0} - Nombre: {1} - Cantidad de ordenes : {2}", c.CustomerID, c.CompanyName, c.CantOrders))));


            Console.ReadLine();

           
        }
    }
}
