using System.Text.RegularExpressions;

namespace ThirdTeam_Study.Data.Classes
{
    public class HomeWork
    {
        public readonly Student Student;
        public record Submission(string StudentFullName, ushort HomeWorkNumber, string FilePath, string Comment, ushort Grade);

        
        public ushort HomeWorkNumber { get; set; } = 1;
        public required Guid Id { get; set; }
        public string Comment { get; set; } = string.Empty;
        public ushort Grade { get; set; }

        public string HomeWorkFile { get; set; } = string.Empty;

        public HomeWork(Student _student)
        {
            Student = _student;
        }

    }
}
