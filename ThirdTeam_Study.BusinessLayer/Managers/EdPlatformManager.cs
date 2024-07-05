using ThirdTeam_Study.CustomExceptions;
using ThirdTeam_Study.Data.Classes;
using ThirdTeam_Study.Records;

namespace ThirdTeam_Study.BusinessLayer.Managers
{
    public class EdPlatformManager // будет здорово прописать логику авторизации. Но для этого нам нужно создать отдельный класс Юзер
    {
        public EdPlatformManager()
        {
            
        }

        public EdPlatform EdPlatformInstance = EdPlatform.Initialize();

        public TutorManager TutorManager = new();

        public void SignUp(Student student) 
        {
            EdPlatformInstance.Students.AddStudent(student);
        }
        public void SignUp(Tutor tutor)
        // я бы тут передавал в качестве параметров нужные поля для создания Тьютора,
        // а в самом методе вызывал ТьюторМенеджер.СоздатьТьютора (параметры).
        // Так у тебя все будет храниться в файле
        {
            EdPlatformInstance.Tutors.Add(tutor);
        }

        public bool RemoveStudent(Student student)
        {
            return EdPlatformInstance.Students.RemoveStudent(student.Id);
        }
        public bool RemoveTutor(Tutor tutor)
        // тут также как и с SignUp: я бы передавал в качестве параметра Айди Тьютора,
        // а в самом методе вызывал ТьюторМенеджер.УдалитьТьютора (айди).
        // Так объект удалится из файла 
        {
            return EdPlatformInstance.Tutors.Remove(tutor);
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
