using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica.MVC.Entities;

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
            ///TODO seguir!

            context.SaveChanges();

        }
    }
}
