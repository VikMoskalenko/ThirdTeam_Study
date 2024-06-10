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
        public static int ThrowConnectionException()
        {
            var connectionException = new ConnectionException();
            OutputManager.Write(connectionException.Message);
            throw connectionException;
        }
    }
}
