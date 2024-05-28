using System;
using System.Diagnostics.CodeAnalysis;

public class Student
{
	public string Id { get; }
	public required string Name { get; set; }
	public required string LastName { get; set; }
	public const string University = "Hogwarts";
	public DateOnly? DOB { get; set; }
	public readonly string StudyYear;

    [SetsRequiredMembers]
    public Student (string id, string studyyear, string name, string lastname)
	{
		Id = id;
		StudyYear = studyyear;
		Name = name;
		LastName = lastname;

	}
	public string GetStudentInfo()
	{
		return "Hello, student  ";
	}

    public string GetStudentInfo(string Name)
    {
        return $"Id : {Id}, name : {Name}, lastName {LastName} ";
    }

    public string StudentSayHello()
	{
		return $"Hello, I am {Name}";
	}
}
