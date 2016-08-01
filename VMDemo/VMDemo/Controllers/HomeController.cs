using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VMDemo.Models;

namespace VMDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            Person p1 = new Person();

            p1.FirstName = "Fredrik";
            // osv


            Test t = new Test();

            return View(p1);

            // return View(Tuple.Create(p1, t));
        }
    }
}