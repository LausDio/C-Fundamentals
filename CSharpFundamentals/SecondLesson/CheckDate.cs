/* 5) Enter two integers numbers and check if they can represent the day and month.
        Output result on the console.*/
using System;
using System.Globalization;
namespace Fundamentals.SecondLesson
{
    internal class CheckDate
    {
        // --- Enum of months for readable output ---
        private enum Month
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

        // --- Helper: Convert month number to name ---
        private static string GetMonthName(int month)
        {
            return Enum.GetName(typeof(Month), month) ?? "Unknown";
        }
        // --- Main task method ---
        public static void Run()
        {
            int month = InputCheck.ReadInt("Please, input a mounth: ");
            int day = InputCheck.ReadInt("Please, input a day: ");
            // Validate month range
            if (!InputCheck.AreAllInRange(1f, 12f, (float)month))
            {
                Console.WriteLine("❌ Invalid month. Must be between 1 and 12.");
                return;
            }
            // Determine days in the given month
            int daysInMonth = month switch
            {
                1 or 3 or 5 or 7 or 8 or 10 or 12 => 31,
                4 or 6 or 9 or 11 => 30,
                2 => 28, // ignoring leap years
                _ => 0
            };
            // Validate day range for the given month
            if (!InputCheck.AreAllInRange(1f, (float)daysInMonth, (float)day))
            {
                Console.WriteLine($"❌ Invalid day. {GetMonthName(month)} has {daysInMonth} days.");
                return;
            }

            // If both are valid
            string monthName = GetMonthName(month);
            Console.WriteLine($"✔️ The date is the {day}th of {monthName}.");
        }
    }
}