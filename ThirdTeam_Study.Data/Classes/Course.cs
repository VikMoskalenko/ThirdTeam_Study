namespace ThirdTeam_Study.Data.Classes
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Tutor Tutor { get; set; }
    }
}
