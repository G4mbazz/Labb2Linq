using Labb2Linq.Data;
using Labb2Linq.Modells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Linq.Controllers
{
    internal class UIControlls
    {
        public static void Menu()
        {
            bool loop = false;
            while (!loop)
            {
                Console.WriteLine("\t\bMeny\n1. Alla engelska lärare\n2. Alla elever med sina lärare" +
                    "\n3. Contains\n4. Ändra namn på ämne\n5. Ändra namn på lärare\n6. Avluta ");
                int.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        AllTeachSub();
                        ReturnToMenu();
                        break;
                    case 2:
                        AllStudentsAndTeachers();
                        ReturnToMenu();
                        break;
                    case 3:
                        CheckIfContains();
                        ReturnToMenu();
                        break;
                    case 4:
                        ChangeSubjectName();
                        ReturnToMenu();
                        break;
                    case 5:
                        ChangeTeacherName();
                        ReturnToMenu();
                        break;
                    case 6:
                        loop = true;
                        break;
                    default:
                        Console.WriteLine("Du invalid");
                        ReturnToMenu();
                        break;
                }
            }

        }
        public static void AllTeachSub()
        {
            AppDbContext context = new AppDbContext();
            var allTeach = from sub in context.Subjects
                           where sub.Name == "Engelska"
                           join
                           t in context.Teachers on sub.TeacherID equals t.ID
                           select new
                           {
                              Fullname = t.FName + " " + t.LName,
                              subject = sub.Name
                           };
            foreach (var item in allTeach)
            {
                Console.WriteLine(item.Fullname + " " + item.subject);
            }
        }
        public static void AllStudentsAndTeachers()
        {
            AppDbContext context = new AppDbContext();
            var students = from student in context.Students
                           select student;
            var teachers = from teacher in context.Teachers
                          join sub in context.Subjects on
                          teacher.ID equals sub.TeacherID
                          select new
                          {
                              fullname = teacher.FName + " " + teacher.LName,
                              courseid = sub.CourseID
                          };
            var countStart = from cid in context.Courses 
                             select cid.ID;
            int counter = 1;
            foreach (var item in countStart)
            {
                counter++;
            }

            for (int i = 1; i < counter; i++)
            {
                Console.WriteLine($"-----Klass {i} Lärarna-----");
                foreach (var teacher in teachers.Where(p => p.courseid == i).Distinct())
                {
                    Console.WriteLine(teacher.fullname);
                }
                Console.WriteLine($"-----Klass {i} Elever");
                foreach (var item in students.Where(p => p.CourseID == i))
                {
                    Console.WriteLine(item.FName + " " + item.LName);
                }

            }

            var courseOneStudents = from s in context.Students
                                    join sub in context.Subjects
                                    on s.CourseID equals sub.CourseID
                                    join t in context.Teachers
                                    on sub.TeacherID equals t.ID
                                    where t.ID == sub.TeacherID && s.CourseID == sub.CourseID
                                    orderby s.CourseID descending
                                    select new
                                    {
                                        student = s.FName + " " + s.LName,

                                        teacher = t.FName + " " + t.LName
                                    };

            foreach (var item in courseOneStudents.Distinct())
            {
                Console.Write("Elev: " + item.student + " har lärare, ");
                foreach (var teacher in item.teacher)
                {
                    Console.Write(teacher);
                }
                Console.WriteLine();
            }
                //var courseOneTeachers;
                // var courseTwoStudents;
                //  var courseTwoTeachers;

            }
        public static void CheckIfContains()
        {
            AppDbContext context = new AppDbContext();
            bool doesContain = context.Subjects.Any(p => p.Name == "Programmering 1");
            Console.WriteLine(doesContain ? "Programmering 1 Finns" : "Programmering 1 Finns inte");

        }

        public static void ChangeSubjectName()
        {
            var context = new AppDbContext();
            bool ifExist = context.Subjects.Any(p => p.Name == "Programmering 1");
            var toChange = context.Subjects.Where(p => p.Name == "Programmering 1").FirstOrDefault();


            if (ifExist)
            {
                toChange.Name = "OOP";
                context.SaveChanges();
            }
            else 
            {
               toChange = context.Subjects.Where(p => p.Name == "OOP").FirstOrDefault();

                toChange.Name = "Programmering 1";
                context.SaveChanges();

            }

        }
        public static void ChangeTeacherName()
        {
            var context = new AppDbContext();
            bool ifExist = context.Teachers.Any(p => p.FName == "Anas");
            var toChange = context.Teachers.Where(p => p.FName == "Anas").FirstOrDefault();


            if (ifExist)
            {
                toChange.FName = "Tobias";
                context.SaveChanges();
            }
            else
            {
                toChange = context.Teachers.Where(p => p.FName == "Tobias").FirstOrDefault();

                toChange.FName = "Anas";
                context.SaveChanges();

            }
        }
    public static void ReturnToMenu()
        {
            Console.Write("Tryck på enter för at fortsätta: ");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
