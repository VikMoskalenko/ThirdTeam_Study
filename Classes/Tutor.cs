using System;
using System.Diagnostics.CodeAnalysis;

namespace ThirdTeam_Study
{
    public class Tutor
    {
        public Guid Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required DateOnly Birthday { get; set; }

        public int Age { get; set; }

        public int Seniority { get; set; } 

        public Tutor()
        {

        }

        public override string ToString()
        {
            return "\n[ ID ]: " + Id.ToString() + "\n[ FIRST NAME ]: " + FirstName + "\n[ LAST NAME ]: " + LastName + "\n[ BIRTHDAY ]: " + Birthday.Day + "/" + Birthday.Month + "/" + Birthday.Year + "\n[ AGE ]: " + Age.ToString() + "\n[ SENIORITY ]: " + Seniority.ToString();
        }

    }

}

