using Practica.MVC.Logic;
using Practica.MVC.Entities;
using Practica.MVC.WA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Practica.MVC.WA.Controllers
{
    public class CategoriesController : ApiController
    {
        CategoriesLogic logic = new CategoriesLogic();

        public IEnumerable<CategoriesRequest> Index()
        {
            List<Categories> categories = logic.GetAll();
            List<CategoriesRequest> categoriesViews = categories.Select(c => new CategoriesRequest
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
                Description = c.Description

            }).ToList();

            return categoriesViews;
        }

        //// GET: Categories/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Categories/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Categories/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Categories/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Categories/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Categories/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Categories/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
