using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using association.Models;

namespace association.Controllers
{
    public class VilleController : Controller
    {
        private ville v = new ville();
        public ActionResult Index()
        {
            Model1 m = new Model1();
            ViewBag.villes = new SelectList(m.villes, "idville", "ville");
            return View();
        }
    }
}
