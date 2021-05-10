using Practica.MVC.Logic;
using Practica.MVC.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Practica.MVC.MVC.Controllers
{
    public class DogController : Controller
    {
        
        public ActionResult Index()
        {
            DogLogic dogLogic = new DogLogic();
            var responseString = dogLogic.GetApi();
            var dogs = new JavaScriptSerializer().Deserialize<DogView>(responseString);
            return View(dogs);
        }
    }
}