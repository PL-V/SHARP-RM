using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHARP_RM.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SupprimerProduct()
        {

            MySqlConnection conn;

        

            conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from Produit where id = " + Request.Params["id"], conn);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            return RedirectToAction("../Home/Products");
        }

        public ActionResult AjouterProduct() {

            MySqlConnection conn;

            var nom = Request.Params["nom"];
            var description = Request.Params["description"];
            var quantite = Request.Params["quantite"];
            var categorie = Request.Params["categorie"];
            var prix = Request.Params["prix"] + Request.Params["devise"];
    

            DateTime today = DateTime.Today;


            conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Produit(nom,description,quantite,category,prix,date) VALUES(@nom,@description,@quantite,@categorie,@prix,@date)", conn);
            cmd.Parameters.AddWithValue("@nom", nom);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@quantite", quantite);
            cmd.Parameters.AddWithValue("@categorie", categorie);
            cmd.Parameters.AddWithValue("@prix", prix);
            cmd.Parameters.AddWithValue("@date", today.ToString("dd/MM/yyyy"));
            cmd.ExecuteNonQuery();
            return RedirectToAction("../Home/Products");


        }


        public ActionResult ModifierProduit() {


            MySqlConnection conn;
            var id = Request.Params["id"];

            var nom = Request.Params["nom"];
            var description = Request.Params["description"];
            var quantite = Request.Params["quantite"];
            var categorie = Request.Params["categorie"];
            var prix = Request.Params["prix"] + Request.Params["devise"];

            String Query = "UPDATE PRODUIT SET id= " + id;


            if (!String.IsNullOrEmpty(nom)) Query += ",nom=" + "'" + nom + "'";
            if (!String.IsNullOrEmpty(description)) Query += ",description=" + "'" + description + "'";
            if (!String.IsNullOrEmpty(quantite)) Query += ",quantite=" + "'" + quantite + "'";
            if (!String.IsNullOrEmpty(categorie)) Query += ",category=" + "'" + categorie + "'";
            if (!String.IsNullOrEmpty(prix)) Query += ",prix=" + "'" + prix + " " +Request.Params["devise"] +  "'";
            Query += " WHERE id = " + id; 



            conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(Query, conn);
           



            cmd.ExecuteNonQuery();
            return RedirectToAction("../Home/Products");



        }









    }
}