using System.Text.RegularExpressions;

namespace ThirdTeam_Study
{
    public class Program
    {
        static void Main()
        {
            HomeWork hw1 = new(new Tutor("Jhon", "Dou", new DateOnly(1991, 1, 24)))
            {
                Id= Guid.NewGuid().ToString(),
            };

            while (true)
            {
                Console.WriteLine("Enter path to your home work file:");
                string sourceFilePath = Console.ReadLine() ?? string.Empty;

                if (String.IsNullOrEmpty(sourceFilePath)) {
                    Console.WriteLine("You need to paste path to home work file");
                }

                try
                {
                    hw1.UploadHomeWork(sourceFilePath ?? string.Empty);
                    Console.WriteLine("File saved successfully.");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occur: {ex.Message}");
                }
            }

            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("enter homework grade");
                string value = Console.ReadLine() ?? string.Empty;

                if (!ushort.TryParse(value, out ushort result)) {
                    Console.WriteLine("Wrong format. Please enter number between 1 and 100");
                    continue;
                } else if (result < 0 || result > 100)
                {
                    Console.WriteLine("Grade should be between 1 and 100");
                    continue;
                } else
                {
                    hw1.Grade = result;
                }
                break;
            }

            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Add some comment or leave it empty:");
                string comment = Console.ReadLine() ?? string.Empty;

                if (!Regex.IsMatch(comment, @"[A-Za-z]?"))
                {
                    Console.WriteLine("Only letters allowed");
                }
                else {
                    hw1.Comment = comment;
                    break;
                }
            }

            Console.WriteLine(String.Format("| {0,15 } | {1,20} | {2,15} | {3,25} |", "Teacher", "Home work number", "Grade", "Comment"));
            Console.WriteLine("| {0,-15} | {1,-20} | {2, -15} | {3, -25} |", new string('-', 15), new string('-', 20), new string('-', 15), new string('-', 25));
            Console.WriteLine(String.Format("| {0,15} | {1,20} | {2,15} | {3,25} |", hw1.GetTutorFullName(), hw1.HomeWorkNumber, hw1.Grade, hw1.Comment));


            var tutor = new Tutor("Mykola", "Posipajlo", new DateOnly(1965, 4, 1));
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

            customerService.GetSupportInfo();

            lesson.StudentPresent("1234572");
            lesson.StudentPresent("Luis", "González");
            lesson.StudentPresent("Manuel", "Pérez");
            lesson.StudentPresent("1212");

            var newBook = new Book
            { ISBN = "0274878844",
            Author = "Sacha Baron Cohen",
            Name = "The Unauthorized Biography: From Cambridge to Kazakhstan",
            Year = 2007,
            Place = "London"};

            var book2 = new Book();

            Console.WriteLine(newBook.ToString());
            Console.WriteLine(book2.ToString());

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
