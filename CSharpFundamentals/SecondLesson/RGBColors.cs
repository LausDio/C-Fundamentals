/* 9) Determine struct RGB that represents the color with fields red, green, blue (type byte).
Identify two variables of this type and enter their fields for white and black colors.*/
namespace Fundamentals.SecondLesson
{
    internal class RGBColors
    {
        internal struct RGB
        {
            public byte green;
            public byte red;
            public byte blue;
            public RGB(byte red, byte green, byte blue)
            {
                this.red = red;
                this.green = green;
                this.blue = blue;
            }
            public override string ToString()
            {
                return $"(R: {red}, G: {green}, B: {blue})";
            }
        }
        public static void TwoColors()
        {
            // White: all color channels at maximum (255)
            RGB white = new RGB(255, 255, 255);

            // Black: all color channels at zero (0)
            RGB black = new RGB(0, 0, 0);

            Console.WriteLine("🎨 Defined colors:");
            Console.WriteLine($"White = {white}");
            Console.WriteLine($"Black = {black}");
        }
    }
}