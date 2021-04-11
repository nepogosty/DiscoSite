using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Disco2.Controllers
{
    public class HomeController : Controller
    {
        Disco2.Models.DiscoContext db = new Disco2.Models.DiscoContext();
        
        public ActionResult Index()
        {
                return RedirectToAction("Login", "Account");
         
        }
    }
}