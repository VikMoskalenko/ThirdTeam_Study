namespace ThirdTeam_Study.BusinessLayer.Managers
{
    public class StudentManager
    {
        public StudentManager() 
        { 

        }
        
        public static string GetStudentInfo()
        {
            return "Hello, student  ";
        }

        public static string  GetStudentInfo(string Name, string LastName, int Id)
        {
            return $"Id: {Id}, name : {Name}, lastName {LastName} ";
        }

        public static string StudentSayHello(string Name)
        {
            return $"Hello, I am {Name}";
        }
    }
}
