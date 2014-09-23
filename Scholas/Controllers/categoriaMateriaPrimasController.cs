using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scholas.Models;
using System.Configuration;

namespace Scholas.Controllers
{ 
    public class categoriaMateriaPrimasController : Controller
    {
        private GlobalInfo db = new GlobalInfo();

        //
        // GET: /categoriaMateriaPrimas/

        public ViewResult Index()
        {
            return View(db.categoria_materia_primas.ToList());
        }

        //
        // GET: /categoriaMateriaPrimas/Details/5

        public ViewResult Details(int id)
        {
            categoria_materia_primas categoria_materia_primas = db.categoria_materia_primas.Find(id);
            return View(categoria_materia_primas);
        }

        //
        // GET: /categoriaMateriaPrimas/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /categoriaMateriaPrimas/Create

        [HttpPost]
        public ActionResult Create(categoria_materia_primas categoria_materia_primas)
        {
            if (ModelState.IsValid)
            {
                db.categoria_materia_primas.Add(categoria_materia_primas);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(categoria_materia_primas);
        }
        
        //
        // GET: /categoriaMateriaPrimas/Edit/5
 
        public ActionResult Edit(int id)
        {
            categoria_materia_primas categoria_materia_primas = db.categoria_materia_primas.Find(id);
            return View(categoria_materia_primas);
        }

        //
        // POST: /categoriaMateriaPrimas/Edit/5

        [HttpPost]
        public ActionResult Edit(categoria_materia_primas categoria_materia_primas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoria_materia_primas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria_materia_primas);
        }

        //
        // GET: /categoriaMateriaPrimas/Delete/5
 
        public ActionResult Delete(int id)
        {
            categoria_materia_primas categoria_materia_primas = db.categoria_materia_primas.Find(id);
            return View(categoria_materia_primas);
        }

        //
        // POST: /categoriaMateriaPrimas/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            categoria_materia_primas categoria_materia_primas = db.categoria_materia_primas.Find(id);
            db.categoria_materia_primas.Remove(categoria_materia_primas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}