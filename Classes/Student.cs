using ThirdTeam_Study;

public class Student
{
	public readonly string StudyYear;
	public const string University = "Hogwarts";

  public Guid Id { get; }
  public HomeWork Homework { get; set; }
  
	public required string Name { get; set; }
	public required string LastName { get; set; }
	
	public DateOnly? DOB { get; set; }

    public Student()
    {

    }
    public Student(Guid id, string studyyear, string name, string lastname)
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
