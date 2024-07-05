using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ThirdTeam_Study.BusinessLayer.Managers;
using ThirdTeam_Study.Data.Classes;

namespace ThirdTeam_Study.Extentions
{
    static class LessontExtension
    {
        public static void StudentPresent(this Lesson lesson, Guid id)
        {
            bool studentFound = false;
            foreach (Student student in lesson.Students)
            {
                if (student.Id == id)
                {
                    OutputManager.Write($"Student {student.Name} {student.LastName} is on {lesson.LessonType} lesson");
                    studentFound = true;
                    break;
                }
            }
            if (!studentFound)
            {
                OutputManager.Write($"Student  with ID: {id} not found");
            }
        }

        public static void StudentPresent(this Lesson lesson, string name, string lastName)
        {
            bool studentFound = false;
            foreach (Student student in lesson.Students)
            {
                if (student.Name == name && student.LastName == lastName)
                {
                    Console.WriteLine($"Student ID: {student.Id} - {student.Name} {student.LastName} is on {lesson.LessonType} lesson");
                    studentFound = true;
                    break;
                }
            }
            if (!studentFound)
            {
                Console.WriteLine($"Student - {name} {lastName} not found");
            }
        }
    }
}
