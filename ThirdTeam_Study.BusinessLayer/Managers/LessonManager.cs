using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdTeam_Study.Data.Classes;

namespace ThirdTeam_Study.BusinessLayer.Managers
{
    public class LessonManager
    {
        public const int MaxStudents = 20;

        private Data.ListTypes.StudentList CheckCapacity(Data.ListTypes.StudentList students)
        {
            if (students.Count() > MaxStudents)
            {
                throw new ArgumentException("Capacity of lesson is 20 students!");
            }
            return students;
        }

        public void LessonStartAt(DateTime lessonStart)
        {
            if (DateTime.Now > lessonStart)
            {
                OutputManager.Write($"Lesson was: {lessonStart} , You late!");
            }
            else
            {
                OutputManager.Write($"Lesson start at: {lessonStart}");
            }

        }
        public void LessonInfo(Lesson lesson, Tutor teacher)
        {

            OutputManager.Write($"Lesson {lesson.LessonType} with {teacher.FirstName} {teacher.LastName}");
            LessonStartAt(lesson.LessonStart);
            OutputManager.Write($"Theme: {lesson.LessonTheme} ");
        }

        private Dictionary<Guid, int> LessonScoreInit(Lesson lesson)
        {
            var lessonScore = new Dictionary<Guid, int>();

            foreach (Student student in lesson.Students)
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

        public void SetUpdateScore(Guid id, string score, Lesson lesson)
        {

            string? firstName = null;
            string? lastName = null;
            foreach (Student student in lesson.Students)
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
                lesson.LessonScore[id] = CorrectScore(score);
                Console.WriteLine($"Score for student: {firstName} {lastName} : {score}");
            }
            else
            {
                Console.WriteLine($"Student {id} not in this lesson");
            }

        }

        public void SetUpdateScore(string firstName, string lastName, string score, Lesson lesson)
        {
            Guid id = Guid.Empty;

            foreach (Student student in lesson.Students)
            {
                if (student.Name == firstName && student.LastName == lastName)
                {
                    id = student.Id;
                    break;
                }
            }
            if (id != Guid.Empty)
            {
                lesson.LessonScore[id] = CorrectScore(score);
                Console.WriteLine($"Score for student: {firstName} {lastName} : {score}");
            }
            else
            {
                Console.WriteLine($"Student {id} not in this lesson");
            }

        }
    }
}
