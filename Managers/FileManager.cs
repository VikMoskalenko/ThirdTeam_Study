using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ThirdTeam_Study.Managers
{
<<<<<<< HEAD
    public class FileManager<T>
=======
    public class FileManager <T>
>>>>>>> TutorManagerBranch
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

        public bool WriteToFile(T obj)
        {
            ArgumentNullException.ThrowIfNull(obj);

            try
<<<<<<< HEAD
            {
                string json_str = JsonConvert.SerializeObject(obj, settings);
                if (!File.Exists(FilePath)) File.Create(FilePath).Close();
                File.WriteAllText(FilePath, ToParceJSON(json_str));
                return true;
=======
            {            
                string json_str = JsonConvert.SerializeObject(obj,settings);
                if (!File.Exists(FilePath)) File.Create(FilePath).Close();
                File.WriteAllText(FilePath, ToParceJSON(json_str));
                return true;                
>>>>>>> TutorManagerBranch
            }
            catch (JsonSerializationException ex) { throw new JsonSerializationException("Serialization / Deserialization error! Check fixing info: " + ex.HelpLink); }
            catch (FileLoadException ex) { throw new FileLoadException("File cannot be loaded! Check fixing info: " + ex.HelpLink); }
            catch (Exception ex) { throw new Exception("Error! Check fixing info: " + ex.HelpLink); }

        }

        public bool WriteToFile(List<T>? list)
        {
            ArgumentNullException.ThrowIfNull(list);
<<<<<<< HEAD

=======
 
>>>>>>> TutorManagerBranch
            if (list.Count == 0) return false;
            try
            {
                List<string> json_list = new();
                foreach (T obj in list)
                    json_list.Add(JsonConvert.SerializeObject(obj, settings));

                if (!File.Exists(FilePath)) File.Create(FilePath).Close();

                foreach (string json in json_list)
                    File.WriteAllText(FilePath, ToParceJSON(json));
                return true;
            }
            catch (JsonSerializationException ex) { throw new JsonSerializationException("Serialization / Deserialization error! Check fixing info: " + ex.HelpLink); }
            catch (FileLoadException ex) { throw new FileLoadException("File cannot be loaded! Check fixing info: " + ex.HelpLink); }
            catch (Exception ex) { throw new Exception("Error! Check fixing info: " + ex.HelpLink); }

        }

        public List<T>? ReadAllFromFile()
        {
            List<T>? list = new();
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath).Close();
                return list;
            }
<<<<<<< HEAD

            try
            {
                string json_str = File.ReadAllText(FilePath);
                list = JsonConvert.DeserializeObject<List<T>>(json_str);
                return list;

=======
              
            try
            {              
                string json_str = File.ReadAllText(FilePath);
                list = JsonConvert.DeserializeObject<List<T>>(json_str);
                return list;
               
>>>>>>> TutorManagerBranch
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
<<<<<<< HEAD
            return (data.Length == 0) ? "[" + json + "]" : data.Remove(data.Length - 1) + "," + json + "]";
=======
            return (data.Length == 0) ? "[" + json + "]" : data.Remove(data.Length - 1) + "," + json + "]";     
>>>>>>> TutorManagerBranch
        }
    }
}

