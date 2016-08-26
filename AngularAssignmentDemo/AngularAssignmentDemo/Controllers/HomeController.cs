using AngularAssignmentDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AngularAssignmentDemo.Controllers
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
            Person p1 = new Person();

            p1.firstName = "Kalle";
            p1.lastName = "svensson";
            p1.email = "test@test.se";
            p1.phoneNumber = "0948494994";
            people.Add(p1);

            Person p2 = new Person();

            p2.firstName = "Pelle";
            p2.lastName = "andersson";
            p2.email = "test2@test.se";
            p2.phoneNumber = "94398398";
            people.Add(p2);

            return Json(people, JsonRequestBehavior.AllowGet);

            //    return Json((people.count > 0 ? people : null), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddPerson([Bind(Include = "Name, Country, Age, Email")]Person p)
        {
            if (ModelState.IsValid)
            {

                Context db = new Context();
                var check = db.People.FirstOrDefault(x => x.email == p.email);
                if (check != null)
                {
                    return Json("EmailExists");
                }
                db.People.Add(p);
                return Json("Success");
            }


            return Json("Empty");
        }
    }
}