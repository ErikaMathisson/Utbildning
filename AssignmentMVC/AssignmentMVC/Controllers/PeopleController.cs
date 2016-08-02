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
            People people = new People();
            var peoples = people.Peoples;

            if (people.Peoples == null)
            {
                peoples = people.AddPeople();
            }

            return View(peoples);
        }

        [HttpPost]
        public ActionResult SearchPeople(List<AssignmentMVC.Models.People> peoples, string Search)
        {

            List<People> searchResult = new List<People>();


            if (peoples != null)
            {
                foreach (var item in peoples)
                {
                    if (item.City.Contains(Search) || item.Name.Contains(Search) || item.PhoneNumber.Contains(Search))
                    {
                        searchResult.Add(item);

                    }
                    
                   
                }

            }

            
            if (searchResult.Count == 0)
            {
                ViewBag.Message = "No entries found";
                
            }

            peoples = searchResult;
            return View("ShowPeople", peoples);
         //   return RedirectToAction("ShowPeople", peoples);
        }



        [HttpPost]
        public ActionResult Delete(People delP)
        {

            if (delP != null)
            {

                ViewBag.Message = "Deleting";

            }


            return View();

        }




    }
}




/*
 * 
 * 
 * @Html.EditorFor(model => model, new { htmlAttributes = new { @class = "form-control" }, }) 
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





    

<h3>List of peoples: </h3>
<ul>

    @foreach (var item in Model)
    {
        <li><h5> @item.Name, @item.PhoneNumber, @item.City </h5></li>
    }

</ul>



















    
            @foreach (var item in Model)
            {
                <tbody>

                    <tr>
                        <td>@item.Name</td>
                        <td>@item.PhoneNumber</td>
                        <td>@item.City</td>
                    </tr>
                </tbody>
            }


    

               @foreach (var item in Model)
            {
                <tbody>

                    <tr>
                        <td>@item.Name</td>
                        <td>@item.PhoneNumber</td>
                        <td>@item.City</td>
                    </tr>
                </tbody>
            }







@model List<AssignmentMVC.Models.People>

<h1>People</h1>

<h4>List of peoples: </h4>

<h4>@ViewBag.Message</h4>

@using (Html.BeginForm("SearchPeople", "People", FormMethod.Post))
{

<div class="container">
    <table class="table">

        <thead>

            <tr>
                <th>Name</th>
                <th>Phone number</th>
                <th>City</th>
            </tr>

        </thead>

        @foreach (var item in Model)
        {
            <tbody>

                <tr>
                    <td>@item.Name</td>
                    <td>@item.PhoneNumber</td>
                    <td>@item.City</td>
                </tr>
            </tbody>
        }

    </table>

</div>


    

    @Html.Label("Enter a search string");
    @Html.TextBox("Search", Model, new { @class = "form-control", @type = "text" })
    <br />
    <input type="submit" value="Search" class="btn btn-sm btn-success" />

}

<script src="~/Scripts/jquery-1.10.2.min.js"></script>
<script src="~/Scripts/jquery.validate.min.js"></script>
<script src="~/Scripts/jquery.validate.unobtrusive.min.js"></script>
<script src="~/scripts/bootstrap.min.js"></script>













@model List<AssignmentMVC.Models.People>

<h1>People</h1>

<h4>List of peoples: </h4>

<h4>@ViewBag.Message</h4>

@using (Html.BeginForm("SearchPeople", "People", FormMethod.Post))
{
    <div class="container">
        <table class="table">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Phone number</th>
                    <th>City</th>
                </tr>

            </thead>


            <tbody>
                @for (int i = 0; i < Model.Count; i++)
                {
                    <tr>
                        <td>
                          
                            @Html.DisplayFor(model => model[i].Name)
                            
                          <!--  Html.TextBoxFor(m => m[i].Name) -->
                        </td>
                        <td>
                            @Html.DisplayFor(model => model[i].PhoneNumber)
                         <!--   Html.TextBoxFor(m => m[i].PhoneNumber)  -->
                        </td>
                        <td>
                            @Html.DisplayFor(model => model[i].City)
                            
                      <!--      Html.TextBoxFor(m => m[i].City)  -->
                        </td>
                    </tr>
                }

            </tbody>
        </table>
    </div>

    @Html.Label("Enter a search string")
    
    @Html.TextBox("Search", null, new { @class = "form-control", @type = "text" })
    
    
    
    <br />

    <input type="submit" value="Search" class="btn btn-sm btn-success" />

}

<script src="~/Scripts/jquery-1.10.2.min.js"></script>
<script src="~/Scripts/jquery.validate.min.js"></script>
<script src="~/Scripts/jquery.validate.unobtrusive.min.js"></script>
<script src="~/scripts/bootstrap.min.js"></script>







    */



