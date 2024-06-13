using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdTeam_Study.CustomExceptions
{
    public class ConnectionException: Exception
    {
        public const int ErrorCode = 404;
        public string ErrorMessage { get; set; } = "ConnectionError";
    }
}
