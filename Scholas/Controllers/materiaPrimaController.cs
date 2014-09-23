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
    public class materiaPrimaController : Controller
    {
        private GlobalInfo db = new GlobalInfo();

        //
        // GET: /materiaPrima/

        public ViewResult Index()
        {
            return View(db.materia_primas.ToList());
        }

        //
        // GET: /materiaPrima/Details/5

        public ViewResult Details(int id)
        {
            materia_primas materia_primas = db.materia_primas.Find(id);
            return View(materia_primas);
        }

        //
        // GET: /materiaPrima/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /materiaPrima/Create

        [HttpPost]
        public ActionResult Create(materia_primas materia_primas)
        {
            if (ModelState.IsValid)
            {
                db.materia_primas.Add(materia_primas);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(materia_primas);
        }
        
        //
        // GET: /materiaPrima/Edit/5
 
        public ActionResult Edit(int id)
        {
            materiaPrimaEdit materiaPrimaEdit = new materiaPrimaEdit();
           
            List<categoria_materia_primas> categoria_materia_primas = new List<categoria_materia_primas>();
            materia_primas materia_primas = new materia_primas();
            materia_primas = db.materia_primas.Find(id);

            categoria_materia_primas = db.categoria_materia_primas.ToList();
            materiaPrimaEdit.categoria_materia_primas = categoria_materia_primas ;
            materiaPrimaEdit.id = materia_primas.id;
            materiaPrimaEdit.codigo_smk = materia_primas.codigo_smk;
            materiaPrimaEdit.descricao = materia_primas.descricao;
            materiaPrimaEdit.unidade = materia_primas.unidade ;
            materiaPrimaEdit.categoria_materia_primas_id =  materia_primas.categoria_materia_primas_id;


            return View(materiaPrimaEdit);
        }

        //
        // POST: /materiaPrima/Edit/5

        [HttpPost]
        public ActionResult Edit(materia_primas materia_primas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materia_primas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materia_primas);
        }

        //
        // GET: /materiaPrima/Delete/5
 
        public ActionResult Delete(int id)
        {
            materia_primas materia_primas = db.materia_primas.Find(id);
            return View(materia_primas);
        }

        //
        // POST: /materiaPrima/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            materia_primas materia_primas = db.materia_primas.Find(id);
            db.materia_primas.Remove(materia_primas);
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