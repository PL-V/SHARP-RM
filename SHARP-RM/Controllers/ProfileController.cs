using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHARP_RM.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ModifierProfile()
        {

            MySqlConnection conn;
            var id = Session["id"];
            var nom = Request.Params["nom"];
            var prenom = Request.Params["prenom"];
            var login = Request.Params["login"];
            var pays = Request.Params["pays"];
            var telephone = Request.Params["telephone"];
            var username = Request.Params["username"];
            var ville = Request.Params["ville"];
            var description = Request.Params["description"];
            var adresse = Request.Params["adresse"];


            String Query = "UPDATE admin SET id=" + id;
            if (!String.IsNullOrEmpty(nom))
            {

                Session["nom"]= nom;
                Query += ",nom=" + "'" + nom + "'";
            }



            if (!String.IsNullOrEmpty(prenom)) {

                Session["prenom"] = prenom;
                Query += ",prenom=" + "'" + prenom + "'";


            }
            if (!String.IsNullOrEmpty(login))
            {


                Session["Login"] = login;

                Query += ",login=" + "'" + login + "'";
            }
            if (!String.IsNullOrEmpty(pays)) {

                Session["Pays"] = pays;

                Query += ",pays=" + "'" + pays + "'"; 
            
            }

            if (!String.IsNullOrEmpty(telephone)) {
            
                Query += ",telephone=" + "'" + telephone + "'";
                Session["Telephone"] = telephone;


            }

            if (!String.IsNullOrEmpty(username)) { 
                
                Query += ",username= " + "'" + username + "'";
                Session["Username"] = username;


            }

            if (!String.IsNullOrEmpty(ville)) {
            
                Query += ",ville= " + "'" + ville + "'";
                Session["Ville"] = ville;

            }
            if (!String.IsNullOrEmpty(description)) {
            
                Query += ",description= " + "'" + description + "'";
                Session["Description"] = description;

            }
            if (!String.IsNullOrEmpty(adresse)){

                Session["Addresse"] = adresse;

                Query += ",addresse= " + "'" + adresse + "'"; 
            
            }
            Query += " Where id=" + id;

            conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(Query, conn);

            cmd.ExecuteNonQuery();



            return RedirectToAction("../Home/profile");




                 }


    }
}