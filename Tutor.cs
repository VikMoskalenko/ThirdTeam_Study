using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;


namespace ThirdTeam_Study
{
    internal class Tutor
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public int Age { get; set; }

        public const string DescriptionLink = "https//hillel.com/tutordesc/11dw2e2e34rw";

        public readonly int ID;

        [SetsRequiredMembers]
        public Tutor(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        
        public Tutor()
        {
            FirstName = "Unknown";
            LastName = "Tutor";
        }
    }
}

