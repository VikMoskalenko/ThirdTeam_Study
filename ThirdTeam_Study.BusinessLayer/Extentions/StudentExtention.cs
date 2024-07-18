using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdTeam_Study.Data.Classes;

namespace ThirdTeam_Study.BusinessLayer.Extentions
{
    public static class StudentExtention
    {
        public static string GetFullInfo(this Student student)
        {
            return $"{student.Name}, {student.DOB}, {student.LastName}";
        }
    }
}
