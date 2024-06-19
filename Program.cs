using System.Text.RegularExpressions;
using ThirdTeam_Study.Managers;
using ThirdTeam_Study.ListTypes;

namespace ThirdTeam_Study
{
    public class Program
    {
        static void Main()
        {
            //TutorManager tutor_manager = new();
            var tutor_manager = new TutorManager();

            Console.WriteLine(tutor_manager.CreateTutor("Володимир", "Мунтян", new DateOnly(2001, 12, 13)));
            Console.WriteLine(tutor_manager.CreateTutor("Марія", "Яремчук", new DateOnly(1997, 9, 7)));
            Console.WriteLine(tutor_manager.CreateTutor("Олег", "Омельчук", new DateOnly(2000, 8, 8)));
            Console.WriteLine(tutor_manager.CreateTutor("Каріна", "Маліна", new DateOnly(1999, 10, 11)));
            Console.WriteLine(tutor_manager.CreateTutor("Василь", "Вірастюк", new DateOnly(2001, 1, 7)));
            Console.WriteLine(tutor_manager.CreateTutor("Микола", "Сидоренко", new DateOnly(2000, 5, 5)));

            var edPlatformManager = new EdPlatformManager();
            var edPlatform = EdPlatformManager.EdPlatformInstance;

            // GetTutorById, UpdateTutor, DeleteTutor можно проверить, выбрав какой-то айдишник из файла Tutor.json

            // Общая часть мейна:
            
             var tutor = tutor_manager.CreateTutor("Мікола", "Посіпайло", new DateOnly(1965, 4, 1));
             var tutor2 = tutor_manager.CreateTutor("Павло", "Лазаренко", new DateOnly(2004, 11, 4));

            edPlatformManager.SignUp(tutor);
            edPlatformManager.SignUp(tutor2);

            edPlatformManager.SignUp(new Student(Guid.NewGuid(), "2016", "José", "Martínez") { Name = "José", LastName = "Martínez" });
            edPlatformManager.SignUp(new Student(Guid.NewGuid(), "2017", "María", "García") { Name = "María", LastName = "García" });
            edPlatformManager.SignUp(new Student(Guid.NewGuid(), "2016", "Antonio", "López") { Name = "Antonio", LastName = "López" });
            edPlatformManager.SignUp(new Student(Guid.NewGuid(), "2016", "Carmen", "Hernández") { Name = "Carmen", LastName = "Hernández" });
            edPlatformManager.SignUp(new Student(Guid.NewGuid(), "2017", "Luis", "González") { Name = "Luis", LastName = "González" });
            edPlatformManager.SignUp(new Student(Guid.NewGuid(), "2017", "Ana", "Rodríguez") { Name = "Ana", LastName = "Rodríguez" });
            edPlatformManager.SignUp(new Student(Guid.NewGuid(), "2016", "Manuel", "Pérez") { Name = "Manuel", LastName = "Pérez" });
            edPlatformManager.SignUp(new Student(Guid.NewGuid(), "2017", "Isabel", "Sánchez") { Name = "Isabel", LastName = "Sánchez" });
            edPlatformManager.SignUp(new Student(Guid.NewGuid(), "2016", "Francisco", "Ramírez") { Name = "Francisco", LastName = "Ramírez" });
            edPlatformManager.SignUp(new Student(Guid.NewGuid(), "2017", "Laura", "Torres") { Name = "Laura", LastName = "Torres" });

            var lesson = new Lesson("Ukrainian", "Ukrainian alphabet", edPlatform.Students)
            {
                Teacher = tutor_manager.CreateTutor("Вікторія", "Вакарчук", new DateOnly(2002, 08, 08)),
                LessonStart = new DateTime(2024, 01, 25, 14, 00, 00),
            };

            lesson.LessonInfo();


             Student firstStudent = edPlatform.Students.First();

             edPlatformManager.GetSupportInfo();

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
                    string? input = Console.ReadLine();
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
