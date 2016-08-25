using Assignment_Angular2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_Angular2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPeople()
        {
            //Context db = new Context();
            //List<Person> people = db.People.ToList();

            List<Person> people = new List<Person>();
            Person p = new Person();

            p.firstName = "Kalle";
            p.lastName = "svensson";
            p.email = "test@test.se";
            p.phoneNumber = "0948494994";
            people.Add(p);

     
            return Json(people, JsonRequestBehavior.AllowGet);
        }
    }
}