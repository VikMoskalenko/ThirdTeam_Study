using System.Collections;

namespace ThirdTeam_Study.BusinessLayer.Managers
{
    public class StudentList : IEnumerable<Student>
    {


        private List<Student> Students = new List<Student>();

        public void AddStudent(Student student)
        {
            Students.Add(student);
            OutputManager.Write($"Student {student.LastName} added.");
        }

        public void AddStudent(Guid id, string studyyear, string name, string lastname)
        {
            var NewStudent = new Student(id, studyyear, name, lastname)
            { LastName = lastname, Name = name };
            Students.Add(NewStudent);
            OutputManager.Write($"Student {NewStudent.LastName} added.");
        }
        public bool RemoveStudent(string name, string lastname)
        {
            var student = Students.Find(t => t.Name == name && t.LastName == lastname);
            if (student != null)
            {
                OutputManager.Write($"Student {student.Id} : {student.Name} {student.LastName} removed");
                Students.Remove(student);
                return true;
            }
            else
            {
                OutputManager.Write("Student not found");
                return false;
            }
        }
        public bool RemoveStudent(Guid id)
        {
            var student = Students.Find(t => t.Id == id);
            if (student != null)
            {
                OutputManager.Write($"Student {student.Id} : {student.Name} {student.LastName} removed");
                Students.Remove(student);
                return true;
            }
            else
            {
                OutputManager.Write("Student not found");
                return false;
            }
        }

        public List<Student> GetAll()
        {
            return Students;
        }
        public IEnumerator<Student> GetEnumerator()
        {
            return Students.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
