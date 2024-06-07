using System;
using Newtonsoft.Json;
using ThirdTeam_Study.Interfaces;
using ThirdTeam_Study.Managers;
using Newtonsoft.Json.Serialization;

namespace ThirdTeam_Study
{
    public class TutorManager// Создать отдельный класс, реализуемый ФайлИнтерфейс и унаследовать его
    {
        public FileManager FileManager { get; }

        public TutorManager()
        {
            FileManager = new();
        }

        public Tutor CreateTutor(string first_name, string last_name, DateOnly b_day)
        {
            Tutor tutor = new ()
            {
                //Info = new PersonalInfo { First_name = first_name, Last_name = last_name, Birthday = b_day },
                First_name = first_name,
                Last_name = last_name,
                Birthday = b_day,
                Id = Guid.NewGuid(),
                Age = b_day.ToCalculateAge(),
                Seniority = 0
            };
            FileManager.WriteToFile(tutor);
            return tutor;
        }


        public Tutor? GetTutorById(Guid id)
        {
            return FileManager.ReadAllFromFile().Find(x => x.Id == id);
        }

        /*public bool UpdateTutor(Guid id, string first_name, string last_name, DateOnly birthday)
        {
            var tutor = FileManager.ReadAllFromFile().Find(x => x.Id == id)
            
            return true;
        }*/

        public bool DeleteTutor(Guid id)
        {
            var tutor_list = FileManager.ReadAllFromFile();
            //tutor_list.Remove(GetTutorById(id));
            tutor_list.RemoveAll(x => x.Id == id);
            FileManager.ClearFile();
            FileManager.WriteToFile(tutor_list);
            return true;
        }


    }
}

