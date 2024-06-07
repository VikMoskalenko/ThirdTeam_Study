using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ThirdTeam_Study.Managers
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
