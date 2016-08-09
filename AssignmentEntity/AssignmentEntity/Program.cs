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
            bool keepAlive = true;

            while (keepAlive)
            {
                Console.Clear();
                Console.WriteLine("\nWelcome to the school application");
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
                       
                        //add student
                        Console.WriteLine("Add student");
                        AddStudent();
                        Console.ReadKey();
                        break;
                    case "b":
                        Console.WriteLine("Add teacher");
                        AddTeacher();
                        Console.ReadKey();
                        break;
                    case "c":
                        Console.WriteLine("Add course");
                        AddCourse();
                        Console.ReadKey();
                        break;
                    case "d":
                        Console.WriteLine("Add assignment");
                        AddAssignment();
                        Console.ReadKey();
                        break;
                    case "e":
                        Console.WriteLine("Assign students to course");
                        break;
                    case "f":
                        Console.WriteLine("Assign teacher to course");
                        AssignTeacherToCourse();                        
                        break;
                    case "g":
                        Console.WriteLine("Assign assignment to course");
                        break;
                    case "h":
                        Console.WriteLine("Print info about a course");
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


        public static void AddStudent()
        {
            Console.WriteLine("Enter a name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter a phone number: ");
            string phoneNumber = Console.ReadLine();

            if (name.Length != 0 && phoneNumber.Length != 0)
            {
                Student s = new Student();
                s.Name = name;
                s.PhoneNumber = phoneNumber;

                using (var db = new AssignmentContext())
                {
                    db.Database.Log = Console.WriteLine;             
                    db.Students.Add(s);
                    db.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("Required information not entered, press any key...");
            }

        }


        public static void AddTeacher()
        {
            Console.WriteLine("Enter a name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter a phone number: ");
            string phoneNumber = Console.ReadLine();

            if (name.Length != 0 && phoneNumber.Length != 0)
            {
                Teacher t = new Teacher();
                t.Name = name;
                t.PhoneNumber = phoneNumber;

                using (var db = new AssignmentContext())
                {
                    db.Database.Log = Console.WriteLine;
                    db.Teachers.Add(t);
                    db.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("Required information not entered, press any key...");
            }

        }


        public static void AddCourse()
        {
            Console.WriteLine("Enter a name: ");
            string name = Console.ReadLine();
           
            if (name.Length != 0)
            {
                Course c = new Course();
                c.Name = name;
               
                using (var db = new AssignmentContext())
                {
                    db.Database.Log = Console.WriteLine;
                    db.Courses.Add(c);
                    db.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("Required information not entered, press any key...");
            }

        }


        public static void AddAssignment()
        {
            Console.WriteLine("Enter a name: ");
            string name = Console.ReadLine();

            if (name.Length != 0)
            {
                Assignment a = new Assignment();
                a.Name = name;
               
                using (var db = new AssignmentContext())
                {
                    db.Database.Log = Console.WriteLine;
                    db.Assignments.Add(a);
                    db.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("Required information not entered, press any key...");
            }

        }

        public static void AssignStudentsToCourse()
        {
            //list all courses

            //select a course to add students to

            //list all students

            //enter a studentid to add to course, -1 for instance to exit, add all students to a list

            //add the list to the course
            

        }
        
        public static void AssignTeacherToCourse()
        {
            AssignmentContext db = new AssignmentContext();

            //list all courses
            List<Course> courses = db.Courses.ToList();

            Console.WriteLine("All available courses right now: \n");
            foreach (var course in courses)
            {
                Console.WriteLine("Id: " + course.Id +" - " + course.Name);
            }

            //select a course to add a teacher to
            Console.WriteLine("Enter a course id for assigning to a teacher");
            int courseChoice = int.Parse(Console.ReadLine());

            //list all teachers
            List<Teacher> teachers = db.Teachers.ToList();

            Console.WriteLine("All available teachers right now: \n");
            foreach (var teacher in teachers)
            {
                Console.WriteLine("Id: " +teacher.Id + " - " +teacher.Name);
            }

            //enter a teacher id to add to a course, -1 for instance to exit
            Console.WriteLine("Enter a teacher id for assigning to selected course");
            int teacherChoice = int.Parse(Console.ReadLine());



            //testing

            var courseUpdate = new Course();
            courseUpdate = db.Courses.Find(courseChoice);

            var teacherToAdd = new Teacher();
            teacherToAdd = db.Teachers.Find(teacherChoice);

            //         courseUpdate.AssignedToTeacher.Id = teacherChoice;

            // nullpointer....
            courseUpdate.AssignedToTeacher.Id = teacherToAdd.Id;




            //       courseUpdate.AssignedToTeacher



            //ninja.EquipmentOwned.Add(muscles);
            //ninja.EquipmentOwned.Add(spunk);
            //context.Ninjas.Add(ninja);
            //context.SaveChanges();







            //add the teacher to the course


        }

    }
}
