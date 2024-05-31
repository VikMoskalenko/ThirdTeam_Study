using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdTeam_Study
{
    static class LessontExtension
    {
        public static void StudentPresent(this Lesson lesson, string id)
        {
            foreach (Student student in lesson.Students)
            {
                if (student.Id == id)
                {
                    Console.WriteLine($"Student {student.Name} {student.LastName} is on lesson {lesson.LessonType}");
                    break;
                }
            }
        }

        public static void StudentPresent(this Lesson lesson, string name, string lastName)
        {
            foreach (Student student in lesson.Students)
            {
                if (student.Name == name && student.LastName == lastName)
                {
                    Console.WriteLine($"Student ID: {student.Id} - {student.Name} {student.LastName} is on lesson {lesson.LessonType}");
                    break;
                }
            }
        }
    }
}
