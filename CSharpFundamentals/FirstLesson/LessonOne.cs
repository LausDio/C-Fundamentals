using System;
using System.Globalization;
namespace Fundamentals.FirstLesson
{
    internal class LessonOne
    {
        // 1) Simple calculator (int math + safe division + optional real division)
        public static void SimpleCalc()
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
        // 2) "How are you?"
        public static void AskHowAreYou()
        {
            Console.Write("How are you ?");
            string? answer = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(answer))
            {
                Console.WriteLine("You didn't answer. I'll assume you're fine 😀");
            }
            else
            {
                Console.WriteLine("You are {0}", answer);
            }
        }
        //3. Read three chars
        public static void ReadThreeChars()
        {
            Console.Write("Enter at least three characters, then press Enter: ");
            string? line = Console.ReadLine();

            if (string.IsNullOrEmpty(line) || line.Length < 3)
            {
                Console.WriteLine("Please enter at least three characters.");
                return;
            }

            Console.WriteLine($"You entered {line[0]}, {line[1]}, {line[2]}");
        }
        // 4) Check both positive
        public static void ArePositive()
        {
            Console.WriteLine("Enter first number:");
            int first = InputCheck.ReadInt();

            Console.WriteLine("Enter second number:");
            int second = InputCheck.ReadInt();
            bool areBothPositive = first > 0 && second > 0;
            if (areBothPositive)
            {
                Console.WriteLine("Both numbers are positive");
            }
            else
            {

                Console.WriteLine("At least one number is not positive");
            }
        }
        // 5) Name and age
        public static void Age()
        {
            Console.Write("What is your name? ");
            string name = (Console.ReadLine() ?? string.Empty).Trim();
            if (name.Length == 0) name = "friend";

            int age = InputCheck.ReadNonNegativeInt($"How old are you, {name}? ");
            Console.WriteLine($"Hello {name}, you are {age} years old :)");
        }
        // 6) Circle/sphere calculations (PI, invariant formatting, non-negative radius)
        public static void CircleCalculations()
        {
            double radius = InputCheck.ReadNonNegativeDouble("Enter the radius of the circle (double): ");
            double circumference = 2 * Math.PI * radius;
            double area = Math.PI * Math.Pow(radius, 2);
            double sphereVolume = (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);

            Console.WriteLine("length: " + Math.Round(circumference, 2, MidpointRounding.AwayFromZero));
            Console.WriteLine("area: " + Math.Round(area, 2, MidpointRounding.AwayFromZero));
            Console.WriteLine("volume: " + Math.Round(sphereVolume, 2, MidpointRounding.AwayFromZero));
        }
        // 7) Square metrics
        public static void SquareMetrics()
        {
            int length = InputCheck.ReadNonNegativeInt("Enter the side length of the square (integer): ");
            int area = length * length;
            int perimeter = 4 * length;
            Console.WriteLine($"Area: {area}");
            Console.WriteLine($"Perimeter: {perimeter}");
        }
    }
}