
using ThirdTeam_Study.Enums;

namespace ThirdTeam_Study.Data.Classes
{
    public class EdPlatform
    {
        public static int Id;
        private static EdPlatform? Instance = null;

        public const string URL = "zttps://HillelEdPlatform.com";
        public readonly string Name = "HillelEdPlatform";

        public Properties PlatformProperties { get; }
        public List<Tutor>? Tutors { get; set; }
        public List<Student>? Students { get; set; }

        protected EdPlatform()
        {
            PlatformProperties = new Properties("en", Themes.Light);
        }
        protected EdPlatform(string language, Themes theme)
        {
            PlatformProperties = new Properties(language, theme);
        }

        public static EdPlatform Initialize()
        {
            if (Instance == null)
            {
                Instance = new EdPlatform();
            }
            return Instance;
        }

        public static EdPlatform Initialize(string language, Themes theme)
        {
            if (Instance == null)
            {
                Instance = new EdPlatform(language, theme);
            }
            return Instance;
        }

        public bool Drop()
        {
            if(Instance != null)
            {
                Instance = null;
                return true;
            }
            else 
            { 
                return false; 
            }
        }




        public class Properties
        {
            public Properties(string language, Themes theme)
            {
                Language = language;
                PlatformTheme = theme;
            }
            public string Language { get; set; }
            public Themes PlatformTheme { get; set; }
        }
    }
}
