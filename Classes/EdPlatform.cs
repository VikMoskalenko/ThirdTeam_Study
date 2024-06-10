using System.Diagnostics.Metrics;
using ThirdTeam_Study.Enums;
using ThirdTeam_Study.Managers;


namespace ThirdTeam_Study
{
    public class EdPlatform
    {
        public const string URL = "zttps://HillelEdPlatform.com";

        public readonly string ServiceName = "Hillel Education Platform Support Service";

        public readonly string Name = "HillelEdPlatform";
        public readonly string ServiceEmail = "hillelsupprot@zmail.com";
        public readonly string ServicePhone = "+40857295375";
        public required TutorList Tutors { get; set; }
        public required StudentList Students { get; set; }
        public EdPlatform() 
        {
            PlatformProperties = new Properties("en", Themes.Light);
        }
        public EdPlatform(string language, Themes theme)
        {
            PlatformProperties = new Properties(language, theme);
        }

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
