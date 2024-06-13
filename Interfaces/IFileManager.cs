using System;
namespace ThirdTeam_Study.Interfaces
{
<<<<<<< HEAD
    public interface IFileManager<T>
=======
    public interface IFileManager <T>
>>>>>>> TutorManagerBranch
    {
        public bool WriteToFile(T obj);
        public bool WriteToFile(List<T>? list);
        public List<T> ReadAllFromFile();
        public bool ClearFile();
        protected string ToParceJSON(string json);
    }
}
<<<<<<< HEAD
=======

>>>>>>> TutorManagerBranch
