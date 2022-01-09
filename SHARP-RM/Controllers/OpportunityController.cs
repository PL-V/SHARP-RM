using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHARP_RM.Controllers
{
    public class OpportunityController : Controller
    {
        // GET: Opportunity
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AjouterOpportunity()
        {


            MySqlConnection conn;


            var nom = Request.Params["nom"];
            var owner = Request.Params["owner"];
            var value = Request.Params["value"];
            var Contact = Request.Params["Contact"];
            var Source = Request.Params["Source"];
            var description = Request.Params["description"];
            var statut = Request.Params["statut"];
            var dateexp = Request.Params["dateexp"];
      
            var proba = Request.Params["proba"];
            DateTime today = DateTime.Today;


            conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO opportunities(nom,PROPRIETER,valeur,Contact,Source,description,status,date,CREATION_DATE)" +
                "VALUES(@nom,@owner,@value,@Contact,@Source,@description,@statut,@dateexp,@CREATION_DATE)", conn);
            cmd.Parameters.AddWithValue("@nom", nom);
            cmd.Parameters.AddWithValue("@owner", owner);
            cmd.Parameters.AddWithValue("@value", value);
            cmd.Parameters.AddWithValue("@Contact", Contact);
            cmd.Parameters.AddWithValue("@Source", Source);
            cmd.Parameters.AddWithValue("@statut", statut);
            cmd.Parameters.AddWithValue("@dateexp", dateexp);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@CREATION_DATE", today.ToString("dd/MM/yyyy"));
            cmd.ExecuteNonQuery();

            return RedirectToAction("../Home/opportunities");
        }


        public ActionResult SupprimerOpportunity()
        {


            MySqlConnection conn;



            conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE from opportunities where id = " + Request.Params["id"], conn);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();



            return RedirectToAction("../Home/opportunities");
        }

        public ActionResult ModifierOpportunity() {






            MySqlConnection conn;

            var id = Request.Params["id"];

            var nom = Request.Params["nom"];
            var owner = Request.Params["owner"];
            var value = Request.Params["value"];
            var Contact = Request.Params["Contact"];
            var Source = Request.Params["Source"];
            var description = Request.Params["description"];
            var statut = Request.Params["statut"];
            var dateexp = Request.Params["dateexp"];

            var proba = Request.Params["proba"];
  


            conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
            conn.Open();


            String Query = "UPDATE opportunities SET ID = " + id;
            if (!String.IsNullOrEmpty(nom)) Query += ",nom=" + "'" + nom + "'";
            if (!String.IsNullOrEmpty(owner)) Query += ",PROPRIETER=" + "'" + owner + "'";
            if (!String.IsNullOrEmpty(value)) Query += ",VALEUR=" + "'" + value + "'";
            if (!String.IsNullOrEmpty(dateexp)) Query += ",DATE=" + "'" + dateexp + "'";
            if (!String.IsNullOrEmpty(statut)) Query += ",STATUS=" + "'" + statut + "'";
            if (!String.IsNullOrEmpty(proba)) Query += ",PROBABILITE= " + "'" + proba + "'";
            if (!String.IsNullOrEmpty(Contact)) Query += ",Contact= " + "'" + Contact + "'";
            if (!String.IsNullOrEmpty(description)) Query += ",description= " + "'" + description + "'";
            if (!String.IsNullOrEmpty(Source)) Query += ",Source= " + "'" + Source + "'";

            Query += " WHERE id= " + id;

            MySqlCommand cmd = new MySqlCommand(Query, conn);
            
            cmd.ExecuteNonQuery();









            return RedirectToAction("../Home/opportunities");

        }

    }
}