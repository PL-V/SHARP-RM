using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SHARP_RM
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);

			routes.MapRoute(
				name: "Product",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional }
			);

			routes.MapRoute(
				name: "Task",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Task", action = "Index", id = UrlParameter.Optional }
			);
			routes.MapRoute(
				name: "Contact",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional }
			);
			routes.MapRoute(
				name: "Lead",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Lead", action = "Index", id = UrlParameter.Optional }
			);
			routes.MapRoute(
				name: "Opportunity",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Opportunity", action = "Index", id = UrlParameter.Optional }
			);
			routes.MapRoute(
				name: "Login",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
			);
			routes.MapRoute(
				name: "Logout",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Logout", action = "Index", id = UrlParameter.Optional }
			);
			routes.MapRoute(
				name: "Profile",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Profile", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
