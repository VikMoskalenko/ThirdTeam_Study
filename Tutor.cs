using System;
using System.Diagnostics.CodeAnalysis;

namespace ThirdTeam_Study
{
    public class Tutor
    {
        public string ID { get; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public DateOnly BDay { get; }

        public const string Description_link = "https//hillel.com/tutordesc/11dw2e2e34rw";

        public readonly int Age;

        public int Seniority { get; private set; } = 0;

        private const string Finish_str = "The lesson was finished!";

        [SetsRequiredMembers]
        public Tutor(string firstname, string lastname, DateOnly bday)
        {
            FirstName = firstname;
            LastName = lastname;
            BDay = bday;
            ID = Guid.NewGuid().ToString();
            Age = bday.AgeCalculate();
        }

        public string ToTeachLesson(LessonDuration duration)
        {
            Tutor tutor = this;
            tutor = tutor + duration;
            return Finish_str;
        }

        public string ToTeachLesson()
        {
            Tutor tutor = this;
            tutor = tutor + LessonDuration.OneHour;
            return Finish_str;
        }

        public override string ToString()
        {
            return "FirstName: " + FirstName + ", LastName: " + LastName + ", ID: " + ID + ", Age: " + Age + ", Seniority: " + Seniority;
        }

        public static Tutor operator +(Tutor tutor, LessonDuration duration)
        {
            tutor.Seniority =+ (int)duration;
            return tutor;
        }

    }

}

