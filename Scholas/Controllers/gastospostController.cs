using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scholas.Models;
using Scholas.Classes;
namespace Scholas.Controllers
{
    public class gastospostController : Controller
    {
        //
        // GET: /gastospost/
        private GlobalInfo db = new GlobalInfo();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(gastospost gastospost)
        {
            if (ModelState.IsValid)
            {
                db.gastos.Add(gastospost.gastos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gastospost.gastos);
        }


    }
}
