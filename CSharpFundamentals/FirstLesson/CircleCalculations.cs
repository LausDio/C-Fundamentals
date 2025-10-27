// 6) Circle/sphere calculations (PI, invariant formatting, non-negative radius)
namespace Fundamentals.FirstLesson
{
    internal class CircleCalculations
    {
        public static void Run()
        {
            double radius = InputCheck.ReadNonNegativeDouble("Enter the radius of the circle (double): ");
            double circumference = 2 * Math.PI * radius;
            double area = Math.PI * Math.Pow(radius, 2);
            double sphereVolume = (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);

            Console.WriteLine("length: " + Math.Round(circumference, 2, MidpointRounding.AwayFromZero));
            Console.WriteLine("area: " + Math.Round(area, 2, MidpointRounding.AwayFromZero));
            Console.WriteLine("volume: " + Math.Round(sphereVolume, 2, MidpointRounding.AwayFromZero));
        }
    }
}