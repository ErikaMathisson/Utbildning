using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentMVC.Models
{
    public class Country
    {
        public int Id { get; set; }

        public string CountryName { get; set; }

        public List<City> cities { get; set; }
    }
}