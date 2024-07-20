using ThirdTeam_Study;


namespace ThirdTeam_Study.Data.Classes
{
    public class Student
    {
        public readonly string? StudyYear;
        //public const string University = "Hogwarts";

        public Guid Id { get; }
        public HomeWork? Homework { get; set; }

        public required string Name { get; set; }
        public required string LastName { get; set; }

        public DateOnly? DOB { get; set; }

        public List<Lesson> Lessons { get; set; }

        public Student()
        {

        }
        public Student(Guid id, string studyyear, string name, string lastname)
        {
            Id = id;
            StudyYear = studyyear;
            Name = name;
            LastName = lastname;

        }

    }
}


