using System;

namespace Practica.EF.Entities
{
    public class CustomersOrdersJoin
    {
        public string CustomerID { get; set; }

        public string CompanyName { get; set; }

        public string Region { get; set; }

        public DateTime? OrderDate { get; set; }

        public int CantOrders { get; set; }
    }
}
