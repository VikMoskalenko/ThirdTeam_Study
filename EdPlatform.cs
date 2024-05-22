namespace ThirdTeam_Study
{
    internal class EdPlatform
    {
        public EdPlatform(string language, string country)
        {
            PlatformProperties = new Properties(language, country);
        }

        public const string URL = "zttps://HillelEdPlatform.com";

        public readonly string Name = "HillelEdPlatform";

        public int MaxStudentsCount { get; set; } //Maximum number of students at one meeting

        public Properties PlatformProperties { get; }
        
        public void LaunchMeeting(int currentStudentsCount)
        {
            if(currentStudentsCount <= MaxStudentsCount)
            {
                Console.WriteLine("Launch meeting");
            }
            else
            {
                Console.WriteLine("Limit of students reached.");
            }
        }
        public void LaunchMeeting()
        {
            Console.WriteLine("Launch meeting");
        }
        
        public void ConnectToMeeting()
        {
            Console.WriteLine("Connect to meeting");
        }

        public int ThrowConnectionError()
        {
            // Some logic, that controls properties.Language state
            Console.WriteLine("Connection Error!");
            return 400;
        }

       

        public class Properties() 
        {
            public Properties(string language, string country) : this()
            {
                Language = language;
                Country = country;
            }
            public string Language { get; }
            public string Country { get; }
        }
    }

}
