using System;
using System.Diagnostics.CodeAnalysis;

namespace ThirdTeam_Study
{
    public class Tutor
    {
        public string ID { get; }

        public readonly PersonalInfo Info;

        public const string Description_link = "https//hillel.com/tutordesc/11dw2e2e34rw";

        public readonly int Age;

        public int Seniority { get; private set; } = 0;

        private const string Finish_str = "The lesson was finished!";

        [SetsRequiredMembers]
        public Tutor(string firstname, string lastname, DateOnly bday)
        {
            Info = new PersonalInfo { FirstName = firstname, LastName = lastname, BDay = bday };
            ID = Guid.NewGuid().ToString();
            Age = Info.BDay.AgeCalculate();
        }

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


    }

}

