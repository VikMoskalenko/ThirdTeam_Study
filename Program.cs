namespace ThirdTeam_Study
{
    internal class Program
    {
        static void Main()
        {
            HomeWork hw1 = new(new Tutor("Jhon", "Dou", new DateOnly(1991, 1, 24))) 
            { 
                Id= Guid.NewGuid().ToString() 
            };

            while (true)
            {
                Console.WriteLine("1. Choose file");
                Console.WriteLine("2. Exit");
                Console.Write("Choose option: ");
                string option = Console.ReadLine() ?? string.Empty; ;

                if (option == "2")
                {
                    break;
                }
                else if (option == "1")
                {
                    Console.WriteLine("Choose path to your home work file:");
                    string sourceFilePath = Console.ReadLine() ?? string.Empty;

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
                else
                {
                    Console.WriteLine("Wrong option. Please try again.");
                }
            }

            hw1.GradeHomeWork(100);
            hw1.Comment = "Looks good to me";

            Console.WriteLine(String.Format("| {0,15 } | {1,20} | {2,15} | {3,25} |", "Teacher", "Home work number", "Grade", "Comment"));
            Console.WriteLine("| {0,-15} | {1,-20} | {2, -15} | {3, -25} |", new string('-', 15), new string('-', 20), new string('-', 15), new string('-', 25));
            Console.WriteLine(String.Format("| {0,15} | {1,20} | {2,15} | {3,25} |", hw1.GetTutorFullName(), hw1.HomeWorkNumber, hw1.Grade, hw1.Comment));
        }
    }
}
