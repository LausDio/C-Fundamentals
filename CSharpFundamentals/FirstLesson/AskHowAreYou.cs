// 2) "How are you?"
namespace Fundamentals.FirstLesson
{
    internal class AskHowAreYou
    {
        public static void Run()
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
    }
}