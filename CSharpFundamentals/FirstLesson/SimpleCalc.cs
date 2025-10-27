// 1) Simple calculator (int math + safe division + optional real division)
using System.Globalization;
namespace Fundamentals.FirstLesson
{
    internal class SimpleCalc
    {
        public static void Run()
        {
            int a = InputCheck.ReadInt("Write a first number: ");
            int b = InputCheck.ReadInt("Write a second number: ");

            Console.WriteLine($"a+b = {a + b}, a-b = {a - b}, a*b = {a * b}");

            if (b == 0)
            {
                Console.WriteLine("a/b = undefined (division by zero)");
            }
            else
            {
                Console.WriteLine($"a/b (integer) = {a / b}");
                Console.WriteLine($"a/b (real)    = {(a / (double)b).ToString("G", CultureInfo.InvariantCulture)}");
            }
        }
    }
}