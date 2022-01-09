using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHARP_RM.Models
{
	public class Lead
	{

		public int id { get; set; }
		public String Description { get; set; }
		public String Nom { get; set; }
		public String Prenom { get; set; }
		public String Telephone { get; set; }
		public String Title { get; set; }
		public String LeadOwner { get; set; }
		public String LeadSource { get; set; }
		public String Revenu { get; set; }
		public String email { get; set; }
		public String Adresse { get; set; }
		public String Ville { get; set; }
		public String Pays { get; set; }
		

	}
}