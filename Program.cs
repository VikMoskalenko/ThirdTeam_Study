using System.Text.RegularExpressions;
using ThirdTeam_Study.Managers;
<<<<<<< HEAD
=======
using ThirdTeam_Study.ListTypes;
>>>>>>> 4fd579358fc8ecf7dc5879dad1b6608758383345

namespace ThirdTeam_Study
{
    public class Program
    {
        static void Main()
        {
            TutorManager tutor_manager = new();

<<<<<<< HEAD
            Console.WriteLine(tutor_manager.CreateTutor("Володимир", "Мунтян", new DateOnly(2001, 12, 13)));
            Console.WriteLine(tutor_manager.CreateTutor("Марія", "Яремчук", new DateOnly(1997, 9, 7)));
            Console.WriteLine(tutor_manager.CreateTutor("Олег", "Омельчук", new DateOnly(2000, 8, 8)));
            Console.WriteLine(tutor_manager.CreateTutor("Каріна", "Маліна", new DateOnly(1999, 10, 11)));
            Console.WriteLine(tutor_manager.CreateTutor("Василь", "Вірастюк", new DateOnly(2001, 1, 7)));
            Console.WriteLine(tutor_manager.CreateTutor("Микола", "Сидоренко", new DateOnly(2000, 5, 5)));
=======
<<<<<<< HEAD
            TutorManager tutorManager = new TutorManager();
            Console.WriteLine(tutorManager.CreateTutor("Ірина", "Щука", new DateOnly(2004, 11, 01)));
            Console.WriteLine(tutorManager.CreateTutor("Марія", "Кущ", new DateOnly(2000, 10, 22)));
            Console.WriteLine(tutorManager.CreateTutor("Василь", "Шевченко", new DateOnly(2006, 06, 01)));
            Console.WriteLine(tutorManager.CreateTutor("Володимир", "Мунтян", new DateOnly(1999, 12, 11)));
            Console.WriteLine(tutorManager.CreateTutor("Сань", "Ху-сінь", new DateOnly(1997, 08, 01)));

            var studentList = new StudentList();
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
=======
            var edPlatformManager = new EdPlatformManager();
            var edPlatform = edPlatformManager.EdPlatformInstance;
<<<<<<< HEAD
>>>>>>> TutorManagerBranch

            // GetTutorById, UpdateTutor, DeleteTutor можно проверить, выбрав какой-то айдишник из файла Tutor.json

            // Общая часть мейна:
            /* 
             var tutor = tutor_manager.CreateTutor("Мікола", "Посіпайло", new DateOnly(1965, 4, 1));
             var tutor2 = tutor_manager.CreateTutor("Павло", "Лазаренко", new DateOnly(2004, 11, 4));

<<<<<<< HEAD
             var edPlatformManager = new EdPlatformManager();
             var edPlatform = edPlatformManager.EdPlatformInstance;
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
=======
=======

            var tutor = TutorManager.CreateTutor("Mykola", "Posipajlo", new DateOnly(1965, 4, 1));
            edPlatformManager.SignUp(tutor);
            var tutor2 = TutorManager.CreateTutor("Pavlo", "Lazarenko", new DateOnly(1950, 4, 1));
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

>>>>>>> parent of f9938dc (..)
            var lesson = new Lesson("Ukrainian", "Ukrainian alphabet", edPlatform.Students)
>>>>>>> 4fd579358fc8ecf7dc5879dad1b6608758383345
            {
                Tutor = tutorManager.CreateTutor("Вікторія", "Вакарчук", new DateOnly(2002, 08, 08)),
                LessonStart = new DateTime(2024, 01, 25, 14, 00, 00),
            };

            lesson.LessonInfo();
<<<<<<< HEAD
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
=======
            InputManager.UserInput("Enter score", input => 
                lesson.SetUpdateScore(edPlatform.Students.Find(s => s.Name == "Manuel")?.Id ?? Guid.Empty, input)); // Id is not null, cause students was created with hardcode!
            InputManager.UserInput("Enter score", input => lesson.SetUpdateScore("Isabel", "Sánchez", input));
            InputManager.UserInput("Enter score", input => 
                lesson.SetUpdateScore(edPlatform.Students.Find(s => s.Name == "Elisa")?.Id ?? Guid.Empty, input));
            edPlatformManager.RemoveStudent(edPlatform.Students.Find(s => s.Name == "Manuel") ?? new Student(Guid.Empty, "", "", "") { Name = "", LastName = ""});
            
>>>>>>> 4fd579358fc8ecf7dc5879dad1b6608758383345
>>>>>>> TutorManagerBranch

             var lesson = new Lesson("Ukrainian", "Ukrainian alphabet", edPlatform.Students)
             {
                 Teacher = tutor,
                 LessonStart = new DateTime(2024, 01, 25, 14, 00, 00),
             };

             lesson.LessonInfo();
             InputManager.UserInput("Enter score", input => 
                 lesson.SetUpdateScore(edPlatform.Students.Find(s => s.Name == "Manuel")?.Id ?? Guid.Empty, input)); // Id is not null, cause students was created with hardcode!
             InputManager.UserInput("Enter score", input => lesson.SetUpdateScore("Isabel", "Sánchez", input));
             InputManager.UserInput("Enter score", input => 
                 lesson.SetUpdateScore(edPlatform.Students.Find(s => s.Name == "Elisa")?.Id ?? Guid.Empty, input));
             edPlatformManager.RemoveStudent(edPlatform.Students.Find(s => s.Name == "Manuel") ?? new Student(Guid.Empty, "", "", "") { Name = "", LastName = ""});


             Student firstStudent = edPlatform.Students.First();

             edPlatformManager.GetSupportInfo();

             HomeWork hw1 = new(firstStudent)
             {
                 Id = Guid.NewGuid()
             };

             hw1.SubmitHW();

             Console.WriteLine();

<<<<<<< HEAD
             hw1.AssertHW();

             Console.WriteLine();

             hw1.AddHWComment();

             Console.WriteLine(String.Format("| {0,15 } | {1,20} | {2,15} | {3,25} |", "Teacher", "Home work number", "Grade", "Comment"));
             Console.WriteLine("| {0,-15} | {1,-20} | {2, -15} | {3, -25} |", new string('-', 15), new string('-', 20), new string('-', 15), new string('-', 25));
             Console.WriteLine(String.Format("| {0,15} | {1,20} | {2,15} | {3,25} |", hw1.GetStudentFullName(), hw1.HomeWorkNumber, hw1.Grade, hw1.Comment));
            */
        }

=======
            Console.WriteLine(String.Format("| {0,15 } | {1,20} | {2,15} | {3,25} |", "Teacher", "Home work number", "Grade", "Comment"));
            Console.WriteLine("| {0,-15} | {1,-20} | {2, -15} | {3, -25} |", new string('-', 15), new string('-', 20), new string('-', 15), new string('-', 25));
            Console.WriteLine(String.Format("| {0,15} | {1,20} | {2,15} | {3,25} |", hw1.GetStudentFullName(), hw1.HomeWorkNumber, hw1.Grade, hw1.Comment));
            
        }
<<<<<<< HEAD
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
=======
        
>>>>>>> 4fd579358fc8ecf7dc5879dad1b6608758383345
>>>>>>> TutorManagerBranch

    }
}
