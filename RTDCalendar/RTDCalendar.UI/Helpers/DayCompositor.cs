using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace RTDCalendar.UI.Helpers
{
    public interface IRDay
    {
        int Day { get; set; }
    }

    public class RDay : IRDay
    {
        public int Day { get; set; }
    }

    public interface IRMonth
    {
        int Month { get; set; }
        List<RDay> Days { get; set; }
    }

    public class RMonth : IRMonth
    {
        public int Month { get; set; }
        public List<RDay> Days { get; set; }
    }

    public interface IRYear
    {
        int Year { get; set; }
        List<RMonth> Months { get; set; }
    }

    public class RYear : IRYear
    {
        public int Year { get; set; }
        public List<RMonth> Months { get; set; }
    }

    public interface IRDate : IRDay, IRMonth, IRYear
    {

    }

    public class RDate : IRDate
    {
        public RDate() : this(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) { }
        public RDate(int year) : this(year, DateTime.Now.Month, DateTime.Now.Day) { }

        public RDate(int year, int month) : this(year, month, DateTime.Now.Day) { }

        public RDate(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;

            Days = GetDaysInMonth(year, month);
            Months = GetMonthsInYear(year);
        }

        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public List<RDay> Days { get; set; }
        public List<RMonth> Months { get; set; }

        public static List<RDay> GetDaysInMonth(int year, int month)
        {
            var days = new List<RDay>();
            var daysInMonth = DateTime.DaysInMonth(year, month);

            for (int day = 1; day <= daysInMonth; day++)
                days.Add(new RDay { Day = day });

            return days;
        }

        public static List<RMonth> GetMonthsInYear(int year)
        {
            var months = new List<RMonth>();
            var monthsInYear = 12;

            for (int month = 1; month <= monthsInYear; month++)
            {
                var days = new List<RDay>();
                var daysInMonth = DateTime.DaysInMonth(year, month);

                for (int day = 1; day <= daysInMonth; day++)
                    days.Add(new RDay { Day = day });

                months.Add(new RMonth { Month = month, Days = days });
            }
            return months;
        }

        //public static int GetLastMonth(int month)
        //{
        //    if (month < 2)
        //        return 12;
        //    else if (month > 11)
        //        return 11;
        //    else
        //        return month - 1;
        //}

        //public static int GetCurrentMonth(int month)
        //{
        //    if (month < 1)
        //        return 1;
        //    else if (month > 11)
        //        return 12;
        //    else
        //        return month;
        //}

        //public static int GetNextMonth(int month)
        //{
        //    if (month > 11)
        //        return 1;
        //    else if (month < 1)
        //        return 1;
        //    else
        //        return month + 1;
        //}
    }

    public interface IRCompositor
    {
        RDate CurrentRDate { get; set; }
        RDate PreviousRDate { get; }
        RDate NextRDate { get; }
    }

    public class RCompositor : IRCompositor
    {
        public RCompositor() : this(DateTime.Now) { }

        public RCompositor(DateTime dateTime)
        {
            var date = dateTime;
            CurrentRDate = new RDate(date.Year, date.Month, date.Day);

            date = dateTime.AddMonths(-1);
            PreviousRDate = new RDate(dateTime.Year, dateTime.Month, dateTime.Day);

            date = dateTime.AddMonths(1);
            NextRDate = new RDate(dateTime.Year, dateTime.Month, dateTime.Day);
        }



        public RDate CurrentRDate { get; set; }

        public RDate PreviousRDate { get; }

        public RDate NextRDate { get; }
    }
}
