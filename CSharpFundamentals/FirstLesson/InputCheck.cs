using System;
using System.Globalization;
namespace Fundamentals.FirstLesson
{
    public static class InputCheck
    {
        public static int ReadInt(string? prompt = null)
        {
            while (true)
            {
                if (!string.IsNullOrEmpty(prompt)) Console.Write(prompt);
                string? input = Console.ReadLine();

                if (input is null)
                {
                    Console.WriteLine("Input was null. Please, enter a valid integer:");
                    continue;
                }
                if (int.TryParse(input.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int value))
                    return value;

                Console.WriteLine("Please, enter an integer value.");
                prompt = null;
            }
        }
        public static double ReadDouble(string? prompt = null)
        {
            while (true)
            {
                if (!string.IsNullOrEmpty(prompt)) Console.Write(prompt);
                string? input = Console.ReadLine();

                if (input is null)
                {
                    Console.WriteLine("Input was null. Please, enter a valid number:");
                    continue;
                }
                if (double.TryParse(input.Trim(), NumberStyles.Float | NumberStyles.AllowThousands,
                    CultureInfo.InvariantCulture, out double value))
                    return value;

                Console.WriteLine("Please, enter a double value (e.g., 3.14).");
                prompt = null;
            }
        }
    }
}