using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHARP_RM.Models
{
	public class Opportunity
	{

	public int Id { get; set ; }
	public String status { get; set; }
	public String Nom { get; set; }
	public String proprieter { get; set; }
	public String valeur { get; set; }
	public String contact { get; set; }
	public String source { get; set; }
	public String description { get; set; }
	public String probabilite { get; set; }
	public String date { get; set; }
	public String creation_date { get; set; }


}
}
