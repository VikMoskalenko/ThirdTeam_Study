using Microsoft.Extensions.Configuration;
using ThirdTeam_Study.Data.Classes;
using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;

namespace ThirdTeam_Study.BusinessLayer.Managers
{
    public class StudentManager
    {
        private static IConfiguration _configuration = new ConfigurationBuilder().Build();
        private string connectionString = _configuration.GetConnectionString("SqlServer");
        private DapperContext _dapperContext = new DapperContext();
        public event Action StudentsUpdated;
        //private readonly string connectionString;
        //private readonly DapperContext context;
        //private static IConfiguration _configuration = new ConfigurationBuilder().Build();
        ////private string connectionString = _configuration.GetConnectionString("SqlServer");
        ////private DapperContext _context = new DapperContext();
        private static Student? studentInstance = null;

        public StudentManager()
        {

        }
        public StudentManager(IConfiguration configuration)
        {
            
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("SqlServer");
            // context = new DapperContext(connectionString);
        }
        public bool CreateStudent(Student student)
        {
            // Add logic with DB
            StudentsUpdated.Invoke();
            return true;
        }

        //public bool CreateStudent(Student student)
        //{
        //    using var connection = context.OpenConnection(connectionString);
        //    var result = connection.Execute("CreateStudent",
        //        new { student.Name, student.LastName, DOB = student.DOB?.ToDateTime(new TimeOnly()) },
        //        commandType: CommandType.StoredProcedure);
        //    StudentsUpdated?.Invoke();
        //    return result > 0;
        //}
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
