//3. Read three chars
namespace Fundamentals.FirstLesson
{
    internal class ReadThreeChars
    {
        public static void Run()
        {
            Console.Write("Enter at least three characters, then press Enter: ");
            string? line = Console.ReadLine();

            if (string.IsNullOrEmpty(line) || line.Length < 3)
            {
                Console.WriteLine("Please enter at least three characters.");
                return;
            }

            Console.WriteLine($"You entered {line[0]}, {line[1]}, {line[2]}");
        }
    }
}