

namespace ThirdTeam_Study.Data.Classes
{
    public class Lesson
    {
        public readonly string LessonType;
        public List<Student> Students { get; set; }
        public required Tutor Teacher { get; set; }
        public string LessonTheme { get; set; }

        public required DateTime LessonStart { get; set; }
        public Dictionary<Guid, int> LessonScore;
        public Lesson(string lessonType, string lessonTheme, List<Student> students)
        {
            //Students = CheckCapacity(students);
            LessonType = lessonType;
            LessonTheme = lessonTheme;
            //LessonScore = LessonScoreInit();
        }

    }

}
