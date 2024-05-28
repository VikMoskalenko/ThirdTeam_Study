using System;
namespace ThirdTeam_Study
{
    public static class DateOnlyExtention
    {
        public static int AgeCalculate(this DateOnly b_day)
        {
            return DateTime.Now.Year - b_day.Year;
        }
    }
}

