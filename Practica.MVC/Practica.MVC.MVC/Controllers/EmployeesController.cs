using System.Web.Mvc;
using Practica.MVC.Logic;
using Practica.MVC.MVC.Models;
using Practica.MVC.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Practica.MVC.MVC.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeesLogic logic = new EmployeesLogic();

        public ActionResult Index()
        {
            List<Employees> employees = logic.GetAll();
            List<EmployeesView> employeesViews = employees.Select(e => new EmployeesView
            {
                EmployeeID = e.EmployeeID,
                LastName = e.LastName,
                FirstName = e.FirstName,
                Title = e.Title,
                BirthDate = e.BirthDate.Value.Date,
                HireDate = e.HireDate.Value.Date,
                Address = e.Address,
                City = e.City,
                PostalCode = e.PostalCode,
                Country = e.Country,
                HomePhone = e.HomePhone
            }).ToList();
            return View(employeesViews);
        }
        public ActionResult InsertOrEdit(int id)
        {
            if (id == 0)
            {
                return View(new EmployeesView{ });
            }
            else
            {
                try
                {
                    Employees employee = logic.GetAll().FirstOrDefault(e => e.EmployeeID == id);
                    EmployeesView employeesView = new EmployeesView
                    {
                        EmployeeID = employee.EmployeeID,
                        LastName = employee.LastName,
                        FirstName = employee.FirstName,
                        Address = employee.Address,
                        City = employee.City,
                        PostalCode = employee.PostalCode,
                        Country = employee.Country,
                        HomePhone = employee.HomePhone,
                        BirthDate = employee.BirthDate,
                        HireDate = employee.HireDate,

                    };
                    return View(employeesView);
                }
                catch (System.Exception)
                {
                    return RedirectToAction("Index", "Error");
                }
            }
        }

        [HttpPost]
        public ActionResult InsertOrEdit(EmployeesView employee)
        {
            //si los campos no son válidos se devuelve la misma vista pero se activan los ErrorMessage
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            try
            {
                Employees employeeEntity = new Employees
                {
                    EmployeeID = employee.EmployeeID,
                    LastName = employee.LastName,
                    FirstName = employee.FirstName,
                    Address = employee.Address,
                    City = employee.City,
                    PostalCode = employee.PostalCode,
                    Country = employee.Country,
                    HomePhone = employee.HomePhone,
                    BirthDate = employee.BirthDate,
                    HireDate = employee.HireDate,
                };
                if (employee.EmployeeID == 0)
                {
                    logic.Add(employeeEntity);
                }
                else
                {
                    logic.Update(employeeEntity);
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {

                return RedirectToAction("Index", "Error");
            }

        }

        public ActionResult Delete(int id)
        {
            try
            {
                logic.Delete(id);
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {

                return RedirectToAction("Index", "Error");
            }
        }
    }
}