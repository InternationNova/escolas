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
    public class smkItmesController : Controller
    {
        private GlobalInfo db = new GlobalInfo();
        
        private static string str_connection = "Data Source=rys-PC;Initial Catalog=school;Persist Security Info=True;User ID=sa;Password=P@$$word";
        
        //
        // GET: /smkItmes/

        public ViewResult Index()
        {
            return View(db.smk_itens.ToList());
        }

        //
        // GET: /smkItmes/Details/5

        public ViewResult Details(int id)
        {
            
           smkProductView smkProductView = new smkProductView();
           List<smkSubProdus> smkSubProdus = new List<smkSubProdus>();

    
           smkProductView objProductView = new smkProductView();
           smkSubProdus objsubProdus = new smkSubProdus();

           List<smkAccessory> smkSubAccessory = new List<smkAccessory>();
           List<smkAccessory> smkAccessory1 = new List<smkAccessory>();
           List<smkAccessory> smkAccessory2 = new List<smkAccessory>();

           smkProductView objsmkProductView= new smkProductView();
          
           smkAccessory   objsmkAccessory = new smkAccessory();

           string str_query = @"SELECT sp.id, sp.descricao, comprimento_acabada, largura_acabada, espessura_acabada, comprimento_bruto, 
								largura_bruto, espessura_bruto, quantidade, AREA, perda, 
									smk_itens_id, csp.descricao AS csp_descricao FROM sub_produtos sp 
									JOIN categoria_sub_produtos csp ON csp.id = sp.categoria_sub_produtos_id
									WHERE sp.smk_itens_id =@id ORDER BY csp.descricao";

            using (SqlConnection conn = new SqlConnection(str_connection))
            using (SqlCommand cmd = new SqlCommand(str_query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int nId = Convert.ToInt32(reader["id"]);
                    string descricao = reader["descricao"].ToString();
                    string comprimento_acabada = reader["comprimento_acabada"].ToString();
                    string largura_acabada = reader["largura_acabada"].ToString();
                    string espessura_acabada = reader["espessura_acabada"].ToString();
                    string comprimento_bruto = reader["comprimento_bruto"].ToString();
                    string largura_bruto = reader["largura_bruto"].ToString();
                    string espessura_bruto = reader["espessura_bruto"].ToString();
                    double quantidade = Convert.ToDouble(reader["quantidade"]);
                    string area = reader["Area"].ToString();
                    string perda = reader["perda"].ToString();
                    int smkItemId = Convert.ToInt32(reader["smk_itens_id"]);
                    string csp_descricao = reader["csp_descricao"].ToString();
                    

                    objsubProdus.id = nId;
                    objsubProdus.sp_descricao = descricao;
                    objsubProdus.comprimento_acabada = comprimento_acabada;
                    objsubProdus.espessura_acabada = espessura_acabada;
                    objsubProdus.comprimento_bruto = comprimento_bruto;
                    objsubProdus.largura_bruto = largura_bruto;
                    objsubProdus.quantidade = quantidade;
                    objsubProdus.area = area;
                    objsubProdus.perda = perda;
                    objsubProdus.smk_itens_id = smkItemId;
                    objsubProdus.csp_descricao = csp_descricao;
                    objsubProdus.largura_acabada = largura_acabada;

                    smkSubAccessory = getSmkProduct(id);
                    objsubProdus.smkAccessory = smkSubAccessory;
                    smkSubProdus.Add(objsubProdus);

                   

                 
                }
                    smkAccessory1 = getSmkAccessory1(id);
                    smkAccessory2 = getSmkAccessory2(id);

                    smkProductView.smkSubProdus = smkSubProdus;
                    smkProductView.smkAccessory1 = smkAccessory1;
                    smkProductView.smkAccessory2 = smkAccessory2;


                    conn.Close();
            }
            smk_itens smk_itens = db.smk_itens.Find(id);

            return View(smkProductView);
        }
        public List<smkAccessory> getSmkProduct(int id)
        {
            List<smkAccessory> smkAccessory = new List<smkAccessory>();
            smkAccessory objsmkAccessory = new smkAccessory();
            string str_query = @"SELECT *
												FROM sub_produtos_materia_primas spmp
												JOIN materia_primas mp ON mp.id = spmp.materia_primas_id
												WHERE sub_produtos_id = @id";

            using (SqlConnection conn = new SqlConnection(str_connection))
            using (SqlCommand cmd = new SqlCommand(str_query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int nId = Convert.ToInt32(reader["id"]);
                    string descricao = reader["codigo_smk"].ToString() + "-" + reader["descricao"].ToString();
                    int unidade = Convert.ToInt32(reader["unidade"]);
                    int sub_produtos_id = Convert.ToInt32(reader["sub_produtos_id"]);
                    
                    objsmkAccessory.id = nId;
                    objsmkAccessory.codigo_smk = descricao;
                    objsmkAccessory.unidade = unidade;
                    objsmkAccessory.sub_produtos_id = sub_produtos_id;
                    smkAccessory.Add(objsmkAccessory);

                }

                conn.Close();
            }


            return smkAccessory;
        }
        //
        public List<smkAccessory> getSmkAccessory1(int id)
        {
            List<smkAccessory> smkAccessory = new List<smkAccessory>();
            smkAccessory objsmkAccessory = new smkAccessory();
            string str_query = @"SELECT *
														FROM acessorios ac
														JOIN smk_itens si ON si.id = ac.smk_itens_id
														JOIN materia_primas mp ON mp.id = ac.materia_primas_id 
														JOIN categoria_materia_primas cmp on cmp.id = mp.categoria_materia_primas_id
														where ac.smk_itens_id = @id order by cmp.descricao, mp.descricao";

            using (SqlConnection conn = new SqlConnection(str_connection))
            using (SqlCommand cmd = new SqlCommand(str_query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int nId = Convert.ToInt32(reader["id"]);
                    string descricao = reader["codigo_smk"].ToString() + "-" + reader.GetString(10);
                    int unidade = Convert.ToInt32(reader["unidade"]);
                    

                    objsmkAccessory.id = nId;
                    objsmkAccessory.codigo_smk = descricao;
                    objsmkAccessory.unidade = unidade;
                    objsmkAccessory.quantitide = reader.GetFloat(3);
                    objsmkAccessory.categoria = reader.GetString(14);
                    smkAccessory.Add(objsmkAccessory);

                }

                conn.Close();
            }


            return smkAccessory;
        }
        // GET: /smkItmes/Create
        public List<smkAccessory> getSmkAccessory2(int id)
        {
            List<smkAccessory> smkAccessory = new List<smkAccessory>();
            smkAccessory objsmkAccessory = new smkAccessory();
            string str_query = @"SELECT si.codigo_smk, mp.descricao, cmp.descricao AS categoria, mp.unidade, t1.sumQuantidade AS quantidade, mp.codigo_smk AS mp_codigo_smk
                                          FROM sub_produtos_materia_primas spmp
                                          JOIN sub_produtos sp ON sp.id = spmp.sub_produtos_id
                                          JOIN materia_primas mp ON mp.id = spmp.materia_primas_id
                                          JOIN categoria_materia_primas cmp ON cmp.id = mp.categoria_materia_primas_id
                                          JOIN smk_itens si ON si.id = sp.smk_itens_id
                                          JOIN (
                                         SELECT SUM( spmp.quantidade ) AS sumQuantidade, mp.codigo_smk AS codigo_smk
                                           FROM sub_produtos_materia_primas spmp
                                           JOIN materia_primas mp ON mp.id = spmp.materia_primas_id
                                          GROUP BY mp.codigo_smk ) t1 ON t1.codigo_smk = mp.codigo_smk
                                         WHERE si.id = @id
                                         ORDER BY cmp.descricao,mp.descricao";

            using (SqlConnection conn = new SqlConnection(str_connection))
            using (SqlCommand cmd = new SqlCommand(str_query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int nId = Convert.ToInt32(reader["id"]);
                    string descricao = reader["codigo_smk"].ToString() + "-" + reader["descricao"].ToString();
                    int unidade = Convert.ToInt32(reader["unidade"]);

                    objsmkAccessory.id = nId;
                    objsmkAccessory.codigo_smk = descricao;
                    objsmkAccessory.unidade = unidade;
                    objsmkAccessory.quantitide = reader.GetFloat(3);
                    smkAccessory.Add(objsmkAccessory);

                    smkAccessory.Add(objsmkAccessory);

                }

                conn.Close();
            }


            return smkAccessory;
        }
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /smkItmes/Create

        [HttpPost]
        public ActionResult Create(smk_itens smk_itens)
        {
            if (ModelState.IsValid)
            {
                db.smk_itens.Add(smk_itens);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(smk_itens);
        }
        
        //
        // GET: /smkItmes/Edit/5
 
        public ActionResult Edit(int id)
        {
            smk_itens smk_itens = db.smk_itens.Find(id);
            return View(smk_itens);
        }

        //
        // POST: /smkItmes/Edit/5

        [HttpPost]
        public ActionResult Edit(smk_itens smk_itens)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smk_itens).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(smk_itens);
        }

        //
        // GET: /smkItmes/Delete/5
 
        public ActionResult Delete(int id)
        {
            smk_itens smk_itens = db.smk_itens.Find(id);
            return View(smk_itens);
        }

        //
        // POST: /smkItmes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            smk_itens smk_itens = db.smk_itens.Find(id);
            db.smk_itens.Remove(smk_itens);
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