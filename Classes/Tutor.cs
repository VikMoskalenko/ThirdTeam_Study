using System;
using System.Diagnostics.CodeAnalysis;

namespace ThirdTeam_Study
{
    public class Tutor
    {
        public Guid Id { get; set; }

        public required string FirstName { get; set; } //change to FirtsName

        public required string LastName { get; set; }

        public required DateOnly Birthday { get; set; }

        public int Age { get; set; }

        public int Seniority { get; set; }

        public Tutor()
        {
            
        }

        public override string ToString()
        {
            return Id.ToString() + " " + FirstName + " " + LastName + " " + Birthday + " " + Age.ToString() + " " + Seniority.ToString();
        }

    }

}

