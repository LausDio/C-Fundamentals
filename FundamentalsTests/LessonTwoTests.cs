using System;
using Xunit;
using Fundamentals.SecondLesson;

namespace Fundamentals.Tests
{
    public class LessonTwoTests
    {
        // ------------- CheckRange -----------------
        [Fact]
        public static void CheckRange_AllValidValues_PrintsTrue()
        {
            // 3 valid numbers in [-5, 5]
            string input = "1\n2\n3\n";
            string output = ConsoleTestUtils.RunWithIo(CheckRange.Run, input);
            Assert.Contains("True", output);
        }

        // ------------- CheckMinMax -----------------
        [Fact]
        public static void CheckMinMax_ReturnsCorrectMaxMin()
        {
            string input = "3\n7\n1\n";
            string output = ConsoleTestUtils.RunWithIo(CheckMinMax.Run, input);
            Assert.Contains("max: 7", output);
            Assert.Contains("min: 1", output);
        }

        // ------------- CheckHttpError (ReadIntInRange) -------------
        [Theory]
        [InlineData("400\n", "BadRequest")]
        [InlineData("401\n", "Unauthorized")]
        [InlineData("402\n", "PaymentRequired")]
        [InlineData("403\n", "Forbidden")]
        [InlineData("404\n", "NotFound")]
        public static void CheckHttpError_ValidCodes_ShowCorrectName(string input, string expected)
        {
            // Should accept a single valid code (within 400–404)
            string output = ConsoleTestUtils.RunWithIo(CheckHttpError.Run, input);
            Assert.Contains(expected, output);
        }

        [Fact]
        public static void CheckHttpError_InvalidThenValid_ShowsRangeWarningThenResolves()
        {
            // First line is out of range (405), second line valid (400)
            string input = "405\n400\n";
            string output = ConsoleTestUtils.RunWithIo(CheckHttpError.Run, input);

            // Message produced by ReadIntInRange when out of allowed range
            Assert.Contains("between 400 and 404", output);
            // Then prints the enum name after valid input
            Assert.Contains("BadRequest", output);
        }

        // ------------- ShowDogInfo (ReadNonNegativeInt) -------------
        [Fact]
        public static void ShowDogInfo_PrintsAllDogData_WhenAgeValid()
        {
            string input = "Rex\nexcellent\n5\n";
            string output = ConsoleTestUtils.RunWithIo(Dog.ShowDogInfo, input);

            Assert.Contains("Name: Rex", output);
            Assert.Contains("mark: excellent", output);
            Assert.Contains("age: 5", output);
        }

        [Fact]
        public static void ShowDogInfo_NegativeThenValidAge_ShowsNonNegativeWarningThenPrints()
        {
            // Age: -1 (invalid) then 3 (valid)
            string input = "Milo\ngood\n-1\n3\n";
            string output = ConsoleTestUtils.RunWithIo(Dog.ShowDogInfo, input);

            // Message produced by ReadNonNegativeInt on a negative value
            Assert.Contains("non-negative", output, StringComparison.OrdinalIgnoreCase);

            // Final printed struct line
            Assert.Contains("Name: Milo", output);
            Assert.Contains("mark: good", output);
            Assert.Contains("age: 3", output);
        }
    }
}
