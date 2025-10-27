// 4) Read Dog info and print it
using System;
using System.Globalization;
namespace Fundamentals.SecondLesson
{
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