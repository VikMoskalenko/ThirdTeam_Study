﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdTeam_Study.ListTypes;
using ThirdTeam_Study.Managers;

namespace ThirdTeam_Study.Extentions
{
    public static class EdPlatformExtention
    {
        public static StudentList GetAllStudents()
        {
            var edPlatformManager = new EdPlatformManager();
            var edPlatform = edPlatformManager.EdPlatformInstance;

            return edPlatform.Students;
        }

        public static TutorList GetAllTutors()
        {
            var edPlatformManager = new EdPlatformManager();
            var edPlatform = edPlatformManager.EdPlatformInstance;

            return edPlatform.Tutors;
        }
    }
}
