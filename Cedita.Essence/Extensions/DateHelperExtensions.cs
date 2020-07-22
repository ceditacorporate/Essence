// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Cedita.Essence.Extensions
{
    public static class DateHelperExtensions
    {
        public static bool DatesAreInTheSameWeek(this DateTime date1, DateTime date2)
        {
            var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            var d1 = date1.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date1));
            var d2 = date2.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date2));

            return d1 == d2;
        }

        public static DateTime ConvertToDateTime(this string unixTime)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(System.Convert.ToInt32(unixTime)).ToLocalTime();
            return dtDateTime;
        }

        public static string ConvertToSane(this string date)
        {
            var dt = date.Split(' ');
            var dates = dt[0].Split('-');
            var ts = dt[1].Split(':');
            return $"{dates[2]}/{dates[1]}/{dates[0]} ({ts[0]}:{ts[1]})";
        }

        public static string EnsureUKDateTime(this DateTime dt)
        {
            return dt.Date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        public static int MonthWeeks(this DateTime dateTime)
        {
            dateTime = DateTime.Now;
            var daysInMonth = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
            var firstOfMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
            var firstDayOfMonth = (int)firstOfMonth.DayOfWeek;
            return (int)Math.Ceiling((firstDayOfMonth + daysInMonth) / 7.0);
        }

        public static List<string> MonthNamesForMonth(this DateTime dateTime)
        {
            var dates = new List<string>();
            var fridays = AllDatesInMonth(dateTime.Year, dateTime.Month).Where(t => t.DayOfWeek == DayOfWeek.Friday);
            foreach (var f in fridays)
                dates.Add(f.ToShortDateString());

            return dates;
        }

        public static IEnumerable<DateTime> AllDatesInMonth(int year, int month)
        {
            var days = DateTime.DaysInMonth(year, month);
            for (var day = 1; day <= days; day++)
            {
                yield return new DateTime(year, month, day);
            }
        }
    }
}
