using ThirdTeam_Study.CustomExceptions;
using ThirdTeam_Study.Data.Classes;
using ThirdTeam_Study.Enums;
using ThirdTeam_Study.Records;

namespace ThirdTeam_Study.BusinessLayer.Managers
{
    public class EdPlatformManager // будет здорово прописать логику авторизации. Но для этого нам нужно создать отдельный класс Юзер
    {
        public EdPlatformManager(){ }

        private static EdPlatform? EdPlatformInstance = null;

        private TutorManager _tutorManager = new TutorManager();
        private StudentManager _studentManager = new StudentManager();

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

        public bool CreateEdPlatform()
        {
            EdPlatformInstance = EdPlatform.Initialize();
            _tutorManager.TutorsUpdated += UpdateTutors;
            _studentManager.StudentsUpdated += UpdateStudents;
            return true;
        }
        public bool CreateEdPlatform(string language, Themes theme)
        {
            EdPlatformInstance = EdPlatform.Initialize(language, theme);
            _tutorManager.TutorsUpdated += UpdateTutors;
            _studentManager.StudentsUpdated += UpdateStudents;
            return true;
        }
        public bool DeleteEdPlatform()
        {
            if(EdPlatformInstance == null)
            {
                return false;
            } 
            else
            {
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
                CreateEdPlatform();
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
