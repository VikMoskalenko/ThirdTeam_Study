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
        private static Student? studentInstance = null;

        public StudentManager()
        {
        }

        public StudentManager(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("SqlServer");
        }

        public async Task<bool> CreateStudentAsync(Student student)
        {
            
                using var connection = _dapperContext.OpenConnection(connectionString);
                var result = await connection.ExecuteAsync("CreateStudent",
                    new { student.Name, student.LastName, DOB = student.DOB?.ToDateTime(new TimeOnly()) },
                    commandType: CommandType.StoredProcedure);
                StudentsUpdated?.Invoke();
                return result > 0;
            

        }

        public async Task<bool> DeleteStudentByIdAsync(Guid id)
        {
            using var connection = _dapperContext.OpenConnection(connectionString);
            var result = await connection.ExecuteAsync("DeleteStudentById",
                new { Id = id },
                commandType: CommandType.StoredProcedure);

            StudentsUpdated?.Invoke();
            return result > 0;
        }

        public async Task<Student?> GetStudentByIdAsync(Guid id)
        {
            using var connection = _dapperContext.OpenConnection(connectionString);
            var student = await connection.QueryFirstOrDefaultAsync<Student>(
                "GetStudentById",
                new { Id = id },
                commandType: CommandType.StoredProcedure);

            return student;
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            using var connection = _dapperContext.OpenConnection(connectionString);
            var result = await connection.ExecuteAsync("UpdateStudent",
                new { student.Id, student.Name, student.LastName, DOB = student.DOB?.ToDateTime(new TimeOnly()) },
                commandType: CommandType.StoredProcedure);

            StudentsUpdated?.Invoke();
            return result > 0;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            using var connection = _dapperContext.OpenConnection(connectionString);
            var students = await connection.QueryAsync<Student>("GetAllStudents", commandType: CommandType.StoredProcedure);

            return students.ToList();
        }

        //public static string GetStudentInfo(string Name, string LastName, int Id)
        //{
        //    return $"Id: {Id}, name: {Name}, lastName: {LastName}";
        //}
    }
}
