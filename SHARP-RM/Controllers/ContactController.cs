using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHARP_RM.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjouterContact()
        {
            MySqlConnection conn;

            var nom = Request.Params["nom"];
            var prenom = Request.Params["prenom"];
            var email = Request.Params["email"];
            var pays = Request.Params["pays"];
            var telephone = Request.Params["telephone"];
            var etat = Request.Params["etat"];
            var ville = Request.Params["ville"];
            var description = Request.Params["description"];
            var adresse = Request.Params["adresse"];


            DateTime today = DateTime.Today;
            conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO contact(nom,prenom,email,pays,telephone,etat,ville,description,adresse,date)" +
                "VALUES(@nom,@prenom,@email,@pays,@telephone,@etat,@ville,@description,@adresse,@date)", conn);
            cmd.Parameters.AddWithValue("@nom", nom);
            cmd.Parameters.AddWithValue("@prenom", prenom);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@pays", pays);
            cmd.Parameters.AddWithValue("@telephone", telephone);
            cmd.Parameters.AddWithValue("@etat", etat);
            cmd.Parameters.AddWithValue("@ville", ville);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@adresse", adresse);
            cmd.Parameters.AddWithValue("@date", today.ToString("MMMM dd yyyy"));
            cmd.ExecuteNonQuery();

            return RedirectToAction("../Home/Contact");
        }
        public ActionResult SupprimerContact()
        {
            MySqlConnection conn;



            conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from Contact where id = " + Request.Params["id"], conn);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();


            return RedirectToAction("../Home/Contact");
           
        }

        public ActionResult ModifierContact() {

            MySqlConnection conn;
            var id = Request.Params["id"];
            var nom = Request.Params["nom"];
            var prenom = Request.Params["prenom"];
            var email = Request.Params["email"];
            var pays = Request.Params["pays"];
            var telephone = Request.Params["telephone"];
            var etat = Request.Params["etat"];
            var ville = Request.Params["ville"];
            var description = Request.Params["description"];
            var adresse = Request.Params["adresse"];


            String Query = "UPDATE Contact SET id=" + id;
            if (!String.IsNullOrEmpty(nom)) Query +=",nom=" + "'" + nom +"'";
            if (!String.IsNullOrEmpty(prenom)) Query += ",prenom=" + "'" + prenom + "'";
            if (!String.IsNullOrEmpty(email)) Query += ",email=" + "'" + email + "'";
            if (!String.IsNullOrEmpty(pays)) Query += ",pays=" + "'" + pays + "'";
            if (!String.IsNullOrEmpty(telephone)) Query += ",telephone=" + "'" + telephone + "'";
            if (!String.IsNullOrEmpty(etat)) Query += ",etat= " + "'" + etat + "'";
            if (!String.IsNullOrEmpty(ville)) Query += ",ville= " + "'" + ville + "'";
            if (!String.IsNullOrEmpty(description)) Query += ",description= " + "'" + description + "'";
            if (!String.IsNullOrEmpty(adresse)) Query += ",adresse= " + "'" + adresse + "'";
            Query += " Where id=" + id; 
            
            conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(Query, conn);
        
            cmd.ExecuteNonQuery();



            return RedirectToAction("../Home/Contact");

        }






    }
}