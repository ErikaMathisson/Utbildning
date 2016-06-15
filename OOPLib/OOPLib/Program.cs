using OOPLib.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLib
{
    class Program
    {
        static void Main(string[] args)
        {

            //main är inte ok, behöver felsökas...

            Repository repo = new Repository();
            User loggedInUser = new User();

            while (true)
            {
                Console.WriteLine("Enter username:");
                string username = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                string password = Console.ReadLine();
                if (repo.CheckLogin(username, password))
                {


                    loggedInUser = repo.users.FirstOrDefault(x => x.UserName == username);
                    Console.WriteLine("1: to add new user\n2. to add new role\n3. to assign a role to another user\n4. log out");
                    string ch = Console.ReadLine();

                    switch (ch)
                    {
                        case "1":
                            Console.WriteLine("Enter a new username ");
                            string tempUserName = Console.ReadLine();
                            Console.WriteLine("Enter a password");
                            string tempPassWord = Console.ReadLine();

                            if (repo.AddNewUser(tempUserName, tempPassWord, loggedInUser))
                            {
                                Console.WriteLine($"{tempUserName} has been added successfully");


                            }
                            else
                            {
                                Console.WriteLine($"{tempUserName} already exists");

                            }

                            break;

                        case "2":
                            Console.WriteLine("Enter a new rolename ");
                            string tempRoleName = Console.ReadLine();

                            if (repo.AddNewRole(tempRoleName, loggedInUser))
                            {
                                Console.WriteLine($"{tempRoleName} has been added successfully");

                            }
                            else
                            {
                                Console.WriteLine($"{tempRoleName} already exists");

                            }

                            break;

                        case "3":
                            Console.WriteLine("Available users: ");
                            foreach (var user in repo.users)
                            {
                                Console.WriteLine($"{user.Id}.\t{user.UserName}");

                            }

                            Console.WriteLine("Available roles: ");
                            foreach (var role in repo.roles)
                            {
                                Console.WriteLine($"{role.Id}.\t{role.RoleName}");

                            }

                            Console.WriteLine("Select user id ");
                            User tempUserId = repo.users.FirstOrDefault(x => x.Id.ToString() == Console.ReadLine());
                            Console.WriteLine("Select role id ");
                            Role tempRoleId = repo.roles.FirstOrDefault(x => x.Id.ToString() == Console.ReadLine());

                            string status = repo.AssignRoleToUser(tempUserId, loggedInUser, tempRoleId);
                            if (status == "Success")
                            {
                                Console.WriteLine($"{tempUserId.UserName} has been added successfully {tempRoleId.RoleName}");

                            }
                            else if(status == "Unauthorized")
                            {
                                Console.WriteLine("You are not authorized ");

                            }
                            
                            break;



                        default:
                            break;
                    }




                    // check if user already exist and add it if it doesn't
                    if (repo.AddNewUser(username, password, loggedInUser))
                    {
                        Console.WriteLine($"{username} has been added");
                    }
                    else
                    {
                        Console.WriteLine($"{username} already exist");

                    }


                }
                else
                {
                    Console.WriteLine("Invalid username or password...");
                    Console.ReadKey();
                }



            }
        }
    }
}
