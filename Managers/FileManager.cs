using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ThirdTeam_Study.Managers
{
    public class FileManager
    {
        public string FilePath { get; }
        public readonly JsonSerializerSettings settings;

        public FileManager(string file_name)
        {
            FilePath = Directory.GetCurrentDirectory().Replace("/bin/Debug/net8.0", "/Files/" + file_name);
            settings = new()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() }
            };
        }

        public bool WriteToFile(Tutor obj)
        {
            ArgumentNullException.ThrowIfNull(obj);

            try
            {            
                string json_str = JsonConvert.SerializeObject(obj,settings);
                if (!File.Exists(FilePath)) File.Create(FilePath).Close();
                File.WriteAllText(FilePath, ToParceJSON(json_str));
                return true;                
            }
            catch (JsonSerializationException ex) { throw new JsonSerializationException("Serialization / Deserialization error! Check fixing info: " + ex.HelpLink); }
            catch (FileLoadException ex) { throw new FileLoadException("File cannot be loaded! Check fixing info: " + ex.HelpLink); }
            catch (Exception ex) { throw new Exception("Error! Check fixing info: " + ex.HelpLink); }

        }

        public bool WriteToFile(List<Tutor>? list)
        {
            ArgumentNullException.ThrowIfNull(list);
 
            if (list.Count == 0) return false;
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
            catch (JsonSerializationException ex) { throw new JsonSerializationException("Serialization / Deserialization error! Check fixing info: " + ex.HelpLink); }
            catch (FileLoadException ex) { throw new FileLoadException("File cannot be loaded! Check fixing info: " + ex.HelpLink); }
            catch (Exception ex) { throw new Exception("Error! Check fixing info: " + ex.HelpLink); }

        }

        public List<Tutor>? ReadAllFromFile()
        {
            List<Tutor>? tutors = new();
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
            catch (JsonSerializationException ex) { throw new JsonSerializationException("Serialization / Deserialization error! Check fixing info: " + ex.HelpLink); }
            catch (FileLoadException ex) { throw new FileLoadException("File cannot be loaded! Check fixing info: " + ex.HelpLink); }
            catch (Exception ex) { throw new Exception("Error! Check fixing info: " + ex.HelpLink); }

        }

        public bool ClearFile()
        {
            try
            {
                File.Delete(FilePath);
                return true;
            }
            catch (FileNotFoundException ex) { throw new FileNotFoundException("File is not finded! Check fixing info: " + ex.HelpLink); }
        }

        protected string ToParceJSON(string json)
        {
            string data = File.ReadAllText(FilePath);
            return (data.Length == 0) ? "[" + json + "]" : data.Remove(data.Length - 1) + "," + json + "]";     
        }
    }
}

