namespace ThirdTeam_Study.Managers
{
    public class FileManager 
    {
        public required string FilePath { get; set; } // "/Users/volodimir/ThirdTeam_Study/Files/Tutor.json"
        public readonly JsonSerializerSettings settings;

        public FileManager ()
        {

        }
// set required attribute
        public FileManager(string path)
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
            catch (Exception ex) { throw new Exception("File error", ex); }      
        }

        public bool WriteToFile(List<Tutor> list)
        {
            if (list.Count == 0) return true;
            try
            {
                List<string> json_list = new();
                foreach (Tutor tutor in list)
                    json_list.Add(JsonConvert.SerializeObject(tutor, settings));

                if (!File.Exists(FilePath)) File.Create(FilePath).Close();

                foreach (string json in json_list)
                    File.WriteAllText(FilePath, ToParceJSON(json));
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
                tutors = JsonConvert.DeserializeObject<List<Tutor>>(json_str);
                return tutors;
               
            }
            catch (Exception ex) { return tutors; }
        }

        public bool ClearFile()
        {
            try
            {
                File.Delete(FilePath);
                return true;
            }
            catch (Exception) { return false; }
        }

        protected string ToParceJSON(string json)
        {
            string data = File.ReadAllText(FilePath);
            return (data.Length == 0) ? "[" + json + "]" : data.Remove(data.Length - 1) + "," + json + "]";     
        }
    }
}

