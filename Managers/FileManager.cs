using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ThirdTeam_Study.Managers
{
    public class FileManager 
    {
        public string FilePath { get; }
        public readonly JsonSerializerSettings settings;
        
        public FileManager(string path = "/Users/volodimir/ThirdTeam_Study/Files/Tutor.json")
        {
            FilePath = path;
            settings = new()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() }
            };
        }

        public bool WriteToFile(Tutor obj)
        {
            if (obj == null) throw new NullReferenceException();
            try
            {
              
                string json_str = JsonConvert.SerializeObject(obj,settings);
                if (!File.Exists(FilePath)) File.Create(FilePath).Close();
                File.WriteAllText(FilePath, ToParceJSON(json_str));
                return true;
            }
            catch (Exception) { return false; }      
        }

        public List<Tutor> ReadAllFromFile()
        {
            List<Tutor> tutors = new();
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath).Close();
                return tutors;
            }
              
            try
            {
               
                string json_str = File.ReadAllText(FilePath);               
                tutors = JsonConvert.DeserializeObject<List<Tutor>>(json_str);//не работает десериализация
                return tutors;
               
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return tutors; }
        }

        protected string ToParceJSON(string json)
        {
            string data = File.ReadAllText(FilePath);
            return (data.Length == 0) ? "[" + json + "]" : data.Remove(data.Length - 1) + "," + json + "]";     
        }
    }
}

