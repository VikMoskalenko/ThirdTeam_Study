using System.Text.RegularExpressions;
using ThirdTeam_Study.Managers;

namespace ThirdTeam_Study
{
    public class Program
    {
        static void Main()
        {

            TutorManager tutorManager = new TutorManager();
            Console.WriteLine(tutorManager.CreateTutor("Ірина", "Щука", new DateOnly(2004, 11, 01)));
            Console.WriteLine(tutorManager.CreateTutor("Марія", "Кущ", new DateOnly(2000, 10, 22)));
            Console.WriteLine(tutorManager.CreateTutor("Василь", "Шевченко", new DateOnly(2006, 06, 01)));
            Console.WriteLine(tutorManager.CreateTutor("Володимир", "Мунтян", new DateOnly(1999, 12, 11)));
            Console.WriteLine(tutorManager.CreateTutor("Сань", "Ху-сінь", new DateOnly(1997, 08, 01)));

            /*var studentList = new StudentList();
            studentList.AddStudent(1234567, "2016", "José", "Martínez");
            studentList.AddStudent(1234568, "2017", "María", "García");
            studentList.AddStudent(1234569, "2016", "Antonio", "López");
            studentList.AddStudent(1234570, "2016", "Carmen", "Hernández");
            studentList.AddStudent(1234571, "2017", "Luis", "González");
            studentList.AddStudent(1234572, "2017", "Ana", "Rodríguez");
            studentList.AddStudent(1234573, "2016", "Manuel", "Pérez");
            studentList.AddStudent(1234574, "2017", "Isabel", "Sánchez");
            studentList.AddStudent(1234575, "2016", "Francisco", "Ramírez");
            studentList.AddStudent(1234576, "2017", "Laura", "Torres");
            var lesson = new Lesson("Ukrainian", "Ukrainian alphabet", studentList)
            {
                Tutor = tutorManager.CreateTutor("Вікторія", "Вакарчук", new DateOnly(2002, 08, 08)),
                LessonStart = new DateTime(2024, 01, 25, 14, 00, 00),
            };

            lesson.LessonInfo();
            UserInput("Enter score", input => lesson.SetUpdateScore(1234573, input));
            UserInput("Enter score", input => lesson.SetUpdateScore("Isabel", "Sánchez", input));
            UserInput("Enter score", input => lesson.SetUpdateScore(12573, input));
            studentList.RemoveStudent(1234573);
            var customerService = new CustomerService("nostupidquestion@study.md")
            {
                Students = studentList,
                Tutors = tutorManager.GetAllTutors(),
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
            Console.WriteLine(String.Format("| {0,15} | {1,20} | {2,15} | {3,25} |", hw1.GetStudentFullName(), hw1.HomeWorkNumber, hw1.Grade, hw1.Comment));
            */
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
