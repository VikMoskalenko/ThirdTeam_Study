﻿using System;
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
}

