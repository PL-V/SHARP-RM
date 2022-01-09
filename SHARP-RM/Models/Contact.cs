using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHARP_RM.Models
{
	public class Contact
	{



		public int Id { get; set ; }
		public string Nom { get; set; }
		public string Prenom { get ; set; }
		public string Email { get ; set; }
		public string Adresse { get ; set ; }
		public string Telephone { get ; set; }
		public string Ville { get ; set; }
		public string Etat { get ; set; }
		public string Description { get; set; }
		public string Date { get ; set; }
		public string Pays { get ; set; }
	}
}