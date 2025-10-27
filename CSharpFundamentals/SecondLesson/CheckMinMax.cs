// 2) Find min and max of 3 integers
using System;
using System.Globalization;
namespace Fundamentals.SecondLesson
{
    internal class CheckMinMax
    {
        private static (int min, int max) FindMinMax(int a, int b, int c)
        {
            int min = a;
            int max = a;

            // Compare with b
            if (b < min)
            {
                min = b;
            }
            if (b > max)
            {
                max = b;
            }

            // Compare with c
            if (c < min)
            {
                min = c;
            }
            if (c > max)
            {
                max = c;
            }

            return (min, max);
        }
        public static void Run()
        {
            Console.WriteLine("Enter three integer numbers:");

            // Read 3 integers from the console
            int a = InputCheck.ReadInt("First number: ");
            int b = InputCheck.ReadInt("Second number: ");
            int c = InputCheck.ReadInt("Third number: ");

            // Find max and min
            (int min, int max) = FindMinMax(a, b, c);

            // Output results
            Console.WriteLine($"max: {max}");
            Console.WriteLine($"min: {min}");
        }

    }
}