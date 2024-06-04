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
            Console.WriteLine($"Tutor {tutor.Info.FirstName} added.");
        }

        public void AddTutor(string firstname, string lastname, DateOnly bday)
        {
            var NewTutor = new Tutor(firstname, lastname, bday);
            Tutors.Add(NewTutor);
            Console.WriteLine($"Tutor {NewTutor.Info.FirstName} added.");
        }

        public void RemoveTutor(string firstname, string lastname)
        {
            var tutor = Tutors.Find(t => t.Info.FirstName == firstname && t.Info.LastName == lastname);
            if (tutor != null)
            {
                Console.WriteLine($"Tutor {tutor.ID} : {tutor.Info.FirstName} {tutor.Info.LastName} removed");
                Tutors.Remove(tutor);
            }
            else
            {
                Console.WriteLine("Tutor not found");
            }
        }

        public void RemoveTutor(string id)
        {
            var tutor = Tutors.Find(t => t.ID == id);
            if (tutor != null)
            {
                Console.WriteLine($"Tutor {tutor.ID} : {tutor.Info.FirstName} {tutor.Info.LastName} removed");
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
