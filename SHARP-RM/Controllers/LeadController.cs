using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHARP_RM.Controllers
{
    public class LeadController : Controller
    {
        // GET: Lead
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjouterLead()
        {
            MySqlConnection conn;


            var nom = Request.Params["nom"];
            var prenom = Request.Params["prenom"];
            var email = Request.Params["email"];
            var title = Request.Params["title"];
            var leadowner = Request.Params["leadowner"];
            var telephone = Request.Params["telephone"];
            var revenu = Request.Params["revenu"];
            var leadsource = Request.Params["leadsource"];
            var adresse = Request.Params["adresse"];
            var ville = Request.Params["ville"];
            var pays = Request.Params["pays"];
            var description = Request.Params["description"];



            conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO leads(nom,prenom,email,title,leadowner,telephone,revenu,leadsource,adresse,ville,pays,description)" +
                "VALUES(@nom,@prenom,@email,@title,@leadowner,@telephone,@revenu,@leadsource,@adresse,@ville,@pays,@description)", conn);
            cmd.Parameters.AddWithValue("@nom", nom);
            cmd.Parameters.AddWithValue("@prenom", prenom);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@pays", pays);
            cmd.Parameters.AddWithValue("@telephone", telephone);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@ville", ville);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@adresse", adresse);
            cmd.Parameters.AddWithValue("@leadsource", leadsource);
            cmd.Parameters.AddWithValue("@revenu", revenu);
            cmd.Parameters.AddWithValue("@leadowner", leadowner);
            cmd.ExecuteNonQuery();



            return RedirectToAction("../Home/leads");
        }

        public ActionResult SupprimerLead()
        {


            MySqlConnection conn;



            conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from leads where id = " + Request.Params["id"], conn);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();



            return RedirectToAction("../Home/leads");

        }

        public ActionResult ModifierLead() {
            MySqlConnection conn;
            var id = Request.Params["id"];
            var nom = Request.Params["nom"];
            var prenom = Request.Params["prenom"];
            var email = Request.Params["email"];
            var title = Request.Params["title"];
            var leadowner = Request.Params["leadowner"];
            var telephone = Request.Params["telephone"];
            var revenu = Request.Params["revenu"];
            var leadsource = Request.Params["leadsource"];
            var adresse = Request.Params["adresse"];
            var ville = Request.Params["ville"];
            var pays = Request.Params["pays"];
            var description = Request.Params["description"];

            conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
            conn.Open();

            String Query ="UPDATE LEADS SET id = " + id ;
            if (!String.IsNullOrEmpty(nom)) Query += ",nom=" + "'" + nom + "'";
            if (!String.IsNullOrEmpty(prenom)) Query += ",prenom=" + "'" + prenom + "'";
            if (!String.IsNullOrEmpty(email)) Query += ",email=" + "'" + email + "'";
            if (!String.IsNullOrEmpty(pays)) Query += ",pays=" + "'" + pays + "'";
            if (!String.IsNullOrEmpty(telephone)) Query += ",telephone=" + "'" + telephone + "'";
            if (!String.IsNullOrEmpty(title)) Query += ",title= " + "'" + title + "'";
            if (!String.IsNullOrEmpty(ville)) Query += ",ville= " + "'" + ville + "'";
            if (!String.IsNullOrEmpty(description)) Query += ",description= " + "'" + description + "'";
            if (!String.IsNullOrEmpty(adresse)) Query += ",adresse= " + "'" + adresse + "'";
            if (!String.IsNullOrEmpty(leadowner)) Query += ",leadowner= " + "'" + leadowner + "'";
            if (!String.IsNullOrEmpty(revenu)) Query += ",revenu= " + "'" + revenu + "'";
            if (!String.IsNullOrEmpty(leadsource)) Query += ",leadsource= " + "'" + leadsource + "'";

            Query += " WHERE id= " + id;
            MySqlCommand cmd = new MySqlCommand(Query, conn);

            cmd.ExecuteNonQuery();


            return RedirectToAction("../Home/leads");


        }

    }
}