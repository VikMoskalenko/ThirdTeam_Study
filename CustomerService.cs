using System;
using System.Collections;
using System.Collections.Generic;


namespace ThirdTeam_Study
{
    public class CustomerService
    {
        public const string ServiceName = "Hillel Education Platform Support Service";
        public readonly string ServiceEmail;
        public required TutorList Tutors { get; set; }
        public required StudentList Students { get; set; }
        public string? ServicePhone { get; set; }

        public CustomerService(string serviceEmail)
        {
            ServiceEmail = serviceEmail;
        }

        public void GetSupportInfo()
        {
            Console.WriteLine($"Service: {ServiceName}");
            Console.WriteLine($"Service Email: {ServiceEmail}");
            Console.WriteLine($"Service Phone Number: {ServicePhone}");
        }
    }



    public class StudentList : IEnumerable<Student>
    {


        private List<Student> Students = new List<Student>();

        public void AddStudent(Student student)
        {
            Students.Add(student);
            Console.WriteLine($"Student {student.LastName} added.");
        }

        public void AddStudent(string id, string studyyear, string name, string lastname)
        {
            var NewStudent = new Student(id, studyyear, name, lastname)
            { LastName = lastname, Name = name };
            Students.Add(NewStudent);
            Console.WriteLine($"Student {NewStudent.LastName} added.");
        }
        public void RemoveStudent(string name, string lastname)
        {
            var student = Students.Find(t => t.Name == name && t.LastName == lastname);
            if (student != null)
            {
                Console.WriteLine($"Student {student.Id} : {student.Name} {student.LastName} removed");
                Students.Remove(student);
            }
            else
            {
                Console.WriteLine("Student not found");
            }
        }
        public void RemoveStudent(string id)
        {
            var student = Students.Find(t => t.Id == id);
            if (student != null)
            {
                Console.WriteLine($"Student {student.Id} : {student.Name} {student.LastName} removed");
                Students.Remove(student);
            }
            else
            {
                Console.WriteLine("Student not found");
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

