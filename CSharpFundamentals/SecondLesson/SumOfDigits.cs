/* 6) Enter double number and get the first 2 digits after the point of this number and
output the sum of these numbers. For example: 3.456 -> 4+5=9*/
namespace Fundamentals.SecondLesson
{
    internal class SumOfDigits
    {
        public static void Run()
        {
            double number = InputCheck.ReadDouble("Enter a decimal number: ");

            // Get the fractional part
            double fractional = Math.Abs(number % 1);

            // Shift two digits to the left of the decimal and truncate
            int twoDigits = (int)(fractional * 100);

            // Extract individual digits
            int firstDigit = twoDigits / 10;
            int secondDigit = twoDigits % 10;

            int sum = firstDigit + secondDigit;

            Console.WriteLine($"Number: {number}");
            Console.WriteLine($"First two digits after decimal: {firstDigit} and {secondDigit}");
            Console.WriteLine($"Their sum = {sum}");
        }
    }
}