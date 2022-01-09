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
	public class HomeController : Controller
	{
		
	     public ActionResult Index()
		{

			string commandLine = "SELECT COUNT(*) FROM Tasks";
			int Taskscount;
			int OpposCount;
			int ContactCount;
			int LeadCount;

			MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");

			using (MySqlCommand cmd = new MySqlCommand(commandLine, conn))
			{
				conn.Open();
				Taskscount= Convert.ToInt32(cmd.ExecuteScalar());
			}

		    commandLine = "SELECT COUNT(*) FROM opportunities";

			using (MySqlCommand cmd = new MySqlCommand(commandLine, conn))
			{
				
				OpposCount = Convert.ToInt32(cmd.ExecuteScalar());
			}

			commandLine = "SELECT COUNT(*) FROM Contact";

			using (MySqlCommand cmd = new MySqlCommand(commandLine, conn))
			{
				ContactCount = Convert.ToInt32(cmd.ExecuteScalar());
			}


			commandLine = "SELECT COUNT(*) FROM leads";

			using (MySqlCommand cmd = new MySqlCommand(commandLine, conn))
			{
		
				LeadCount = Convert.ToInt32(cmd.ExecuteScalar());
			}


			ViewBag.Tasks = Taskscount;
			ViewBag.Opps = OpposCount;
			ViewBag.Contacts = ContactCount;
			ViewBag.Leads = LeadCount;

			conn.Close();




			return View();
		}

		public ActionResult Contact()
		{
			MySqlConnection conn;

			MySqlDataAdapter da;
			DataTable dataset;

			conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
			da = new MySqlDataAdapter("select * from Contact",conn);
			dataset = new DataTable();

			da.Fill(dataset);


			List<Contact> contacts = new List<Contact>();
			
			Contact contact = null;

			foreach (DataRow dr in dataset.Rows)
			{
				contact = new Contact
				{
					Id = Convert.ToInt32(dr["id"].ToString()),
					Nom = dr["nom"].ToString(),
					Prenom = dr["prenom"].ToString(),
					Email = dr["Email"].ToString(),
					Adresse = dr["Adresse"].ToString(),
					Telephone = dr["Telephone"].ToString(),
					Ville = dr["Ville"].ToString(),
					Etat = dr["Etat"].ToString(),
					Description = dr["Description"].ToString(),
					Date = dr["Date"].ToString(),
					Pays = dr["Pays"].ToString()
				};
				contacts.Add(contact);
			}

			
				ViewBag.Contacts = contacts;

			    return View();
		}
		public ActionResult dashboard()
		{

			return View();
		}
		public ActionResult leads()
		{




			MySqlConnection conn;

			MySqlDataAdapter da;
			DataTable dataset;

			conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
			da = new MySqlDataAdapter("select * from Leads", conn);
			dataset = new DataTable();

			da.Fill(dataset);


			List<Lead> Leads = new List<Lead>();

			Lead Lead = null;

			foreach (DataRow dr in dataset.Rows)
			{
				Lead = new Lead
				{
					id = Convert.ToInt32(dr["id"].ToString()),
					Description = dr["Description"].ToString(),
					Nom = dr["nom"].ToString(),
					Prenom = dr["Prenom"].ToString(),
					Telephone = dr["Telephone"].ToString(),
					Title = dr["Title"].ToString(),
					LeadOwner = dr["LeadOwner"].ToString(),
					LeadSource = dr["LeadSource"].ToString(),
					Revenu = dr["Revenu"].ToString(),
					email = dr["email"].ToString(),
					Adresse = dr["Adresse"].ToString(),
					Ville = dr["Ville"].ToString(),
					Pays = dr["Pays"].ToString(),

				};
				Leads.Add(Lead);
			}


			ViewBag.Leads = Leads;







			return View();
		}
		public ActionResult login()
		{






			return View();
		}
		public ActionResult opportunities()
		{

			MySqlConnection conn;

			MySqlDataAdapter da;
			DataTable dataset;

			conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
			da = new MySqlDataAdapter("select * from opportunities where status='new'", conn);
			dataset = new DataTable();

			da.Fill(dataset);


			List<Opportunity> opportunitiesNew= new List<Opportunity>();
			List<Opportunity> opportunitiesQualified = new List<Opportunity>();
			List<Opportunity> opportunitiesProposition = new List<Opportunity>();
			List<Opportunity> opportunitiesWon = new List<Opportunity>();
			List<Opportunity> opportunitiesLost = new List<Opportunity>();

			Opportunity opportunity = null;

			foreach (DataRow dr in dataset.Rows)
			{
				opportunity = new Opportunity
				{
					Id = Convert.ToInt32(dr["id"].ToString()),
					Nom = dr["nom"].ToString(),
					status = dr["STATUS"].ToString(),
					proprieter = dr["PROPRIETER"].ToString(),
					valeur = dr["valeur"].ToString(),
					contact = dr["contact"].ToString(),
					source = dr["source"].ToString(),
					description = dr["description"].ToString(),
					probabilite = dr["probabilite"].ToString(),
					date = dr["date"].ToString(),
					creation_date = dr["creation_date"].ToString(),
				};
				opportunitiesNew.Add(opportunity);
			}

			da = new MySqlDataAdapter("select * from opportunities where status='won'", conn);
			dataset = new DataTable();

			da.Fill(dataset);


			foreach (DataRow dr in dataset.Rows)
			{
				opportunity = new Opportunity
				{
					Id = Convert.ToInt32(dr["id"].ToString()),
					Nom = dr["nom"].ToString(),
					status = dr["STATUS"].ToString(),
					proprieter = dr["PROPRIETER"].ToString(),
					valeur = dr["valeur"].ToString(),
					contact = dr["contact"].ToString(),
					source = dr["source"].ToString(),
					description = dr["description"].ToString(),
					probabilite = dr["probabilite"].ToString(),
					date = dr["date"].ToString(),
					creation_date = dr["creation_date"].ToString(),
				};
				opportunitiesWon.Add(opportunity);
			}


			da = new MySqlDataAdapter("select * from opportunities where status='lost'", conn);
			dataset = new DataTable();

			da.Fill(dataset);

			foreach (DataRow dr in dataset.Rows)
			{
				opportunity = new Opportunity
				{
					Id = Convert.ToInt32(dr["id"].ToString()),
					Nom = dr["nom"].ToString(),
					status = dr["STATUS"].ToString(),
					proprieter = dr["PROPRIETER"].ToString(),
					valeur = dr["valeur"].ToString(),
					contact = dr["contact"].ToString(),
					source = dr["source"].ToString(),
					description = dr["description"].ToString(),
					probabilite = dr["probabilite"].ToString(),
					date = dr["date"].ToString(),
					creation_date = dr["creation_date"].ToString(),
				};
				opportunitiesLost.Add(opportunity);
			}

			da = new MySqlDataAdapter("select * from opportunities where status='qualified'", conn);
			dataset = new DataTable();

			da.Fill(dataset);

			foreach (DataRow dr in dataset.Rows)
			{
				opportunity = new Opportunity
				{
					Id = Convert.ToInt32(dr["id"].ToString()),
					Nom = dr["nom"].ToString(),
					status = dr["STATUS"].ToString(),
					proprieter = dr["PROPRIETER"].ToString(),
					valeur = dr["valeur"].ToString(),
					contact = dr["contact"].ToString(),
					source = dr["source"].ToString(),
					description = dr["description"].ToString(),
					probabilite = dr["probabilite"].ToString(),
					date = dr["date"].ToString(),
					creation_date = dr["creation_date"].ToString(),
				};
				opportunitiesQualified.Add(opportunity);
			}


			da = new MySqlDataAdapter("select * from opportunities where status='proposition'", conn);
			dataset = new DataTable();

			da.Fill(dataset);

			foreach (DataRow dr in dataset.Rows)
			{
				opportunity = new Opportunity
				{
					Id = Convert.ToInt32(dr["id"].ToString()),
					Nom = dr["nom"].ToString(),
					status = dr["STATUS"].ToString(),
					proprieter = dr["PROPRIETER"].ToString(),
					valeur = dr["valeur"].ToString(),
					contact = dr["contact"].ToString(),
					source = dr["source"].ToString(),
					description = dr["description"].ToString(),
					probabilite = dr["probabilite"].ToString(),
					date = dr["date"].ToString(),
					creation_date = dr["creation_date"].ToString(),
				};
				opportunitiesProposition.Add(opportunity);
			}


			ViewBag.opportunitiesNew = opportunitiesNew;
			ViewBag.opportunitiesQualified = opportunitiesQualified;
			ViewBag.opportunitiesProposition = opportunitiesProposition;
			ViewBag.opportunitiesWon = opportunitiesWon;
			ViewBag.opportunitiesLost = opportunitiesLost;



			return View();
		}
		public ActionResult Products()
		{

			MySqlConnection conn;

			MySqlDataAdapter da;
			DataTable dataset;

			conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
			da = new MySqlDataAdapter("select * from produit", conn);
			dataset = new DataTable();

			da.Fill(dataset);


			List<Produit> Produits = new List<Produit>();

			Produit produit = null;

			foreach (DataRow dr in dataset.Rows)
			{
				produit = new Produit
				{
					id = Convert.ToInt32(dr["id"].ToString()),
					Nom = dr["nom"].ToString(),
					Prix = dr["prix"].ToString(),
					Quantite = dr["quantite"].ToString(),
					Description = dr["description"].ToString(),
					Date = dr["date"].ToString(),
					Category = dr["category"].ToString(),
				};
				Produits.Add(produit);
			}


			ViewBag.Produits = Produits;




			return View();


		
		}
		public ActionResult profile()
		{
			return View();
		}
		public ActionResult Tasks()
		{

			MySqlConnection conn;

			MySqlDataAdapter da;
			DataTable dataset;

			conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
			da = new MySqlDataAdapter("select * from Tasks", conn);
			dataset = new DataTable();

			da.Fill(dataset);


			List<Task> Tasks = new List<Task>();

			Task task = null;

			foreach (DataRow dr in dataset.Rows)
			{
				task = new Task
				{
					id = Convert.ToInt32(dr["id"].ToString()),
					Sujet = dr["sujet"].ToString(),
					Contact = dr["contact"].ToString(),
					Statut = dr["Statut"].ToString(),
					Priorite = dr["Priorite"].ToString(),
					Description = dr["Description"].ToString(),

				};
				Tasks.Add(task);
			}







			conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
			da = new MySqlDataAdapter("select * from Contact", conn);
			dataset = new DataTable();

			da.Fill(dataset);


			List<Contact> contacts = new List<Contact>();

			Contact contact = null;

			foreach (DataRow dr in dataset.Rows)
			{
				contact = new Contact
				{
					Id = Convert.ToInt32(dr["id"].ToString()),
					Nom = dr["nom"].ToString(),
					Prenom = dr["prenom"].ToString(),
					Email = dr["Email"].ToString(),
					Adresse = dr["Adresse"].ToString(),
					Telephone = dr["Telephone"].ToString(),
					Ville = dr["Ville"].ToString(),
					Etat = dr["Etat"].ToString(),
					Description = dr["Description"].ToString(),
					Date = dr["Date"].ToString(),
					Pays = dr["Pays"].ToString()
				};
				contacts.Add(contact);
			}







			ViewBag.Contacts = contacts;
			ViewBag.Tasks = Tasks;




			return View();
		}
		
		
		
		
		
		public ActionResult ViewContact()
		{

			MySqlConnection conn;

			MySqlDataAdapter da;
			DataTable dataset;

			conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
			da = new MySqlDataAdapter("select * from Contact where id = " + Request.Params["id"], conn);
			dataset = new DataTable();

			da.Fill(dataset);

			Contact contact = null;

			foreach (DataRow dr in dataset.Rows)
			{
				contact = new Contact
				{
					Id = Convert.ToInt32(dr["id"].ToString()),
					Nom = dr["nom"].ToString(),
					Prenom = dr["prenom"].ToString(),
					Email = dr["Email"].ToString(),
					Adresse = dr["Adresse"].ToString(),
					Telephone = dr["Telephone"].ToString(),
					Ville = dr["Ville"].ToString(),
					Etat = dr["Etat"].ToString(),
					Description = dr["Description"].ToString(),
					Date = dr["Date"].ToString(),
					Pays = dr["Pays"].ToString()
				};
				
			}
			ViewBag.Contact = contact;
			return View();
		}
		public ActionResult ViewLead()
		{
			MySqlConnection conn;

			MySqlDataAdapter da;
			DataTable dataset;

			conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
			da = new MySqlDataAdapter("select * from Leads where id= " + Request.Params["id"], conn);
			dataset = new DataTable();

			da.Fill(dataset);


		

			Lead Lead = null;

			foreach (DataRow dr in dataset.Rows)
			{
				Lead = new Lead
				{
					id = Convert.ToInt32(dr["id"].ToString()),
					Description = dr["Description"].ToString(),
					Nom = dr["nom"].ToString(),
					Prenom = dr["Prenom"].ToString(),
					Telephone = dr["Telephone"].ToString(),
					Title = dr["Title"].ToString(),
					LeadOwner = dr["LeadOwner"].ToString(),
					LeadSource = dr["LeadSource"].ToString(),
					Revenu = dr["Revenu"].ToString(),
					email = dr["email"].ToString(),
					Adresse = dr["Adresse"].ToString(),
					Ville = dr["Ville"].ToString(),
					Pays = dr["Pays"].ToString(),

				};
				
			}


			ViewBag.Lead = Lead;
			return View();
		}
		public ActionResult viewOpportunity()
		{


			MySqlConnection conn;

			MySqlDataAdapter da;
			DataTable dataset;

			conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
			da = new MySqlDataAdapter("select * from opportunities where id=" + Request.Params["id"], conn);
			dataset = new DataTable();

			da.Fill(dataset);

			Opportunity opportunity = null;

			foreach (DataRow dr in dataset.Rows)
			{
				opportunity = new Opportunity
				{
					Id = Convert.ToInt32(dr["id"].ToString()),
					Nom = dr["nom"].ToString(),
					status = dr["STATUS"].ToString(),
					proprieter = dr["PROPRIETER"].ToString(),
					valeur = dr["valeur"].ToString(),
					contact = dr["contact"].ToString(),
					source = dr["source"].ToString(),
					description = dr["description"].ToString(),
					probabilite = dr["probabilite"].ToString(),
					date = dr["date"].ToString(),
					creation_date = dr["creation_date"].ToString(),
				};
				
			}



			Contact contact = null;

			da = new MySqlDataAdapter("select * from Contact where nom=" + "'" + opportunity.contact + "'", conn);
			dataset = new DataTable();

			da.Fill(dataset);


			foreach (DataRow dr in dataset.Rows)
			{
				contact = new Contact
				{
					Id = Convert.ToInt32(dr["id"].ToString()),
					Nom = dr["nom"].ToString(),
					Prenom = dr["prenom"].ToString(),
					Email = dr["Email"].ToString(),
					Adresse = dr["Adresse"].ToString(),
					Telephone = dr["Telephone"].ToString(),
					Ville = dr["Ville"].ToString(),
					Etat = dr["Etat"].ToString(),
					Description = dr["Description"].ToString(),
					Date = dr["Date"].ToString(),
					Pays = dr["Pays"].ToString()
				};

			}


			ViewBag.opportunity = opportunity;
			ViewBag.contact = contact;

			return View();
		}
		public ActionResult viewProduct()
		{
			MySqlConnection conn;

			MySqlDataAdapter da;
			DataTable dataset;

			conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
			da = new MySqlDataAdapter("select * from produit where id =" + Request.Params["id"], conn);
			dataset = new DataTable();

			da.Fill(dataset);


			Produit produit = null;

			foreach (DataRow dr in dataset.Rows)
			{
				produit = new Produit
				{
					id = Convert.ToInt32(dr["id"].ToString()),
					Nom = dr["nom"].ToString(),
					Prix = dr["prix"].ToString(),
					Quantite = dr["quantite"].ToString(),
					Description = dr["description"].ToString(),
					Date = dr["date"].ToString(),
					Category = dr["category"].ToString(),
				};
			
			}


			ViewBag.Produit = produit;

			return View();
		}
		public ActionResult viewTask()
		{
			MySqlConnection conn;

			MySqlDataAdapter da;
			DataTable dataset;

			conn = new MySqlConnection("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
			da = new MySqlDataAdapter("select * from Tasks where id=" + Request.Params["id"], conn);
			dataset = new DataTable();

			da.Fill(dataset);


			
			Task task = null;
			Contact contact = null;
			Contact Contacts = null;
			List<Contact> contacts = new List<Contact>();


			foreach (DataRow dr in dataset.Rows)
			{
				task = new Task
				{
					id = Convert.ToInt32(dr["id"].ToString()),
					Sujet = dr["sujet"].ToString(),
					Contact = dr["contact"].ToString(),
					Statut = dr["Statut"].ToString(),
					Priorite = dr["Priorite"].ToString(),
					Description = dr["Description"].ToString(),

				};
			
			}


			da = new MySqlDataAdapter("select * from Contact where nom=" + "'" + task.Contact +"'" , conn);
			dataset = new DataTable();

			da.Fill(dataset);


			foreach (DataRow dr in dataset.Rows)
			{
				contact = new Contact
				{
					Id = Convert.ToInt32(dr["id"].ToString()),
					Nom = dr["nom"].ToString(),
					Prenom = dr["prenom"].ToString(),
					Email = dr["Email"].ToString(),
					Adresse = dr["Adresse"].ToString(),
					Telephone = dr["Telephone"].ToString(),
					Ville = dr["Ville"].ToString(),
					Etat = dr["Etat"].ToString(),
					Description = dr["Description"].ToString(),
					Date = dr["Date"].ToString(),
					Pays = dr["Pays"].ToString()
				};
			
			}


			da = new MySqlDataAdapter("select * from Contact", conn);
			dataset = new DataTable();

			da.Fill(dataset);


			

			foreach (DataRow dr in dataset.Rows)
			{
				Contacts = new Contact
				{
					Id = Convert.ToInt32(dr["id"].ToString()),
					Nom = dr["nom"].ToString(),
					Prenom = dr["prenom"].ToString(),
					Email = dr["Email"].ToString(),
					Adresse = dr["Adresse"].ToString(),
					Telephone = dr["Telephone"].ToString(),
					Ville = dr["Ville"].ToString(),
					Etat = dr["Etat"].ToString(),
					Description = dr["Description"].ToString(),
					Date = dr["Date"].ToString(),
					Pays = dr["Pays"].ToString()
				};
				contacts.Add(Contacts);
			}


			ViewBag.Contacts = contacts;
			ViewBag.Task = task;
			ViewBag.Contact = contact;


			return View();
		}

		

	}
}