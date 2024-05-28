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

        public const string DescriptionLink = "https//hillel.com/tutordesc/11dw2e2e34rw";

        public readonly int Age;

        public int Seniority { get; private set; } = 0;

        public LessonDuration Lesson_duration { get; private set; }

        [SetsRequiredMembers]
        public Tutor(string firstname, string lastname, DateOnly bday, LessonDuration duration)
        {
            FirstName = firstname;
            LastName = lastname;
            BDay = bday;
            ID = Guid.NewGuid().ToString();
            Age = bday.AgeCalculate();
            Lesson_duration = duration;
        }

        public string ToTeach()
        {
            Tutor t = this;
            t++;
            return "I will teach you today!";
        }

        public string ToTeach(int lesson_id)
        {
            Tutor t = this;
            t++;
            return "I will teach you today on the lesson: " + lesson_id.ToString() + "!";
        }

        public override string ToString()
        {
            return "FirstName: " + FirstName + ", LastName: " + LastName + ", ID: " + ID + ", Age: " + Age;
        }

        public static Tutor operator ++(Tutor tutor)
        {
            tutor.Seniority =+ (int)tutor.Lesson_duration;
            return tutor;
        }

    }

}

