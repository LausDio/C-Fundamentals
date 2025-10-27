/* 7) Enter integer number h, representing the time of day (hour).
Depending on the time of day, output greetings ("Good morning!", "Good afternoon!",
"Good evening!“ or "Good night!")*/
namespace Fundamentals.SecondLesson
{
    internal class Greeting
    {
        public static void Run()
        {
            int hour = InputCheck.ReadIntInRange(0,23,"Input the time of the day(0–23): ");
            string greeting = hour switch
            {
                >= 5 and < 12 => "☀️ Good morning!",
                >= 12 and < 17 => "🌤️ Good afternoon!",
                >= 17 and < 22 => "🌇 Good evening!",
                _ => "🌙 Good night!"
            };
            Console.WriteLine(greeting);
        }
    }
}