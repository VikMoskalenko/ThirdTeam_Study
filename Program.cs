using System.Text.RegularExpressions;

namespace ThirdTeam_Study
{
    public class Program
    {
        static void Main()
        {
            Student student1 = new("1", "2024", "Myke", "Tyson");

            HomeWork hw1 = new(student1)
            {
                Id = Guid.NewGuid()
            };

            hw1.SubmitHW();

            Console.WriteLine();

            hw1.AssertHW();

            Console.WriteLine();

            hw1.AddHWComment();

            Console.WriteLine(hw1.GetHWTitle());
            Console.WriteLine();
            Console.WriteLine(String.Format("| {0,15 } | {1,20} | {2,10} | {3,25} |", "Student", "Home work number", "Grade", "Comment"));
            Console.WriteLine("| {0,-15} | {1,-20} | {2, -10} | {3, -25} |", new string('-', 15), new string('-', 20), new string('-', 10), new string('-', 25));
            Console.WriteLine(String.Format("| {0,15} | {1,20} | {2,10} | {3,25} |", $"{hw1.GetStudentFullName()}", hw1.HomeWorkNumber, hw1.Grade, hw1.Comment));
        }
    }
}
