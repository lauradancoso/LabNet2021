using Practica.MVC.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Practica.MVC.Logic
{
    public class EmployeesLogic : BaseLogic, IABM<Employees>
    {
        public void Add(Employees newT)
        {
            context.Employees.Add(newT);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var employeeToDelete = context.Employees.Find(id);
            employeeToDelete.Employees1.Clear();
            employeeToDelete.Orders.Clear();
            employeeToDelete.Territories.Clear();
            context.SaveChanges();
            context.Employees.Remove(employeeToDelete);
            context.SaveChanges();

        }

        public List<Employees> GetAll()
        {
            return context.Employees.ToList();
        }

        public void Update(Employees updatedT)
        {

            var employeeToUpdate = context.Employees.Find(updatedT.EmployeeID);

            employeeToUpdate.FirstName = updatedT.FirstName;
            employeeToUpdate.LastName = updatedT.LastName;

            employeeToUpdate.Title = updatedT.Title;
            employeeToUpdate.TitleOfCourtesy = updatedT.TitleOfCourtesy;
            employeeToUpdate.BirthDate = updatedT.BirthDate;
            employeeToUpdate.HireDate = updatedT.HireDate;
            employeeToUpdate.Address = updatedT.Address;
            employeeToUpdate.City = updatedT.City;
            employeeToUpdate.Country = updatedT.Country;
            employeeToUpdate.HomePhone = updatedT.HomePhone;
            employeeToUpdate.PostalCode = updatedT.PostalCode;

            context.SaveChanges();

        }
    }
}
