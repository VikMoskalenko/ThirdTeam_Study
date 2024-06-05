using System;
namespace ThirdTeam_Study
{
    public record PersonalInfo
    {

        public required string FirstName { get; init; }

        public required string LastName { get; init; }

        public required DateOnly BDay { get; init; }

    }
}

