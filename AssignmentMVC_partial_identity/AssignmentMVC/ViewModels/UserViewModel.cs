using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentMVC.ViewModels
{
    public class RegUserViewModel
    {

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

    }

    public class EditUserViewModel
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }


    public class LogInViewModel2
    {
        public string UserEmail { get; set; }

        public string Password { get; set; }


    }
}