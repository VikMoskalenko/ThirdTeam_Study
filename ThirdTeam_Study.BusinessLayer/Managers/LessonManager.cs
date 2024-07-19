using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdTeam_Study.Data.Classes;

namespace ThirdTeam_Study.BusinessLayer.Managers
{
    public class LessonManager
    {

        private static IConfiguration _configuration = new ConfigurationBuilder().Build();
        private string connectionString = _configuration.GetConnectionString("SqlServer");
        private DapperContext _dapperContext = new DapperContext();

        public LessonManager() { }
        public LessonManager(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("SqlServer");
        }

        public const int MaxStudents = 20;

        private List<Student> CheckCapacity(List<Student> students)
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
        public void LessonInfo(Guid lessonId)
        {
            using (IDbConnection connection = _dapperContext.OpenConnection(connectionString))
            {
                var parameters = new { LessonId = lessonId };
                var lessonInfo = connection.QuerySingleOrDefault("GetLessonInfo", parameters, commandType: System.Data.CommandType.StoredProcedure);

                if (lessonInfo != null)
                {
                    OutputManager.Write($"Lesson {lessonInfo.LessonType} with {lessonInfo.TutorFirstName} {lessonInfo.TutorLastName}");
                    LessonStartAt(lessonInfo.LessonStart);
                    OutputManager.Write($"Theme: {lessonInfo.LessonTheme}");
                }
                else
                {
                    OutputManager.Write("Lesson not found.");
                }
                connection.Close();
            }
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
                OutputManager.Write($"Score for student: {firstName} {lastName} : {score}");
            }
            else
            {
                OutputManager.Write($"Student {id} not in this lesson");
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
                OutputManager.Write($"Score for student: {firstName} {lastName} : {score}");
            }
            else
            {
                OutputManager.Write($"Student {id} not in this lesson");
            }

        }
    }
}
