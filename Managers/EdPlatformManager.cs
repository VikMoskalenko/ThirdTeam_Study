using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdTeam_Study.CustomExceptions;
using ThirdTeam_Study.Records;

namespace ThirdTeam_Study.Managers
{
    public class EdPlatformManager
    {
        public EdPlatformManager() { }

        public EdPlatform EdPlatformInstance = EdPlatform.Initialize();

        public void SignUp(Student student) 
        {
            EdPlatformInstance.Students.AddStudent(student);
        }
        public void SignUp(Tutor tutor)
        {
            EdPlatformInstance.Tutors.AddTutor(tutor);
        }

        public bool RemoveStudent(Student student)
        {
            return EdPlatformInstance.Students.RemoveStudent(student.Id);
        }
        public bool RemoveTutor(Tutor tutor)
        {
            return EdPlatformInstance.Tutors.RemoveTutor(tutor.Id);
        }

        public void GetSupportInfo()
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
