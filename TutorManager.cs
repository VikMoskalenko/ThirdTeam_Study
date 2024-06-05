using System;
namespace ThirdTeam_Study
{
    public class TutorManager
    {
        public TutorManager()
        {
        }

        public Tutor CreateTutor(Guid id, PersonalInfo info)
        {
            return new Tutor
            {
                Info = new PersonalInfo { First_name = info.First_name, Last_name = info.Last_name, Birthday = info.Birthday },
                Id = id,
                Age = info.Birthday.ToCalculateAge(),
                Seniority = 0
            };
        }
    }
}

