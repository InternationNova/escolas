using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scholas.Models;
using Scholas.Classes;
using System.Data.SqlClient;
using System.Configuration;

namespace Scholas.Controllers
{ 
    public class consumosController : Controller
    {
        private GlobalInfo db = new GlobalInfo();
        string str_connection = ConfigurationManager.ConnectionStrings["GlobalInfo"].ConnectionString;
       
        //
        // GET: /consumos/

        public ViewResult Index()
        {
            return View(db.consumos.ToList());
        }

        //
        // GET: /consumos/Details/5

        public ViewResult Details(int id)
        {
            consumos consumos = db.consumos.Find(id);
            return View(consumos);
        }

        //
        // GET: /consumos/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /consumos/Create

        [HttpPost]
        public ActionResult Create(consumos consumos)
        {
            if (ModelState.IsValid)
            {
                db.consumos.Add(consumos);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(consumos);
        }
        
        //
        // GET: /consumos/Edit/5
 
        public ActionResult Edit(int id)
        {
            consumosEdit consumosEdit = new consumosEdit();
            List<materia_primas> materia_primas = new List<materia_primas>();
            
           
            
            string str_query = @"select co.id, mp.id as mpid, descricao, quantidade, co.unidade from consumos co
											join materia_primas mp on mp.id = co.materia_primas_id
											where co.id = @id";
            using (SqlConnection conn = new SqlConnection(str_connection))
            using (SqlCommand cmd = new SqlCommand(str_query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int nId = Convert.ToInt32(reader["id"]);
                    string codigo_smk = reader["codigo_smk"].ToString();
                    int quantidade = Convert.ToInt32(reader["quantidade"]);
                    string descricao = reader["descricao"].ToString();
                    string unidade = reader["unidade"].ToString();

                    consumosEdit.quantidade = quantidade;
                    consumosEdit.unidade = unidade;
                    materia_primas = db.materia_primas.ToList();

                    consumosEdit.materia_primas = materia_primas;

                }

                conn.Close();
            }

            return View(consumosEdit);
        }

        //
        // POST: /consumos/Edit/5

        [HttpPost]
        public ActionResult Edit(consumos consumos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consumos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consumos);
        }

        //
        // GET: /consumos/Delete/5
 
        public ActionResult Delete(int id)
        {
            consumos consumos = db.consumos.Find(id);
            return View(consumos);
        }

        //
        // POST: /consumos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            consumos consumos = db.consumos.Find(id);
            db.consumos.Remove(consumos);
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