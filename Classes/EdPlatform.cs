using System.Diagnostics.Metrics;
using ThirdTeam_Study.Enums;
using ThirdTeam_Study.ListTypes;
using ThirdTeam_Study.Managers;


namespace ThirdTeam_Study
{
    public class EdPlatform
    {
        private static EdPlatform? edPlatform = null;

        public const string URL = "zttps://HillelEdPlatform.com";
        public readonly string Name = "HillelEdPlatform";
        

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
            if (edPlatform == null)
            {
                edPlatform = new EdPlatform();
            }
            return edPlatform;
        }

        public static EdPlatform Initialize(string language, Themes theme)
        {
            if (edPlatform == null)
            {
                edPlatform = new EdPlatform(language, theme);
            }
            return edPlatform;
        }

        
        public List<Tutor> Tutors { get; set; } = new List<Tutor>();
        public StudentList Students { get; set; } = new StudentList();

        public Properties PlatformProperties { get; }

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
