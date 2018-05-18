using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace RTDCalendar.UI.Helpers
{
    public class DayCompositor
    {
        // день как единица...фазирование на три месяца...
        // кнопки назад и вперед
        // месяц из нескольких дней
        // год из 12 месяцев
        // 


    }

    public interface IDate
    {
        int Unit { get; set; }
    }

    public class Date : IDate
    {
        private int _unit;
        public int Unit
        {
            get => _unit;
            set => _unit = value;
        }
    }

    public class Day : Date
    {

    }

    public class Month : Date
    {

    }

    public class Year : Date
    {

    }

    public interface INavigationDate<T>
    {
        bool GoToNextDate(Type dateType);
        bool GoToPreviousDate(Type dateType);
        bool GoToDate(T date);
    }

    public interface ICurrentDate<T>
    {
        T CurrentYear { get; }
        T CurrentMonth { get; }
    }

    public interface IDateStorage<T>
    {
        List<T> LastDates { get; }
        List<T> CurrentDates { get; }
        List<T> NextDates { get; }

        List<T> GetDatesAtMonth(T year, T month);
    }

    public class DateStorage<T> : INavigationDate<T>, ICurrentDate<T>, IDateStorage<T> where T : Date, new()
    {
        public T CurrentYear { get; }
        public T CurrentMonth { get; }

        public List<T> LastDates { get; }
        public List<T> CurrentDates { get; }
        public List<T> NextDates { get; }

        public DateStorage(T year = default(T), T month = default(T))
        {
            InitializeDate(ref year, ref month);

            CurrentYear = year;
            CurrentMonth = month;

            LastDates = GetDatesAtMonth(year, new T { Unit = MonthHelper.GetLastMonth(month.Unit) });
            CurrentDates = GetDatesAtMonth(year, new T { Unit = MonthHelper.GetCurrentMonth(month.Unit) });
            NextDates = GetDatesAtMonth(year, new T { Unit = MonthHelper.GetNextMonth(month.Unit) });
        }

        private void InitializeDate(ref T year, ref T month)
        {
            if (year == default(T) || year.Unit < 1)
                year = new T { Unit = DateTime.Now.Year };
            if (month == default(T) || month.Unit < 1)
                month = new T { Unit = DateTime.Now.Month };
        }

        public List<T> GetDatesAtMonth(T year, T month)
        {
            List<T> listDates = new List<T>();
            int daysInMonth = DateTime.DaysInMonth(year.Unit, month.Unit);

            for (int day = 1; day <= daysInMonth; day++)
                listDates.Add(new T { Unit = day });

            return listDates;
        }

        public bool GoToNextDate(Type dateType)
        {
            return true;
        }

        public bool GoToPreviousDate(Type dateType)
        {
            return true;
        }

        public bool GoToDate(T date)
        {
            return true;
        }
    }

    public static class MonthHelper
    {
        public static int GetLastMonth(int month)
        {
            if (month < 2)
                return 12;
            else if (month > 11)
                return 11;
            else
                return month - 1;
        }

        public static int GetCurrentMonth(int month)
        {
            if (month < 1)
                return 1;
            else if (month > 11)
                return 12;
            else
                return month;
        }

        public static int GetNextMonth(int month)
        {
            if (month > 11)
                return 1;
            else if (month < 1)
                return 1;
            else
                return month + 1;
        }
    }

    // Текущий месяц
}
