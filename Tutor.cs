using System;
using System.Diagnostics.CodeAnalysis;

namespace ThirdTeam_Study
{
    internal class Tutor
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public DateOnly BDay { get; }

        public const string DescriptionLink = "https//hillel.com/tutordesc/11dw2e2e34rw";

        public int ID { get; }

        public readonly int Age;

        [SetsRequiredMembers]
        public Tutor(string firstname, string lastname, DateOnly bday)
        {
            FirstName = firstname;
            LastName = lastname;
            BDay = bday;
            ID = Math.Abs((this.FirstName + this.LastName + this.BDay.ToString()).GetHashCode()); //самая примитивная реализация для примера, в идеале это
            Age = DateTime.Now.Year - bday.Year;
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


    }

}

