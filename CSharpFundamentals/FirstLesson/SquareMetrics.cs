// 7) Square metrics
namespace Fundamentals.FirstLesson
{
    internal class SquareMetrics
    {
        public static void Run()
        {
            int length = InputCheck.ReadNonNegativeInt("Enter the side length of the square (integer): ");
            int area = length * length;
            int perimeter = 4 * length;
            Console.WriteLine($"Area: {area}");
            Console.WriteLine($"Perimeter: {perimeter}");
        }
    }
}