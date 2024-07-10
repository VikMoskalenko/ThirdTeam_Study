using System.Text.RegularExpressions;

namespace ThirdTeam_Study.Data.Classes
{
    public record Book()
    {
        private string _isbn = "000-0-00000-000-0";
        private string _name  = "No name";
        private string _author = "No author";
        private int _year = 1990;
        private string _publisher = "No publisher";


        public string ISBN
        {
            get { return _isbn; }
            init => _isbn = CheckISBN(value);
        }

        public string Name
        {
            get { return _name; }
            init => _name = value;
        }

        public string Author
        {
            get { return _author; }
            init => _author = value;
        }

        public int Year
        {
            get { return _year; }
            init => _year = CheckYear(value);
        }

        public string Publisher
        {
            get { return _publisher; }
            init => _publisher = value;
        }

        private string CheckISBN(string isbn)
        {

            Regex template = new Regex(@"^(?=(?:[^0-9]*[0-9]){10}(?:(?:[^0-9]*[0-9]){3})?$)[\d-]+$");
            if (!template.IsMatch(isbn))
            {
                throw new ArgumentException("Icorrect ISBN. Examples: 978-1-45678-123-4, 1-56619-909-3, 1207199818865");
            }
            return isbn;
        }

        private int CheckYear(int year)
        {

            if (year < 0 || year > DateTime.Now.Year) 
            {
                throw new ArgumentException("Icorrect Year!");
            }
            return year;
        }


        public override string ToString()
        {
            return $"\"{_name}\" by {_author}. ISBN: {_isbn}. {_year}, {_publisher}";
        }

    }

    public record Book2(string ISBN, string Name, string Author, int Year, string Publisher)
    {
        public string Isbn { get; init; } = CheckISBN(ISBN);
        public string Name { get; init; } = Name;
        public string Author { get; init; } = Author;
        public int Year { get; init; } = CheckYear(Year);
        public string Publisher { get; init; } = Publisher;
        
        private static string CheckISBN(string isbn)
        {

            Regex template = new Regex(@"^(?=(?:[^0-9]*[0-9]){10}(?:(?:[^0-9]*[0-9]){3})?$)[\d-]+$");
            if (!template.IsMatch(isbn))
            {
                throw new ArgumentException("Icorrect ISBN. Examples: 978-1-45678-123-4, 1-56619-909-3, 1207199818865");
            }
            return isbn;
        }

        private static int CheckYear(int year)
        {

            if (year < 0 || year > DateTime.Now.Year)
            {
                throw new ArgumentException("Icorrect Year!");
            }
            return year;
        }


        public override string ToString()
        {
            return $"\"{Name}\" by {Author}. ISBN: {Isbn}. {Year}, {Publisher}";
        }

    }
}
