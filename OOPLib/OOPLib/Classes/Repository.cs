using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLib.Classes
{
    class Repository
    {
        public List<User> users = new List<User> {
            new User { Id = 1, UserName = "Admin", PassWord = "PassWord!@" }
        };
        public List<Role> roles = new List<Role> {
            new Role {Id = 1, RoleName = "Admin" }
        };

        public Repository()
        {
            users[0].Role = roles[0];
        }


        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="username">new user username</param>
        /// <param name="password">new user password</param>
        /// <param name="currentuser">logged in user</param>
        /// <returns>boolean status</returns>
        public bool AddNewUser(string username, string password, User currentUser)
        {

            if (currentUser.IsLoggedIn)
            {
                if (currentUser.Role.RoleName == "Admin")
                {

                    var user = users.FirstOrDefault(x => x.UserName == username);
                    //if user doesn't exist return false
                    if (user == null)
                    {
                        User tempUser = new User
                        {
                            Id = users.Count + 1,
                            UserName = username,
                            PassWord = password


                        };
                        users.Add(tempUser);
                        return true;

                    }

                }


            }
            return false;

        }

        /// <summary>
        /// Add new role to list of roles
        /// </summary>
        /// <param name="roleName">Rolename</param>
        /// <returns>boolean status</returns>
        public bool AddNewRole(string roleName, User currentUser)
        {
            if (currentUser.IsLoggedIn)
            {
                if (currentUser.Role.RoleName == "Admin")
                {

                    //två raderna nedan utför samma sak men på olika sätt. Andra LINQ
                    var role = roles.FirstOrDefault(x => x.RoleName == roleName); //delegate
                    var test = from r in roles where r.RoleName == roleName select r; //returns enumerable

                    if (role == null)
                    {
                        var tempRole = new Role
                        {
                            Id = roles.Count + 1,
                            RoleName = roleName

                        };
                        roles.Add(tempRole);
                        return true;


                    }

                }


            }
            return false;

        }


        /// <summary>
        /// Check if the user is logged in
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>boolean status</returns>
        public bool CheckLogin(string username, string password)
        {
            User tempUser = users.FirstOrDefault(x => x.UserName == username && x.PassWord == password);

            if (tempUser != null)
            {
                tempUser.IsLoggedIn = true;
                return true;

            }

            return false;
        }


        /// <summary>
        /// Assign a role to a user
        /// </summary>
        /// <param name="user">user to a assign a role to</param>
        /// <param name="loggedInUser">current user that is logged in</param>
        /// <param name="role">role that should be assignet to given user</param>
        /// <returns>string</returns>
        public string AssignRoleToUser(User user, User loggedInUser, Role role)
        {
            if (loggedInUser.IsLoggedIn)
            {

                if (loggedInUser.Role.RoleName == "Admin")
                {
                    user.Role = role;
                    return "Success";

                }
                return "Unauthorized";

            }
            return "NoLogin";
        }


        public void LogOut(User currentUser)
        {
            currentUser.IsLoggedIn = false;

        }


    }
}
