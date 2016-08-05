using AssignmentMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace AssignmentMVC.Controllers
{
    public class PeopleController : Controller
    {
        /// <summary>
        /// creating a static list for the peoples and adding with peoples and it's attributes
        /// </summary>
        List<People> Peoples = new List<People>
        {
            new People { Id = 1, Name ="Erika", PhoneNumber = "0708430473", City = "Ronneby"},
            new People { Id = 2, Name = "Stina", PhoneNumber = "045523145", City = "Karlskrona"},
            new People { Id = 3, Name = "Calle", PhoneNumber = "0454322412", City = "Karlshamn" },
            new People { Id = 4, Name = "Pelle", PhoneNumber = "045412345", City = "Olofström" },
            new People { Id = 5, Name = "Anna", PhoneNumber = "045698765", City = "Sölvesborg" }
        };

        // GET: People
        /// <summary>
        /// action for rendering the view ShowPeople, sending the model of a list of peoples to it
        /// </summary>
        /// <returns>view</returns>
        public ActionResult ShowPeople()
        {
            return View(Peoples);
        }

        /// <summary>
        /// action for rendering a partialview
        /// </summary>
        /// <param name="p">model to be sent to partialview</param>
        /// <returns></returns>
        public ActionResult RenderPeople(People p)
        {
            return PartialView("_people", p);
        }


        public ActionResult Search()
        {
            return PartialView("_search");
        }

        public ActionResult Add()
        {
            return PartialView("_add");
        }

        public ActionResult ShowPeoplePartial()
        {
            return PartialView("_showPeople", Peoples);
        }


        //todo edit

        [HttpPost]
        //     public ActionResult Edit([Bind(Include = "Name, PhoneNumber, City")]People p)
        public ActionResult Edit([Bind(Include = "Id, Name, PhoneNumber, City")]People p)
        {
            var people = new People();

            people = Peoples.Find(x => x.Id == p.Id);

            if (ModelState.IsValid)
            {
             
                return PartialView("_people", p);
            }
            else
            {
                return PartialView("_people", people);
            }
          
        }

        [HttpPost]
        //     public ActionResult Edit([Bind(Include = "Name, PhoneNumber, City")]People p)
        public ActionResult EditPerson(int id = 0)
        {
            var people = Peoples.FirstOrDefault(x => x.Id == id);

            return PartialView("_EditPerson", people);
        }

        [HttpPost]
        //     public ActionResult Edit([Bind(Include = "Name, PhoneNumber, City")]People p)
        public ActionResult GetPerson(int id = 0)
        {
            var people = Peoples.FirstOrDefault(x => x.Id == id);

            return PartialView("_EditPerson", people);
        }




        /// <summary>
        /// action for searching for peoples in the list of static peoples
        /// </summary>
        /// <param name="Search">the string to be searched for</param>
        /// <returns>view with searchresult</returns>
        [HttpPost]
        public ActionResult SearchPeople(string Search)
        {
            // creating a new list of peoples for the search result
            List<People> searchResult = new List<People>();

            //make sure the list of peoples, Peoples, have elements in it before doing the search 
            if (Peoples != null)
            {
                //loop through the elements in the Peoples list
                foreach (var item in Peoples)
                {
                    // check if the city or name contains the search string from the user
                    if (item.City.Contains(Search) || item.Name.Contains(Search))
                    {
                        // if an element is found add it to the new list of peoples
                        searchResult.Add(item);
                    }
                }
            }

            // if no elements where found in the search display this information to the user.
            if (searchResult.Count == 0)
            {
                ViewBag.Message = "No entries found";
            }

            // render the view with the list of found elements

            return PartialView("_showPeople", searchResult);

            //    return View("ShowPeople", searchResult);
        }

        /// <summary>
        /// add a people to the list of peoples
        /// </summary>
        /// <param name="name">name entered by the user</param>
        /// <param name="phoneNumber">phonenumber entered by the user</param>
        /// <param name="city">city entered by the user</param>
        /// <returns>view with list of peoples</returns>
        [HttpPost]
        public ActionResult AddPeople(string name, string phoneNumber, string city)
        {
            //make sure the user entered information in all required fields
            if (name.Length != 0 && phoneNumber.Length != 0 && city.Length != 0)
            {
                // add the new people to the list of peoples
                Peoples.Add(new People { Name = name, PhoneNumber = phoneNumber, City = city });
            }
            else
            {
                // the user didn't enter the required information, send information back about this
                ViewBag.Message = "You need to enter information in order to add a new person";
            }
            //render the view with the list of peoples
            //    return View("ShowPeople", Peoples);

            return PartialView("_showPeople", Peoples);
        }

        /// <summary>
        /// action for removing a people in the list of peoples
        /// </summary>
        /// <param name="id">name of people who should be removed</param>
        /// <returns>view with updated peoplelist</returns>
        public ActionResult Delete(string search)
        {
            //make sure the list isn't null
            if (Peoples != null)
            {
                //counter for what element to remove
                int i = 0;
                //loop through the list of peoples
                foreach (var item in Peoples)
                {
                    //check if the people is in the list
                    if (item.Name == search)
                    {
                        //remove the people from the list
                        Peoples.RemoveAt(i);
                        //display message for the user that people is removed
                        ViewBag.Message = "People removed";
                        //skip the rest of looping in the list
                        break;
                    }
                    //increment counter
                    i++;
                }
            }
            else
            {
                ViewBag.Message = "No information in the list....";
            }
            //return the list of peoples to the view
            return PartialView("_showPeople", Peoples);
            //   return View("ShowPeople", Peoples);
        }

        /// <summary>
        /// ///////////////////////////////////////////
        /// </summary>
        /// <returns></returns>


        //// from ws, partialView
        //public ActionResult Person()
        //{
        //    //for a delay before shown, due to ajax
        //    Thread.Sleep(3000);

        //    return PartialView("_person", Peoples);

        //}


    }
}


