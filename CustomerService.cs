using System;
using System.Collections.Generic;


namespace ThirdTeam_Study
{
    public class CustomerService
    {
        public const string ServiceName = "Hillel Education Platform Support Service";
        public readonly string ServiceEmail;
        public required TutorList Tutors { get; set; }
        //public required StudentList Students { get; set; }
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


    // TODO: Add student list class
    //public class StudentList
    //{
    //    private List<Student> students = new List<Student>();

    //}

    public class TutorList
    {
        private List<Tutor> Tutors = new List<Tutor>();

        //Not work, Tutor class has internal access modifier
        //public void AddTutor(Tutor tutor)
        //{
        //    Tutors.Add(tutor);
        //    Console.WriteLine($"Tutor {tutor.FirstName} added.");
        //}

        public void AddTutor(string firstname, string lastname, DateOnly bday)
        {
            var NewTutor = new Tutor(firstname, lastname, bday);
            Tutors.Add(NewTutor);
            Console.WriteLine($"Tutor {NewTutor.FirstName} added.");
        }

        public void RemoveTutor(string firstname, string lastname) 
        {
            var tutor = Tutors.Find(t => t.FirstName == firstname && t.LastName == lastname);
            if (tutor != null) 
            {
                Console.WriteLine($"Tutor {tutor.ID} : {tutor.FirstName} {tutor.LastName} removed");
                Tutors.Remove(tutor);
            }
            else
            {
                Console.WriteLine("Tutor not found");
            }
        }

        public void RemoveTutor(int id)
        {
            var tutor = Tutors.Find(t => t.ID == id);
            if (tutor != null)
            {
                Console.WriteLine($"Tutor {tutor.ID} : {tutor.FirstName} {tutor.LastName} removed");
                Tutors.Remove(tutor);
            }
            else
            {
                Console.WriteLine("Tutor not found");
            }
        }
    }


}

