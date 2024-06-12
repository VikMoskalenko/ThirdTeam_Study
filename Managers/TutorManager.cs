using ThirdTeam_Study.Managers;

namespace ThirdTeam_Study
{
    public class TutorManager //Добавить валидацию ФИО регекс + добавить список курсов в Тьютор
    {
        public FileManager FileManager { get; }

        public TutorManager()
        {
            FileManager = new("Tutor.json");
        }

        public Tutor CreateTutor(string first_name, string last_name, DateOnly b_day)
        {
            if (b_day.ToCalculateAge() < 18) throw new ArgumentException("Tutor`s age cannot be less than 18 y.o.!");

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
            return FileManager?.ReadAllFromFile()?.Find(x => x.Id == id);
        }

        public bool UpdateTutor(Guid id, string first_name, string last_name, DateOnly birthday)
        {
            var tutor = FileManager?.ReadAllFromFile()?.Find(x => x.Id == id);

            if (birthday.ToCalculateAge() < 18) throw new ArgumentException();
            if (tutor == null) return false;

            tutor.Id = id;
            tutor.FirstName = first_name;
            tutor.LastName = last_name;
            tutor.Birthday = birthday;
            tutor.Age = tutor.Birthday.ToCalculateAge();

            DeleteTutor(id);
            FileManager?.WriteToFile(tutor);

            return true;
        }

        public bool UpdateTutor(Guid id, string first_name, string last_name)
        {
            var tutor = FileManager?.ReadAllFromFile()?.Find(x => x.Id == id);

            if (tutor == null) return false;

            tutor.Id = id;
            tutor.FirstName = first_name;
            tutor.LastName = last_name;

            DeleteTutor(id);
            FileManager?.WriteToFile(tutor);

            return true;
        }

        public bool UpdateTutor(Guid id, DateOnly birthday)
        {
            if (birthday.ToCalculateAge() < 18) throw new ArgumentException();

            var tutor = FileManager?.ReadAllFromFile()?.Find(x => x.Id == id);

            if (tutor == null) return false;

            tutor.Id = id;
            tutor.Birthday = birthday;
            tutor.Age = tutor.Birthday.ToCalculateAge();

            this.DeleteTutor(id);
            FileManager?.WriteToFile(tutor);

            return true;
        }

        public bool DeleteTutor(Guid id)
        {  
            if (GetTutorById(id) == null) return false;

            List<Tutor>? tutor_list = FileManager?.ReadAllFromFile();

            if (tutor_list?.Count == 0) return false;

            tutor_list?.RemoveAll(x => x.Id == id);
            
            FileManager?.ClearFile();
            FileManager?.WriteToFile(tutor_list);

            return true;
        }

        public List<Tutor>? GetAllTutors()
        {
            return FileManager.ReadAllFromFile();
        }


    }
}

