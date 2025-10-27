using Fundamentals.FirstLesson;
using Fundamentals.SecondLesson;
namespace Fundamentals
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(5.11 % 10);   
            Console.WriteLine("Select lesson:");
            Console.WriteLine("1 - Lesson One");
            Console.WriteLine("2 - Lesson Two");
            Console.Write("Choice: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Running Lesson 1...");
                    LessonOneMenu();
                    break;

                case "2":
                    Console.WriteLine("Running Lesson 2...");
                    LessonTwoMenu();
                    break;

                default:
                    Console.WriteLine("Invalid selection.");
                    break;
            }
        }
        private static void LessonOneMenu()
        {
            Console.WriteLine("\nSelect task:");
            Console.WriteLine("1 - Simple calculator");
            Console.WriteLine("2 - How are you?");
            Console.WriteLine("3 - Read three chars");
            Console.WriteLine("4 - Check both positive");
            Console.WriteLine("5 - Name and age");
            Console.WriteLine("6 - Circle/sphere calculations");
            Console.WriteLine("7 - Square metrics");
            Console.Write("Choice: ");
            string? task = Console.ReadLine();

            switch (task)
            {
                case "1": SimpleCalc.Run(); break;
                case "2": AskHowAreYou.Run(); break;
                case "3": ReadThreeChars.Run(); break;
                case "4": ArePositive.Run(); break;
                case "5": Age.Run(); break;
                case "6": CircleCalculations.Run(); break;
                case "7": SquareMetrics.Run(); break;
                default: Console.WriteLine("Invalid task."); break;
            }
        }
        private static void LessonTwoMenu()
        {
            Console.WriteLine("\nSelect task:");
            Console.WriteLine("1 - Check float range");
            Console.WriteLine("2 - Find min/max");
            Console.WriteLine("3 - HTTP error info");
            Console.WriteLine("4 - Dog info");
            Console.WriteLine("5 - Check if number is a date");
            Console.WriteLine("6 - Find a sum of the first 2 digits");
            Console.WriteLine("7 - Greetings");
            Console.WriteLine("8 - Show status");
            Console.WriteLine("9 - Show colors");
            Console.WriteLine("10 - Show students in a group");
            Console.WriteLine("11 - Feed a cat");
            Console.Write("Choice: ");
            string? task = Console.ReadLine();

            switch (task)
            {
                case "1": CheckRange.Run(); break;
                case "2": CheckMinMax.Run(); break;
                case "3": CheckHttpError.Run(); break;
                case "4": Dog.ShowDogInfo(); break;
                case "5": CheckDate.Run(); break;
                case "6": SumOfDigits.Run(); break;
                case "7": Greeting.Run(); break;
                case "8": TestStatus.Run(); break;
                case "9": RGBColors.TwoColors(); break;
                case "10": StudentFilter.Run(); break;
                case "11": Cat.GreetCat(); break;
                default: Console.WriteLine("Invalid task."); break;
            }
        }
    }
}