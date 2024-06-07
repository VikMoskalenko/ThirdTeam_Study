using System;
using System.Diagnostics.CodeAnalysis;

public class Student
{
	public readonly string StudyYear;
	public const string University = "Hogwarts";

    public int Id { get; }
	public required string Name { get; set; }
	public required string LastName { get; set; }
	
	public DateOnly? DOB { get; set; }

    public Student()
    {

    }
    public Student(int id, string studyyear, string name, string lastname)
    {
        Id = id;
        StudyYear = studyyear;
        Name = name;
        LastName = lastname;

    }

}
public static class StudentExtensionsHW4
{
	public static string GetFullInfo(this Student student)
	{
		return $"{student.Name}, {student.DOB}, {student.LastName}";
	}
}
public record StudentRecord(string Id, string Name, string LastName, string StudyYear);