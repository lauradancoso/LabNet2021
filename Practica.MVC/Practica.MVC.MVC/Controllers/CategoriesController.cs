using System.Web.Mvc;
using Practica.MVC.Logic;
using Practica.MVC.MVC.Models;
using Practica.MVC.Entities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Practica.MVC.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        CategoriesLogic logic = new CategoriesLogic();

        public ActionResult Index()
        {
            try
            {
                List<Categories> categories = logic.GetAll();
                List<CategoriesView> categoriesViews = categories.Select(c => new CategoriesView
                {
                    CategoryID = c.CategoryID,
                    CategoryName = c.CategoryName,
                    Description = c.Description

                }).ToList();

                return View(categoriesViews);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }         
        }

        public ActionResult InsertOrEdit(int id)
        {
            if(id == 0)
            {
                return View(new CategoriesView { });
            }
            else
            {
                try
                {
                    Categories category = logic.GetAll().FirstOrDefault(c => c.CategoryID == id);
                    CategoriesView categoryView = new CategoriesView
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName,
                        Description = category.Description
                    };
                    return View(categoryView);
                }
                catch (Exception ex)
                {
                    return this.RedirectToAction("Index","Error", new {msg = ex.Message});
                }
            }
        }

        [HttpPost]
        public ActionResult InsertOrEdit(CategoriesView category)
        {
            //si los campos no son válidos se devuelve la misma vista pero se activan los ErrorMessage
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            try
            {
                Categories categoryEntity = new Categories {
                                            CategoryID = category.CategoryID,
                                            CategoryName = category.CategoryName,
                                            Description = category.Description
                };
                if(category.CategoryID == 0)
                {
                    logic.Add(categoryEntity);
                }
                else
                {
                    logic.Update(categoryEntity);
                }
                
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return this.RedirectToAction("Index", "Error", new { msg = ex.Message });
            }

        }

        public ActionResult Delete(int id)
        {
            try
            {
                logic.Delete(id);
                return RedirectToAction("Index");
            }
            catch (NullReferenceException)
            {
                return new HttpNotFoundResult();
            }
            catch (Exception ex)
            {
                return this.RedirectToAction("Index", "Error", new { msg = ex.Message });
            }
        }
    }
}