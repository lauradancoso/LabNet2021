using Practica.MVC.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica.MVC.MVC.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(string msg)
        {

            return View(new ErrorView(msg));
        }
    }
}