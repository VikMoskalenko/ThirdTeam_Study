using System;

public class Student
{
	public string Id { get; }
	public required string Name { get; set; }
	public required string LastName { get; set; }
	public const string University = "Hogwarts";
	public DateOnly? DOB { get; set; }
	public readonly string StudyYear;
	public Student (string id, string studyyear, string name, string lastname)
	{
		Id = id;
		StudyYear = studyyear;
		Name = name;
		LastName = lastname;

	}
	public string GetStudentInfo()
	{
		return $"Id : {Id}, name : {Name}, lastName {LastName} ";
	}

	public string StudentSayHello()
	{
		return $"Hello, I am {Name}";
	}
}
