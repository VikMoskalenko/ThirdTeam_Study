using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdTeam_Study.Data.Classes;

namespace ThirdTeam_Study.BusinessLayer.Extentions
{
    public static class HomeWorkExtensions
    {
        public static bool IsSubmitted(this HomeWork homework)
        {
            return !string.IsNullOrEmpty(homework.HomeWorkFile);
        }
    }
}
