using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica.EF.Entities;

namespace Practica.EF.Logic
{
    public class EmployeesContext : BaseLogic, IABM<Employees>
    {
        public void Add(Employees newT)
        {
            context.Employees.Add(newT);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            try
            {
                var employeeToDelete = context.Employees.Find(id);
                context.Employees.Remove(employeeToDelete);
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Employees> GetAll()
        {
            return context.Employees.ToList();
        }

        public void Update(Employees updatedT)
        {
            try
            {
                var employeeToUpdate = context.Employees.Find(updatedT.EmployeeID);

                employeeToUpdate.FirstName = updatedT.FirstName;
                employeeToUpdate.LastName = updatedT.LastName;
                if (updatedT.Title != null)
                    employeeToUpdate.Title = updatedT.Title;
                if (updatedT.TitleOfCourtesy != null)
                    employeeToUpdate.TitleOfCourtesy = updatedT.TitleOfCourtesy;
                if (updatedT.BirthDate != null)
                    employeeToUpdate.BirthDate = updatedT.BirthDate;
                if (updatedT.HireDate != null)
                    employeeToUpdate.HireDate = updatedT.HireDate;
                ///TODO seguir!

                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
