using System;
using Newtonsoft.Json;

namespace ThirdTeam_Study
{
    public class TutorManager
    {

        public TutorManager()
        {
        }

        public static Tutor CreateTutor(string first_name, string last_name, DateOnly b_day)
        {

            return new Tutor
            {
                Info = new PersonalInfo { First_name = first_name, Last_name = last_name, Birthday = b_day },
                Id = new Guid(),
                Age = b_day.ToCalculateAge(),
                Seniority = 0
            };
        }

       
    }
}

