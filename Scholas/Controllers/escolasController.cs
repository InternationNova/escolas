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

namespace Scholas.Controllers
{ 
    public class escolasController : Controller
    {
        private GlobalInfo db = new GlobalInfo();
        private static string str_connection = "Data Source=rys-PC;Initial Catalog=school;Persist Security Info=True;User ID=sa;Password=P@$$word";
       
        //
        // GET: /escolas/
        
        public ViewResult Index()
        {
            List<escolasIndex> escolasIndex = new List<escolasIndex>();
            escolasIndex arrescolaIndex = new escolasIndex();

            escolas escolas = new escolas();


            string str_query = @"select * from escolas";

            using (SqlConnection conn = new SqlConnection(str_connection))
            using (SqlCommand cmd = new SqlCommand(str_query, conn))
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int nId = Convert.ToInt32(reader["id"]);
                    string nome = reader["nome"].ToString();
                    string endereco = reader["endereco"].ToString();
                    string bairro = reader["bairro"].ToString();
                    string cidade = reader["cidade"].ToString();
                    string cep = reader["cep"].ToString();
                    string telefone = reader["telefone"].ToString();
                    int estados_id = Convert.ToInt32(reader["estados_id"]);

                    escolas.id = nId;
                    escolas.nome = nome;
                    escolas.endereco = endereco;
                    escolas.bairro = bairro;
                    escolas.cidade = cidade;
                    escolas.cep = cep;
                    escolas.telefone = telefone;
                    escolas.estados_id = estados_id;

                    arrescolaIndex.escolas = escolas;

                    string estadosNome = getEstadosNome(estados_id);
                    arrescolaIndex.estados_nome = estadosNome;
                    escolasIndex.Add(arrescolaIndex);
                }

                conn.Close();
            }

            return View(escolasIndex);
        }

        public string getEstadosNome(int id)
        { 
                string estadosNome = "" ;

                estados estados = new estados();

                estados = db.estados.Find(id);
                estadosNome = estados.nome;

                return estadosNome;
        }
        //
        // GET: /escolas/Details/5

        public ViewResult Details(int id)
        {
            escolas escolas = db.escolas.Find(id);
            return View(escolas);
        }

        //
        // GET: /escolas/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /escolas/Create

        [HttpPost]
        public ActionResult Create(escolas escolas)
        {
            if (ModelState.IsValid)
            {
                db.escolas.Add(escolas);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(escolas);
        }
        
        //
        // GET: /escolas/Edit/5
 
        public ActionResult Edit(int id)
        {
            escolasEdit arrModel = new escolasEdit();
            
            escolas escolas = db.escolas.Find(id);
            List<estados> estados = db.estados.ToList();
            arrModel.escolas = escolas;
            arrModel.estados = estados;
            return View(arrModel);
        }

        //
        // POST: /escolas/Edit/5

        [HttpPost]
        public ActionResult Edit(escolas escolas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(escolas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(escolas);
        }

        //
        // GET: /escolas/Delete/5
 
        public ActionResult Delete(int id)
        {
            escolas escolas = db.escolas.Find(id);
            return View(escolas);
        }

        //
        // POST: /escolas/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            escolas escolas = db.escolas.Find(id);
            db.escolas.Remove(escolas);
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