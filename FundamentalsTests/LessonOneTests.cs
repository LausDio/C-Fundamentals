using System;
using Xunit;
using Fundamentals.FirstLesson;

namespace Fundamentals.Tests
{
    [Collection("InvariantCulture")]
    public class LessonOneTests
    {
        // ---------------- SimpleCalc ----------------
        [Fact]
        public void SimpleCalc_NonZero_PrintsAllOps_IntAndRealDivision()
        {
            string input = "7\n2\n";
            string output = ConsoleTestUtils.RunWithIo(LessonOne.SimpleCalc, input);

            Assert.Contains("a+b = 9", output);
            Assert.Contains("a-b = 5", output);
            Assert.Contains("a*b = 14", output);
            Assert.Contains("a/b (integer) = 3", output);
            Assert.Contains("a/b (real)    = 3.5", output);
        }

        [Fact]
        public void SimpleCalc_DivideByZero_PrintsFriendlyMessage_AndNoOtherDivisionLines()
        {
            string input = "7\n0\n";
            string output = ConsoleTestUtils.RunWithIo(LessonOne.SimpleCalc, input);

            Assert.Contains("a/b = undefined (division by zero)", output);
            Assert.DoesNotContain("a/b (integer)", output);
            Assert.DoesNotContain("a/b (real)", output);
        }

        // ---------------- AskHowAreYou ----------------
        [Fact]
        public void AskHowAreYou_Blank_PrintsDefaultMessage()
        {
            string input = "\n";
            string output = ConsoleTestUtils.RunWithIo(LessonOne.AskHowAreYou, input);
            Assert.Contains("assume you're fine", output, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void AskHowAreYou_Text_Echoes()
        {
            string input = "great\n";
            string output = ConsoleTestUtils.RunWithIo(LessonOne.AskHowAreYou, input);
            Assert.Contains("You are great", output);
        }

        // ---------------- ReadThreeChars ----------------
        [Fact]
        public void ReadThreeChars_TooShort_ShowsHint()
        {
            string input = "ab\n";
            string output = ConsoleTestUtils.RunWithIo(LessonOne.ReadThreeChars, input);
            Assert.Contains("Please enter at least three characters.", output);
        }

        [Fact]
        public void ReadThreeChars_Valid_PrintsFirstThree()
        {
            string input = "abcd\n";
            string output = ConsoleTestUtils.RunWithIo(LessonOne.ReadThreeChars, input);
            Assert.Contains("You entered a, b, c", output);
        }

        // ---------------- ArePositive ----------------
        [Fact]
        public void ArePositive_BothPositive_PrintsPositive()
        {
            string input = "5\n6\n";
            string output = ConsoleTestUtils.RunWithIo(LessonOne.ArePositive, input);
            Assert.Contains("Both numbers are positive", output);
        }

        [Fact]
        public void ArePositive_NotBothPositive_PrintsNotPositive()
        {
            string input = "5\n-1\n";
            string output = ConsoleTestUtils.RunWithIo(LessonOne.ArePositive, input);
            Assert.Contains("At least one number is not positive", output);
        }

        // ---------------- Age (uses ReadNonNegativeInt) ----------------
        [Fact]
        public void Age_NegativeThenValid_ShowsNonNegativeWarning_ThenGreets()
        {
            // name: Bob, age: -2 (invalid), then 30 (valid)
            string input = "Bob\n-2\n30\n";
            string output = ConsoleTestUtils.RunWithIo(LessonOne.Age, input);

            Assert.Contains("non-negative", output, StringComparison.OrdinalIgnoreCase);
            Assert.Contains("Hello Bob, you are 30 years old :)", output);
        }

        // ---------------- CircleCalculations (uses ReadNonNegativeDouble) ----------------
        [Fact]
        public void CircleCalculations_NegativeThenValid_ComputesAndPrints()
        {
            // radius: -1 (invalid), then 3 (valid)
            string input = "-1\n3\n";
            string output = ConsoleTestUtils.RunWithIo(LessonOne.CircleCalculations, input);

            // The non-negative double reader should complain first:
            Assert.Contains("non-negative", output, StringComparison.OrdinalIgnoreCase);

            // Then results for r = 3
            Assert.Contains("length: 18.85", output);
            Assert.Contains("area: 28.27", output);
            Assert.Contains("volume: 113.1", output); // 113.10 prints as 113.1 default
        }

        [Fact]
        public void CircleCalculations_Radius3_RoundsAwayFromZeroAt2dp()
        {
            string input = "3\n";
            string output = ConsoleTestUtils.RunWithIo(LessonOne.CircleCalculations, input);

            Assert.Contains("length: 18.85", output);
            Assert.Contains("area: 28.27", output);
            Assert.Contains("volume: 113.1", output);
        }

        // ---------------- SquareMetrics (uses ReadNonNegativeInt) ----------------
        [Fact]
        public void SquareMetrics_Length5_PrintsAreaAndPerimeter()
        {
            string input = "5\n";
            string output = ConsoleTestUtils.RunWithIo(LessonOne.SquareMetrics, input);

            Assert.Contains("Area: 25", output);
            Assert.Contains("Perimeter: 20", output);
        }

        [Fact]
        public void SquareMetrics_NegativeThenValid_ShowsNonNegativeWarning_ThenPrints()
        {
            string input = "-3\n5\n";
            string output = ConsoleTestUtils.RunWithIo(LessonOne.SquareMetrics, input);

            Assert.Contains("non-negative", output, StringComparison.OrdinalIgnoreCase);
            Assert.Contains("Area: 25", output);
            Assert.Contains("Perimeter: 20", output);
        }
    }
}
