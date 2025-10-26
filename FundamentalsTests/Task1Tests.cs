using System;
using Xunit;
using Fundamentals;
using Fundamentals.FirstLesson;


namespace Fundamentals.Tests
{
    // All tests run with InvariantCulture (defined in your helper)
    [Collection("InvariantCulture")]
    public class Task1Tests
    {
        // ---------------- SimpleCalc ----------------

        [Fact]
        public void SimpleCalc_NonZero_PrintsAllOps_IntAndRealDivision()
        {
            // a = 7, b = 2
            string input = "7\n2\n";
            string output = ConsoleTestUtils.RunWithIo(Task1.SimpleCalc, input);

            Assert.Contains("a+b = 9", output);
            Assert.Contains("a-b = 5", output);
            Assert.Contains("a*b = 14", output);

            // integer division first
            Assert.Contains("a/b (integer) = 3", output);

            // real division uses invariant culture ("G" format)
            // 7 / 2 = 3.5
            Assert.Contains("a/b (real)    = 3.5", output);
        }

        [Fact]
        public void SimpleCalc_DivideByZero_PrintsFriendlyMessage_AndNoOtherDivisionLines()
        {
            // a = 7, b = 0
            string input = "7\n0\n";
            string output = ConsoleTestUtils.RunWithIo(Task1.SimpleCalc, input);

            Assert.Contains("a/b = undefined (division by zero)", output);
            Assert.DoesNotContain("a/b (integer)", output);
            Assert.DoesNotContain("a/b (real)", output);
        }

        // ---------------- AskHowAreYou ----------------

        [Fact]
        public void AskHowAreYou_Blank_PrintsDefaultMessage()
        {
            // User hits Enter
            string input = "\n";
            string output = ConsoleTestUtils.RunWithIo(Task1.AskHowAreYou, input);

            Assert.Contains("I'll assume you're fine", output);
        }

        [Fact]
        public void AskHowAreYou_Text_Echoes()
        {
            string input = "great\n";
            string output = ConsoleTestUtils.RunWithIo(Task1.AskHowAreYou, input);

            // Your code uses format string: "You are {0}"
            Assert.Contains("You are great", output);
        }

        // ---------------- ReadThreeChars ----------------

        [Fact]
        public void ReadThreeChars_TooShort_ShowsHint()
        {
            string input = "ab\n";
            string output = ConsoleTestUtils.RunWithIo(Task1.ReadThreeChars, input);

            Assert.Contains("Please enter at least three characters.", output);
        }

        [Fact]
        public void ReadThreeChars_Valid_PrintsFirstThree()
        {
            string input = "abcd\n";
            string output = ConsoleTestUtils.RunWithIo(Task1.ReadThreeChars, input);

            Assert.Contains("You entered a, b, c", output);
        }

        // ---------------- ArePositive ----------------

        [Fact]
        public void ArePositive_BothPositive_PrintsPositive()
        {
            string input = "5\n6\n";
            string output = ConsoleTestUtils.RunWithIo(Task1.ArePositive, input);

            Assert.Contains("Both numbers are positive", output);
        }

        [Fact]
        public void ArePositive_NotBothPositive_PrintsNotPositive()
        {
            string input = "5\n-1\n";
            string output = ConsoleTestUtils.RunWithIo(Task1.ArePositive, input);

            Assert.Contains("At least one number is not positive", output);
        }

        // ---------------- Age ----------------

        [Fact]
        public void Age_Normal_PrintsGreeting()
        {
            string input = "Alice\n30\n";
            string output = ConsoleTestUtils.RunWithIo(Task1.Age, input);

            Assert.Contains("Hello Alice, you are 30 years old :)", output);
        }

        [Fact]
        public void Age_Negative_PrintsErrorAndStops()
        {
            string input = "Bob\n-2\n";
            string output = ConsoleTestUtils.RunWithIo(Task1.Age, input);

            Assert.Contains("Age cannot be negative.", output);
            Assert.DoesNotContain("Hello Bob", output);
        }

        // ---------------- CircleCalculations ----------------

        [Fact]
        public void CircleCalculations_Radius3_RoundsAwayFromZeroAt2dp()
        {
            // radius = 3
            // circumference ≈ 18.849555 -> 18.85
            // area ≈ 28.274333 -> 28.27 (not a .5 tie)
            // volume ≈ 113.097336 -> 113.10
            string input = "3\n";
            string output = ConsoleTestUtils.RunWithIo(Task1.CircleCalculations, input);

            Assert.Contains("length: 18.85", output);
            Assert.Contains("area: 28.27", output);
            Assert.Contains("volume: 113.1", output); // "113.10" renders as "113.1" by default ToString of rounded double
        }

        [Fact]
        public void CircleCalculations_NegativeRadius_PrintsErrorAndReturns()
        {
            string input = "-1\n";
            string output = ConsoleTestUtils.RunWithIo(Task1.CircleCalculations, input);

            Assert.Contains("Radius cannot be negative.", output);
            Assert.DoesNotContain("length:", output);
            Assert.DoesNotContain("area:", output);
            Assert.DoesNotContain("volume:", output);
        }

        // ---------------- SquareMetrics ----------------

        [Fact]
        public void SquareMetrics_Length5_PrintsAreaAndPerimeter()
        {
            string input = "5\n";
            string output = ConsoleTestUtils.RunWithIo(Task1.SquareMetrics, input);

            Assert.Contains("Area: 25", output);
            Assert.Contains("Perimeter: 20", output);
        }
    }
}
