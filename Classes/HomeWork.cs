using System.Text.RegularExpressions;
using ThirdTeam_Study.Managers;

namespace ThirdTeam_Study
{
    public class HomeWork
    {
        private readonly Student Student;
        public record Submission(string StudentFullName, ushort HomeWorkNumber, string FilePath, string Comment, ushort Grade);

        const string noFile = "File not found";
        public ushort HomeWorkNumber { get; set; } = 1;
        public required Guid Id { get; set; }
        public string Comment { get; set; } = string.Empty;
        public ushort Grade { get; set; }

        public string HomeWorkFile { get; set; } = string.Empty;

        private static readonly string basePath = AppDomain.CurrentDomain.BaseDirectory;
        private readonly string destinationDirectory = Path.Combine(basePath.Replace("bin\\Debug\\net8.0\\", ""), "uploads");

        public HomeWork(Student _student)
        {
            Student = _student;
        }

        private void UploadHomeWork(string sourceFilePath)
        {
            if (!File.Exists(sourceFilePath))
            {
                throw new FileNotFoundException(noFile, sourceFilePath);
            }

            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }
            string fileName = Path.GetFileName(sourceFilePath);

            string destinationFilePath = Path.Combine(destinationDirectory, fileName);

            File.Copy(sourceFilePath, destinationFilePath, overwrite: true);
        }
        public string GetStudentFullName() => $"{Student.Name} {Student.LastName}";
        // ToDo: get lesson number from Lesson class 
        public string GetHWTitle() => $"Home work to lesson 1 from student {GetStudentFullName()}";

        public void SubmitHW() {
            while (true)
            {
                OutputManager.Write("Enter path to your home work file:");
                string sourceFilePath = Console.ReadLine() ?? string.Empty;

                if (String.IsNullOrEmpty(sourceFilePath))
                {
                    OutputManager.Write("You need to paste path to home work file");
                }

                try
                {
                    UploadHomeWork(sourceFilePath ?? string.Empty);
                    OutputManager.Write("File saved successfully.");
                    break;
                }
                catch (Exception ex)
                {
                    OutputManager.Write($"Error occur: {ex.Message}");
                }
            }
        }

        public void AssertHW ()
        {
            while (true)
            {
                OutputManager.Write("enter homework grade");
                string value = Console.ReadLine() ?? string.Empty;

                if (!ushort.TryParse(value, out ushort result))
                {
                    OutputManager.Write("Wrong format. Please enter number between 1 and 100");
                    continue;
                }
                else if (result < 0 || result > 100)
                {
                    OutputManager.Write("Grade should be between 1 and 100");
                    continue;
                }
                else
                {
                    Grade = result;
                }
                break;
            }
        }

        public void AddHWComment() 
        {
            while (true)
            {
                OutputManager.Write("Add some comment or leave it empty:");
                string comment = Console.ReadLine() ?? string.Empty;

                if (!Regex.IsMatch(comment, @"[A-Za-z]?"))
                {
                    OutputManager.Write("Only letters allowed");
                }
                else
                {
                    Comment = comment;
                    break;
                }
            }
        }
    }
    public static class HomeWorkExtensions
    {
        public static bool IsSubmitted(this HomeWork homework)
        {
            return !string.IsNullOrEmpty(homework.HomeWorkFile);
        }
    }
}
