using System;
namespace ThirdTeam_Study.Interfaces
{
    public interface IFileManager <T>
    {
        public bool WriteToFile(T obj);
    }
}

