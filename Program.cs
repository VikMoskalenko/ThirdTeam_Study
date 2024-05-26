using System.Text.RegularExpressions;

namespace ThirdTeam_Study
{
    internal class Program
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
        }
    }
}
