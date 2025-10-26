using System;
using System.Globalization;
namespace Fundamentals.SecondLesson
{
    internal class LessonTwo
    {
        // 1) Check if 3 floats are in range [-5, 5]
        private static bool AreAllInRange(float min, float max, params float[] numbers)
        {
            foreach (float n in numbers)
            {
                if (n < min || n > max)
                {
                    return false;
                }
            }
            return true;
        }

        public static void CheckRange()
        {
            Console.WriteLine("Enter three float numbers (use '.' for decimals):");

            // Read 3 float numbers safely
            float x = InputCheck.ReadFloat("First number: ");
            float y = InputCheck.ReadFloat("Second number: ");
            float z = InputCheck.ReadFloat("Third number: ");

            bool allInRange = AreAllInRange(-5f, 5f, x, y, z);
            Console.WriteLine(allInRange ? "True" : "False");
        }
        // 2) Find min and max of 3 integers
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
        public static void CheckMinMax()
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

        // 3) Show HTTP error name by code (400–404)
        public enum HttpError
        {
            BadRequest = 400,
            Unauthorized,
            PaymentRequired,
            Forbidden,
            NotFound
        };

        public static void CheckHttpError()
        {
            int code = InputCheck.ReadIntInRange(400, 404, "Enter HTTP error code (400–404): ");
            HttpError error = (HttpError)code;
            Console.WriteLine($"Error {code}: {error}");
        }

        // 4) Read Dog info and print it
        struct Dog
        {
            public string Name;
            public string Mark;
            public int Age;

            // Override ToString to display the dog info nicely
            public override string ToString()
            {
                return $"Name: {Name}, mark: {Mark}, age: {Age}";
            }
        }
        public static void ShowDogInfo()
        {
            Dog myDog;

            Console.Write("Enter dog name: ");
            myDog.Name = Console.ReadLine() ?? "Unknown";

            Console.Write("Enter dog mark (e.g., excellent, good): ");
            myDog.Mark = Console.ReadLine() ?? "no mark";

            Console.Write("Enter dog age: ");

            myDog.Age = InputCheck.ReadNonNegativeInt("Age: ");

            // Output info using overridden ToString()
            Console.WriteLine(myDog.ToString());
        }
    }
}