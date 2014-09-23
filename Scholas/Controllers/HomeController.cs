using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scholas.Classes;
using Scholas.Models;
using System.Data.SqlClient;

namespace Scholas.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private GlobalInfo db = new GlobalInfo();

        private static string str_connection = "Data Source=rys-PC;Initial Catalog=school;Persist Security Info=True;User ID=sa;Password=P@$$word";


        public ActionResult Index()
        {
            return View();
        }
        public string GetStatus()
        {
            return "Status OK at " + DateTime.Now.ToLongTimeString();
        }
        public ActionResult login(string username, string password)
        {
            string str_query = @"SELECT * FROM users WHERE username =@username AND password = @password";
            using (SqlConnection conn = new SqlConnection(str_connection))
            using (SqlCommand cmd = new SqlCommand(str_query, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Session["USERNAME"] = username;
                    
                }
                
                conn.Close();
                if (Session["USERNAME"] == null)

                {
                    return Json(new { ok = "failed" });
                    
                }
                else
                {
                    return Json(new { ok = "success" });
                }

                
            }
        }
        public ActionResult logout() {
            Session.Remove("USERNAME");
            return RedirectToAction("Index", "Home");
        }
    }
}
