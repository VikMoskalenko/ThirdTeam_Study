using System;
using System.Diagnostics.CodeAnalysis;

namespace ThirdTeam_Study
{
    public class Tutor
    {
        public Guid Id { get; set; }

        public required string First_name { get; init; } //change to FirtsName

        public required string Last_name { get; init; }

        public required DateOnly Birthday { get; init; }

        public int Age { get; set; }

        public int Seniority { get; set; }

        public Tutor()
        {
            
        }

        /*

        public string ToTeachLesson(LessonDuration duration)
        {
            Seniority += (int)duration;
            return Finish_str;
        }

        public string ToTeachLesson() //урок по умолчанию 1 час
        {
            Seniority += (int)LessonDuration.OneHour;
            return Finish_str;
        }

        public override string ToString()
        {
            return "FirstName: " + Info.FirstName + ", LastName: " + Info.LastName + ", ID: " + ID + ", Age: " + Age + ", Seniority: " + Seniority;
        }
      */

    }

}

