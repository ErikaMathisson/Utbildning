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
            new People { Name ="Erika", PhoneNumber = "0708430473", City = "Ronneby"},
            new People { Name = "Stina", PhoneNumber = "045523145", City = "Karlskrona"},
            new People { Name = "Calle", PhoneNumber = "0454322412", City = "Karlshamn" },
            new People { Name = "Pelle", PhoneNumber = "045412345", City = "Olofström" },
            new People { Name = "Anna", PhoneNumber = "045698765", City = "Sölvesborg" }
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
            return View("ShowPeople", searchResult);
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
            return View("ShowPeople", Peoples);
        }

        /// <summary>
        /// action for removing a people from the list
        /// </summary>
        /// <param name="id">the id of the people that should be removed</param>
        /// <returns>view with new list of people</returns>
        public ActionResult Delete(int id)
        {
            //make sure the list isn't null
            if (Peoples != null)
            {
                //display a message if the user is trying to remove an people 
                //that's been added by user and not in the static list
                if (Peoples.Count < (id + 1))
                {
                    ViewBag.Message = "Sorry you are trying to remove an object not included in the static list... No can do...";
                }
                else
                {
                    //remove the people from list
                    Peoples.RemoveAt(id);
                }
            }
            else
            {
                ViewBag.Message = "No information in the list....";
            }

            return View("ShowPeople", Peoples);
        }
    }
}
