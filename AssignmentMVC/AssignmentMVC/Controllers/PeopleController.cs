using AssignmentMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentMVC.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public ActionResult ShowPeople()
        {
            List<People> peoples = new List<People>();
            
            peoples.Add(new People { Name = "Erika", PhoneNumber = 0708430473, City = "Ronneby" });
            peoples.Add(new People { Name = "Stina", PhoneNumber = 045523145, City = "Karlskrona" });
            peoples.Add(new People { Name = "Calle", PhoneNumber = 0454322412, City = "Karlshamn" });
            peoples.Add(new People { Name = "Pelle", PhoneNumber = 045412345, City = "Olofström" });
            peoples.Add(new People { Name = "Anna", PhoneNumber = 045698765, City = "Sölvesborg" });
                  
           return View(peoples);
        }

        [HttpPost]
        public ActionResult ShowPeople(string Name)
        {
            return View();
        }




    }
}




/*
 * 
 * 
 * 
 * 
 * 
 * 
 * 
<ol>
    
    @foreach (var item in Model)
    {
        <li><h5> @item.Name, @item.PhoneNumber, @item.City </h5></li>
    }

</ol>



    
<table style="width:auto">


   
    <tr>
        <th padding="5">Name</th>
        <th padding="5">Phone number</th>
        <th padding="5">City</th>
    </tr>


    @foreach (var item in Model)
    {
        

        <tr>
            <td padding="5">@item.Name</td>
            <td padding="5">@item.PhoneNumber</td>
            <td padding="5">@item.City</td>
        </tr>

    }
   
</table>




    */
