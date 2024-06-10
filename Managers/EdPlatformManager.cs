using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdTeam_Study.CustomExceptions;

namespace ThirdTeam_Study.Managers
{
    public class EdPlatformManager
    {
        public EdPlatformManager() { }

        public void SignUp(Student student) 
        {

        }

        public void GetSupportInfo(EdPlatform edPlatform)
        {
            OutputManager.Write($"Service: {edPlatform.ServiceName}");
            OutputManager.Write($"Service Email: {edPlatform.ServiceEmail}");
            OutputManager.Write($"Service Phone Number: {edPlatform.ServicePhone}");
        }
        public static int ThrowConnectionException()
        {
            var connectionException = new ConnectionException();
            OutputManager.Write(connectionException.Message);
            throw connectionException;
        }
    }
}
