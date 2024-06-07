﻿using System;
using Newtonsoft.Json;
using ThirdTeam_Study.Interfaces;
using ThirdTeam_Study.Managers;
using Newtonsoft.Json.Serialization;

namespace ThirdTeam_Study
{
    public class TutorManager //Добавить валидацию ФИО регекс 
    {
        public FileManager FileManager { get; }

        public TutorManager()
        {
            FileManager = new();
        }

        public Tutor CreateTutor(string first_name, string last_name, DateOnly b_day)
        {
            if (b_day.ToCalculateAge() < 18) throw new ArgumentException();

            Tutor tutor = new ()
            {
                FirstName = first_name,
                LastName = last_name,
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

        public bool UpdateTutor(Guid id, string first_name, string last_name, DateOnly birthday)
        {
            var tutor = FileManager.ReadAllFromFile().Find(x => x.Id == id);

            if (birthday.ToCalculateAge() < 18) throw new ArgumentException();
            if (tutor == null) return false;

            tutor.Id = id;
            tutor.FirstName = first_name;
            tutor.LastName = last_name;
            tutor.Birthday = birthday;
            tutor.Age = tutor.Birthday.ToCalculateAge();

            DeleteTutor(id);
            FileManager.WriteToFile(tutor);

            return true;
        }

        public bool UpdateTutor(Guid id, string first_name, string last_name)
        {
            var tutor = FileManager.ReadAllFromFile().Find(x => x.Id == id);

            if (tutor == null) return false;

            tutor.Id = id;
            tutor.FirstName = first_name;
            tutor.LastName = last_name;

            DeleteTutor(id);
            FileManager.WriteToFile(tutor);

            return true;
        }

        public bool UpdateTutor(Guid id, DateOnly birthday)
        {
            if (birthday.ToCalculateAge() < 18) throw new ArgumentException();

            var tutor = FileManager.ReadAllFromFile().Find(x => x.Id == id);

            if (tutor == null) return false;

            tutor.Id = id;
            tutor.Birthday = birthday;
            tutor.Age = tutor.Birthday.ToCalculateAge();

            DeleteTutor(id);
            FileManager.WriteToFile(tutor);

            return true;
        }

        public bool DeleteTutor(Guid id)
        {
            var tutor_list = FileManager.ReadAllFromFile();

            if (GetTutorById(id) == null) return false;

            tutor_list.RemoveAll(x => x.Id == id);
            
            FileManager.ClearFile();
            FileManager.WriteToFile(tutor_list);

            return true;
        }

    }
}

