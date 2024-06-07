using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ThirdTeam_Study
{
    public class Lesson
    {
        public const int MaxStudents = 20;
        public readonly string LessonType;
        public StudentList Students { get; set; }
        public required Tutor Tutor { get; set; }
        public string LessonTheme { get; set; }
        public required DateTime LessonStart { get; set; }
        private Dictionary<int, int> LessonScore;
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
                Console.WriteLine($"Lesson was: {LessonStart} , You late!");
            }
            else
            {
                Console.WriteLine($"Lesson start at: {LessonStart}");
            }

        }
        public void LessonInfo()
        {
            Console.WriteLine($"Lesson {LessonType} with {Tutor.FirstName} {Tutor.LastName}");
            LessonStartAt();
            Console.WriteLine($"Theme: {LessonTheme} ");
        }
        private Dictionary<int, int> LessonScoreInit()
        {
            var lessonScore = new Dictionary<int, int>();

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

        public void SetUpdateScore(int id, string score)
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
            int id = 0 ;

            foreach (Student student in Students)
            {
                if (student.Name == firstName && student.LastName == lastName)
                {
                    id = student.Id;
                    break;
                }
            }
            if (id != 0)
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
