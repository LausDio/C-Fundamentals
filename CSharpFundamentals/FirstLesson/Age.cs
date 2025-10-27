// 5) Name and age
namespace Fundamentals.FirstLesson
{
    internal class Age
    {
        public static void Run()
        {
            Console.Write("What is your name? ");
            string name = (Console.ReadLine() ?? string.Empty).Trim();
            if (name.Length == 0) name = "friend";

            int age = InputCheck.ReadNonNegativeInt($"How old are you, {name}? ");
            Console.WriteLine($"Hello {name}, you are {age} years old :)");
        }
    }
}