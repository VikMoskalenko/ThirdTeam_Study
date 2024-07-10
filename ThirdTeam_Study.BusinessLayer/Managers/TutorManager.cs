using ThirdTeam_Study.Data.Classes;

namespace ThirdTeam_Study.BusinessLayer.Managers
{
    public class TutorManager // добавить список курсов в Тьютор
    {
        public TutorManager(){ }
        public Tutor CreateTutor(string first_name, string last_name, DateOnly b_day)
        {
            if (b_day.ToCalculateAge() < 18) throw new ArgumentException("Tutor`s age cannot be less than 18 y.o.!");

            Tutor tutor = new()
            {
                FirstName = first_name,
                LastName = last_name,
                Birthday = b_day,
                Id = Guid.NewGuid(),
                Age = b_day.ToCalculateAge(),
                Seniority = 0
            };

            //Треба змiнити на Insert в БД (використовуючи DapperContext)
            //FileManager.WriteToFile(tutor);  

            return tutor;
        }

        public Tutor? GetTutorById(Guid id)
        {
            // Змiнити на Select * from Teachers where id == {id}
            //return FileManager?.ReadAllFromFile()?.Find(x => x.Id == id); 

            return null;
        }

        public bool UpdateTutor(Guid id, string first_name, string last_name, DateOnly birthday)
        {
            /*
            var tutor = FileManager?.ReadAllFromFile()?.Find(x => x.Id == id);

            var tutor = GetTutorById(id);
            if (birthday.ToCalculateAge() < 18) throw new ArgumentException();
            if (tutor == null) return false;

            tutor.Id = id;
            tutor.FirstName = first_name;
            tutor.LastName = last_name;
            tutor.Birthday = birthday;
            tutor.Age = tutor.Birthday.ToCalculateAge();

            DeleteTutor(id);
            FileManager?.WriteToFile(tutor); */

            // Зробити Set з новими данними по id
            return true;
        }

        public bool UpdateTutor(Guid id, string first_name, string last_name)
        {
            /* var tutor = FileManager?.ReadAllFromFile()?.Find(x => x.Id == id);

            if (tutor == null) return false;

            tutor.Id = id;
            tutor.FirstName = first_name;
            tutor.LastName = last_name;

            DeleteTutor(id);
            FileManager?.WriteToFile(tutor); */

            // Теж саме що й вище
            return true;
        }

        public bool UpdateTutor(Guid id, DateOnly birthday)
        {
            /* if (birthday.ToCalculateAge() < 18) throw new ArgumentException();

            var tutor = FileManager?.ReadAllFromFile()?.Find(x => x.Id == id);

            if (tutor == null) return false;

            tutor.Id = id;
            tutor.Birthday = birthday;
            tutor.Age = tutor.Birthday.ToCalculateAge();

            this.DeleteTutor(id);
            FileManager?.WriteToFile(tutor); */

            // Теж саме що й вище
            return true;
        }

        public bool DeleteTutor(Guid id)
        {
            /* if (GetTutorById(id) == null) return false;

            List<Tutor>? tutor_list = FileManager?.ReadAllFromFile();

            if (tutor_list?.Count == 0) return false;

            tutor_list?.RemoveAll(x => x.Id == id);
            FileManager?.ClearFile();
            FileManager?.WriteToFile(tutor_list); */
            
            //DELETE FROM Teachers WHERE id = {id} 

            return true;
        }

        public List<Tutor>? GetAllTutors()
        {
            // SELECT * FROM Teachers
            return new List<Tutor>();
        }


    }
}

