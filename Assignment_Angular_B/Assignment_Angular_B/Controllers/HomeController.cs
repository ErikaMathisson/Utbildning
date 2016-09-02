using Assignment_Angular_B.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_Angular_B.Controllers
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
            Context db = new Context();
            List<Person> people = db.people.ToList();

            //List<Person> people = new List<Person>();
            //Person p1 = new Person();

            //p1.Name = "Kalle Svensson";
            //p1.Email = "test@test.se";
            //p1.PhoneNumber = "0948494994";
            //p1.Country = "Sverige";
            //people.Add(p1);

            //Person p2 = new Person();

            //p2.Name = "Pelle Andersson";
            //p2.Email = "test2@test.se";
            //p2.PhoneNumber = "94398398";
            //p2.Country = "Norge";
            //people.Add(p2);

            //   return Json(people, JsonRequestBehavior.AllowGet);

            //if (people.Count > 0)
            //{
            //    return Json(people, JsonRequestBehavior.AllowGet);

            //}
            //else
            //{
            //    return Json(null, JsonRequestBehavior.AllowGet);
            //}

            return Json(people, JsonRequestBehavior.AllowGet);

            //   return Json((people.Count > 0 ? people : null), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddPerson([Bind(Include = "name, email, phone, country")]Person p)
        {
            if (ModelState.IsValid)
            {

                Context db = new Context();
                var check = db.people.FirstOrDefault(x => x.email == p.email);
                if (check != null)
                {
                    return Json("EmailExists");
                }

                try
                {
                    db.people.Add(p);
                    db.SaveChanges();
                    return Json(p);


                 //   return Json("Success");
                }
                catch (Exception)
                {
                    return Json("Empty");
                 //   throw;
                }
            }
            return Json("NonValid");
        }


        public JsonResult EditPerson([Bind(Include = "id, name, email, phone, country")]Person p)
        {
            if (ModelState.IsValid)
            {

                Context db = new Context();
                var check = db.people.FirstOrDefault(x => x.email == p.email);

                if (check != null && check.id != p.id)
                {
                    return Json("EmailExists");

                }

          //      var idCheck = db.people.FirstOrDefault(x => x.id == p.id);
                //if (check != null)
                //{
                //    return Json("EmailExists");
                //}
                try
                {
                    db.people.Add(p);
                    db.SaveChanges();
                    return Json(p);
                }
                catch (Exception)
                {
                    return Json("Empty");
                    throw;
                }

            }
            return Json("NonValid");
        }


        public JsonResult DeletePerson([Bind(Include = "id, name, email, phone, country")]Person p)
        {
            if (ModelState.IsValid)
            {

                Context db = new Context();
                var check = db.people.FirstOrDefault(x => x.email == p.email);

                if (check != null && check.id != p.id)
                {
                    return Json("EmailExists");

                }

                //      var idCheck = db.people.FirstOrDefault(x => x.id == p.id);
                //if (check != null)
                //{
                //    return Json("EmailExists");
                //}
                try
                {
                    db.people.Add(p);
                    db.SaveChanges();
                    return Json(p);
                }
                catch (Exception)
                {
                    return Json("Empty");
                    throw;
                }

            }
            return Json("NonValid");
        }




    }
}