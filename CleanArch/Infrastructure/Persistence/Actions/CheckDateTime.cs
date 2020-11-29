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
            if(DateTime.Now.Year == date.Year && DateTime.Now.Month == date.Month && DateTime.Now.Day <= date.Day)
            {
                return true;
            }
            return false;
        }
    }
}
