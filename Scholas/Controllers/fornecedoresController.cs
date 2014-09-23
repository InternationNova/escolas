using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scholas.Models;
using System.Data.SqlClient;
using Scholas.Classes;

namespace Scholas.Controllers
{ 
    public class fornecedoresController : Controller
    {
        private GlobalInfo db = new GlobalInfo();
        private static string str_connection = "Data Source=rys-PC;Initial Catalog=school;Persist Security Info=True;User ID=sa;Password=P@$$word";
       
        //
        // GET: /fornecedores/

        public ViewResult Index()
        {
            return View(db.fornecedores.ToList());
        }

        //
        // GET: /fornecedores/Details/5

        public ViewResult Details(int id)
        {
            fornecedores fornecedores = db.fornecedores.Find(id);
            return View(fornecedores);
        }

        //
        // GET: /fornecedores/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /fornecedores/Create

        [HttpPost]
        public ActionResult Create(fornecedores fornecedores)
        {
            if (ModelState.IsValid)
            {
                db.fornecedores.Add(fornecedores);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(fornecedores);
        }
        
        //
        // GET: /fornecedores/Edit/5

        public ActionResult Edit(int id)
        {
            fornecedoresEdit fornecedoresEdit = new fornecedoresEdit();
            string str_query = @"SELECT * 
								FROM fornecedores fo
								JOIN estados es ON es.id = fo.estados_id
								where fo.id = @id";

            using (SqlConnection conn = new SqlConnection(str_connection))
            using (SqlCommand cmd = new SqlCommand(str_query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int nId = Convert.ToInt32(reader["id"]);
                    string tipo = reader["tipo"].ToString();

                    string nome = reader["nome"].ToString();
                    string cnpj = reader["cnpj"].ToString();
                    string endereco = reader["endereco"].ToString();
                    string bairro = reader["bairro"].ToString();
                    string cidade = reader["cidade"].ToString();
                    string cep = reader["cep"].ToString();
                    string telefone = reader["telefone"].ToString();
                    string email = reader["email"].ToString();
                    List<estados> estados = new List<estados>();
                    estados = db.estados.ToList();
                    fornecedoresEdit.nome = nome;
                    fornecedoresEdit.cnpj = cnpj;
                    fornecedoresEdit.endereco = endereco;
                    fornecedoresEdit.bairro = bairro;
                    fornecedoresEdit.cidade = cidade;
                    fornecedoresEdit.cep = cep;
                    fornecedoresEdit.telefone = telefone;
                    fornecedoresEdit.email = email;
                    fornecedoresEdit.estados = estados;
                }

                conn.Close();
                return View(fornecedoresEdit);
            }
        }
        //
        // POST: /fornecedores/Edit/5

        [HttpPost]
        public ActionResult Edit(fornecedores fornecedores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fornecedores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fornecedores);
        }

        //
        // GET: /fornecedores/Delete/5
 
        public ActionResult Delete(int id)
        {
            fornecedores fornecedores = db.fornecedores.Find(id);
            return View(fornecedores);
        }

        //
        // POST: /fornecedores/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            fornecedores fornecedores = db.fornecedores.Find(id);
            db.fornecedores.Remove(fornecedores);
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