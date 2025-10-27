using System.Globalization;

namespace Fundamentals.Tests
{
    // Ensures invariant culture for numeric formatting in all tests
    public class InvariantCultureFixture : IDisposable
    {
        private readonly CultureInfo _oldCulture = CultureInfo.CurrentCulture;
        private readonly CultureInfo _oldUiCulture = CultureInfo.CurrentUICulture;

        public InvariantCultureFixture()
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
        }

        public void Dispose()
        {
            CultureInfo.DefaultThreadCurrentCulture = _oldCulture;
            CultureInfo.DefaultThreadCurrentUICulture = _oldUiCulture;
        }
    }

    [CollectionDefinition("InvariantCulture")]
    public class InvariantCultureCollection : ICollectionFixture<InvariantCultureFixture> { }

    internal static class ConsoleTestUtils
    {
        public static string RunWithIo(Action action, string simulatedInput)
        {
            var oldIn = Console.In;
            var oldOut = Console.Out;

            try
            {
                using var input = new StringReader(simulatedInput);
                using var output = new StringWriter();
                Console.SetIn(input);
                Console.SetOut(output);

                action();

                return output.ToString();
            }
            finally
            {
                Console.SetIn(oldIn);
                Console.SetOut(oldOut);
            }
        }
        public static T RunWithIo<T>(Func<T> func, string input, out string consoleOut)
        {
            var oldIn = Console.In;
            var oldOut = Console.Out;

            try
            {
                using var reader = new StringReader(input);
                using var writer = new StringWriter();
                Console.SetIn(reader);
                Console.SetOut(writer);
                var result = func();
                consoleOut = writer.ToString();
                return result;
            }
            finally
            {
                Console.SetIn(oldIn);
                Console.SetOut(oldOut);
            }
        }
    }
}
