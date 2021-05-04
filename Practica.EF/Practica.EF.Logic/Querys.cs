using Practica.EF.Data;
using Practica.EF.Entities;
using System;
using System.Linq;

namespace Practica.EF.Logic
{
    public class Querys
    {
        readonly NorthwindContext db;

        public Querys()
        {
            db = new NorthwindContext();
        }

        // 1. Query para devolver objeto customer

        public IQueryable<Customers> GetCustomer(string id)
        {
            return from cust in db.Customers
                   where cust.CustomerID.Equals(id)
                   select cust;
        }

        //2. Query para devolver todos los productos sin stock

        public IQueryable<Products> GetProductsOutOfStock()
        {
            return db.Products.Where(p => p.UnitsInStock == 0 || p.UnitsInStock == null);
        }

        //3. Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad

        public IQueryable<Products> GetProductsInStockWithUnitPrice3()
        {
            return db.Products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);
        }

        //4. Query para devolver todos los customers de Washington

        public IQueryable<Customers> GetCustomersFromWA()
        {
            return from cust in db.Customers
                   where cust.Region.Equals("WA")
                   select cust;
        }

        //5. Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789

        public Products GetFirstProductWithId789()
        {
            return db.Products.FirstOrDefault(p => p.ProductID == 789);
        }

        //6. Query para devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula.

        public IQueryable<String> GetCustomersName()
        {
            return  from cust in db.Customers
                    select cust.CompanyName;
        }

        //7. Query para devolver Join entre Customers y Orders donde los customers sean de Washington y la fecha de orden sea mayor a 1/1/1997.

        public IQueryable<CustomersOrdersJoin> GetCustomersOrdersJoin()
        {
            return from cust in db.Customers
                   join ord in db.Orders
                       on cust.CustomerID equals ord.CustomerID
                   where (cust.Region != null && cust.Region.Equals("WA")) && DateTime.Compare((DateTime)ord.OrderDate, new DateTime(1997, 1, 1)) > 0
                   select new CustomersOrdersJoin
                   {
                       CustomerID =cust.CustomerID,
                       CompanyName = cust.CompanyName,
                       Region = cust.Region,
                       OrderDate = ord.OrderDate
                   };
        }

        //8. Query para devolver los primeros 3 Customers de Washington

        public IQueryable<Customers> Get3CustomersFromWA()
        {
            return db.Customers.Where(c => c.Region.Equals("WA")).Take(3);
        }

        //"9. Query para devolver lista de productos ordenados por nombre"

        public IQueryable<Products> GetProductsOrderedByName()
        {
            return from prod in db.Products
                   orderby prod.ProductName
                   select prod;
        }

        //"10. Query para devolver lista de productos ordenados por unit in stock de mayor a menor."

        public IQueryable<Products> GetProductsOrderedByUnitInStock()
        {
            return from prod in db.Products
                   orderby prod.UnitsInStock descending
                   select prod;
        }
        //intentar hacerlo con method query

        //"11. Query para devolver las distintas categorías asociadas a los productos"

        public IQueryable<String> GetCategoriesWithProductsAsociated()
        {
            return (from cat in db.Categories

                    join prod in db.Products
                     on cat.CategoryID equals prod.CategoryID

                    where cat.CategoryID == prod.CategoryID
                    select cat.CategoryName).Distinct();
        }

        //"12. Query para devolver el primer elemento de una lista de productos"

        public IQueryable<Products> GetFirstProduct()
        {
            return db.Products.Take(1);
        }

        //"13. Query para devolver los customer con la cantidad de ordenes asociadas"

        public IQueryable<CustomersOrdersJoin> GetCustomersOrdersCount()
        {
            return (from cust in db.Customers
                   join ord in db.Orders
                       on cust.CustomerID equals ord.CustomerID
                    select new CustomersOrdersJoin
                   {
                       CustomerID = cust.CustomerID,
                       CompanyName = cust.CompanyName,
                       CantOrders = cust.Orders.Count()
                   }).Distinct();
        }
    }
}
