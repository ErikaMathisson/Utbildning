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
        /// <summary>
        /// Action for showing Index view
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Action for getting all people in database
        /// </summary>
        /// <returns>All people in database</returns>
        public JsonResult GetPeople()
        {
            // new database instance
            Context db = new Context();
            // list of people retreived from the database
            List<Person> people = db.people.ToList();
            // return peoples, allowing the method to be HttpGet
            return Json(people, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Action for adding a person to database
        /// </summary>
        /// <param name="p">person who should be added</param>
        /// <returns>added person or error message</returns>
        [HttpPost]
        public JsonResult AddPerson([Bind(Include = "name, email, phone, country")]Person p)
        {
            // check if model is valid, for instance all required information is entered
            if (ModelState.IsValid)
            {
                // create a new database instance
                Context db = new Context();
                // check if entered email already exist in database
                var check = db.people.FirstOrDefault(x => x.email == p.email);
                // email already exist in database return error code
                if (check != null)
                {
                    return Json("EmailExists");
                }
                // try to add person p to database and save the changes
                try
                {
                    db.people.Add(p);
                    db.SaveChanges();
                    //return the newly added person 
                    return Json(p);                    
                }
                catch (Exception)
                {
                    //something went wrong return error code 
                    return Json("Empty");                    
                }
            }
            // not all required information was entered ok, return error code
            return Json("NonValid");
        }

        /// <summary>
        /// Action for editing a person
        /// </summary>
        /// <param name="p">the person whom should be edited</param>
        /// <returns>newly edited person or error code</returns>
        public JsonResult EditPerson([Bind(Include = "id, name, email, phone, country")]Person p)
        {
            //check if model is valid
            if (ModelState.IsValid)
            {
                // create a new database connection
                Context db = new Context();
                //try to fetch a person via email address
                var person = db.people.FirstOrDefault(x => x.email == p.email);
                // email already exist and it doesn't belong to the person who should be edited, return error code
                if (person != null && person.id != p.id)
                {
                    return Json("EmailExists");
                }
                
                //try to add the changes on the person to the database               
                try
                {
                    person.name = p.name;
                    person.email = p.email;
                    person.country = p.country;
                    person.phone = p.phone;              
                    db.SaveChanges();
                    //return the newly edited person
                    return Json(person);
                }
                catch (Exception)
                {
                    // something went wrong, error code returned
                    return Json("Empty");                   
                }
            }
            // the model isn't valid return error code
            return Json("NonValid");
        }

        /// <summary>
        /// Action for deleting a person
        /// </summary>
        /// <param name="p">person whom should be deleted</param>
        /// <returns>Information/error code</returns>
        public JsonResult DeletePerson([Bind(Include = "id, name, email, phone, country")]Person p)
        {
            // check if it's a valid person whom should be removed
            if (ModelState.IsValid)
            {
                // create a database connection
                Context db = new Context();
                // try to fetch a person from the database with entered email
                var check = db.people.FirstOrDefault(x => x.email == p.email);
                // person exist in database, try and remove the person
                if (check != null)
                {
                    try
                    {
                        db.people.Remove(check);
                        db.SaveChanges();
                        return Json(p);
                    }
                    catch (Exception)
                    {
                        //Something went wrong, return error code
                        return Json("Error");
                    }
                }
            }
            // something was not right with information, return error code
            return Json("Error");
        }
    }
}