using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ThirdTeam_Study.ListTypes;
using ThirdTeam_Study.Managers;
using static System.Formats.Asn1.AsnWriter;

namespace ThirdTeam_Study
{
    public class Lesson
    {
        public const int MaxStudents = 20;
        public readonly string LessonType;
        public StudentList Students { get; set; }
        public required Tutor Teacher { get; set; }
        public string LessonTheme { get; set; }
        public required DateTime LessonStart { get; set; }
        private Dictionary<Guid, int> LessonScore;
        public Lesson(string lessonType, string lessonTheme, StudentList students)
        {
            Students = CheckCapacity(students);
            LessonType = lessonType;
            LessonTheme = lessonTheme;
            LessonScore = LessonScoreInit();
        }

        private StudentList CheckCapacity(StudentList students)
        {
            if (students.Count() > MaxStudents)
            {
                throw new ArgumentException("Capacity of lesson is 20 students!");
            }
            return students;
        }

        public void LessonStartAt()
        {
            if (DateTime.Now > LessonStart)
            {
                OutputManager.Write($"Lesson was: {LessonStart} , You late!");
            }
            else
            {
                OutputManager.Write($"Lesson start at: {LessonStart}");
            }

        }
        public void LessonInfo()
        {
            OutputManager.Write($"Lesson {LessonType} with {Teacher.FirstName} {Teacher.LastName}");
            LessonStartAt();
            OutputManager.Write($"Theme: {LessonTheme} ");
        }
        private Dictionary<Guid, int> LessonScoreInit()
        {
            var lessonScore = new Dictionary<Guid, int>();

            foreach (Student student in Students)
            {
                lessonScore.Add(student.Id, -1); // -1 no score
            }
            return lessonScore;
        }

        private int CorrectScore(string score)
        {
            int scoreInt;
            if (!int.TryParse(score, out scoreInt) || scoreInt < -1 || scoreInt > 100)
            {
                throw new ArgumentException("Please enter correct score on range from 0 to 100. -1 - no score");
            }
            scoreInt = int.Parse(score);
            return scoreInt;
        }

        public void SetUpdateScore(Guid id, string score)
        {

            string? firstName = null;
            string? lastName = null;
            foreach (Student student in Students)
            {
                if (student.Id == id)
                {
                    firstName = student.Name;
                    lastName = student.LastName;
                    break;
                }
            }
            if (firstName != null && lastName != null)
            {
                LessonScore[id] = CorrectScore(score);
                Console.WriteLine($"Score for student: {firstName} {lastName} : {score}");
            }
            else
            {
                Console.WriteLine($"Student {id} not in this lesson");
            }

        }

        public void SetUpdateScore(string firstName, string lastName, string score)
        {
            Guid id = Guid.Empty;

            foreach (Student student in Students)
            {
                if (student.Name == firstName && student.LastName == lastName)
                {
                    id = student.Id;
                    break;
                }
            }
            if (id != Guid.Empty)
            {
                LessonScore[id] = CorrectScore(score);
                Console.WriteLine($"Score for student: {firstName} {lastName} : {score}");
            }
            else
            {
                Console.WriteLine($"Student {id} not in this lesson");
            }

        }
    }

}
