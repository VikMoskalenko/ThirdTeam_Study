using System;
using System.Diagnostics.CodeAnalysis;

namespace ThirdTeam_Study
{
    public class Tutor
    {
        public readonly Guid Id;

        public readonly PersonalInfo Info;

        public int Age { get; set; }

        public int Seniority { get; set; }

        public Tutor()
        {
            
        }

        public Tutor(Guid id, PersonalInfo info)
        {
            Info = new PersonalInfo { First_name = info.First_name, Last_name = info.Last_name, Birthday = info.Birthday };
            Id = id;
            Age = Info.Birthday.AgeCalculate();
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

