using System.Globalization;

namespace Fundamentals.Tests
{
    public class InputCheckTests
    {
        public InputCheckTests()
        {
            // Ensure predictable parsing independent of OS/user locale.
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
        }

        // ---------- ReadInt ----------

        [Fact]
        public void ReadInt_ValidFirstTry_ReturnsValue()
        {
            int result = ConsoleTestUtils.RunWithIo(() => InputCheck.ReadInt("n: "), "42\n", out _);
            Assert.Equal(42, result);
        }

        [Fact]
        public void ReadInt_InvalidThenValid_WithinMaxRetries_Succeeds()
        {
            int result = ConsoleTestUtils.RunWithIo(() => InputCheck.ReadInt("n: ", maxRetries: 3), "abc\n-7\n", out string output);
            Assert.Equal(-7, result);
            Assert.Contains("Please, enter a valid integer value", output);
        }

        [Fact]
        public void ReadInt_TooManyInvalid_Throws()
        {
            Assert.Throws<InvalidOperationException>(() =>
                ConsoleTestUtils.RunWithIo(() => InputCheck.ReadInt("n: ", maxRetries: 2), "bad\nstill bad\n", out _));
        }

        [Fact]
        public void ReadInt_Eof_ThrowsEndOfStream()
        {
            Assert.Throws<EndOfStreamException>(() =>
                ConsoleTestUtils.RunWithIo(() => InputCheck.ReadInt("n: "), "", out _));
        }

        // ---------- ReadNonNegativeInt ----------

        [Theory]
        [InlineData("0\n", 0)]
        [InlineData("5\n", 5)]
        public void ReadNonNegativeInt_ValidNonNegative(string input, int expected)
        {
            int result = ConsoleTestUtils.RunWithIo(() => InputCheck.ReadNonNegativeInt("age: "), input, out _);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReadNonNegativeInt_NegativeThenValid_RespectsMaxRetries()
        {
            int result = ConsoleTestUtils.RunWithIo(() => InputCheck.ReadNonNegativeInt("age: ", maxRetries: 3), "-1\n12\n", out string output);
            Assert.Equal(12, result);
            Assert.Contains("non-negative", output);
        }

        [Fact]
        public void ReadNonNegativeInt_TooManyInvalid_Throws()
        {
            Assert.Throws<InvalidOperationException>(() =>
                ConsoleTestUtils.RunWithIo(() => InputCheck.ReadNonNegativeInt(maxRetries: 2), "-5\n-2\n", out _));
        }

        // ---------- ReadDouble ----------

        [Theory]
        [InlineData("3.14\n", 3.14)]
        [InlineData("-2.5\n", -2.5)]
        public void ReadDouble_ParsesInvariant(string input, double expected)
        {
            double result = ConsoleTestUtils.RunWithIo(() => InputCheck.ReadDouble("d: "), input, out _);
            Assert.Equal(expected, result, 8);
        }

        [Fact]
        public void ReadDouble_InvalidThenValid_WithCap_Succeeds()
        {
            double result = ConsoleTestUtils.RunWithIo(() => InputCheck.ReadDouble(maxRetries: 2), "xx\n1.25\n", out string output);
            Assert.Equal(1.25, result, 8);
            Assert.Contains("double value", output);
        }

        [Fact]
        public void ReadDouble_TooManyInvalid_Throws()
        {
            Assert.Throws<InvalidOperationException>(() =>
                ConsoleTestUtils.RunWithIo(() => InputCheck.ReadDouble(maxRetries: 2), "x\nx\n", out _));
        }

        [Fact]
        public void ReadDouble_Eof_Throws()
        {
            Assert.Throws<EndOfStreamException>(() =>
                ConsoleTestUtils.RunWithIo(() => InputCheck.ReadDouble(), "", out _));
        }

        // ---------- ReadNonNegativeDouble ----------

        [Fact]
        public void ReadNonNegativeDouble_NegativeThenValid_Succeeds()
        {
            double result = ConsoleTestUtils.RunWithIo(() => InputCheck.ReadNonNegativeDouble("v: ", maxRetries: 3), "-0.1\n0.0\n", out string output);
            Assert.Equal(0.0, result, 8);
            Assert.Contains("non-negative", output);
        }

        [Fact]
        public void ReadNonNegativeDouble_TooManyInvalid_Throws()
        {
            Assert.Throws<InvalidOperationException>(() =>
                ConsoleTestUtils.RunWithIo(() => InputCheck.ReadNonNegativeDouble(maxRetries: 2), "-1\n-2\n", out _));
        }

        // ---------- ReadFloat ----------

        [Theory]
        [InlineData("1.5\n", 1.5f)]
        [InlineData("-3\n", -3f)]
        public void ReadFloat_Parses(string input, float expected)
        {
            float result = ConsoleTestUtils.RunWithIo(() => InputCheck.ReadFloat("f: "), input, out _);
            Assert.Equal(expected, result, 6);
        }

        [Fact]
        public void ReadFloat_InvalidThenValid_Succeeds()
        {
            float result = ConsoleTestUtils.RunWithIo(() => InputCheck.ReadFloat(maxRetries: 2), "bad\n2.25\n", out string output);
            Assert.Equal(2.25f, result, 6);
            Assert.Contains("Invalid input", output);
        }

        [Fact]
        public void ReadFloat_TooManyInvalid_Throws()
        {
            Assert.Throws<InvalidOperationException>(() =>
                ConsoleTestUtils.RunWithIo(() => InputCheck.ReadFloat(maxRetries: 2), "x\nx\n", out _));
        }

        // ---------- ReadIntInRange ----------

        [Theory]
        [InlineData("5\n", 1, 10, 5)]
        [InlineData("1\n", 1, 1, 1)]
        public void ReadIntInRange_Valid(string input, int min, int max, int expected)
        {
            int result = ConsoleTestUtils.RunWithIo(() => InputCheck.ReadIntInRange(min, max, "n: "), input, out _);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReadIntInRange_OutOfRangeThenValid_Succeeds()
        {
            int result = ConsoleTestUtils.RunWithIo(() => InputCheck.ReadIntInRange(400, 404, maxRetries: 3), "405\n404\n", out string output);
            Assert.Equal(404, result);
            Assert.Contains("between 400 and 404", output);
        }

        [Fact]
        public void ReadIntInRange_TooManyInvalid_Throws()
        {
            Assert.Throws<InvalidOperationException>(() =>
                ConsoleTestUtils.RunWithIo(() => InputCheck.ReadIntInRange(400, 404, maxRetries: 2), "405\n-1\n", out _));
        }

        // ---------- ReadFloatInRange ----------

        [Fact]
        public void ReadFloatInRange_Valid()
        {
            float result = ConsoleTestUtils.RunWithIo(() => InputCheck.ReadFloatInRange(-5f, 5f, "f: "), "3.5\n", out _);
            Assert.Equal(3.5f, result, 6);
        }

        [Fact]
        public void ReadFloatInRange_OutOfRangeThenValid_Succeeds()
        {
            float result = ConsoleTestUtils.RunWithIo(() => InputCheck.ReadFloatInRange(-5f, 5f, maxRetries: 3), "6\n-4.5\n", out string output);
            Assert.Equal(-4.5f, result, 6);
            Assert.Contains("between -5 and 5", output);
        }

        [Fact]
        public void ReadFloatInRange_TooManyInvalid_Throws()
        {
            Assert.Throws<InvalidOperationException>(() =>
                ConsoleTestUtils.RunWithIo(() => InputCheck.ReadFloatInRange(0f, 1f, maxRetries: 2), "1.5\n2.0\n", out _));
        }

        [Fact]
        public void ReadFloatInRange_Eof_Throws()
        {
            Assert.Throws<EndOfStreamException>(() =>
                ConsoleTestUtils.RunWithIo(() => InputCheck.ReadFloatInRange(0f, 1f), "", out _));
        }
    }
}