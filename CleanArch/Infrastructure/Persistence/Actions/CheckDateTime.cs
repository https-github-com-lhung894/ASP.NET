using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Actions
{
    public static class CheckDateTime
    {
        public static bool AfterNow(this DateTime date)
        {
            if(DateTime.Now.Year < date.Year)
            {
                return true;
            }
            if(DateTime.Now.Year == date.Year && DateTime.Now.Month < date.Month)
            {
                return true;
            }
            if(DateTime.Now.Year == date.Year && DateTime.Now.Month == date.Month && DateTime.Now.Day < date.Day)
            {
                return true;
            }
            return false;
        }
        public static bool Before(this DateTime date, DateTime date1)
        {
            if (date.Year < date1.Year)
            {
                return true;
            }
            if (date.Year == date1.Year && date.Month < date1.Month)
            {
                return true;
            }
            if (date.Year == date1.Year && date.Month == date1.Month && date.Day < date1.Day)
            {
                return true;
            }
            return false;
        }
        public static bool After(this DateTime date, DateTime date1)
        {
            if (date.Year > date1.Year)
            {
                return true;
            }
            if (date.Year == date1.Year && date.Month > date1.Month)
            {
                return true;
            }
            if (date.Year == date1.Year && date.Month == date1.Month && date.Day > date1.Day)
            {
                return true;
            }
            return false;
        }
        public static bool EqualTo(this DateTime date, DateTime date1)
        {
            return date.Year == date1.Year && date.Month == date1.Month && date.Day == date1.Day;
        }
        public static bool IsFirstDayOfMonth(this DateTime date)
        {
            if(date.Year == DateTime.Now.Year && date.Month == DateTime.Now.Month && date.Day == 1)
            {
                return true;
            }

            return false;
        }
        public static DateTime FirstDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }
        public static DateTime LastDayOfMonth(this DateTime date)
        {
            //Tính ngày tháng
            int m = 30;
            int[] array = new int[] { 1, 3, 5, 7, 8, 10, 12 };
            for (int i = 0; i < array.Length; i++)
            {
                if (date.Month == array[i])
                {
                    m = 31;
                }
            }
            return new DateTime(date.Year, date.Month, m);
        }
        public static DateTime FirstDayOfPreviousMonth(this DateTime date)
        {
            return new DateTime(date.Month == 1 ? date.Year - 1 : date.Year, date.Month == 1 ? 12 : date.Month - 1, 1);
        }
    }
}
