using Azure;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Npgsql;
using ThirdTeam_Study.CustomExceptions;
using ThirdTeam_Study.Data.Classes;
using ThirdTeam_Study.Enums;
using ThirdTeam_Study.Records;

namespace ThirdTeam_Study.BusinessLayer.Managers
{
    public class EdPlatformManager // будет здорово прописать логику авторизации. Но для этого нам нужно создать отдельный класс Юзер
    {
        

        private static IConfiguration _configuration = new ConfigurationBuilder().Build();
        private string connectionString = _configuration.GetConnectionString("PostgreSql");
        private DapperContext _dapperContext = new DapperContext();
        private static EdPlatform? EdPlatformInstance = null;

        private TutorManager _tutorManager = new TutorManager();
        private StudentManager _studentManager = new StudentManager();

        public EdPlatformManager() { }
        public EdPlatformManager(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("PostgreSql");
        }

        public void UpdateStudents()
        {   if(EdPlatformInstance != null)
            {
                EdPlatformInstance.Students = _studentManager.GetAllStudents();
            }
        }
        public void UpdateTutors()
        {
            if (EdPlatformInstance != null)
            {
                EdPlatformInstance.Tutors = _tutorManager.GetAllTutors();
            }
        }

        public async Task<bool> CreateEdPlatformAsync()
        {
            EdPlatformInstance = EdPlatform.Initialize();
            _tutorManager.TutorsUpdated += UpdateTutors;
            _studentManager.StudentsUpdated += UpdateStudents;

            NpgsqlConnection? connection = _dapperContext.OpenConnection(connectionString);

            var parameters = new { };
            await connection.ExecuteAsync("CreateEdPlatformProcedure", parameters, commandType: System.Data.CommandType.StoredProcedure);
            connection.Close();

            return true;
        }
        public async Task<bool> CreateEdPlatformAsync(string language, Themes theme)
        {
            if (language.Length > 2) return false;
            EdPlatformInstance = EdPlatform.Initialize(language, theme);
            _tutorManager.TutorsUpdated += UpdateTutors;
            _studentManager.StudentsUpdated += UpdateStudents;

            NpgsqlConnection? connection = _dapperContext.OpenConnection(connectionString);
 
            var parameters = new { @Language = language, @Theme = theme};
            await connection.ExecuteAsync("CreateEdPlatformProcedure", parameters, commandType: System.Data.CommandType.StoredProcedure);
            connection.Close();

            return true;
        }
        public async Task<bool> DeleteEdPlatformAsync()
        {
            NpgsqlConnection? connection = _dapperContext.OpenConnection(connectionString);
            var parameters = new { };
            if (EdPlatformInstance == null)
            {
                return false;
            } 
            else
            {
                _tutorManager.TutorsUpdated -= UpdateTutors;
                _studentManager.StudentsUpdated -= UpdateStudents;
                await connection.ExecuteAsync("eEdPlatformProcedure", parameters, commandType: System.Data.CommandType.StoredProcedure);
                connection.Close();
                return EdPlatformInstance.Drop();
            }
        }
        
        public EdPlatform GetPlatformInstance()
        {
            if (EdPlatformInstance != null)
            {
                return EdPlatformInstance;
            }
            else
            {
                CreateEdPlatformAsync();
                return EdPlatformInstance;
            }
        }

        public void SignUp(Student student) 
        {
            _studentManager.CreateStudent(student);
        }
        public void SignUp(Tutor tutor)
        {
            _tutorManager.CreateTutor(tutor);
        }

        public bool RemoveStudent(Guid id)
        {
            return _studentManager.DeleteStudentById(id);
        }
        public bool RemoveTutor(Guid id)
        {
            return _tutorManager.DeleteTutorById(id);
        }

        public static void GetSupportInfo()
        {
            OutputManager.Write($"Service: {SupportInfo.ServiceName}");
            OutputManager.Write($"Service Email: {SupportInfo.ServiceEmail}");
            OutputManager.Write($"Service Phone Number: {SupportInfo.ServicePhone}");
        }

        //TODO
        //CreateCourse
        public static int ThrowConnectionException()
        {
            var connectionException = new ConnectionException();
            OutputManager.Write(connectionException.Message);
            throw connectionException;
        }
    }
}
