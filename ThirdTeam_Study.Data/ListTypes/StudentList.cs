using System.Collections;

namespace ThirdTeam_Study.Data.ListTypes
{
    public class StudentList : IEnumerable<Student>
    {
        private List<Student> _students = new List<Student>();

        public bool AddStudent(Student student)
        {
            _students.Add(student);
            //OutputManager.Write($"Student {student.LastName} added.");
            return true;
        }

        public bool AddStudent(Guid id, string studyyear, string name, string lastname)
        {
            var NewStudent = new Student(id, studyyear, name, lastname)
            { LastName = lastname, Name = name };
            _students.Add(NewStudent);
            //OutputManager.Write($"Student {NewStudent.LastName} added.");
            return true;
        }

        public Student? Find(Predicate<Student> match)
        {
            if (match != null)
            {
                for (int i = 0; i < _students.Count; i++)
                {
                    if (match(_students[i]))
                    {
                        return _students[i];
                    }
                }
                return default;
            }
            else
            {
                return null;
            }
        }

        public bool RemoveStudent(string name, string lastname)
        {
            var student = _students.Find(t => t.Name == name && t.LastName == lastname);
            if (student != null)
            {
                //OutputManager.Write($"Student {student.Id} : {student.Name} {student.LastName} removed");
                _students.Remove(student);
                return true;
            }
            else
            {
                //OutputManager.Write("Student not found");
                return false;
            }
        }
        public bool RemoveStudent(Guid id)
        {
            var student = _students.Find(t => t.Id == id);
            if (student != null)
            {
                //OutputManager.Write($"Student {student.Id} : {student.Name} {student.LastName} removed");
                _students.Remove(student);
                return true;
            }
            else
            {
                //OutputManager.Write("Student not found");
                return false;
            }
        }

        public List<Student> GetAll()
        {
            return _students;
        }
        public IEnumerator<Student> GetEnumerator()
        {
            return _students.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
