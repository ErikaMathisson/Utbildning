using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLib.Classes
{
    class User
    {

        public int Id { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public bool IsLoggedIn { get; set; }

        public Role Role { get; set; }

    }
}
