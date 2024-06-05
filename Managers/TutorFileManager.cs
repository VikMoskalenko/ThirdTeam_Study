using System;
using Newtonsoft.Json;
using ThirdTeam_Study.Interfaces;

namespace ThirdTeam_Study.Managers
{
    public class TutorFileManager : IFileManager<Tutor>
    {

        public TutorFileManager()
        {
        }

        public bool WriteToFile(Tutor? obj, string file_path)
        {
            if ((obj == null)||(file_path==null)) throw new NullReferenceException();
            if (!File.Exists(file_path)) File.Create(file_path);

            string json_str = JsonConvert.SerializeObject(obj);//эксепшн когда файл не существует, хотя в конструкторе я его создаю
            File.WriteAllText(file_path, json_str);
            return true;
        }
    }
}

