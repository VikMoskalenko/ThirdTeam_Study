using System;
namespace ThirdTeam_Study.Interfaces
{
    public interface IFileManager <T>
    {
        public bool WriteToFile(T obj);
        public List<T> ReadAllFromFile();
        public bool ClearFile();
        protected string ToParceJSON(string json);
    }
}

