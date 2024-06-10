using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdTeam_Study.Exceptions
{
    [Serializable]
    public class ConnectionError : Exception
    {
        public ConnectionError() { }
        public ConnectionError(string message) : base(message) { }
    }
}
