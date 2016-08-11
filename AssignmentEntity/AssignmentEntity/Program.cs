using AssignmentEntity.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            // loop for letting user run program more than once
            bool keepAlive = true;
            while (keepAlive)
            {
                //menu for all valid options
                Console.Clear();
                Console.WriteLine("\nWelcome to the school application - enter an option");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Add a student ---------------------(a)");
                Console.WriteLine("Add a teacher ---------------------(b)");
                Console.WriteLine("Add a course ----------------------(c)");
                Console.WriteLine("Add an assignment -----------------(d)");
                Console.WriteLine("Assign students to a course -------(e)");
                Console.WriteLine("Assign teacher to a course --------(f)");
                Console.WriteLine("Assign assignment to a course -----(g)");
                Console.WriteLine("Print information about a course --(h)");
                Console.WriteLine("Finished? -------------------------(q)\n");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "a":
                        //choice for adding a student
                        DBFunctions.AddStudent();
                        Console.ReadKey();
                        break;
                    case "b":
                        //choice for adding a teacher
                        DBFunctions.AddTeacher();
                        Console.ReadKey();
                        break;
                    case "c":
                        //choice for adding a course
                        DBFunctions.AddCourse();
                        Console.ReadKey();
                        break;
                    case "d":
                        //choice for adding an assignment
                        DBFunctions.AddAssignment();
                        Console.ReadKey();
                        break;
                    case "e":
                        //choice for adding a course to a student
                        DBFunctions.AssignCoursesToStudent();
                        Console.ReadKey();
                        break;
                    case "f":
                       //choice for adding a teacher to a course
                        DBFunctions.AssignTeacherToCourse();
                        Console.ReadKey();
                        break;
                    case "g":
                        //choice for adding an assignment to a course
                        DBFunctions.AssignAssignmentToCourse();
                        Console.ReadKey();
                        break;
                    case "h":
                        //choice for printing information about a course
                        DBFunctions.PrintCourse();
                        Console.ReadKey();
                        break;
                    case "q":
                        keepAlive = false;
                        Console.WriteLine("Press any key...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Not a valid choice, press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }        
    }
}
