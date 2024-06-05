using System;
using System.IO;
using Newtonsoft.Json;
using ThirdTeam_Study.Interfaces;

namespace ThirdTeam_Study.Managers
{
    public class TutorFileManager : IFileManager<Tutor> // айдишники абсолютно одинаковые создаются
    {
        private const string MACOS_PATH = "/Users/volodimir/ThirdTeam_Study/Files/";
        public string File_path { get; }

        public TutorFileManager(string file_name = "Tutor.json")
        {
            File_path = MACOS_PATH + file_name;
            if (!File.Exists(File_path))
            {
                File.Create(File_path).Close();
                
            }
        }

        public bool WriteToFile(Tutor obj)
        {
            if (obj == null) throw new NullReferenceException();
            string json_str = JsonConvert.SerializeObject(obj);
   
            try
            {
                File.AppendAllText(File_path, json_str);
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
            
        }
    }
}

