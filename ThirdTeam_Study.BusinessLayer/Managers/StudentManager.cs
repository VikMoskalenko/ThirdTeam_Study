using Microsoft.Extensions.Configuration;
using ThirdTeam_Study.Data.Classes;
using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ThirdTeam_Study.BusinessLayer.Managers
{
    public class StudentManager
    {
        public event Action StudentsUpdated;
        private static IConfiguration _configuration = new ConfigurationBuilder().Build();
        private string connectionString = _configuration.GetConnectionString("SqlServer");
        private DapperContext _context = new DapperContext();
        private static Student? studentInstance = null;

        public StudentManager()
        {

        }
        public StudentManager(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("SqlServer");
        }
        public StudentManager(DapperContext context)
        {
            _context = context;
        }
        public bool CreateStudent(Student student)
        {
            // Add logic with DB
            StudentsUpdated.Invoke();
            return true;
        }
        public bool DeleteStudent(Student student)
        {
            // Add logic with DB
            StudentsUpdated.Invoke();
            return true;
        }
        public bool DeleteStudentById(Guid id)
        {
            // Add logic with DB
            StudentsUpdated.Invoke();
            return true;
        }
        public Student GetStudentById(Guid id)
        {
            // Add logic with DB
          
            return new Student() { Name = "", LastName = "" };
        }
        public bool UpdateStudent(Student student)
        {
            // Add logic with DB
           
            StudentsUpdated.Invoke();
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
