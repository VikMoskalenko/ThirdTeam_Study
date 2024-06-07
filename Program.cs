using System.Text.RegularExpressions;
using ThirdTeam_Study.Managers;

namespace ThirdTeam_Study
{
    public class Program
    {
        static void Main()
        {

            TutorManager f = new();
            Console.WriteLine(f.CreateTutor("wedewfef", "vvvvvv", new DateOnly(1998,10,11)));


            List<Tutor> t = f.FileManager.ReadAllFromFile();
            foreach (var tutor in t) Console.WriteLine(tutor.Id.ToString());
            Console.WriteLine();
            Console.WriteLine(f.GetTutorById(new Guid("09327d5c-6d03-43cf-a2d3-462d50ca20b8")).Id.ToString());




            /*var tutor = TutorManager.CreateTutor("Mykola", "Posipajlo", new DateOnly(1965, 4, 1));
            var tutorList = new TutorList();
            tutorList.AddTutor(tutor);
            tutorList.AddTutor("Pavlo", "Lazarenko", new DateOnly(1950, 4, 1));
            var studentList = new StudentList();
            studentList.AddStudent("1234567", "2016", "José", "Martínez");
            studentList.AddStudent("1234568", "2017", "María", "García");
            studentList.AddStudent("1234569", "2016", "Antonio", "López");
            studentList.AddStudent("1234570", "2016", "Carmen", "Hernández");
            studentList.AddStudent("1234571", "2017", "Luis", "González");
            studentList.AddStudent("1234572", "2017", "Ana", "Rodríguez");
            studentList.AddStudent("1234573", "2016", "Manuel", "Pérez");
            studentList.AddStudent("1234574", "2017", "Isabel", "Sánchez");
            studentList.AddStudent("1234575", "2016", "Francisco", "Ramírez");
            studentList.AddStudent("1234576", "2017", "Laura", "Torres");
            var lesson = new Lesson("Ukrainian", "Ukrainian alphabet", studentList)
            {
                Tutor = tutor,
                LessonStart = new DateTime(2024, 01, 25, 14, 00, 00),
            };

            lesson.LessonInfo();
            UserInput("Enter score", input => lesson.SetUpdateScore("1234573", input));
            UserInput("Enter score", input => lesson.SetUpdateScore("Isabel", "Sánchez", input));
            UserInput("Enter score", input => lesson.SetUpdateScore("12573", input));
            studentList.RemoveStudent("1234573");
            var customerService = new CustomerService("nostupidquestion@study.md")
            {
                Students = studentList,
                Tutors = tutorList,
                ServicePhone = "937-99-92"
            };

            Student firstStudent = studentList.First();

            customerService.GetSupportInfo();

            HomeWork hw1 = new(firstStudent)
            {
                Id = Guid.NewGuid()
            };

            hw1.SubmitHW();

            Console.WriteLine();

            hw1.AssertHW();

            Console.WriteLine();

            hw1.AddHWComment();

            Console.WriteLine(String.Format("| {0,15 } | {1,20} | {2,15} | {3,25} |", "Teacher", "Home work number", "Grade", "Comment"));
            Console.WriteLine("| {0,-15} | {1,-20} | {2, -15} | {3, -25} |", new string('-', 15), new string('-', 20), new string('-', 15), new string('-', 25));
            Console.WriteLine(String.Format("| {0,15} | {1,20} | {2,15} | {3,25} |", hw1.GetStudentFullName(), hw1.HomeWorkNumber, hw1.Grade, hw1.Comment));*/

        }
        public static void UserInput(string Message, Action<string> setInput)
        {
            bool enterError;
            do
            {
                enterError = false;
                try
                {
                    Console.WriteLine(Message);
                    string input = Console.ReadLine();
                    if (input != null)
                    {
                        setInput(input);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    enterError = true;

                }
            } while (enterError);
        }

    }
}
