using System;
namespace ThirdTeam_Study.Interfaces
{
    public interface IFileManager <T>
    {
        public bool WriteToFile(T obj);
        public bool WriteToFile(List<T>? list);
        public List<T> ReadAllFromFile();
        public bool ClearFile();
        protected string ToParceJSON(string json);
    }
}

