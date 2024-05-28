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

        public int Seniority { get; private set; }

        [SetsRequiredMembers]
        public Tutor(string firstname, string lastname, DateOnly bday)
        {
            FirstName = firstname;
            LastName = lastname;
            BDay = bday;
            ID = Guid.NewGuid().ToString();
            Age = bday.AgeCalculate();
        }

        public string ToTeach()
        {
            return "I will teach you today!";
        }

        public string ToTeach(int lesson_id)
        {
            return "I will teach you today on the lesson: " + lesson_id.ToString() + "!";
        }

        public override string ToString()
        {
            return "FirstName: " + FirstName + ", LastName: " + LastName + ", ID: " + ID + ", Age: " + Age;
        }

        public static int operator +(Tutor t, LessonDuration duration)
        {
            return t.Seniority + (int)duration;
        }

    }

}

