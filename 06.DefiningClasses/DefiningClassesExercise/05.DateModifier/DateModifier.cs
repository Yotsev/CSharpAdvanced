using System;

namespace DefiningClasses
{
    public static class DateModifier
    {
        public static double DifferemceBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            double diff = 0;
            diff = (firstDate - secondDate).TotalDays;

            return Math.Abs(diff);
        }

    }
}
