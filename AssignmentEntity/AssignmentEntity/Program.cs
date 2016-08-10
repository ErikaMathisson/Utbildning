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
                        Console.WriteLine("Add student - ready");
                        AddStudent();
                        Console.ReadKey();
                        break;
                    case "b":
                        Console.WriteLine("Add teacher - ready");
                        AddTeacher();
                        Console.ReadKey();
                        break;
                    case "c":
                        Console.WriteLine("Add course - ready");
                        AddCourse();
                        Console.ReadKey();
                        break;
                    case "d":
                        Console.WriteLine("Add assignment - ready");
                        AddAssignment();
                        Console.ReadKey();
                        break;
                    case "e":
                        Console.WriteLine("Assign students to course - ready");
                        AssignCoursesToStudent();                        
                        break;
                    case "f":
                        Console.WriteLine("Assign teacher to course - ready");
                        AssignTeacherToCourse();
                        break;
                    case "g":
                        Console.WriteLine("Assign assignment to course - ready");
                        AssignAssignmentToCourse();
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

        /// <summary>
        /// Function for adding a student to the database
        /// </summary>
        public static void AddStudent()
        {
            //get name and phonenumber from the user
            Console.WriteLine("Enter a name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter a phone number: ");
            string phoneNumber = Console.ReadLine();
            //check if any values where entered
            if (name.Length != 0 && phoneNumber.Length != 0)
            {
                //create a new student and assign the properties
                Student s = new Student();
                s.Name = name;
                s.PhoneNumber = phoneNumber;
                //add the student to the database
                using (var db = new AssignmentContext())
                {
                    //     db.Database.Log = Console.WriteLine;
                    db.Students.Add(s);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }

                }
            }
            else
            {
                Console.WriteLine("Required information not entered, press any key...");
            }
        }

        /// <summary>
        /// Function for adding a teacher to the database
        /// </summary>
        public static void AddTeacher()
        {
            // get input for a teacher from the user
            Console.WriteLine("Enter a name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter a phone number: ");
            string phoneNumber = Console.ReadLine();
            // check if required information where entered by the user
            if (name.Length != 0 && phoneNumber.Length != 0)
            {
                //create a new teacher and assign the properties to it
                Teacher t = new Teacher();
                t.Name = name;
                t.PhoneNumber = phoneNumber;
                // connect to database and store the teacher
                using (var db = new AssignmentContext())
                {
                    //       db.Database.Log = Console.WriteLine;
                    db.Teachers.Add(t);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e);
                    }
                }
            }
            else
            {
                Console.WriteLine("Required information not entered, press any key...");
            }
        }

        /// <summary>
        /// function for adding a course to the database
        /// </summary>
        public static void AddCourse()
        {
            // get information from the user
            Console.WriteLine("Enter a name: ");
            string name = Console.ReadLine();
            // check if information where entered
            if (name.Length != 0)
            {
                // create a new course and assign the property to it
                Course c = new Course();
                c.Name = name;
                //connect to database and try to store the course
                using (var db = new AssignmentContext())
                {
                    db.Database.Log = Console.WriteLine;
                    db.Courses.Add(c);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            else
            {
                Console.WriteLine("Required information not entered, press any key...");
            }

        }

        /// <summary>
        /// function for adding an assignment
        /// </summary>
        public static void AddAssignment()
        {
            // get information from the user
            Console.WriteLine("Enter a name: ");
            string name = Console.ReadLine();
            // check if information where entered
            if (name.Length != 0)
            {
                // create a new assignment and assign the property to it
                Assignment a = new Assignment();
                a.Name = name;
                //connect to database and try to update it with the assignment
                using (var db = new AssignmentContext())
                {
                    db.Database.Log = Console.WriteLine;
                    db.Assignments.Add(a);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }

                }
            }
            else
            {
                Console.WriteLine("Required information not entered, press any key...");
            }

        }

        /// <summary>
        /// function for adding courses to a student
        /// </summary>
        public static void AssignCoursesToStudent()
        {
            // new database connection
            AssignmentContext db = new AssignmentContext();
            //    db.Database.Log = Console.WriteLine;

            //retrieve all available students from database and show them for the user
            Console.WriteLine("\nAll available students right now: \n");
            List<Student> students = db.Students.ToList();
            if (students != null)
            {
                foreach (var student in students)
                {
                    Console.WriteLine("Id: " + student.Id + " - " + student.Name);
                }

                //ask the user to select a student to add a course to it
                Console.WriteLine("Enter a student id for assigning to a course");
                int studentChoice = 0;
                bool alive = true;
                // loop until a valid value is entered
                while (alive)
                {
                    // convert the input from user from string to a int
                    string c = Console.ReadLine();
                    if (CanBeConverted(c))
                    {
                        studentChoice = ConvertToInt(c);
                        alive = false;
                    }
                    else
                    {
                        Console.WriteLine("Not a valid option");
                    }
                }

                // select all courses from database and list them for the user
                Console.WriteLine("All available courses right now: \n");
                List<Course> courses = db.Courses.ToList();
                //check so that the list contains any elements
                if (courses != null)
                {
                    foreach (var course in courses)
                    {
                        Console.WriteLine("Id: " + course.Id + " - " + course.Name);
                    }

                    // new list of courses for adding to the student
                    List<Course> addCourse = new List<Course>();

                    bool keepAlive = true;
                    int courseChoice = 0;
                    //loop for entering more than one course if the user wants to
                    while (keepAlive)
                    {
                        //enter a course id to add to a student
                        Console.WriteLine("Enter a course id for assigning to selected student");
                        alive = true;
                        // loop as long as the user enters a non valid option
                        while (alive)
                        {
                            // convert the input from user from string to a int
                            string c = Console.ReadLine();
                            if (CanBeConverted(c))
                            {
                                courseChoice = ConvertToInt(c);
                                alive = false;
                            }
                            else
                            {
                                Console.WriteLine("Not a valid option, try again");
                            }
                        }
                        // course to be added to a student                                  
                        var courseToAdd = courses.Find(x => x.Id == courseChoice);
                        //add the course in a list
                        addCourse.Add(courseToAdd);
                        //check if the user wants to add another course to the selected student
                        Console.WriteLine("Enter another one? (n) for no or press any key...");
                        string choice = Console.ReadLine();
                        if (choice == "n")
                        {
                            keepAlive = false;
                        }
                    }
                    //find the student to be updated, check if its not null and add the courses
                    var studentUpdate = students.Find(x => x.Id == studentChoice);
                    if (studentUpdate != null)
                    {
                        studentUpdate.Courses = addCourse;

                        //try to add the changes to the database
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("You entered a faulty choice, press any key...");
                        Console.ReadKey();
                    }

                }
                else
                {
                    Console.WriteLine("No courses available, add some first. Press any key...");
                    Console.ReadKey();
                }

            }
            else
            {
                Console.WriteLine("No students exists, add some first. Press any key... ");
                Console.ReadKey();
            }
        }

       /// <summary>
       /// function for assigning a teacher to a course
       /// </summary>
        public static void AssignTeacherToCourse()
        {
            // create a new instance of database
            AssignmentContext db = new AssignmentContext();
         //   db.Database.Log = Console.WriteLine;

            //list all courses
            List<Course> courses = db.Courses.ToList();
            Console.WriteLine("All available courses right now: \n");
            //check if any courses exist
            if (courses != null)
            {
                // list all the courses for the user
                foreach (var course in courses)
                {
                    Console.WriteLine("Id: " + course.Id + " - " + course.Name);
                }

                //select a course to add a teacher to
                Console.WriteLine("Enter a course id for assigning to a teacher");
                int courseChoice = int.Parse(Console.ReadLine());

                Console.WriteLine("All available teachers right now: \n");
                // list all teachers
                List<Teacher> teachers = db.Teachers.ToList();
                //check if any teachers exist
                if (teachers != null)
                {
                    //list the teachers for the user
                    foreach (var teacher in teachers)
                    {
                        Console.WriteLine("Id: " + teacher.Id + " - " + teacher.Name);
                    }

                    //enter a teacher id to add to a course, -1 for instance to exit
                    Console.WriteLine("Enter a teacher id for assigning to selected course");
                    int teacherChoice = int.Parse(Console.ReadLine());
                    
                    var courseUpdate = courses.Find(x => x.Id == courseChoice);
                    var teacherToAdd = teachers.Find(x => x.Id == teacherChoice);
                    //update the course with the teacher
                    courseUpdate.AssignedToTeacher = teacherToAdd;
                    // save the changes to the database
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.ReadKey();
                    }

                }
                else
                {
                    Console.WriteLine("No teachers exits, press any key...");
                    Console.ReadKey();
                }

            }
            else
            {
                Console.WriteLine("No courses entered, press any key...");
            }
        }

        /// <summary>
        /// function for adding assignments to a course
        /// </summary>
        public static void AssignAssignmentToCourse()
        {
            // new database connection
            AssignmentContext db = new AssignmentContext();
            //    db.Database.Log = Console.WriteLine;

            //retrieve all available courses from database and show them for the user
            Console.WriteLine("\nAll available courses right now: \n");
            List<Course> courses = db.Courses.ToList();
            if (courses != null)
            {
                foreach (var course in courses)
                {
                    Console.WriteLine("Id: " + course.Id + " - " + course.Name);
                }

                //ask the user to select a course to add an assignment to
                Console.WriteLine("Enter a course id for assigning to an assignment");
                int courseChoice = 0;
                bool alive = true;
                // loop until a valid value is entered
                while (alive)
                {
                    // convert the input from user from string to a int
                    string c = Console.ReadLine();
                    if (CanBeConverted(c))
                    {
                        courseChoice = ConvertToInt(c);
                        alive = false;
                    }
                    else
                    {
                        Console.WriteLine("Not a valid option");
                    }
                }

                // select all assignments from database and list them for the user
                Console.WriteLine("All available assignments right now: \n");
                List<Assignment> assignments = db.Assignments.ToList();
                //check so that the list contains any elements
                if (assignments != null)
                {
                    foreach (var a in assignments)
                    {
                        //if the assignment is assigned to a course list the course
                        if (a.AssignedToCourse != null)
                        {
                            Console.WriteLine("Id: " + a.Id + " - " + a.Name + " - assigned to course: " + a.AssignedToCourse.Name);
                        }
                        else
                        {
                            Console.WriteLine("Id: " + a.Id + " - " + a.Name);
                        }
                    }

                    // new list of assignments for adding to the course
                    List<Assignment> addAssignment = new List<Assignment>();

                    bool keepAlive = true;
                    int assignmentChoice = 0;
                    //loop for entering more than one assignment if the user wants to
                    while (keepAlive)
                    {
                        //enter an assignment id to add to a course
                        Console.WriteLine("Enter an assignment id for assigning to selected course");
                        alive = true;
                        // loop as long as the user enters a non valid option
                        while (alive)
                        {
                            // convert the input from user from string to a int
                            string c = Console.ReadLine();
                            if (CanBeConverted(c))
                            {
                                assignmentChoice = ConvertToInt(c);
                                alive = false;
                            }
                            else
                            {
                                Console.WriteLine("Not a valid option, try again");
                            }
                        }
                        // assignment to be added to a course                                  
                        var assignmentToAdd = assignments.Find(x => x.Id == assignmentChoice);
                        //add the assignment in a list
                        addAssignment.Add(assignmentToAdd);
                        //check if the user wants to add another assignment to the selected course
                        Console.WriteLine("Enter another one? (n) for no or press any key...");
                        string choice = Console.ReadLine();
                        if (choice == "n")
                        {
                            keepAlive = false;
                        }
                    }
                    //find the course to be updated, check if its not null and add the assignments
                    var courseUpdate = courses.Find(x => x.Id == courseChoice);
                    if (courseUpdate != null)
                    {
                        courseUpdate.Assignments = addAssignment;

                        //try to add the changes to the database
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("You entered a faulty choice, press any key...");
                        Console.ReadKey();
                    }

                }
                else
                {
                    Console.WriteLine("No assignments available, add some first. Press any key...");
                    Console.ReadKey();
                }

            }
            else
            {
                Console.WriteLine("No courses exists, add some first. Press any key... ");
                Console.ReadKey();
            }
        }




        //todo

        public static void PrintCourse()
        {

            // new database connection
            AssignmentContext db = new AssignmentContext();
            //    db.Database.Log = Console.WriteLine;

            //retrieve all available courses from database and show them for the user
            Console.WriteLine("\nAll available courses: \n");
            List<Course> courses = db.Courses.ToList();
            if (courses != null)
            {
                foreach (var course in courses)
                {
                    Console.WriteLine("Id: " + course.Id + " - " + course.Name);
                }

                //ask the user to select a course to add an assignment to
                Console.WriteLine("Enter a course id to get information about:");
                int courseChoice = 0;
                bool alive = true;
                // loop until a valid value is entered
                while (alive)
                {
                    // convert the input from user from string to a int
                    string c = Console.ReadLine();
                    if (CanBeConverted(c))
                    {
                        courseChoice = ConvertToInt(c);
                        alive = false;
                    }
                    else
                    {
                        Console.WriteLine("Not a valid option");
                    }
                }

                var selectedCourse = courses.Find(x => x.Id == courseChoice);
                if (selectedCourse != null)
                {
                   

                    //should you use include here??









                }
            else
            {
                Console.WriteLine("No courses exists, add some first. Press any key... ");
                Console.ReadKey();
            }





        }

        /// <summary>
        /// Method for checking if the input text from user can be converted to an integer
        /// </summary>
        /// <param name="input">String input from user</param>
        /// <returns>bool</returns>
        public static bool CanBeConverted(string input)
        {
            int result;
            if (int.TryParse(input, out result))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Method for convering an input string to integer
        /// </summary>
        /// <param name="input">The text input from the user</param>
        /// <returns>int</returns>
        public static int ConvertToInt(string input)
        {
            return int.Parse(input);
        }




    }
}
