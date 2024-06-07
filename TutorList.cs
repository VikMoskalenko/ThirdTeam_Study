using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdTeam_Study
{
    public class TutorList
    {
        private List<Tutor> Tutors = new List<Tutor>();

        public void AddTutor(Tutor tutor)
        {
            Tutors.Add(tutor);
            Console.WriteLine($"Tutor {tutor.FirstName} added.");
        }

        public void AddTutor(string firstname, string lastname, DateOnly bday)
        {
            TutorManager manager = new TutorManager();
            var NewTutor = manager.CreateTutor(firstname, lastname, bday);
            Tutors.Add(NewTutor);
            Console.WriteLine($"Tutor {NewTutor.FirstName} added.");
        }

        public void RemoveTutor(string firstname, string lastname)
        {
            var tutor = Tutors.Find(t => t.FirstName == firstname && t.LastName == lastname);
            if (tutor != null)
            {
                Console.WriteLine($"Tutor {tutor.Id} : {tutor.FirstName} {tutor.LastName} removed");
                Tutors.Remove(tutor);
            }
            else
            {
                Console.WriteLine("Tutor not found");
            }
        }

        public void RemoveTutor(string id)
        {
            var tutor = Tutors.Find(t => t.Id.ToString() == id);
            if (tutor != null)
            {
                Console.WriteLine($"Tutor {tutor.Id} : {tutor.FirstName} {tutor.LastName} removed");
                Tutors.Remove(tutor);
            }
            else
            {
                Console.WriteLine("Tutor not found");
            }
        }
        public List<Tutor> GetAll()
        {
            return Tutors;
        }
    }
}
