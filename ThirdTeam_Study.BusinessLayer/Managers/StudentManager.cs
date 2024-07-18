namespace ThirdTeam_Study.BusinessLayer.Managers
{
    public class StudentManager
    {
        public StudentManager() 
        { 

        }

        public bool AddStudent(Student student)
        {
            // Add logic with DB
            return true;
        }
        public bool DeleteStudent(Student student)
        {
            // Add logic with DB
            return true;
        }
        public bool DeleteStudentById(Guid id)
        {
            // Add logic with DB
            return true;
        }
        public Student GetStudentById(Guid id)
        {
            // Add logic with DB
            return new Student() { Name = "", LastName = ""};
        }
        public bool UpdateStudent(Student student)
        {
            // Add logic with DB
            return true;
        }
        public List<Student>? GetAllStudents()
        {
            return new List<Student>();
        }
        public static string GetStudentInfo()
        {
            return "Hello, student  ";
        }

        public static string GetStudentInfo(string Name, string LastName, int Id)
        {
            return $"Id: {Id}, name : {Name}, lastName {LastName} ";
        }

        public static string StudentSayHello(string Name)
        {
            return $"Hello, I am {Name}";
        }
    }
}
