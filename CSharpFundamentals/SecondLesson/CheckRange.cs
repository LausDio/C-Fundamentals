// 1) Check if 3 floats are in range [-5, 5]
namespace Fundamentals.SecondLesson
{
    internal class CheckRange
    {
        public static void Run()
        {
            Console.WriteLine("Enter three float numbers (use '.' for decimals):");

            // Read 3 float numbers safely
            float x = InputCheck.ReadFloat("First number: ");
            float y = InputCheck.ReadFloat("Second number: ");
            float z = InputCheck.ReadFloat("Third number: ");

            bool allInRange = InputCheck.AreAllInRange(-5f, 5f, x, y, z);
            Console.WriteLine(allInRange ? "True" : "False");
        }
    }
}