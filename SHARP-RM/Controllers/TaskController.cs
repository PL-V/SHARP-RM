using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHARP_RM.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SupprimerTask()
        {

            MySqlConnection conn;



            conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from tasks where id = " + Request.Params["id"], conn);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();


            return RedirectToAction("../Home/Tasks");

        }

        public ActionResult AjouterTask()
        {
            MySqlConnection conn;

            var sujet = Request.Params["sujet"];
            var statut = Request.Params["statut"];
            var priorite = Request.Params["priorite"];
            var description = Request.Params["description"];
            var contact = Request.Params["contact"] ;
            conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO tasks(sujet,statut,priorite,description,contact) VALUES(@sujet,@statut,@priorite,@description,@contact)", conn);
            cmd.Parameters.AddWithValue("@sujet", sujet);
            cmd.Parameters.AddWithValue("@statut", statut);
            cmd.Parameters.AddWithValue("@priorite", priorite);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@contact", contact);
            cmd.ExecuteNonQuery();

            return RedirectToAction("../Home/Tasks");



        }

        public ActionResult ModifierTask() {

            MySqlConnection conn;


            var id = Request.Params["id"];
            var sujet = Request.Params["sujet"];
            var statut = Request.Params["statut"];
            var priorite = Request.Params["priorite"];
            var description = Request.Params["description"];
            var contact = Request.Params["contact"];

            String Query = "UPDATE Tasks SET id = " + id;


            if (!String.IsNullOrEmpty(sujet)) Query += ",sujet=" + "'" + sujet + "'";
            if (!String.IsNullOrEmpty(statut)) Query += ",statut=" + "'" + statut + "'";
            if (!String.IsNullOrEmpty(priorite)) Query += ",priorite=" + "'" + priorite + "'";
            if (!String.IsNullOrEmpty(description)) Query += ",description=" + "'" + description + "'";
            if (!String.IsNullOrEmpty(contact)) Query += ",contact=" + "'" + contact + "'";
            Query += " WHERE id= " + id;


            conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(Query, conn);

            cmd.ExecuteNonQuery();





            return RedirectToAction("../Home/Tasks");
        }


    }
}