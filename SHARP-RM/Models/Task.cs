using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHARP_RM.Models
{
	public class Task
	{

		public int id { get; set; }
		public String Sujet { get; set; }
		public String Contact { get; set; }
		public String Statut { get; set; }
		public String Priorite { get; set; }
		public String Description { get; set; }


	}
}