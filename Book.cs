using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ThirdTeam_Study
{
    public record Book
    {
        private string _isbn;
        private string _name;
        private string _author;
        private int _year;
        private string _place;


        public Book()
        {
            _isbn = ISBN;
            _name = Name;
            _author = Author;
            _year = Year;
            _place = Place;
        }
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

        public string Place
        {
            get { return _place; }
            init => _place = value;
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
            return $"{_name} by {_author}. ISBN: {_isbn}. {_year}, {_place}";
        }

    }
}
