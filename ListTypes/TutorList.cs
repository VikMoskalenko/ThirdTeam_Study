using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdTeam_Study.Managers;

namespace ThirdTeam_Study.ListTypes
{
    /*public class TutorList : IEnumerable<Tutor>
    {
        private List<Tutor> _tutors = new List<Tutor>();

        public bool AddTutor(Tutor tutor)
        {
            _tutors.Add(tutor);
            OutputManager.Write($"Tutor {tutor.Info.First_name} added.");
            return true;
        }

        public bool AddTutor(string firstname, string lastname, DateOnly bday)
        {
            var NewTutor = TutorManager.CreateTutor(firstname, lastname, bday);
            _tutors.Add(NewTutor);
            OutputManager.Write($"Tutor {NewTutor.Info.First_name} added.");
            return true;
        }

        public Tutor? Find(Predicate<Tutor> match)
        {
            if (match != null)
            {
                for (int i = 0; i < _tutors.Count; i++)
                {
                    if (match(_tutors[i]))
                    {
                        return _tutors[i];
                    }
                }
                return default;
            }
            else
            {
                return null;
            }
        }

        public bool RemoveTutor(string firstname, string lastname)
        {
            var tutor = _tutors.Find(t => t.Info.First_name == firstname && t.Info.Last_name == lastname);
            if (tutor != null)
            {
                OutputManager.Write($"Tutor {tutor.Id} : {tutor.Info.First_name} {tutor.Info.Last_name} removed");
                _tutors.Remove(tutor);
                return true;
            }
            else
            {
                OutputManager.Write("Tutor not found");
                return false;
            }
        }

        public bool RemoveTutor(Guid id)
        {
            var tutor = _tutors.Find(t => t.Id == id);
            if (tutor != null)
            {
                OutputManager.Write($"Tutor {tutor.Id} : {tutor.Info.First_name} {tutor.Info.Last_name} removed");
                _tutors.Remove(tutor);
                return true;
            }
            else
            {
                OutputManager.Write("Tutor not found");
                return false;
            }
        }
        public List<Tutor> GetAll()
        {
            return _tutors;
        }

        public IEnumerator<Tutor> GetEnumerator()
        {
            return _tutors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }*/
}
