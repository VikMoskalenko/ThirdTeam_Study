using System;
namespace ThirdTeam_Study
{
    public class Tutor
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public int Age { get; set; }

        public const string DescriptionLink = "https//hillel.com/tutordesc/11dw2e2e34rw";

        public readonly int ID { get; set; }

        [SetsRequiredMembers]
        public Tutor(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        [SetsRequiredMembers]
        public Tutor()
        {
            FirstName = "Unknown";
            LastName = "Tutor";
        }
    }
}

