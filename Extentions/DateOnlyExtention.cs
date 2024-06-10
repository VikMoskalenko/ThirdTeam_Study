using System;
namespace ThirdTeam_Study
{
    public static class DateOnlyExtention
    {
        public static int ToCalculateAge(this DateOnly b_day)
        {
            DateOnly today = new (DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            return (b_day.Year < today.Year) && (b_day.Month <= today.Month) && (b_day.Day <= today.Day) ? today.Year - b_day.Year : today.Year - b_day.Year - 1;
        }
    }
}

