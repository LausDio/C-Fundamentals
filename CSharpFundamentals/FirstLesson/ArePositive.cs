// 4) Check both positive
namespace Fundamentals.FirstLesson
{
    internal class ArePositive
    {
        public static void Run()
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
    }
}