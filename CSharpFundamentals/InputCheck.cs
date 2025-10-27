using System.Globalization;

namespace Fundamentals
{
    public static class InputCheck
    {
        // 🔹 Read integer (any)
        public static int ReadInt(string? prompt = null, int? maxRetries = null)
        {
            int attempts = 0;

            while (true)
            {
                if (!string.IsNullOrEmpty(prompt))
                    Console.Write(prompt);

                string? input = Console.ReadLine();

                if (input is null)
                    throw new EndOfStreamException("No input provided for ReadInt.");

                if (int.TryParse(input.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int value))
                    return value;

                Console.WriteLine("Please, enter a valid integer value.");
                prompt = null;

                if (++attempts == maxRetries)
                    throw new InvalidOperationException("Maximum retry limit reached for ReadInt.");
            }
        }

        // 🔹 Read non-negative integer
        public static int ReadNonNegativeInt(string? prompt = null, int? maxRetries = null)
        {
            int attempts = 0;

            while (true)
            {
                if (!string.IsNullOrEmpty(prompt))
                    Console.Write(prompt);

                string? input = Console.ReadLine();
                if (input is null)
                    throw new EndOfStreamException("No input provided for ReadNonNegativeInt.");

                if (int.TryParse(input.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int value))
                {
                    if (value >= 0)
                        return value;

                    Console.WriteLine("Please enter a non-negative integer (0 or higher).");
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer number.");
                }

                prompt = null;

                if (++attempts == maxRetries)
                    throw new InvalidOperationException("Maximum retry limit reached for ReadNonNegativeInt.");
            }
        }

        // 🔹 Read double (any)
        public static double ReadDouble(string? prompt = null, int? maxRetries = null)
        {
            int attempts = 0;

            while (true)
            {
                if (!string.IsNullOrEmpty(prompt))
                    Console.Write(prompt);

                string? input = Console.ReadLine();

                if (input is null)
                    throw new EndOfStreamException("No input provided for ReadDouble.");

                if (double.TryParse(input.Trim(), NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out double value))
                    return value;

                Console.WriteLine("Please, enter a double value (e.g., 3.14).");
                prompt = null;

                if (++attempts == maxRetries)
                    throw new InvalidOperationException("Maximum retry limit reached for ReadDouble.");
            }
        }

        // 🔹 Read non-negative double
        public static double ReadNonNegativeDouble(string? prompt = null, int? maxRetries = null)
        {
            int attempts = 0;

            while (true)
            {
                if (!string.IsNullOrEmpty(prompt))
                    Console.Write(prompt);

                string? input = Console.ReadLine();
                if (input is null)
                    throw new EndOfStreamException("No input provided for ReadNonNegativeDouble.");

                if (double.TryParse(input.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
                {
                    if (value >= 0)
                        return value;

                    Console.WriteLine("Please enter a non-negative number (0 or higher).");
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }

                prompt = null;

                if (++attempts == maxRetries)
                    throw new InvalidOperationException("Maximum retry limit reached for ReadNonNegativeDouble.");
            }
        }

        // 🔹 Read float (any)
        public static float ReadFloat(string? prompt = null, int? maxRetries = null)
        {
            int attempts = 0;

            while (true)
            {
                if (!string.IsNullOrEmpty(prompt))
                    Console.Write(prompt);

                string? input = Console.ReadLine();

                if (input is null)
                    throw new EndOfStreamException("No input provided for ReadFloat.");

                if (float.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out float value))
                    return value;

                Console.WriteLine("Invalid input. Please enter a valid float number (e.g., 3.14 or -2.5).");
                prompt = null;

                if (++attempts == maxRetries)
                    throw new InvalidOperationException("Maximum retry limit reached for ReadFloat.");
            }
        }

        // 🔹 Read int in range
        public static int ReadIntInRange(int min, int max, string? prompt = null, int? maxRetries = null)
        {
            int attempts = 0;

            while (true)
            {
                if (!string.IsNullOrEmpty(prompt))
                    Console.Write(prompt);

                string? input = Console.ReadLine();
                if (input is null)
                    throw new EndOfStreamException("No input provided for ReadIntInRange.");

                if (int.TryParse(input, out int value))
                {
                    if (value >= min && value <= max)
                        return value;

                    Console.WriteLine($"Please enter a number between {min} and {max}.");
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer number.");
                }

                prompt = null;

                if (++attempts == maxRetries)
                    throw new InvalidOperationException("Maximum retry limit reached for ReadIntInRange.");
            }
        }

        // 🔹 Read float in range
        public static float ReadFloatInRange(float min, float max, string? prompt = null, int? maxRetries = null)
        {
            int attempts = 0;

            while (true)
            {
                if (!string.IsNullOrEmpty(prompt))
                    Console.Write(prompt);

                string? input = Console.ReadLine();
                if (input is null)
                    throw new EndOfStreamException("No input provided for ReadFloatInRange.");

                if (float.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out float value))
                {
                    if (value >= min && value <= max)
                        return value;

                    Console.WriteLine($"Please enter a number between {min} and {max}.");
                }
                else
                {
                    Console.WriteLine("Please enter a valid floating-point number (e.g., 3.14).");
                }

                prompt = null;

                if (++attempts == maxRetries)
                    throw new InvalidOperationException("Maximum retry limit reached for ReadFloatInRange.");
            }
        }
        public static bool AreAllInRange(float min, float max, params float[] numbers)
        {
            foreach (float n in numbers)
            {
                if (n < min || n > max)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
