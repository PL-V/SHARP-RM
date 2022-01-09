using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHARP_RM.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Index()
        {

            Session.Contents.RemoveAll();

            return RedirectToAction("../Home/login");

            return View();
        }
    }
}