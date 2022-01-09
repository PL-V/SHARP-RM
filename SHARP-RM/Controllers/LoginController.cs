using MySql.Data.MySqlClient;
using SHARP_RM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHARP_RM.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {


			MySqlConnection conn;

			MySqlDataAdapter da;
			DataTable dataset;

			conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
			da = new MySqlDataAdapter("select * from admin", conn);
			dataset = new DataTable();

			da.Fill(dataset);


			String login = Request.Params["logemail"];
			String pass= Request.Params["logpass"];

			Admin admin = null;

			foreach (DataRow dr in dataset.Rows)
			{
				admin = new Admin
				{
					id = Convert.ToInt32(dr["id"].ToString()),
					Nom = dr["nom"].ToString(),
					Prenom = dr["prenom"].ToString(),
					Login = dr["login"].ToString(),
					Addresse = dr["addresse"].ToString(),
					Telephone = dr["Telephone"].ToString(),
					Ville = dr["Ville"].ToString(),
					Username = dr["username"].ToString(),
					Description = dr["Description"].ToString(),
					Pays = dr["Pays"].ToString(),
					Pass = dr["Pass"].ToString()
				};
	
			}
			

			if (String.Equals(login, admin.Login) && String.Equals(pass, admin.Pass))
			{
				Session["id"] = admin.id;
				Session["nom"] = admin.Nom;
				Session["prenom"] = admin.Prenom;
				Session["Login"] = admin.Login;
				Session["Addresse"] = admin.Addresse;
				Session["Telephone"] = admin.Telephone;
				Session["Ville"] = admin.Ville;
				Session["Username"] = admin.Username;
				Session["Ville"] = admin.Ville;
				Session["Pays"] = admin.Pays;
				Session["Description"] = admin.Description;
				return RedirectToAction("../Home/");
			}

			return RedirectToAction("../Home/login");
		}
	}
}