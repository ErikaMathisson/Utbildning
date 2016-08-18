using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentMVC.Models
{
    public class City
    {
        public int Id { get; set; }

        public string CityName { get; set; }

        public Country country { get; set; }
    }
}