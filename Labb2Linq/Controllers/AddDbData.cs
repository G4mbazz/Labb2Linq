using Labb2Linq.Data;
using Labb2Linq.Modells;


namespace Labb2Linq.Controllers
{
    internal class AddDbData
    {
        public static void AddDataMenu()
        {
            bool loop = false;
            while (!loop)
            {
                Console.WriteLine("\t\bMeny\n1.Lägg till en Kurs\n2.Lägg till en lärare\n3. Lägg till ett ämne\n4. Lägg till en Student\n5. Avsluta ");
                int.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        AddCourse();
                        break;
                    case 2:
                        AddTeacher();
                        break;
                    case 3:
                        AddSubject();
                        break;
                    case 4:
                        AddStudent();
                        break;
                    case 5:
                        loop = true;
                        break;
                    default:
                        Console.WriteLine("Du invalid");
                        break;
                }
            }
        }
        public static void AddTeacher()
        {
            Console.Write("Lärares Förnamn: ");
            string fName = Console.ReadLine();
            Console.Write("Lärares Efternamn: ");
            string lName = Console.ReadLine();

            Console.WriteLine("Spara lärare med namn " + fName +" " + lName + "  Y/N?");
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                AppDbContext context = new AppDbContext();
                Teacher teacher = new Teacher()
                {
                    FName = fName,
                    LName = lName
                   
                };
                context.Add(teacher);
                context.SaveChanges();
                Console.WriteLine("Sparat");
            }


        }
        public static void AddSubject()
        {
            AppDbContext context = new AppDbContext();
            var getCourseAndID = context.Courses;
            var getAllTeachersAndID = context.Teachers;
            Console.Write("Vilket ämne vill du lägga till?: ");
            string subName = Console.ReadLine();
            foreach (var item in getAllTeachersAndID)
            {
                Console.WriteLine("ID: " + item.ID + " " + item.FName + " " + item.LName);
            }
            Console.Write("Vem lär ut ämnet?\nID: ");
            int.TryParse(Console.ReadLine(), out int teachID);
            foreach (var item in getCourseAndID)
            {
                Console.WriteLine("ID: " + item.ID + " " + item.Name);
            }
            Console.WriteLine("Vilken kurs har ämnet?\nID: ");
            int.TryParse(Console.ReadLine(), out int courseID);
            Console.Write($"Spara Ämne {subName} för kurs {courseID} med lärare {teachID} \nY/N");
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                Subject subject = new Subject()
                {
                    Name = subName,
                    CourseID = courseID,
                    TeacherID = teachID,
                };
                context.Add(subject);
                context.SaveChanges();
                Console.WriteLine("Sparat");
            }

        }
        public static void AddStudent()
        {
                AppDbContext context = new AppDbContext();
            var getCourseAndID = context.Courses;
            Console.Write("Elev Förnamn: ");
            string fName = Console.ReadLine();
            Console.Write("Elev Efternamn: ");
            string lName = Console.ReadLine();
            foreach (var item in getCourseAndID)
            {
                Console.WriteLine(item.ID + ", " + item.Name);
            }

            Console.Write("Elev KursID: ");
            int.TryParse(Console.ReadLine(), out int courseID);


            Console.WriteLine("Spara Elev med namn " + fName + " " + lName + " och kursID: "+courseID+ "  Y/N?");
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                Student student = new Student()
                {
                    FName = fName,
                    LName = lName,
                    CourseID = courseID

                };
                context.Add(student);
                context.SaveChanges();
                Console.WriteLine("Sparat");
            }


        }
        public static void AddCourse()
        {
            Console.Write("Kurs Namn: ");
            string courseName = Console.ReadLine();
            Console.WriteLine("Spara kurs namn " + courseName + "  Y/N?");
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                AppDbContext context = new AppDbContext();
                Course course = new Course()
                {
                    Name = courseName
                };
                context.Add(course);
                context.SaveChanges();
                Console.WriteLine("Sparat");

            }

        }
    }
}
